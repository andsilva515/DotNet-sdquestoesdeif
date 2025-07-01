using SoQuestoesIF.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }    
        public string FullName { get; set; }      
        public string Role { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLoginAt { get; set; }
    }
    public class UserCreateDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public EnumUserRole Role { get; set; }
    }
    public class UserUpdateDto
    {
        public string FullName { get; set; }
        public EnumUserRole Role { get; set; }
        public EnumUserStatus Status { get; set; }
    }
    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
