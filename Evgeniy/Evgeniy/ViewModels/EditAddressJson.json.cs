using Evgeniy.Database;
using Starcounter;

namespace Evgeniy.ViewModels
{
    partial class EditAddressJson : Json, IBound<Address>
    {
        public string FullAddress => Street + " " + Number + ", " + ZipCode + " " + City + ", " + Country;
    }
}
