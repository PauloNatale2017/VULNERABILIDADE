using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEKRA.VULNERABILIDADE.WEB.DATAACCESSLAYER.EntityFrameWork
{
    public class dbContext : DbContext
    {
        public dbContext() : base("name=dbLocal") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        //public DbSet<DEKRA.VULNERABILIDADE.DOMAIN.ENTIITES.MODELS.ENTITYMODEL.TesteAutomatizadoChartLine> _TesteAutomatizadoChartLine { get; set; }
    }
}
