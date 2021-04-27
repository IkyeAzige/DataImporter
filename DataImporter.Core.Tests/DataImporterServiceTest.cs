using DataImporter.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DataImporter.Core.Tests
{
    [TestClass]
    public class DataImporterServiceTest
    {
        private DataImporterService importerService;
        private ProductService ProdService;
        public IEnumerable<Feed> Feeds { get; set; }
        public IEnumerable<Company> Companies { set; get; }

        public List<Product> Products { set; get; }

        [TestMethod]
        public void FeedIDValidationTest()
        {
            //-- Arrange
            Feed feed = new Feed
            {
                Id = 101

            };
            int expected = 101;

            //-- Act
            int actual = feed.Id;

            //-- Assert
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void CompanyIDValidationTest()
        {
            //-- Arrange
            Company company = new Company
            {
                Id = 100

            };
            int expected = 100;

            //-- Act
            int actual = company.Id;

            //-- Assert
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void ProductUniqueIdValidationTest()
        {
            //-- Arrange
            Product product = new Product
            {
                Id = 3

            };
            Company company = new Company
            {
                Id = 100

            };
            Feed feed = new Feed
            {
                Id = 101

            };


            string expected = "100" + "101" + "3";

            //-- Act
            string actual = company.Id.ToString() + feed.Id.ToString() + product.Id.ToString();

            //-- Assert
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void ReadCompanyFileValidationTest()
        {
            //-- Arrange

            DataImporterService dataImporterService = new DataImporterService();
            ProductService productService = new ProductService();
            Companies = dataImporterService.GetCompanies();
            int dataCount = 0;
            foreach (Company comoany in Companies)
            {
                dataCount++;
            }

            //-- Act
            int actual = 3;

            //-- Assert
            Assert.AreEqual(dataCount, actual);

        }
        [TestMethod]
        public void ReadFeedFileValidationTest()
        {
            //-- Arrange

            DataImporterService dataImporterService = new DataImporterService();
            ProductService productService = new ProductService();
            Feeds = dataImporterService.GetFeeds();
            int dataCount = 0;
            foreach (Feed feed in Feeds)
            {
                dataCount++;
            }

            //-- Act
            int actual = 15;

            //-- Assert
            Assert.AreEqual(dataCount, actual);

        }
        [TestMethod]
        public void ReadProductFileValidationTest()
        {
            //-- Arrange

            DataImporterService dataImporterService = new DataImporterService();
            ProductService productService = new ProductService();
            Companies = dataImporterService.GetCompanies();
            Feeds = dataImporterService.GetFeeds();
            Products = new List<Product>();
            //return Ok();
            foreach (Company company in Companies)
            {
                foreach (Feed feed in Feeds)
                {
                    if (company.Id.ToString().Substring(0, 1) == feed.Id.ToString().Substring(0, 1))
                    {
                        //Get Product for Company Feed
                        foreach (Product product in productService.GetProducts(company, feed))
                        {
                            Products.Add(product);

                        }
                    }

                }
            }

            //-- Act
            int actual = 18000;

            //-- Assert
            Assert.AreEqual(Products.Count, actual);

        }
     
    }
}
