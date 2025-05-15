using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstadioIQ.Entity.Common
{
    public class ResponseData
    {
        public bool SuccessStatus { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }
    }

    public class ResponseData<T>
    {
        public bool SuccessStatus { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }
    }
}
