using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineAPI.Data
{
    [Table("DetailPrescription")]
    [Keyless]
    public class DetailPrescription
    {
        public Guid idDetailPrescription { get; set; }
        public Guid? idPrescription { get; set; }
        public Guid? idMedicine { get; set; }
        public double quantityDetailPrescription { get; set; }
        public string contentDetailPrescription { get; set; }
        public int hourDetailPrescription { get; set; }
        public int minuteDetailPrescription { get; set; }
    }
}
