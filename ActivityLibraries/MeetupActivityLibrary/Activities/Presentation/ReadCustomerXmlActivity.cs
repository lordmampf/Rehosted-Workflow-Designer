using Newtonsoft.Json;
using System;
using System.Activities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MeetupWfIntro.MeetupActivityLibrary.Activities.Presentation
{
    public class ReadCustomerXmlActivity : CodeActivity<Customer>
    {
        public InArgument<string> Filename { get; set; }

        protected override Customer Execute(CodeActivityContext context)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Customer));
            StreamReader reader = new StreamReader(context.GetValue(Filename));
            Customer ret = serializer.Deserialize(reader) as Customer;
            reader.Close();
            return ret;
        }
    }
}
