using Starcounter;

namespace Evgeniy.ViewModels
{
    partial class HomeTransactionJson : Json
    {
        public string FullAddress => Address.Street + " " + Address.Number + ", " + Address.ZipCode + " " + Address.City + ", " + Address.Country;
    }
}
