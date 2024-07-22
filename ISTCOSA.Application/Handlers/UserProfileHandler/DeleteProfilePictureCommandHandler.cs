using AutoMapper;
using ISTCOSA.Application.CommandAndQueries.UserProfile.Commands;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.Handlers.UserProfileHandler
{
    public class DeleteProfilePictureCommandHandler : IRequestHandler<DeleteProfilePIctureCommand, UserRegisterDTOs>
    {
        private readonly IApplicationDBContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<DeleteProfilePictureCommandHandler> _logger;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public DeleteProfilePictureCommandHandler(IApplicationDBContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment, ILogger<DeleteProfilePictureCommandHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;


        }

        public async Task<UserRegisterDTOs> Handle(DeleteProfilePIctureCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingUser = await _context.UserPersonalInformation
                    .Include(upi => upi.User)
                    .FirstOrDefaultAsync(upi => upi.Id == request.Id);

                if (existingUser == null)
                {
                    throw new Exception($"User with ID {request.Id} not found.");
                }

                var imagePathToDelete = existingUser.User.Images;

                if (!string.IsNullOrEmpty(imagePathToDelete))
                {
                    var deletedImagePath = DeleteImage(imagePathToDelete);
                    existingUser.User.Images = null;
                    existingUser.User.UpdatedDateAndTime = DateTime.Now;

                    _context.Update(existingUser);
                    await _context.SaveChangesAsync();


                    return null;
                }

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while deleting profile picture for User ID {request.Id}");
                throw new Exception($"An error occurred while deleting profile picture for User ID {request.Id}. See the inner exception for details.", ex);
            }


        }
            private string DeleteImage(string imagePath)
            {
                if (string.IsNullOrEmpty(imagePath))
                {
                    throw new ArgumentException("Image path cannot be null or empty.", nameof(imagePath));
                }

                if (_webHostEnvironment == null)
                {
                    throw new NullReferenceException("_webHostEnvironment is not initialized.");
                }

                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", Path.GetFileName(imagePath));

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    return Path.Combine("Images", Path.GetFileName(imagePath));
                }

                throw new FileNotFoundException("Image file not found.", filePath);
            }

        }
 }


    
