using ISTCOSA.Application.CommandAndQuries.Account.Commands;


using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;

namespace ISTCOSA.Infrastructure.Handlers.AccountHandler
{
    public class GenerateResetPasswordTokenCommandHandler : IRequestHandler<CreateResetPasswordTokenGenerateCommand, ResetPasswordDTO>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailSender _emailSender;

        public GenerateResetPasswordTokenCommandHandler(UserManager<IdentityUser> userManager, IEmailSender emailSender)
        {
            _emailSender = emailSender;
            _userManager = userManager;
        }

        public async Task<ResetPasswordDTO> Handle(CreateResetPasswordTokenGenerateCommand request, CancellationToken cancellationToken)
        {
            var username = request.UserName;
            Console.WriteLine($"Username: {username} (Type: {username.GetType()})");
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                throw new Exception("User not found.");
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetLink = $"http://localhost:5272/createPassword?token={WebUtility.UrlEncode(token)}&username={WebUtility.UrlEncode(request.UserName)}";
            var emailBody = $"Click the link to reset your password: {resetLink}";
            await _emailSender.SendEmailAsync(user.Email, "Password Reset", emailBody);
            return new ResetPasswordDTO
            {
                UserName = request.UserName,
                Token = token,
            };
        }
    }
}
