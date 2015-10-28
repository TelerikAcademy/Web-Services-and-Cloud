using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles.Models
{
    public class Alert
    {
        public int ID { get; set; }

        public string Content { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
