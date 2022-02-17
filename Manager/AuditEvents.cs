using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;

namespace Manager
{
	public enum AuditEventTypes
	{
		AuthenticationSuccess = 0,
		AuthorizationSuccess = 1,
		AuthorizationFailure = 2,
		CreateDatabaseSuccess = 3,
		CreateDatabaseFailure = 4,
		ArchieveDatabasaSuccess = 5,
		ArchieveDatabaseFailure = 6,
		DeleteDatabasaSuccess = 7,
		DeleteDatabaseFailure = 8,
		FindMaxInRegionSuccess = 9,
		FindMaxInRegionFailure = 10,
		MeanValByCitySuccess = 11,
		MeanValByCityFailure = 12,
		MeanValByRegionSuccess = 13,
		MeanValByRegionFalure = 14,
		ModifySuccess = 15,
		ModifyFailure = 16,
		WriteSuccess = 17,
		WriteFailure = 18
	}

	public class AuditEvents
	{
		private static ResourceManager resourceManager = null;
		private static object resourceLock = new object();

		private static ResourceManager ResourceMgr
		{
			get
			{
				lock (resourceLock)
				{
					if (resourceManager == null)
					{
						resourceManager = new ResourceManager
							(typeof(AuditEventFile).ToString(),
							Assembly.GetExecutingAssembly());
					}
					return resourceManager;
				}
			}
		}

		public static string AuthenticationSuccess
		{
			get
			{
				// TO DO
				return ResourceMgr.GetString(AuditEventTypes.AuthenticationSuccess.ToString());
			}
		}

		public static string AuthorizationSuccess
		{
			get
			{
				//TO DO
				return ResourceMgr.GetString(AuditEventTypes.AuthorizationSuccess.ToString());
			}
		}

		public static string AuthorizationFailed
		{
			get
			{
				//TO DO
				return ResourceMgr.GetString(AuditEventTypes.AuthorizationFailure.ToString());
			}
		}

		public static string CreateDatabaseFailure
		{
			get
			{
				//TO DO
				return ResourceMgr.GetString(AuditEventTypes.CreateDatabaseFailure.ToString());
			}
		}

		public static string CreateDatabaseSuccess
		{
			get
			{
				//TO DO
				return ResourceMgr.GetString(AuditEventTypes.CreateDatabaseSuccess.ToString());
			}
		}

		public static string ArchieveDatabasaSuccess
		{
			get
			{
				//TO DO
				return ResourceMgr.GetString(AuditEventTypes.ArchieveDatabasaSuccess.ToString());
			}
		}

		public static string ArchieveDatabaseFailure
		{
			get
			{
				//TO DO
				return ResourceMgr.GetString(AuditEventTypes.ArchieveDatabaseFailure.ToString());
			}
		}

		public static string DeleteDatabasaSuccess
		{
			get
			{
				//TO DO
				return ResourceMgr.GetString(AuditEventTypes.DeleteDatabasaSuccess.ToString());
			}
		}

		public static string DeleteDatabaseFailure
		{
			get
			{
				//TO DO
				return ResourceMgr.GetString(AuditEventTypes.DeleteDatabaseFailure.ToString());
			}
		}
		
		public static string FindMaxInRegionSuccess
		{
			get
			{
				//TO DO
				return ResourceMgr.GetString(AuditEventTypes.FindMaxInRegionSuccess.ToString());
			}
		}

		
		public static string FindMaxInRegionFailure
		{
			get
			{
				//TO DO
				return ResourceMgr.GetString(AuditEventTypes.FindMaxInRegionFailure.ToString());
			}
		}

		
		public static string MeanValByCitySuccess
		{
			get
			{
				//TO DO
				return ResourceMgr.GetString(AuditEventTypes.MeanValByCitySuccess.ToString());
			}
		}

		public static string MeanValByCityFailure
		{
			get
			{
				//TO DO
				return ResourceMgr.GetString(AuditEventTypes.MeanValByCityFailure.ToString());
			}
		}

		public static string MeanValByRegionSuccess
		{
			get
			{
				//TO DO
				return ResourceMgr.GetString(AuditEventTypes.MeanValByRegionSuccess.ToString());
			}
		}

		public static string MeanValByRegionFalure
		{
			get
			{
				//TO DO
				return ResourceMgr.GetString(AuditEventTypes.MeanValByRegionFalure.ToString());
			}
		}

		public static string ModifySuccess
		{
			get
			{
				//TO DO
				return ResourceMgr.GetString(AuditEventTypes.ModifySuccess.ToString());
			}
		}

		public static string ModifyFailure
		{
			get
			{
				//TO DO
				return ResourceMgr.GetString(AuditEventTypes.ModifyFailure.ToString());
			}
		}

		public static string WriteSuccess
		{
			get
			{
				//TO DO
				return ResourceMgr.GetString(AuditEventTypes.WriteSuccess.ToString());
			}
		}

		public static string WriteFailure
		{
			get
			{
				//TO DO
				return ResourceMgr.GetString(AuditEventTypes.WriteFailure.ToString());
			}
		}
	}
}
