using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using VTMS.Model.Entities;
namespace VTMS.Access
{
    public class CustomerDao
    {
        public static Customer GetById(string userid)
        {
            ISession session = SessionFactory.OpenSession();
            {
                IQuery q = session.CreateQuery("from Customer where userid = :userid");
                q.SetParameter("userid", userid);
                IList<Customer> customers = q.List<Customer>();
                if (customers != null && customers.Count > 0)
                {
                    return customers[0];
                }
                else
                {
                    return null;
                }
            }
        }
        public static void Update(Customer entity)
        {
            ISession session = SessionFactory.OpenSession();
            {
                session.SaveOrUpdate(entity);
                session.Flush();
            }
        }
        public static void Add(Customer entity)
        {
            ISession session = SessionFactory.OpenSession();
            {
                session.SaveOrUpdate(entity);
                session.Flush();
            }
        }
    }
}
