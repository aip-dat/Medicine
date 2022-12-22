using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineAPI.Models
{
    public class TypeModel
    {
        [Required]
        [MaxLength(50)]
        public string nameType { get; set; }
    }
}
