namespace DEKRA.VULNERABILIDADE.DATAACCESLAYER.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DEKRA.VULNERABILIDADE.WEB.DATAACCESSLAYER.EntityFrameWork.dbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DEKRA.VULNERABILIDADE.WEB.DATAACCESSLAYER.EntityFrameWork.dbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
