using AutoMapper;
using ISTCOSA.Application.CommandAndQuries.UserRegister.Commands.CreateUserRegister;
using ISTCOSA.Domain.Entities;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace ISTCOSA.Infrastructure.Handlers.UserProfileHandler
{
    public class CreateUserRegisterCommandHandler : IRequestHandler<CreateUserRegisterCommands, UserRegisterDTOs>
    {
        private readonly IApplicationDBContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailSender _emailSender;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<CreateUserRegisterCommandHandler> _logger;

        public CreateUserRegisterCommandHandler(IHttpContextAccessor httpContextAccessor, IApplicationDBContext context, IMapper mapper, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager,
            IEmailSender emailSender, IWebHostEnvironment webHostEnvironment, ILogger<CreateUserRegisterCommandHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _httpContextAccessor = httpContextAccessor;
            _emailSender = emailSender;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }

        public async Task<UserRegisterDTOs> Handle(CreateUserRegisterCommands request, CancellationToken cancellationToken)
        {
            try
            {
                var existingPhone = await _context.userRegisters.FirstOrDefaultAsync(x => x.PhoneNumber == request.PhoneNumber);
                if (existingPhone != null) throw new Exception("Phone Number has Already used by Someone");
                var existingEmail = await _context.userRegisters.FirstOrDefaultAsync(x => x.Email == request.Email);
                if (existingEmail != null) throw new Exception("Email has Already used by Someone");
                var rollNumber = await _context.rollNumbers
                    .Where(r => r.RollNumberId == request.RollNumberId)
                    .Select(r => r.RollNumbers)
                    .FirstOrDefaultAsync(cancellationToken);
                if (rollNumber == null)
                {
                    throw new Exception("Invalid RollNumberId");
                }
                var existingUser = await _context.userRegisters.FirstOrDefaultAsync(x => x.UserName == rollNumber.ToString());
                if (existingUser != null) throw new Exception("User is already in use. ");

                var batchnumber = await _context.rollNumbers
               .Where(r => r.RollNumberId == request.RollNumberId)
               .Select(r => new
               {
                   r.Batch.BatchNumber

               })
                .FirstOrDefaultAsync();

                if (batchnumber == null) throw new Exception(" batchnumber Not Found");
                var cityExists = await _context.cities.AnyAsync(c => c.Id == request.CityId, cancellationToken);
                if (!cityExists)
                {
                    throw new Exception("Invalid CityId");
                }
                string imagePath = null;

                if (!string.IsNullOrEmpty(request.Images))
                {
                    var ext = request.ImageType;
                    imagePath = SaveImage(request.Images, ext);
                }
                var userProfile = new UserRegister
                {
                    UserName = rollNumber.ToString(),
                    RollNumberId = request.RollNumberId,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    DateOfBirth = request.DateOfBirth,
                    FullName = request.FullName,
                    Gender = request.Gender,
                    PinCode = request.Pincode,
                    IsActive = true,
                    CreatedDateAndTime = DateTime.Now,
                    CityId = request.CityId,
                    Images = imagePath,
                };
                var result = await _userManager.CreateAsync(userProfile, request.Password);
                if (!result.Succeeded)
                {
                    var errors = string.Join("; ", result.Errors.Select(e => e.Description));
                    throw new Exception($"User could not be created. Errors: {errors}");
                }

                var roleExists = await _roleManager.RoleExistsAsync("Student");
                if (!roleExists)
                {
                    var roleResult = await _roleManager.CreateAsync(new IdentityRole("Student"));
                    if (!roleResult.Succeeded)
                    {
                        throw new Exception("Failed to create Student role.");
                    }
                }
                var roleAssignResult = await _userManager.AddToRoleAsync(userProfile, "Student");
                if (!roleAssignResult.Succeeded)
                {
                    throw new Exception("Failed to assign Student role.");
                }
                var userRegisterDTO = _mapper.Map<UserRegisterDTOs>(userProfile);
                string subject = "Registration Email - ISTCOSA";
                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "EmailContext", "EmailContent.txt");
                var emailContent = await File.ReadAllTextAsync(filePath);
                emailContent = emailContent.Replace("{FullName}", userProfile.FullName)
                                           .Replace("{Batch}", batchnumber.ToString())
                                           .Replace("{Email}", userProfile.Email)
                                           .Replace("{RollNumber}", userProfile.UserName);
                try
                {
                    await _emailSender.SendEmailAsync(request.Email, subject, emailContent);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to send email: {Message}", ex.Message);
                }
                return userRegisterDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in CreateUserRegisterCommandHandler: {Message}", ex.Message);
                throw; 
            }
        }

        private string SaveImage(string base64Image,string ImageType)
        {
            if (string.IsNullOrWhiteSpace(base64Image))
            {
                throw new ArgumentException("Invalid image data");
            }

            string data = base64Image;
            byte[] imageBytes;
            try
            {
                imageBytes = Convert.FromBase64String(data);
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

            var fileExtension = Path.GetExtension(ImageType);
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
