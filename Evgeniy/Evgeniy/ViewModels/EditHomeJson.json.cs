using Starcounter;

namespace Evgeniy.ViewModels
{
    partial class EditHomeJson : Json
    {
        static EditHomeJson()
        {
            DefaultTemplate.Address.InstanceType = typeof(EditAddressJson);
            DefaultTemplate.SalesTransaction.InstanceType = typeof(EditTransactionJson);
        }
    }
}
