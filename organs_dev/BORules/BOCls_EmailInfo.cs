using System;
using System.Collections.Generic;
using System.Configuration;

namespace BOLibrary
{
    internal static class BOCls_EmailInfo
    {                        
        internal static String getHost()
        {
            return System.Configuration.ConfigurationManager.AppSettings["Host"].ToString();            
        }

        internal static String getDisplayNameFrom()
        {
            return System.Configuration.ConfigurationManager.AppSettings["NameSender"].ToString();            
        }

        internal static String getEmailFrom()
        {
            return System.Configuration.ConfigurationManager.AppSettings["EmailFrom"].ToString();                        
        }

        internal static String getEmailCarbonCopy()
        {
            return System.Configuration.ConfigurationManager.AppSettings["EmailCC"].ToString();                                    
        }

        internal static String getEmailBlindCarbonCopy()
        {
            return System.Configuration.ConfigurationManager.AppSettings["EmailBCC"].ToString();                                                
        }

        internal static String getEmailSubmitSubject()
        {
            return System.Configuration.ConfigurationManager.AppSettings["EmailSubmitSubject"].ToString();                                                
        }

        internal static String getEmailSubmitBody()
        {
            return System.Configuration.ConfigurationManager.AppSettings["EmailSubmitBody"].ToString();                                                
        }
    }
}
