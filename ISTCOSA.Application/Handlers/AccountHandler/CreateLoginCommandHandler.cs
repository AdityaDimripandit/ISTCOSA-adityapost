using AutoMapper;
using ISTCOSA.Application.CommandAndQuries.Account.Commands;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ISTCOSA.Infrastructure.Handlers.AccountHandler
{
    public class CreateLoginCommandHandler : IRequestHandler<CreateLoginCommand, LoginDTO>
    {
        private readonly IApplicationDBContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public CreateLoginCommandHandler(IApplicationDBContext context, IMapper mapper, IConfiguration configuration,
            UserManager<IdentityUser> userManager,
          RoleManager<IdentityRole> roleManager,
            SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public async Task<LoginDTO> Handle(CreateLoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _context.userRegisters.FirstOrDefaultAsync(u => u.UserName == request.RollNumber, cancellationToken);
                var user1 = await _userManager.FindByNameAsync(request.RollNumber);
                if (user == null)
                {
                    throw new Exception("Invalid username or password.");
                }
                

                var result = await _signInManager.CheckPasswordSignInAsync(user1, request.Password, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    var userPersonal = await _context.UserPersonalInformation.FirstOrDefaultAsync(x => x.UserId == user.Id);
                    user.LastLoginDate = DateTime.Now;
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                    var token = GenerateToken(user.UserName, await _userManager.GetRolesAsync(user1));
                    return new LoginDTO
                    {
                        UserName = user.UserName,
                        Token = token,
                        UserId = user.Id,
                        UserPersonalId = userPersonal?.Id.ToString() ?? "0",
                    };
                }
                else
                {
                    throw new Exception("Invalid username or password.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string GenerateToken(string userName, IList<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName),  
            };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                _configuration["JWT:ValidIssuer"],
                _configuration["JWT:ValidAudience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(20),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        
    }

}
