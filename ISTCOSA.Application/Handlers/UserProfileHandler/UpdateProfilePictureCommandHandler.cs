using AutoMapper;
using ISTCOSA.Application.CommandAndQueries.UserProfile.Commands;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace ISTCOSA.Application.Handlers.UserProfileHandler
{
    public class UpdateProfilePictureCommandHandler : IRequestHandler<UpdateProfilePictureCommand, UserRegisterDTOs>
    {
        private readonly IApplicationDBContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<UpdateProfilePictureCommandHandler> _logger;
        public UpdateProfilePictureCommandHandler(IApplicationDBContext context, IMapper mapper, IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor, ILogger<UpdateProfilePictureCommandHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;


        }
        public async Task<UserRegisterDTOs> Handle(UpdateProfilePictureCommand request, CancellationToken cancellationToken)
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

                string newImagePath = null;
                if (!string.IsNullOrEmpty(request.Images))
                {
                    var ext = request.ImagePath;
                    newImagePath = SaveImage(request.Images, ext, existingUser.Images);

                    if (!string.IsNullOrEmpty(existingUser.Images) && newImagePath != existingUser.Images)
                    {
                        DeleteImage(existingUser.Images);
                    }


                    existingUser.Images = newImagePath;
                    existingUser.UpdatedDateAndTime = DateTime.Now;


                    _context.Update(existingUser);
                    await _context.SaveChangesAsync();
                }

                var mappedUserForUpdate = _mapper.Map<UserRegisterDTOs>(existingUser);
                mappedUserForUpdate.StateId = existingUser.city?.StateId ?? 0;
                mappedUserForUpdate.StateName = existingUser.city?.State?.Name;
                mappedUserForUpdate.CountryId = existingUser.city?.State?.CountryId ?? 0;
                mappedUserForUpdate.CountryName = existingUser.city?.State?.Country?.Name;
                mappedUserForUpdate.CityId = existingUser.CityId;
                mappedUserForUpdate.CityName = existingUser.city?.Name;

                mappedUserForUpdate.Images = existingUser.Images;
                mappedUserForUpdate.ImagePath = request.ImagePath;

                var requestUrl = _httpContextAccessor.HttpContext.Request;
                var baseUrl = $"{requestUrl.Scheme}://{requestUrl.Host}";

                if (!string.IsNullOrEmpty(mappedUserForUpdate.Images))
                {
                    mappedUserForUpdate.ImagePath = $"{baseUrl}/{mappedUserForUpdate.Images}";
                }

                return mappedUserForUpdate;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error occurred while saving entity changes");
                throw new Exception("An error occurred while saving the entity changes. See the inner exception for details.", ex);
            }
        }
        private string SaveImage(string base64String, string fileExtension, string? images)
        {
            if (string.IsNullOrEmpty(base64String))
            {
                throw new ArgumentException("Base64 string is null or empty.", nameof(base64String));
            }

            if (string.IsNullOrEmpty(fileExtension))
            {
                throw new ArgumentException("File extension is null or empty.", nameof(fileExtension));
            }

            byte[] imageBytes = Convert.FromBase64String(base64String);

            string fileName = Guid.NewGuid().ToString() + fileExtension;
            string webRootPath = _webHostEnvironment.WebRootPath;
            string imagesFolder = Path.Combine(webRootPath, "Images");

          
            if (!Directory.Exists(imagesFolder))
            {
                Directory.CreateDirectory(imagesFolder);
            }

            string filePath = Path.Combine(imagesFolder, fileName);

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                fs.Write(imageBytes, 0, imageBytes.Length);
            }

            return  fileName;
        }

        private void DeleteImage(string imagePath)
        {
            if (!string.IsNullOrEmpty(imagePath))
            {
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", Path.GetFileName(imagePath));
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
        }
    }
}
    

    
