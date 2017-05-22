using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Evgeniy.Database;
using Evgeniy.Utils;
using Starcounter;

namespace Evgeniy.ViewModels
{
    partial class CorporationJson : Json
    {
        [CorporationJson_json.Offices]
        partial class OfficeItem : Json, IBound<Office>
        {
            protected override void OnData()
            {
                base.OnData();

                IEnumerable<Home> homes = this.Data.Homes.ToList();
                NumberOfHomes = homes.Count();
                if (homes.Any())
                {
                    TotalComission = (long)homes.Select(x => x.SalesTransaction.Commission).Sum();
                    AverageComission = TotalComission / NumberOfHomes;
                    Trend = (long)Calculation.CalculateTrend(homes.Select(x => x.SalesTransaction).ToList());
                }
                Id = Data.GetObjectID();
                EditUrl = $"/Evgeniy/offices/{this.Id}";
            }
            }

        void Handle(Input.AddNewOfficeTrigger action)
        {
            Db.Transact(() =>
            {
                new Office()
                {
                    Name = this.NewOfficeName,
                    Corporation = this.Data as Corporation,
                    Address = new Address()
                };
            });
            this.Offices = Db.SQL("SELECT o FROM Office o ORDER BY Name");
        }
    }
}
