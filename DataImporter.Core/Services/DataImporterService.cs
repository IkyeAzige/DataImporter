using DataImporter.Core.Abstractions;
using DataImporter.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataImporter.Core
{
  public class DataImporterService : IDataImporterService
  {

        private string FeedJsonFileName
        {
            get { return "C:\\DGH\\DataImporter\\Feed.json"; }
        }
        private string CompanyJsonFileName
        {
            get { return "C:\\DGH\\DataImporter\\Company.json"; }
        }
        public IEnumerable<Feed> GetFeeds()
        {
            using (var jsonFileReader = File.OpenText(FeedJsonFileName))
            {
                return JsonSerializer.Deserialize<Feed[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }
        public IEnumerable<Company> GetCompanies()
        {
            using (var jsonFileReader = File.OpenText(CompanyJsonFileName))
            {
                return JsonSerializer.Deserialize<Company[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }
    }
}
