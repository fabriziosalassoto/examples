using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace BOLibrary
{
    public class BOCls_Mail
    {
        #region PrivateProperties
        private MailMessage oMailMessage;
        private String strHost;
        private String strNameSender;
        private String strFrom;
        private String strTo;
        private String strCarbonCopy;
        private String strBlindCarbonCopy;
        private String strSubmitSubject;
        private String strSubmitBody;        
        #endregion

        #region Constructor
        public BOCls_Mail() {            
            oMailMessage = new MailMessage();            
            try
            {
                strHost = BOCls_EmailInfo.getHost();
                strNameSender = BOCls_EmailInfo.getDisplayNameFrom();
                strFrom = BOCls_EmailInfo.getEmailFrom();
                strCarbonCopy = BOCls_EmailInfo.getEmailCarbonCopy();
                strBlindCarbonCopy = BOCls_EmailInfo.getEmailBlindCarbonCopy();                
                oMailMessage.From = new MailAddress(strFrom, strNameSender);
                if (strCarbonCopy != null)
                {
                    oMailMessage.CC.Add(strCarbonCopy);
                }
                if(strBlindCarbonCopy != null){
                    oMailMessage.Bcc.Add(new MailAddress(strBlindCarbonCopy));
                }           
                oMailMessage.IsBodyHtml = false;
                oMailMessage.Priority = MailPriority.Normal;
            }
            catch (Exception ex){
            }

        }
        #endregion

        #region SendMailUtilities
        public bool DoSendSubmitMail(String pSendTo, String pSendNameToDisplay, String pStoryTitle){
            try
            {
                strTo = pSendTo;
                strSubmitSubject = BOCls_EmailInfo.getEmailSubmitSubject();
                strSubmitBody = BOCls_EmailInfo.getEmailSubmitBody();
                strSubmitSubject = strSubmitSubject.Replace("[SUBMITTER]", pSendNameToDisplay);
                strSubmitSubject = strSubmitSubject.Replace("[STORY]", pStoryTitle);
                strSubmitBody = strSubmitBody.Replace("[SUBMITTER]", pSendNameToDisplay);
                strSubmitBody = strSubmitBody.Replace("[STORY]", pStoryTitle);
                strSubmitBody = strSubmitBody.Replace("[NEWLINE]", Environment.NewLine);
                oMailMessage.To.Add(new MailAddress(pSendTo));
                oMailMessage.Subject = strSubmitSubject;
                oMailMessage.Body = strSubmitBody;
                SmtpClient oSMTP = new SmtpClient(strHost);
                oSMTP.Send(oMailMessage);                
            } catch (Exception ex){
                return false;                
            }
            return true;
        }
        #endregion
    }
}