﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineAPI.Data
{
    [Table("DrUser")]
    public class DrUser
    {
        [Key]
        public Guid idDrUser { get; set; }

        [Required]
        [MaxLength(50)]
        public string nameDrUser { get; set; }

        [Required]
        [MaxLength(50)]
        public string passwordDrUser { get; set; }
        public string fullNameDrUser { get; set; }
        public string emailDrUser { get; set; }
        public string phoneDrUser { get; set; }

        //realtionship
        public virtual ICollection<Prescription> prescriptions { get; set; }
    }
}