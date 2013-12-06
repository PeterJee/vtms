using System;
using System.Collections;
using System.Linq;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using VTMS.Model.Entities;
namespace VTMS.Access
{
    public class VehicletypeDao
    {
        public static string GetLatestId()
        {
            ISession session = SessionFactory.OpenSession();
            {
                string serial = session.CreateSQLQuery(
                            @"SELECT IF(NOT EXISTS(SELECT * FROM vtms.Vehicletype),
                            '00',
                            (SELECT MAX(id)+1 FROM vtms.Vehicletype)) as id"
                            ).List()[0].ToString();
                return string.Format("{0:D2}", int.Parse(serial));
            }
        }
        public static System.Collections.Generic.IList<Vehicletype> LoadAll()
        {
            ISession session = SessionFactory.OpenSession();
            {
                return session.QueryOver<Vehicletype>().Where(m => m.Isactive == true).OrderBy(c => c.Id).Asc.List();
            }
        }
        public static System.Collections.Generic.IList<Vehicletype> Load()
        {
            ISession session = SessionFactory.OpenSession();
            {
                return session.QueryOver<Vehicletype>().OrderBy(c => c.Id).Asc.List();
            }
        }
        public static object AddVehicletype(Vehicletype entity)
        {
            entity.Id = GetLatestId();
            ISession session = SessionFactory.OpenSession();
            {
                var id = session.Save(entity);
                session.Flush();
                return id;
            }
        }

        public static void UpdateVehicletype(Vehicletype entity)
        {
            ISession session = SessionFactory.OpenSession();
            {
                session.Update(entity);
                session.Flush();
            }
        }
        public static Vehicletype Get(string id)
        {
            ISession session = SessionFactory.OpenSession();
            {
                return session.Get<Vehicletype>(id);
            }
        }
    }
}
