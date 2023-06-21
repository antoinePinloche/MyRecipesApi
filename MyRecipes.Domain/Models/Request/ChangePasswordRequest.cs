using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipes.Domain.Models.Request
{
    public sealed class ChangePasswordRequest
    {
        [Required]
        public string NewPassword { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}
