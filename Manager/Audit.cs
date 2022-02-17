using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Manager
{
    public class Audit : IDisposable
    {

        private static EventLog customLog = null;
        const string SourceName = "Manager.Audit";
        const string LogName = "MySecTest";

        static Audit()
        {
            try
            {
                if (!EventLog.SourceExists(SourceName))
                {
                    EventLog.CreateEventSource(SourceName, LogName);
                }
                customLog = new EventLog(LogName,
                    Environment.MachineName, SourceName);
            }
            catch (Exception e)
            {
                customLog = null;
                Console.WriteLine("Error while trying to create log handle. Error = {0}", e.Message);
            }
        }


        public static void AuthenticationSuccess(string userName)
        {
            //TO DO

            if (customLog != null)
            {
                string UserAuthenticationSuccess =
                    AuditEvents.AuthenticationSuccess;
                string message = String.Format(UserAuthenticationSuccess,
                    userName);
                customLog.WriteEntry(message);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.",
                    (int)AuditEventTypes.AuthenticationSuccess));
            }
        }

        public static void AuthorizationSuccess(string userName, string serviceName)
        {
            //TO DO
            if (customLog != null)
            {
                string AuthorizationSuccess =
                    AuditEvents.AuthorizationSuccess;
                string message = String.Format(AuthorizationSuccess,
                    userName, serviceName);
                customLog.WriteEntry(message);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.",
                    (int)AuditEventTypes.AuthorizationSuccess));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="serviceName"> should be read from the OperationContext as follows: OperationContext.Current.IncomingMessageHeaders.Action</param>
        /// <param name="reason">permission name</param>
        public static void AuthorizationFailed(string userName, string serviceName, string reason)
        {
            if (customLog != null)
            {
                string AuthorizationFailed =
                    AuditEvents.AuthorizationFailed;
                string message = String.Format(AuthorizationFailed,
                    userName, serviceName, reason);
                customLog.WriteEntry(message);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.",
                    (int)AuditEventTypes.AuthorizationFailure));
            }
        }

        public static void CreateDatabaseSuccess(string userName, string dataBaseName)
        {
            if (customLog != null)
            {
                string CreateDatabaseSuccess =
                    AuditEvents.CreateDatabaseSuccess;
                string message = String.Format(CreateDatabaseSuccess,
                    userName, dataBaseName);
                customLog.WriteEntry(message);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.",
                    (int)AuditEventTypes.AuthorizationFailure));
            }
        }

        public static void CreateDatabaseFailure(string userName, string dataBaseName, string reason)
        {
            if (customLog != null)
            {
                string CreateDatabaseFailure =
                    AuditEvents.CreateDatabaseFailure;
                string message = String.Format(CreateDatabaseFailure,
                    userName, dataBaseName, reason);
                customLog.WriteEntry(message);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.",
                    (int)AuditEventTypes.AuthorizationFailure));
            }
        }

        
        public static void ArchieveDatabasaSuccess(string userName, string dataBaseName)
        {
            if (customLog != null)
            {
                string ArchieveDatabasaSuccess =
                    AuditEvents.ArchieveDatabasaSuccess;
                string message = String.Format(ArchieveDatabasaSuccess,
                    userName, dataBaseName);
                customLog.WriteEntry(message);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.",
                    (int)AuditEventTypes.AuthorizationFailure));
            }
        }

        public static void ArchieveDatabaseFailure(string userName, string dataBaseName, string reason)
        {
            if (customLog != null)
            {
                string ArchieveDatabaseFailure =
                    AuditEvents.ArchieveDatabaseFailure;
                string message = String.Format(ArchieveDatabaseFailure,
                    userName, dataBaseName, reason);
                customLog.WriteEntry(message);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.",
                    (int)AuditEventTypes.AuthorizationFailure));
            }
        }

        
        public static void DeleteDatabasaSuccess(string userName, string dataBaseName)
        {
            if (customLog != null)
            {
                string DeleteDatabasaSuccess =
                    AuditEvents.DeleteDatabasaSuccess;
                string message = String.Format(DeleteDatabasaSuccess,
                    userName, dataBaseName);
                customLog.WriteEntry(message);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.",
                    (int)AuditEventTypes.AuthorizationFailure));
            }
        }

        public static void DeleteDatabaseFailure(string userName, string dataBaseName, string reason)
        {
            if (customLog != null)
            {
                string DeleteDatabaseFailure =
                    AuditEvents.DeleteDatabaseFailure;
                string message = String.Format(DeleteDatabaseFailure,
                    userName, dataBaseName, reason);
                customLog.WriteEntry(message);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.",
                    (int)AuditEventTypes.AuthorizationFailure));
            }
        }

        public static void FindMaxInRegionSuccess(string userName)
        {
            if (customLog != null)
            {
                string FindMaxInRegionSuccess =
                    AuditEvents.FindMaxInRegionSuccess;
                string message = String.Format(FindMaxInRegionSuccess,
                    userName);
                customLog.WriteEntry(message);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.",
                    (int)AuditEventTypes.AuthorizationFailure));
            }
        }

        public static void FindMaxInRegionFailure(string userName, string reason)
        {
            if (customLog != null)
            {
                string FindMaxInRegionFailure =
                    AuditEvents.FindMaxInRegionFailure;
                string message = String.Format(FindMaxInRegionFailure,
                    userName, reason);
                customLog.WriteEntry(message);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.",
                    (int)AuditEventTypes.AuthorizationFailure));
            }
        }

        public static void MeanValByCitySuccess(string userName)
        {
            if (customLog != null)
            {
                string MeanValByCitySuccess =
                    AuditEvents.MeanValByCitySuccess;
                string message = String.Format(MeanValByCitySuccess,
                    userName);
                customLog.WriteEntry(message);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.",
                    (int)AuditEventTypes.AuthorizationFailure));
            }
        }

        public static void MeanValByCityFailure(string userName, string reason)
        {
            if (customLog != null)
            {
                string MeanValByCityFailure =
                    AuditEvents.MeanValByCityFailure;
                string message = String.Format(MeanValByCityFailure,
                    userName, reason);
                customLog.WriteEntry(message);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.",
                    (int)AuditEventTypes.AuthorizationFailure));
            }
        }

        public static void MeanValByRegionSuccess(string userName)
        {
            if (customLog != null)
            {
                string MeanValByRegionSuccess =
                    AuditEvents.MeanValByRegionSuccess;
                string message = String.Format(MeanValByRegionSuccess,
                    userName);
                customLog.WriteEntry(message);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.",
                    (int)AuditEventTypes.AuthorizationFailure));
            }
        }

        public static void MeanValByRegionFalure(string userName, string reason)
        {
            if (customLog != null)
            {
                string MeanValByRegionFalure =
                    AuditEvents.MeanValByRegionFalure;
                string message = String.Format(MeanValByRegionFalure,
                    userName, reason);
                customLog.WriteEntry(message);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.",
                    (int)AuditEventTypes.AuthorizationFailure));
            }
        }

        public static void ModifySuccess(string userName)
        {
            if (customLog != null)
            {
                string ModifySuccess =
                    AuditEvents.ModifySuccess;
                string message = String.Format(ModifySuccess,
                    userName);
                customLog.WriteEntry(message);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.",
                    (int)AuditEventTypes.AuthorizationFailure));
            }
        }

        public static void ModifyFailure(string userName, string reason)
        {
            if (customLog != null)
            {
                string ModifyFailure =
                    AuditEvents.ModifyFailure;
                string message = String.Format(ModifyFailure,
                    userName, reason);
                customLog.WriteEntry(message);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.",
                    (int)AuditEventTypes.AuthorizationFailure));
            }
        }

        public static void WriteSuccess(string userName)
        {
            if (customLog != null)
            {
                string WriteSuccess =
                    AuditEvents.WriteSuccess;
                string message = String.Format(WriteSuccess,
                    userName);
                customLog.WriteEntry(message);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.",
                    (int)AuditEventTypes.AuthorizationFailure));
            }
        }

        public static void WriteFailure(string userName, string reason)
        {
            if (customLog != null)
            {
                string WriteFailure =
                    AuditEvents.WriteFailure;
                string message = String.Format(WriteFailure,
                    userName, reason);
                customLog.WriteEntry(message);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.",
                    (int)AuditEventTypes.AuthorizationFailure));
            }
        }


        public void Dispose()
        {
            if (customLog != null)
            {
                customLog.Dispose();
                customLog = null;
            }
        }
    }
}
