using System;
using System.Collections;
using System.Linq;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using VTMS.Model.Entities;

namespace VTMS.Access
{
    public class ArchivesDao
    {
        public static System.Collections.Generic.IList<Archives> Load()
        {
            ISession session = SessionFactory.OpenSession();
            {
                return session.QueryOver<Archives>().Where(c=>c.Process != "申档完").OrderBy(c => c.License).Asc.List();
            }
        }
        public static void AddArchives(Archives entity)
        {
            ISession session = SessionFactory.OpenSession();
            {
                session.SaveOrUpdate(entity);
                session.Flush();
            }
        }

        public static void UpdateArchives(Archives entity)
        {
            ISession session = SessionFactory.OpenSession();
            {
                session.Update(entity);
                session.Flush();
            }
        }
        public static Archives Get(string id)
        {
            ISession session = SessionFactory.OpenSession();
            {
                return session.Get<Archives>(id);
            }
        }

        public static IList SearchArchive(string license)
        {
            string sql = "SELECT a.license, c.`name`, c.id, a.`process`,a.reason, DATE_FORMAT(a.saveDate,'%Y年%m月%d日') from vtms.archives a inner join vtms.vehicle v on a.license = v.license inner join vtms.customer c on v.currentid = c.id where a.license = :license order by v.save_date desc limit 1";
            System.Collections.IList listVehicle = new System.Collections.ArrayList();
            IQuery q = null;

            ISession session = SessionFactory.OpenSession();
            {
                q = session.CreateSQLQuery(sql);
                q.SetParameter("license", license);
                return q.List();
            }
        }
    }
}
