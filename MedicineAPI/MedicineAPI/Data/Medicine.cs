using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineAPI.Data
{
    [Table("Medicine")]
    public class Medicine
    {
        [Key]
        public Guid idMedicine { get; set; }
        [Required]
        [MaxLength(255)]
        public string nameMedicine { get; set; }
        public string descriptionMedicine { get; set; }
        public double numberMedicine { get; set; }

        public int? idType { get; set; }
        [ForeignKey("idType")]
        public Type type { get; set; }
    }
}
