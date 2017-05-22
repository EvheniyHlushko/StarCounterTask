using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Starcounter;

namespace Evgeniy.Database
{
    [Database]
    public class Office 
    {
        public Corporation Corporation { get; set; }
        public string Name { get; set; }
        public IEnumerable<Home> Homes => Db.SQL<Home>("select e from Home e where e.Office = ?", this);
        public Address Address { get; set; }
    }
}
