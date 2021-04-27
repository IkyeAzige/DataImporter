using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataImporter.Core.Models
{
    public class Product
    {
        public static int Counter { set; get; }
        public Product()
        {
            Companies = new List<Company>();
            Feeds = new List<Feed>();
            Counter = 0;
        }
        [Key]
        [Column("Id")]
        public int Id { set; get; }
        public string UniqueId { get; set; }
        
        //public int CompanyId { get; set; }
        //public int FeedId { get; set; }
       
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<Feed> Feeds { get; set; }
    }
}
