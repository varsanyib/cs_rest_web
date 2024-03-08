using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebRequest_CS.Model
{
    public class Answer
    {
        public string InternalErrorMessage { get; set; } = string.Empty;
        public bool InternalError { 
            get { 
                return !InternalErrorMessage.Equals(string.Empty); 
            }
        }
        public HttpResponseMessage? Response { get; set; }
        public JObject? Result { get; set; }
    }
}
