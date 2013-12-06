using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using VTMS.Model.Entities;
namespace VTMS.Access
{
    public class PrivilegeDao
    {
        public static IList<Privilege> GetByUserId(string userId)
        {
            ISession session = SessionFactory.OpenSession();
            Privilege p = new Privilege();
            return session.QueryOver<Privilege>().Where(a => a.User.UsersId == userId).List();
        }
        public static void SavePrivileges(IList<Privilege> privileges)
        {
            ISession session = SessionFactory.OpenSession();
            foreach (Privilege privilege in privileges)
            {
                session.SaveOrUpdate(privilege);
            }
            session.Flush();
        }
    }
}
