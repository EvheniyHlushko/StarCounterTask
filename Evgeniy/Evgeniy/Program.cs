using System;
using Evgeniy.Database;
using Evgeniy.ViewModels;
using Starcounter;

namespace Evgeniy
{
    class Program
    {
        static void Main()
        {
            Application.Current.Use(new HtmlFromJsonProvider());
            Application.Current.Use(new PartialToStandaloneHtmlProvider());
            Handle.GET("/Evgeniy", () =>
            {
                return Db.Scope(() =>
                {

                    var json = new CorporationListJson();
                    if (Session.Current == null)
                    {
                        Session.Current = new Session(SessionOptions.PatchVersioning);
                    }
                    json.Corporations = Db.SQL<Corporation>("SELECT c FROM Corporation c");
                    json.Session = Session.Current;
                    return json;
                });


            });

            Handle.GET("/Evgeniy/offices/{?}", (string id) =>
            {
                return Db.Scope(() =>
                {
                    var json = new OfficeJson();
                    if (Session.Current == null)
                    {
                        Session.Current = new Session(SessionOptions.PatchVersioning);
                    }
                    json.Session = Session.Current;
                    json.Data = Db.SQL<Office>("SELECT o FROM Office o WHERE ObjectID=?", id).First;
                    return json;
                });
            });
        }
    }
}