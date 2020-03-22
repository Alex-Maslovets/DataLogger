using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace SQLDataSources
{
    public struct OdbcSource
    {
        public string ServerName;
        public string DriverName;
    }
    
    public static class OdbcWrapper
    {
        [DllImport("odbc32.dll")]
        public static extern int SQLDataSources(int EnvHandle, int Direction, StringBuilder ServerName, int ServerNameBufferLenIn,
    ref int ServerNameBufferLenOut, StringBuilder Driver, int DriverBufferLenIn, ref int DriverBufferLenOut);
        [DllImport("odbc32.dll")]
        public static extern int SQLAllocEnv(ref int EnvHandle);

        public static List<OdbcSource> ListODBCsources()
        {
            int envHandle = 0;
            const int SQL_FETCH_NEXT = 1;
            const int SQL_FETCH_FIRST_SYSTEM = 32;
            List<OdbcSource> sources = new List<OdbcSource>();

            try
            {
                if (OdbcWrapper.SQLAllocEnv(ref envHandle) != -1)
                {
                    int ret;
                    StringBuilder serverName = new StringBuilder(1024);
                    StringBuilder driverName = new StringBuilder(1024);
                    int snLen = 0;
                    int driverLen = 0;

                    ret = OdbcWrapper.SQLDataSources(envHandle, SQL_FETCH_FIRST_SYSTEM, serverName, serverName.Capacity, ref snLen,
                                driverName, driverName.Capacity, ref driverLen);
                    while (ret == 0)
                    {
                        OdbcSource source = new OdbcSource();
                        source.ServerName = serverName.ToString();
                        source.DriverName = driverName.ToString();
                        sources.Add(source);
                        ret = OdbcWrapper.SQLDataSources(envHandle, SQL_FETCH_NEXT, serverName, serverName.Capacity, ref snLen,
                                driverName, driverName.Capacity, ref driverLen);
                    }
                }
                // Sorting by server name
                sources.Sort(delegate(OdbcSource s1, OdbcSource s2) { return s1.ServerName.CompareTo(s2.ServerName); });
            }
            catch
            {

            }
            
            return sources;
        } 
    }
}