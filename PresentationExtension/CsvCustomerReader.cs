using Presentation;
using System;
using System.IO;

namespace PresentationExtension
{
    public class CsvCustomerReader : ICustomerReader
    {
        public Customer Read(string pFilename)
        {
            string[] parts = File.ReadAllText(pFilename).Trim().Split(',');

            return new Customer()
            {
                FirstName = parts[0],
                LastName = parts[1]
            };
        }
    }
}
