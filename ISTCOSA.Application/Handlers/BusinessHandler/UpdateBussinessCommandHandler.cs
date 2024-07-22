using AutoMapper;
using ISTCOSA.Application.CommandAndQueries.UserBusiness.Commands;
using ISTCOSA.Application.Common.Behaviours.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.Handlers.BusinessHandler
{
    public class UpdateBussinessCommandHandler : IRequestHandler<UpdateBussinessCommand, BussinessDTO>
    {
        private readonly IApplicationDBContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UpdateBussinessCommandHandler(IApplicationDBContext context, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<BussinessDTO> Handle(UpdateBussinessCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingBusiness = await _context.postBusinesss
                    .Include(pb => pb.industry)
                    .Include(pb => pb.User)
                    .FirstOrDefaultAsync(pb => pb.Id == request.Id, cancellationToken);

                if (existingBusiness == null)
                {
                    throw new ArgumentException($"Business with ID {request.Id} not found.");
                }

               
                existingBusiness.Company = request.Company;
                existingBusiness.Title = request.Title;
                existingBusiness.IndustryId = request.IndustryId;
                existingBusiness.ContactName = request.Contact;
                existingBusiness.Email = request.Email;
                existingBusiness.PhoneNumber = request.PhoneNumber;
                existingBusiness.JobDescription = request.JobDescription;
                existingBusiness.UpdatedDateAndTime = request.UpdatedDateAndTime = DateTime.UtcNow;
                

             
                if (!string.IsNullOrEmpty(request.Images))
                {
                    var ext = request.ImageType;
                    var imagePath = SaveImage(request.Images, ext);
                    existingBusiness.Images = imagePath;
                }

             
                await _context.SaveChangesAsync(cancellationToken);

                var updatedBusinessDto = _mapper.Map<BussinessDTO>(existingBusiness);
             

                return updatedBusinessDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        private string SaveImage(string base64Image, string imageType)
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

            var fileExtension = imageType.TrimStart('.');
            if (string.IsNullOrWhiteSpace(fileExtension))
            {
                throw new ArgumentException("Invalid image type or missing file extension");
            }

            var fileName = $"{Guid.NewGuid().ToString()}.{fileExtension}";
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


