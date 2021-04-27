using DataImporter.Core.Models;
using System.Data.Entity;

namespace DataImporter.Api.Models
{
    public class DataImporterContext : DbContext
    {

        //public DataImporterContext() : base("name=DataImporterContext")
        //{
        //    // Disable proxy creation and lazy loading; not wanted in this service context.
        //    Configuration.ProxyCreationEnabled = false;
        //    Configuration.LazyLoadingEnabled = false;
        //}
        public DataImporterContext() : base("Server = (localdb)\\mssqllocaldb; Integrated Security = No; Initial Catalog = DataImporterDb; Integrated Security = True")
        {
            // Disable proxy creation and lazy loading; not wanted in this service context.
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }
        //public DataImporterContext()
        //{
        //}

        //public DataImporterContext(DbContextOptions<DataImporterContext> options)
        //    : base(options)
        //{
        //}

        public virtual DbSet<Company> Companys { get; set; }
        public virtual DbSet<Feed> Feeds { get; set; }
        public virtual DbSet<Product> Products { get; set; }

    }
}
