using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4_Grup4.Application.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage="{0} alanı boş olamaz.")]
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
