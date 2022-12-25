using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineAPI.Data
{
    [Table("Prescription")]
    [Keyless]
    public class Prescription
    {
        public Guid idPrescription { get; set; }
        public Guid? idDrUser { get; set; }
        public DateTime? datePrescription { get; set; }


        //realtionship
        //public Medicine medicine { get; set; }
        // public DrUser drUser { get; set; }

    }
}
