using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Presentation
{
    public interface ICustomerReader
    {
        Customer Read(string pFilename);
    }

    public class XmlCustomerReader : ICustomerReader
    {
        public Customer Read(string pFileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Customer));
            StreamReader reader = new StreamReader(pFileName);
            Customer ret = serializer.Deserialize(reader) as Customer;
            reader.Close();
            return ret;
        }
    }

    public class JsonCustomerReader : ICustomerReader
    {
        public Customer Read(string pFileName)
        {
            return JsonConvert.DeserializeObject<Customer>(File.ReadAllText(pFileName));
        }
    }

    public class Complex
    {
        public static Customer ReadCustomerFile(string pFileName)
        {
            string extension = Path.GetExtension(pFileName).ToLower();

            ICustomerReader reader = null;

            if (extension == "xml")
            {
                reader = new XmlCustomerReader();
            }
            else if (extension == "json")
            {
                reader = new JsonCustomerReader();
            }

            return reader.Read(pFileName);
        }
    }
}
