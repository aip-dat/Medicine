using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineAPI.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        #region DbSet
        public DbSet<Medicine> medicines { get; set; }
        public DbSet<Type> types { get; set; }
        public DbSet<User> users  { get; set; }
        public DbSet<Prescription> prescriptions  { get; set; }
        public DbSet<DetailPrescription> detailPrescriptions  { get; set; }
        public DbSet<DrUser> drUsers  { get; set; }
        #endregion
    }
}
