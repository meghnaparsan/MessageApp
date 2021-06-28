using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MessageApp.Models
{
    public class EmailForm
    {
        [Required]
        public string Message { get; set; }
    }
}
