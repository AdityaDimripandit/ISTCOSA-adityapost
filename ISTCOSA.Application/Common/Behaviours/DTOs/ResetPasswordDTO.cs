namespace ISTCOSA.Application.Common.DTOs
{
    public class ResetPasswordDTO
    {
        public string UserName { get; set; }
        public string oldPassword { get; set; } 
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public string Token { get; set; }
    }
}
