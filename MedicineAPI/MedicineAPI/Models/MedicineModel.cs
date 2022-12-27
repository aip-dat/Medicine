using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineAPI.Models
{
    public class MedicineModel
    {
      
        public string nameMedicine { get; set; }
        public string descriptionMedicine { get; set; }
        public string imageUrlMedicine { get; set; }
        public int? idType { get; set; }
        
    }
}
