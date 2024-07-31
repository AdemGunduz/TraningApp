namespace AppBack.Core.Application.Dto
{
    public class CheckUserDto
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Role { get; set; }
        public bool IsExist  { get; set; }
    }
}
