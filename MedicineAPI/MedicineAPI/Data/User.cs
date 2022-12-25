using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace MedicineAPI.Data
{
    [Table("User")]
    [Keyless]
    public class User
    {
        public Guid idUser { get; set; }

       
        public string nameUser { get; set; }

        public string passwordUser { get; set; }
        public string fullNameUser { get; set; }
        public string emailUser { get; set; }
    }
}
