using System;
using System.Web;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using DFControllers;

namespace DFWebHandlers
{
    public class DFWH_Story : IHttpHandler
    {
        private DFCls_StoryForm oDFStory;

        public void ProcessRequest(HttpContext context)
        {
            Debugger.Launch();
            context.Response.ContentType = "text/xml";
            String StorySent = "success";
            using (var reader = new StreamReader(context.Request.InputStream))
            {
                var stream = context.Request.InputStream;
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                String xml = Encoding.UTF8.GetString(buffer);
                oDFStory = new DFCls_StoryForm(xml);
            }            
            context.Response.ContentType = "text/plain";
            context.Response.Write(StorySent);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

    }
}