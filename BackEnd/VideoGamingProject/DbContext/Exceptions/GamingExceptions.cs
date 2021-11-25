using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbContext.Exceptions
{
   public  class GamingExceptions:Exception
    {
        public GamingExceptions()
        {

        }
        public GamingExceptions(string message):base(message)

        {

        }
        public GamingExceptions(string message,Exception innerEx) : base(message, innerEx)

        {

        }
    }
}
