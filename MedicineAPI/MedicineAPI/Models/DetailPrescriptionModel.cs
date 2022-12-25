using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineAPI.Models
{
    public class DetailPrescriptionModel
    {
        public Guid idPrescription { get; set; }
        public Guid idMedicine { get; set; }
        public double quantityDetailPrescription { get; set; }
        public string contentDetailPrescription { get; set; }
        public int hourDetailPrescription { get; set; }
        public int minuteDetailPrescription { get; set; }
    }
}
