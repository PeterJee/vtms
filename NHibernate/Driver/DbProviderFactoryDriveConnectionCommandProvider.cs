using System;
using System.Data;
using System.Data.Common;

namespace NHibernate.Driver
{
	public class DbProviderFactoryDriveConnectionCommandProvider : IDriveConnectionCommandProvider
	{
		private readonly DbProviderFactory dbProviderFactory;

		public DbProviderFactoryDriveConnectionCommandProvider(DbProviderFactory dbProviderFactory)
		{
			if (dbProviderFactory == null)
			{
				throw new ArgumentNullException("dbProviderFactory");
			}
			this.dbProviderFactory = dbProviderFactory;
		}

		public IDbConnection CreateConnection()
		{
			return dbProviderFactory.CreateConnection();
		}

		public IDbCommand CreateCommand()
		{
			return dbProviderFactory.CreateCommand();
		}

        public IDbDataAdapter CreateDataAdapter(IDbCommand command)
        {
            throw new NotImplementedException("Customized method is not implemented by ChenKeFang");
        }
	}
}