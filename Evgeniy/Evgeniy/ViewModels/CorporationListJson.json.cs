using Evgeniy.Database;
using Starcounter;

namespace Evgeniy.ViewModels
{
    partial class CorporationListJson : Json
    {
        static CorporationListJson()
        {
            DefaultTemplate.Corporations.ElementType.InstanceType = typeof(CorporationJson);
        }
        void Handle(Input.AddNewCorporationTrigger action)
        {
            Db.Transact(() =>
            {
                new Corporation()
                {
                    Name = this.Name,

                };
            });
            this.Corporations = Db.SQL<Corporation>("SELECT c FROM Corporation c ORDER BY ObjectNo DESC");
        }
    }
}
