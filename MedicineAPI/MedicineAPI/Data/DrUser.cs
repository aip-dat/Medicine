using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineAPI.Data
{
    [Table("DrUser")]
    [Keyless]
    public class DrUser
    {
        public Guid idDrUser { get; set; }

        
        public string nameDrUser { get; set; }

        public string passwordDrUser { get; set; }
        public string fullNameDrUser { get; set; }
        public string emailDrUser { get; set; }
        public string phoneDrUser { get; set; }

        //realtionship
        //public virtual ICollection<Prescription> prescriptions { get; set; }
    }
}
