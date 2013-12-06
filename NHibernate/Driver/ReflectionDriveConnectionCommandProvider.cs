using System;
using System.Data;
using Environment = NHibernate.Cfg.Environment;

namespace NHibernate.Driver
{
	public class ReflectionDriveConnectionCommandProvider : IDriveConnectionCommandProvider
	{
		private readonly System.Type commandType;
		private readonly System.Type connectionType;
        private readonly System.Type adapterType;

        public ReflectionDriveConnectionCommandProvider(System.Type connectionType, System.Type commandType, System.Type adapterType = null)
        {
            if (connectionType == null)
            {
                throw new ArgumentNullException("connectionType");
            }
            if (commandType == null)
            {
                throw new ArgumentNullException("commandType");
            }
            this.connectionType = connectionType;
            this.commandType = commandType;
            this.adapterType = adapterType;
        }

		public ReflectionDriveConnectionCommandProvider(System.Type connectionType, System.Type commandType)
		{
			if (connectionType == null)
			{
				throw new ArgumentNullException("connectionType");
			}
			if (commandType == null)
			{
				throw new ArgumentNullException("commandType");
			}
			this.connectionType = connectionType;
			this.commandType = commandType;
		}

        public IDbDataAdapter CreateDataAdapter(IDbCommand command)
        {
            if (adapterType == null)
            {
                throw new ArgumentNullException("The Data Adapter type is not passed!");

            }
            return (IDbDataAdapter)Environment.BytecodeProvider.ObjectsFactory.CreateInstance(adapterType, command);
        }
		#region IDriveConnectionCommandProvider Members

		public IDbConnection CreateConnection()
		{
			return (IDbConnection) Environment.BytecodeProvider.ObjectsFactory.CreateInstance(connectionType);
		}

		public IDbCommand CreateCommand()
		{
			return (IDbCommand) Environment.BytecodeProvider.ObjectsFactory.CreateInstance(commandType);
		}

		#endregion
	}
}