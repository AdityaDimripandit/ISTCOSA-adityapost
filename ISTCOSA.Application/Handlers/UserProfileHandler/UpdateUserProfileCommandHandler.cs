using AutoMapper;
using ISTCOSA.Application.CommandAndQuries.UserProfile.Commands;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ISTCOSA.Infrastructure.Handlers.UserProfileHandler
{
    public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, UserRegisterDTOs >
    {
        private readonly IApplicationDBContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<UpdateUserProfileCommandHandler> _logger;
        public UpdateUserProfileCommandHandler(IApplicationDBContext context, IMapper mapper, IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor, ILogger<UpdateUserProfileCommandHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
           

        }

        public async Task<UserRegisterDTOs> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userPersonal = await _context.UserPersonalInformation.FirstOrDefaultAsync(up => up.Id == request.Id);
                if (userPersonal == null)
                    throw new Exception("User personal data not found.");

                var existingUser = await _context.userRegisters
                    .Include(u => u.city)
                    .ThenInclude(c => c.State)
                    .ThenInclude(s => s.Country)
                    .FirstOrDefaultAsync(x => x.Id == userPersonal.UserId);

                if (existingUser == null)
                    throw new Exception("User not found.");

                var existingPhone = await _context.userRegisters.FirstOrDefaultAsync(x => x.PhoneNumber == request.PhoneNumber && x.Id != existingUser.Id);
                if (existingPhone != null)
                    throw new Exception("Phone Number has already been used by someone.");

                var existingEmail = await _context.userRegisters.FirstOrDefaultAsync(x => x.Email == request.Email && x.Id != existingUser.Id);
                if (existingEmail != null)
                    throw new Exception("Email has already been used by someone.");

                string newImagePath = null;
                if (!string.IsNullOrEmpty(request.Images))
                {
                    var ext = request.ImageType;
                    newImagePath = SaveImage(request.Images, ext);
                }

                if (!string.IsNullOrEmpty(request.Images) && !string.IsNullOrEmpty(existingUser.Images))
                {
                    var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", Path.GetFileName(existingUser.Images));
                    if (File.Exists(oldImagePath))
                    {
                        File.Delete(oldImagePath);
                    }
                }

                var cityName = request.CityId != 0 ? await _context.cities.Where(c => c.Id == request.CityId).Select(c => c.Name).FirstOrDefaultAsync() : null;
                var stateName = request.StateId != 0 ? await _context.states.Where(s => s.Id == request.StateId).Select(s => s.Name).FirstOrDefaultAsync() : null;
                var countryName = request.CountryId != 0 ? await _context.countries.Where(ct => ct.Id == request.CountryId).Select(ct => ct.Name).FirstOrDefaultAsync() : null;

                existingUser.RollNumberId = request.RollNumberId;
                existingUser.FullName = request.FullName;
                existingUser.Gender = request.Gender;
                existingUser.DateOfBirth = request.DateOfBirth;
                existingUser.Email = request.Email;
                existingUser.PhoneNumber = request.PhoneNumber;
                existingUser.NormalizedEmail = request.Email.ToUpper();
                existingUser.Images = newImagePath ?? existingUser.Images;
                existingUser.UpdatedDateAndTime = DateTime.Now;
                existingUser.PinCode = request.Pincode;
                existingUser.CityId = request.CityId;
                existingUser.city.Name = cityName;
                existingUser.city.StateId = request.StateId;
                existingUser.city.State.Name = stateName;
                existingUser.city.State.CountryId = request.CountryId;
                existingUser.city.State.Country.Name = request.CountryName;

                userPersonal.ISTCNickName = request.ISTCNickName;
                userPersonal.ISTCFriend = request.ISTCFriend;
                userPersonal.Comments = request.Comments;
                userPersonal.ISTCAbout = request.ISTCAbout;
                userPersonal.AboutYourself = request.AboutYourself;
                userPersonal.Address = request.Address;

                _context.Update(userPersonal);
                _context.Update(existingUser);

                await _context.SaveChangesAsync();

                var mappedUserForUpdate = _mapper.Map<UserRegisterDTOs>(existingUser);

                mappedUserForUpdate.StateId = existingUser.city?.StateId ?? 0;
                mappedUserForUpdate.StateName = existingUser.city?.State?.Name;
                mappedUserForUpdate.CountryId = existingUser.city?.State?.CountryId ?? 0;
                mappedUserForUpdate.CountryName = existingUser.city?.State?.Country?.Name;
                mappedUserForUpdate.CityId = existingUser.CityId;
                mappedUserForUpdate.CityName = existingUser.city?.Name;

                return mappedUserForUpdate;

            }
            catch (DbUpdateException ex)
            {

                _logger.LogError(ex, "Error occurred while saving entity changes");


                throw new Exception("An error occurred while saving the entity changes. See the inner exception for details.", ex);
            }
        }
          private string SaveImage(string base64Image, string imageType)

          {
            if (string.IsNullOrWhiteSpace(base64Image))
            {
                throw new ArgumentException("Invalid image data");
            }
            
            var dataPrefix = "base64,";
            var index = base64Image.IndexOf(dataPrefix);
            if (index != -1)
            {
                base64Image = base64Image.Substring(index + dataPrefix.Length);
            }

            byte[] imageBytes;
            try
            {
                imageBytes = Convert.FromBase64String(base64Image);
            }
            catch (FormatException)
            {
                throw new ArgumentException("Invalid base64 image data");
            }

            using (var ms = new MemoryStream(imageBytes))
            {
                try
                {
                    var image = System.Drawing.Image.FromStream(ms);
                }
                catch (Exception)
                {
                    throw new ArgumentException("Invalid image format");
                }
            }

            var fileExtension = Path.GetExtension(imageType);
            if (string.IsNullOrWhiteSpace(fileExtension))
            {
                throw new ArgumentException("Invalid image type or missing file extension");
            }

            var fileName = $"{Guid.NewGuid()}{fileExtension}";
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", fileName);
            var directory = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            File.WriteAllBytes(filePath, imageBytes);
            return fileName;
        }

    }
}

