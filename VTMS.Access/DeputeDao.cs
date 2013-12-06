using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using VTMS.Model.Entities;

namespace VTMS.Access
{
    public class DeputeDao
    {
        public static string GetCurrentDate()
        {
            ISession session = SessionFactory.OpenSession();
            {
                string currentDate = session.CreateSQLQuery(
                            @"SELECT DATE_FORMAT(CURRENT_DATE,'%Y%m%d') FROM DUAL"
                            ).List()[0].ToString();
                return currentDate;
            }
        }
        public static string GetLatestSerial()
        {
            ISession session = SessionFactory.OpenSession();
            {
                string serial = session.CreateSQLQuery(
                            @"SELECT IF(NOT EXISTS(SELECT * FROM vtms.depute WHERE serial = CONCAT(DATE_FORMAT(CURRENT_DATE,'%Y%m%d'),'001')),
                            CONCAT(DATE_FORMAT(CURRENT_DATE,'%Y%m%d'),'001'),
                            (SELECT MAX(serial)+1 FROM vtms.depute)) as serial"
                            ).List()[0].ToString();
                return serial;
            }
        }

        public static object AddDepute(Depute entity)
        {
            entity.Serial = GetLatestSerial();
            ISession session = SessionFactory.OpenSession();
            {
                var id = session.Save(entity);
                session.Flush();
                return id;
            }
        }

        public static void UpdateDepute(Depute entity)
        {
            ISession session = SessionFactory.OpenSession();
            {
                session.Update(entity);
                session.Flush();
            }
        }

        public static void DeleteDepute(Depute entity)
        {
            ISession session = SessionFactory.OpenSession();
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public static Depute GetBySerial(string id)
        {
            ISession session = SessionFactory.OpenSession();
            {
                return session.Get<Depute>(id);
            }
        }
    }
}
