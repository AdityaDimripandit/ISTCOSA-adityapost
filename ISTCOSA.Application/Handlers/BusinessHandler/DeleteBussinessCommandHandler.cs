using AutoMapper;
using ISTCOSA.Application.CommandAndQueries.UserBusiness.Commands;
using ISTCOSA.Application.Common.Behaviours.DTOs;
using ISTCOSA.Application.Handlers.UserProfileHandler;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace ISTCOSA.Application.Handlers.BusinessHandler
{
    public class DeleteBussinessCommandHandler : IRequestHandler<DeleteBussinessCommand, BussinessDTO>
    {
        private readonly IApplicationDBContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<DeleteProfilePictureCommandHandler> _logger;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public DeleteBussinessCommandHandler(IApplicationDBContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment, ILogger<DeleteProfilePictureCommandHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;


        }
        public async Task<BussinessDTO> Handle(DeleteBussinessCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingBusiness = await _context.postBusinesss
                    .FirstOrDefaultAsync(pb => pb.Id == request.Id, cancellationToken);

                if (existingBusiness == null)
                {
                    throw new ArgumentException($"Business with ID {request.Id} not found.");
                }

                _context.postBusinesss.Remove(existingBusiness);
                await _context.SaveChangesAsync(cancellationToken);
                return null;
              
            }
          
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
    }

}
