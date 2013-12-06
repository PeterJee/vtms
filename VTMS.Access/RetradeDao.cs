using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using VTMS.Model.Entities;

namespace VTMS.Access
{
    public class RetradeDao
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
                            @"SELECT IF(NOT EXISTS(SELECT * FROM vtms.retrade WHERE serial = CONCAT(DATE_FORMAT(CURRENT_DATE,'%Y%m%d'),'001')),
                            CONCAT(DATE_FORMAT(CURRENT_DATE,'%Y%m%d'),'001'),
                            (SELECT MAX(serial)+1 FROM vtms.retrade)) as serial"
                            ).List()[0].ToString();
                return serial;
            }
        }

        public static object AddRetrade(Retrade entity)
        {
            entity.Serial = GetLatestSerial();
            ISession session = SessionFactory.OpenSession();
            {
                var id = session.Save(entity);
                session.Flush();
                return id;
            }
        }

        public static void UpdateRetrade(Retrade entity)
        {
            ISession session = SessionFactory.OpenSession();
            {
                session.Update(entity);
                session.Flush();
            }
        }

        public static void DeleteRetrade(Retrade entity)
        {
            ISession session = SessionFactory.OpenSession();
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public static Retrade GetBySerial(string id)
        {
            ISession session = SessionFactory.OpenSession();
            {
                return session.Get<Retrade>(id);
            }
        }

        public string Retrade()
        {


            return null;
        }
    }
}
