using Newtonsoft.Json;
using System;
using System.Activities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetupWfIntro.MeetupActivityLibrary.Activities.Presentation
{
    public class ReadCustomerJsonActivity : CodeActivity<Customer>
    {
        public InArgument<string> Filename { get; set; }

        protected override Customer Execute(CodeActivityContext context)
        {
            return JsonConvert.DeserializeObject<Customer>(File.ReadAllText(context.GetValue(Filename)));
        }
    }
}
