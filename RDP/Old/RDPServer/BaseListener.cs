using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Media;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace RDPServer {
    abstract class BaseListener {
        protected internal Form InvokerForm = null;
        protected internal IPAddress GivenIPAddress = null;
        protected internal int StartingPort = 0;
        protected internal int EndingPort = 0;
        protected internal volatile bool Stop = false;
        protected internal TcpListener listener;
        protected internal Socket mainSocket;
        protected internal Stream s;
        protected internal int imageDelay;

        public BaseListener(Form pForm, string pIP, int pStartingPort, int pEndingPort) {
            IPAddress.TryParse(pIP,out GivenIPAddress);
            InvokerForm = pForm;            
            StartingPort = pStartingPort;
            EndingPort = pEndingPort;
        }

        public abstract void startListening();
    }
}
