using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineAPI.Models
{
    public class PrescriptionModel
    {
        public Guid idDrUser { get; set; }
        public Guid idMedicine { get; set; }
        public double quantityPrescription { get; set; }
        public string contentPrescription { get; set; }
        public int hourPrescription { get; set; }
        public int minutePrescription { get; set; }
    }
}
