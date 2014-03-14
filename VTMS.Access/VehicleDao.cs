using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using VTMS.Model.Entities;
namespace VTMS.Access
{
    public class VehicleDao
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
        public static string GetCurrentTimestamp()
        {
            ISession session = SessionFactory.OpenSession();
            {
                string currentDate = session.CreateSQLQuery(
                            @"SELECT DATE_FORMAT(NOW(),'%Y-%m-%d %H:%i:%S') FROM DUAL"
                            ).List()[0].ToString();
                return currentDate;
            }
        }
        public static string GetLatestSerial()
        {
            ISession session = SessionFactory.OpenSession();
            {
                string serial = session.GetNamedQuery("GetLatestSerial").List()[0].ToString();
                session.Clear();
                return serial;
            }
        }

        public static object AddVehicle(Vehicle entity)
        {
            entity.Serial = GetLatestSerial();
            ISession session = SessionFactory.OpenSession();
            {
                var id = session.Save(entity);
                session.Flush();
                session.Clear();
                return id;
            }
        }

        public static void UpdateVehicle(Vehicle entity)
        {
            ISession session = SessionFactory.OpenSession();
            {
                session.Update(entity);
                session.Flush();
                session.Clear();
            }
        }

        public static void DeleteVehicle(Vehicle entity)
        {
            ISession session = SessionFactory.OpenSession();
            {
                session.Delete(entity);
                session.Flush();
                session.Clear();
            }
        }

        public static Vehicle GetBySerial(string id)
        {
            ISession session = SessionFactory.OpenSession();
            {
                Vehicle vehicle = session.Get<Vehicle>(id);
                session.Clear();
                return vehicle;
            }
        }
        public static DataSet GetFirst20Row()
        {
            DataSet result = null;
            
            ISession session = SessionFactory.OpenSession();
            {
                try
                {
                    result = session.GetNamedQuery("SearchFirst20Rows").QueryDataSet();
                }
                catch (Exception e)
                {
                    string str = e.Message;
                }
                return result;
            }
        }
        public static DataSet SearchResult(string serial, string customerName, string customerId, string license)
        {
            ISession session = SessionFactory.OpenSession();
            {
                IQuery query = session.GetNamedQuery("SearchResult");
                query.SetParameter("customerName", customerName);
                query.SetParameter("serial", serial);
                query.SetParameter("license", license);
                query.SetParameter("customerId", customerId);
                return query.QueryDataSet();
            }
        }
        public static DataSet CaculateCompanyReport(DateTime startDate, DateTime endDate, string company)
        {
            ISession session = SessionFactory.OpenSession();
            {
                IQuery q = session.GetNamedQuery("CaculateCompanyReport");
                q.SetParameter("company", company);
                q.SetParameter("startDate", startDate);
                q.SetParameter("endDate", endDate);
                return q.QueryDataSet();
            }
        }
        public static DataSet CaculateVehicleReport(DateTime startDate, DateTime endDate, string brand)
        {
            ISession session = SessionFactory.OpenSession();
            {
                IQuery query = session.GetNamedQuery("CaculateVehicleReport");
                query.SetParameter("startDate", startDate);
                query.SetParameter("endDate", endDate);
                query.SetParameter("brand", brand);
                return query.QueryDataSet();
            }
        }
        public static DataSet CaculateTradeDailyReport(DateTime startDate, DateTime endDate, string condition)
        {
            IQuery query = null;
            ISession session = SessionFactory.OpenSession();
            {
                if (condition.Equals("已出票"))
                {
                    query = session.GetNamedQuery("CaculateTradeDailyPrinted");
                }
                else if (condition.Equals("已缴费"))
                {
                    query = session.GetNamedQuery("CaculateTradeDailyCharged");
                }
                else
                {
                    query = session.GetNamedQuery("CaculateTradeDailyAll");
                }
                query.SetParameter("startDate", startDate);
                query.SetParameter("endDate", endDate);
                return query.QueryDataSet();
            }
        }
        public static DataSet CaculateTradeMonthReport(DateTime startDate, DateTime endDate)
        {
            ISession session = SessionFactory.OpenSession();
            {
                IQuery query = session.GetNamedQuery("CaculateTradeMonthReport");
                query.SetParameter("startDate", startDate);
                query.SetParameter("endDate", endDate);
                return query.QueryDataSet();
            }
        }
        public static DataSet CaculateTradeYearReport(DateTime startDate, DateTime endDate)
        {
            ISession session = SessionFactory.OpenSession();
            {
                IQuery query = session.GetNamedQuery("CaculateTradeYearReport");
                query.SetParameter("startDate", startDate);
                query.SetParameter("endDate", endDate);
                return query.QueryDataSet();
            }
        }
        public static DataSet CaculateTaxReport(DateTime startDate, DateTime endDate)
        {
            ISession session = SessionFactory.OpenSession();
            {
                IQuery query = session.GetNamedQuery("CaculateTaxReport");
                query.SetParameter("startDate", startDate);
                query.SetParameter("endDate", endDate);
                return query.QueryDataSet();
            }
        }
        public static System.Collections.IList GetBrands()
        {
            string sql = "select distinct brand from Vehicle";
            System.Collections.IList listVehicle = new System.Collections.ArrayList();
            IQuery q = null;

            ISession session = SessionFactory.OpenSession();
            {
                q = session.CreateSQLQuery(sql);
                System.Collections.IList tmp = q.List();
                foreach (object o in tmp)
                {
                    if(o != null)
                    listVehicle.Add(o.ToString());
                }
                return listVehicle;
            }
        }
    }
}
