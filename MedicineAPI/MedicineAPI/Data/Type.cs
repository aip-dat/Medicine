using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineAPI.Data
{
    [Table("Type")]
    [Keyless]
    public class Type
    {
        public int idType { get; set; }
     
        public string nameType { get; set; }

        //realtionship
        //public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
