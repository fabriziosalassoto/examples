using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime;
using System.Threading;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Media;
using System.Diagnostics;

namespace RDPServer {
    public class RDPEngine {
        RDPImageListener myImageListener = null;
        RDPControlListener myControlListener = null;
        RDPUpdaterListener myUpdaterListener = null;        

        public RDPEngine(Form InvokerForm, string IPAddress, int StartingPort, int EndingPort){                        
            myImageListener = new RDPImageListener(InvokerForm,IPAddress,StartingPort,EndingPort);
            StartEngine(myImageListener);

            myControlListener = new RDPControlListener(InvokerForm, IPAddress, StartingPort, EndingPort);
            StartEngine(myControlListener);

            myUpdaterListener = new RDPUpdaterListener(InvokerForm, IPAddress, StartingPort, EndingPort);
            StartEngine(myUpdaterListener);            
        }         

        private void StartEngine(BaseListener pListener){            
            Thread pListenerThread = new Thread(pListener.startListening);
            pListenerThread.Start();
        }
    }
}
