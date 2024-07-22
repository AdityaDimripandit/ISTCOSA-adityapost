using AutoMapper;
using ISTCOSA.Application.CommandAndQueries.UserBusiness.Commands;
using ISTCOSA.Application.CommandAndQuries.UserEmployment.Commands;
using ISTCOSA.Application.Common.Behaviours.DTOs;
using ISTCOSA.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ISTCOSA.Application.Handlers.BusinessHandler
{
    public class CreateBusinessCommandHandler : IRequestHandler<CreateBussinessCommand, BussinessDTO>
    {
        private readonly IApplicationDBContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateBusinessCommandHandler(IApplicationDBContext context, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<BussinessDTO> Handle(CreateBussinessCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var industry = await _context.industries.FirstOrDefaultAsync(i => i.Id == request.IndustryId, cancellationToken);
                var user = await _context.userRegisters.FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

                if (industry == null)
                {
                    throw new ArgumentException($"Industry with ID {request.IndustryId} not found.");
                }

                if (user == null)
                {
                    throw new ArgumentException($"User with ID {request.UserId} not found.");
                }
                string imagePath = null;

                if (!string.IsNullOrEmpty(request.Images))
                {
                    var ext = request.ImageType;
                    imagePath = SaveImage(request.Images, ext);
                }
                var newBusiness = new PostBusiness
                {
                    Images = imagePath,
                    Company = request.Company,
                    Title = request.Title,
                    IndustryId = request.IndustryId,                   
                    ContactName = request.ContactName,
                    Email = request.Email,
                    industry = industry,
                    UserId = request.UserId,
                    PhoneNumber = request.PhoneNumber,
                    CreatedDateAndTime = request.CreatedDateAndTime,
                    JobDescription = request.JobDescription,
                    User = user,
                };
                _context.postBusinesss.Add(newBusiness);
                await _context.SaveChangesAsync(cancellationToken);
                var businessDto = _mapper.Map<BussinessDTO>(newBusiness);

                return businessDto;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
    
        private string SaveImage(string base64Image, string ImageType)
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