using DataImporter.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataImporter.Core.Abstractions
{
  public interface IDataImporterService
  {
        public IEnumerable<Feed> GetFeeds();
        public IEnumerable<Company> GetCompanies();
    }
}
