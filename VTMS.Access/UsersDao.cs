using System;
using System.Collections;
using System.Linq;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using VTMS.Model.Entities;
namespace VTMS.Access
{
    public class UsersDao
    {
        public static Users GetById(string id)
        {
            return SessionFactory.OpenSession().Get<Users>(id);
        }
        public static IList GetAllUsers()
        {
            ISession session = SessionFactory.OpenSession();
            {
                return session.CreateQuery("from Users where id <> 'admin'").List();
            }
        }
        public static string GenerateId()
        {
            ISession session = SessionFactory.OpenSession();
            {
                string id = session.CreateSQLQuery(
                            @"SELECT IF(NOT EXISTS(SELECT * FROM vtms.users where id <> 'admin'), 1,
                            (SELECT MAX(id)+1 FROM vtms.users where id <> 'admin')) as id"
                            ).List()[0].ToString();
                return string.Format("{0:D6}", int.Parse(id));
            }
        }
        public static object AddUser(Users user)
        {
            ISession session = SessionFactory.OpenSession();
            {
                object o = session.Save(user);
                session.Flush();
                return o;
            }
        }
        public static void Update(Users user)
        {
            ISession session = SessionFactory.OpenSession();
            {
                session.Update(user);
                session.Flush();
            }
        }
    }
}
