using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Starcounter;

namespace Evgeniy.Database
{
    [Database]
    public class Corporation
    {
        public string Name { get; set; }
        public IEnumerable<Office> Offices => Db.SQL<Office>("select e from Office e where e.Corporation = ?", this);
    }
}
