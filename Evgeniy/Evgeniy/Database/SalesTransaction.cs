using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Starcounter;

namespace Evgeniy.Database
{
    [Database]
    public class SalesTransaction
    {
        public DateTime CreatedAt { get; set; }
        public decimal Price { get; set; }
        public decimal Commission { get; set; }
    }
}
