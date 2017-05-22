using System;
using Evgeniy.Database;
using Starcounter;

namespace Evgeniy.ViewModels
{
    partial class OfficeJson : Json
    {
        static OfficeJson()
        {
            DefaultTemplate.Address.InstanceType = typeof(EditAddressJson);
            DefaultTemplate.Homes.ElementType.InstanceType = typeof(HomeTransactionJson);
            DefaultTemplate.Home.InstanceType = typeof(EditHomeJson);
        }
        void Handle(Input.SaveTrigger action)
        {
            Transaction.Commit();
        }

        void Handle(Input.AddNewHomeTrigger action)
        {
            Db.Transact(() =>
            {
                var address = new Address { Street = Home.Address.Street, City = Home.Address.City, Number = (int)Home.Address.Number, ZipCode = (int)Home.Address.ZipCode, Country = Home.Address.Country };
                DateTime? parsedDate = GetDate(Home.SalesTransaction.CreatedAt);
                DateTime date = DateTime.Now; ;
                if (parsedDate != null)
                {
                    date = (DateTime)parsedDate;
                }

                var transaction = new SalesTransaction { Price = Home.SalesTransaction.Price, Commission = Home.SalesTransaction.Comission, CreatedAt = date };
                new Home
                {
                    Office = Data as Office,
                    Address = address,
                    SalesTransaction = transaction
                };
            });
        }

        protected DateTime? GetDate(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            DateTime date;
            DateTime.TryParse(value, out date);

            return date;
        }
    }
}
