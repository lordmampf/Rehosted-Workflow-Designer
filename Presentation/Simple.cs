using Newtonsoft.Json;
using System;
using System.IO;
using System.Xml.Serialization;

namespace Presentation
{
    public class Simple
    {
        public static Customer ReadCustomerFile(string pFileName)
        {
            string extension = Path.GetExtension(pFileName).ToLower();

            if (extension == "xml")
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Customer));
                StreamReader reader = new StreamReader(pFileName);
                Customer ret = serializer.Deserialize(reader) as Customer;
                reader.Close();

                return ret;
            }
            else if (extension == "json")
            {
                return JsonConvert.DeserializeObject<Customer>(File.ReadAllText(pFileName));
            }

            throw new NotImplementedException();
        }
    }
}
