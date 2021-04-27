using DataImporter.Core.Abstractions;
using DataImporter.Core.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace DataImporter.Core
{
    public class ProductService : IProductService
    {
        public readonly  string PATH = "C:\\DGH\\DataImporter\\DataImporter.ConsoleApp\\TestData\\";
        public readonly  string FILENAME = "Data.csv";
        public List<Product> Products = new List<Product>();
     
        public  List<Product> GetProducts(Company company, Feed feed)
        {


            string readData = null;
            StreamReader reader = new StreamReader(PATH + company.Path + "\\" + feed.Path + "\\" + FILENAME);
            try
            {
                int dataRowcount = 0;
                do
                {
                    dataRowcount++;



                        Product product = new Product();
                        readData = reader.ReadLine().ToString();

                    if (dataRowcount > 1)
                    {
                        string[] Columns = readData.Split(',');
                        int count = 0;
                        foreach (var column in Columns)
                        {
                            count++;
                            switch (count)
                            {
                                case 1:
                                    
                                    product.Id = Product.Counter;
                                    product.UniqueId = company.Id.ToString() + feed.Id.ToString() + column.ToString();
                                    product.Companies.Add(company);
                                    product.Feeds.Add(feed);
                                    break;
                                case 2:
                                    product.Name = column.ToString();
                                    break;
                                case 3:
                                    product.Brand = column.ToString();
                                    break;
                                case 4:
                                    product.Description = column.ToString();
                                    break;
                                default:
                                    product.Description = column.ToString();
                                    break;
                            }

                        }
                        Products.Add(product);


                    }
                }
                while (reader.Peek() != -1);
                return Products;
            }
            catch 
            {
                return null;
            }
            finally
            {
                reader.Close();
            }


        }
    }
}
