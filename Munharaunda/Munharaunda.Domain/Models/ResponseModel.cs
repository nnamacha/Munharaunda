using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munharaunda.Domain.Models
{
    public class ResponseModel<T>
    {
        public ResponseModel()
        {
            //this.Errors = new List<string>();
            //Default to success to remove need to redunantly assign them
            //this.ResponseCode = ResponseConstants.R00;
            //this.ResponseMessage = ResponseConstants.R00Message;
        }

        public T ResponseData { get; set; }

        public string ResponseCode { get; set; }

        public List<string> Errors { get; set; }

        public string ResponseMessage { get; set; }
    }
}
