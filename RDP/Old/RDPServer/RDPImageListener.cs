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
    class RDPImageListener : BaseListener {                                        
        public RDPImageListener(Form pForm, string pIP, int pStartingPort, int pEndingPort)
            : base(pForm, pIP, pStartingPort, pEndingPort) {
        }

        public override void startListening() {
            while(!Stop) {
                try {                    
                    imageDelay = 1000;
                    listener = new TcpListener(this.GivenIPAddress, this.StartingPort);
                    listener.Start();
                    mainSocket = listener.AcceptSocket();
                    s = new NetworkStream(mainSocket);                    
                    while(true) {
                        Bitmap screeny = new Bitmap(InvokerForm.Width, InvokerForm.Height, PixelFormat.Format32bppArgb);
                        Graphics theShot = Graphics.FromImage(screeny);
                        theShot.ScaleTransform(.25F, .25F);
                        theShot.CopyFromScreen(InvokerForm.Left, InvokerForm.Top, 0, 0, InvokerForm.Size, CopyPixelOperation.SourceCopy);
                        BinaryFormatter bFormat = new BinaryFormatter();
                        bFormat.Serialize(s, screeny);                        

                        Thread.Sleep(imageDelay);
                        theShot.Dispose();
                        screeny.Dispose();
                    }
                }

                catch(Exception) {
                    if(mainSocket.IsBound)
                        mainSocket.Close();
                    if(listener != null)
                        listener.Stop();
                }
            }
        }   
    }
}