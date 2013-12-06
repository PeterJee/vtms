using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using VTMS.Model.Entities;
namespace VTMS.Access
{
    public class RegisterDao
    {
        public static string GetLatestSerial()
        {
            ISession session = SessionFactory.OpenSession();
            {
                string serial = session.CreateSQLQuery(
                            @"SELECT IF(NOT EXISTS(SELECT * FROM vtms.register WHERE serial = CONCAT(DATE_FORMAT(CURRENT_DATE,'%Y%m%d'),'001')),
                            CONCAT(DATE_FORMAT(CURRENT_DATE,'%Y%m%d'),'001'),
                            (SELECT MAX(serial)+1 FROM vtms.register)) as serial"
                            ).List()[0].ToString();
                return serial;
            }
        }
        public static Register GetBySerial(string id)
        {
            ISession session = SessionFactory.OpenSession();
            {
                return session.Get<Register>(id);
            }
        }
        public static object Add(Register entity)
        {
            entity.Serial = GetLatestSerial();
            ISession session = SessionFactory.OpenSession();
            {
                var id = session.Save(entity);
                session.Flush();
                return id;
            }
        }

        public static void Update(Register entity)
        {
            ISession session = SessionFactory.OpenSession();
            {
                session.Update(entity);
                session.Flush();
            }
        }
        public static System.Collections.IList CaculateRegisterReport(DateTime startDate, DateTime endDate, string condition)
        {
            string sql = null;
            if (condition == "日统计")
            {
                sql = "select DATE_FORMAT(Save_Date,'%Y年%m月%d日'), count(*) from Register where Save_Date > :startDate and Save_Date < :endDate group by DATE_FORMAT(Save_Date,'%Y年%m月%d日') order by DATE_FORMAT(Save_Date,'%Y年%m月%d日')";
            }
            else if (condition == "月统计")
            {
                sql = "select DATE_FORMAT(Save_Date,'%Y年%m月'), count(*) from Register where Save_Date > :startDate and Save_Date < :endDate group by DATE_FORMAT(Save_Date,'%Y年%m月') order by DATE_FORMAT(Save_Date,'%Y年%m月')";
            }
            else
            {
                sql = "select DATE_FORMAT(Save_Date,'%Y年'), count(*) from Register where Save_Date > :startDate and Save_Date < :endDate group by DATE_FORMAT(Save_Date,'%Y年') order by DATE_FORMAT(Save_Date,'%Y年')";
            }
            
            System.Collections.IList listVehicle = new System.Collections.ArrayList();
            IQuery q = null;

            ISession session = SessionFactory.OpenSession();
            {
                q = session.CreateSQLQuery(sql);
                q.SetParameter("startDate", startDate);
                q.SetParameter("endDate", endDate);
                System.Collections.IList tmp = q.List();
                foreach (object[] o in tmp)
                {
                    VirtualReport report = new VirtualReport();
                    report.SaveDate = o[0].ToString();
                    report.Count = int.Parse(o[1].ToString());
                    listVehicle.Add(report);
                }
                return listVehicle;
            }
        }
    }
}
