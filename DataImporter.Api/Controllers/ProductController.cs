
using DataImporter.Core;
using DataImporter.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace DataImporter.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProductController : ControllerBase
    {
    public ProductController(ILogger<ProductController> logger,
       DataImporterService dataImporterService,
       ProductService productService,
       DataImporterContext dbContext)
    {
      _logger = logger;
       importerService = dataImporterService;
       ProdService = productService;
       context = dbContext;
    }


   [HttpGet]
        public List<Product> Get()
    {
            Feeds = importerService.GetFeeds();
            Companies = importerService.GetCompanies();
            
            //return Ok();
            foreach (Company company in Companies)
            {
                int companyCount = 0;

                foreach (Feed feed in Feeds)
                {
                    companyCount++;
                    if (company.Id.ToString().Substring(0,1) == feed.Id.ToString().Substring(0,1))
                    {
                        
                        //Get Product for Company Feed
                        foreach (Product product in ProdService.GetProducts(company, feed))
                        {
                            Products.Add(product);
             
                        }
                           
                    }
                }
            }

            //The data importer should import Product Feed data in the CSV file form and
            //persist them to the Product table in the database. 



            using (var ctx = new DataImporter.Api.Models.DataImporterContext())
            {
                foreach (Product product in Products)
                {
                    ctx.Products.Add(product);

                }

                try
                {
                    //comment out to save
                    //ctx.SaveChanges();
                }
                catch (System.Exception ex)
                {
                    string ErrorMessage = ex.Message;
                }
            }
            

            return Products;
        }
        private DataImporterContext context;
        private readonly ILogger<ProductController> _logger;
        private DataImporterService importerService;
        private ProductService ProdService;
        public IEnumerable<Feed> Feeds { get; set; }
        public IEnumerable<Company> Companies { set; get; }
        public List<Product> Products = new List<Product>();
        public List<Product> DbProducts = new List<Product>();
    }
}
