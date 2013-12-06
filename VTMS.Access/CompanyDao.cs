using System;
using System.Collections;
using System.Linq;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using VTMS.Model.Entities;
namespace VTMS.Access
{
    public class CompanyDao
    {
        public static string GetLatestId()
        {
            ISession session = SessionFactory.OpenSession();
            {
                string serial = session.CreateSQLQuery(
                            @"SELECT IF(NOT EXISTS(SELECT * FROM vtms.company),
                            '00',
                            (SELECT MAX(id)+1 FROM vtms.company)) as id"
                            ).List()[0].ToString();
                return string.Format("{0:D2}", int.Parse(serial));
            }
        }
        public static System.Collections.Generic.IList<Company> LoadAll()
        {
            ISession session = SessionFactory.OpenSession();

            return session.QueryOver<Company>().Where(m => m.Isactive == true).OrderBy(c => c.Priority).Desc.List();
        }
        public static System.Collections.Generic.IList<Company> Load()
        {
            ISession session = SessionFactory.OpenSession();
            {
                return session.QueryOver<Company>().OrderBy(c => c.Id).Asc.List();
            }
        }
        public static object AddCompany(Company entity)
        {
            entity.Id = GetLatestId();
            ISession session = SessionFactory.OpenSession();
            {
                var id = session.Save(entity);
                session.Flush();
                return id;
            }
        }

        public static void UpdateCompany(Company entity)
        {
            ISession session = SessionFactory.OpenSession();
            {
                session.Update(entity);
                session.Flush();
            }
        }
        public static Company Get(string id)
        {
            ISession session = SessionFactory.OpenSession();
            {
                return session.Get<Company>(id);
            }
        }
    }
}
