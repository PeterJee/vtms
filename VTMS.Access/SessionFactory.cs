using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using VTMS.Model;
using VTMS.Common;
namespace VTMS.Access
{
    public static class SessionFactory
    {
        [ThreadStatic]
        private static ISession m_Session;

        private static ISessionFactory sessionFactory;
        public static ISession OpenSession()
        {
            return OpenSession(null);
        }
        public static ISession OpenSession(string server)
        {

            
            if (sessionFactory == null)
            {
                //string pwd = VTMS.Common.Utilities.Base64Dencrypt(Utilities.GetConfigValue("DBPassword"));
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                //connectionString = string.Format(connectionString, , pwd);

                try
                {
                    Configuration cfg = new Configuration().Configure();
                    //cfg.Proxy(p => p.ProxyFactoryFactory<NHibernate.Bytecode.DefaultProxyFactoryFactory>());
                    cfg.DataBaseIntegration(db =>
                    {
                        db.ConnectionString = connectionString;
                    });

                    sessionFactory = cfg.BuildSessionFactory();
                }
                catch (Exception e)
                {
                    VTMS.Common.MessageUtil.ShowError("无法登陆服务器，请检查服务器IP设置是否正确。");
                }
            }
            if (m_Session == null)
            {
                m_Session = sessionFactory.OpenSession();
            }
            if (m_Session != null)
            {
                if (!m_Session.IsConnected)
                {
                    m_Session.Reconnect();
                }
            }
            return m_Session;
        }
    }
}
