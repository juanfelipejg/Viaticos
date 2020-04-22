using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Viaticos.Common.Models;

namespace ViaticosWeb.Helpers
{
        public interface IMailHelper
        {
            Response SendMail(string to, string subject, string body);
        }
        
}
