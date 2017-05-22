using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Starcounter;

namespace Evgeniy.Database
{
    [Database]
    public class Home
    {
        public SalesTransaction SalesTransaction { get; set; }
        public Office Office { get; set; }
        public Address Address { get; set; }

    }
}
