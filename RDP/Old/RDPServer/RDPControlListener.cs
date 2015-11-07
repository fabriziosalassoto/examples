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
    class RDPControlListener : BaseListener {        
        private const int lostInTop = 30;
        private const int lostinLeft = 10;                
        private delegate void SetTextCallback(Control control);
        private Control myControlFound;

        public RDPControlListener(Form pForm, string pIP, int pStartingPort, int pEndingPort)
            : base(pForm, pIP, pStartingPort, pEndingPort) {
        }

        public override void startListening() {
            while(!Stop) {
                try {                    
                    imageDelay = 1000;
                    listener = new TcpListener(this.GivenIPAddress, this.StartingPort + 1);
                    listener.Start();                    
                    mainSocket = listener.AcceptSocket();

                    Point ControlCoordinates;
                    byte[] bytes = new byte[256];
                    myControlFound = null;

                    s = new NetworkStream(mainSocket);
                    int i;

                    while((i = s.Read(bytes, 0, bytes.Length))>0){
                        int milliseconds = 50;
                        Thread.Sleep(milliseconds);
                        string StringReceived = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        string ControlName = "";
                        string ControlValue = "";
                        
                            ControlCoordinates = DecodePoint(StringReceived);
                            myControlFound = FindControlByAxis(ControlCoordinates);


                            if(myControlFound != null) {                                
                                myControlFound.Invoke(new Action(() => { ControlValue = myControlFound.Text; ControlName = myControlFound.Name; }));                                
                            } else {
                                InvokerForm.Invoke(new Action(() => { ControlValue = InvokerForm.Text; ControlName = InvokerForm.Name; }));                                
                            }
                            String ControlFound = "name=" + ControlName + ";value=" + ControlValue;
                            bytes = System.Text.Encoding.ASCII.GetBytes(ControlFound);
                            s.Write(bytes, 0, bytes.Length);                                                         
                        }
                    } catch(IOException Exception) {
                        if(mainSocket.IsBound)
                            mainSocket.Close();
                        if(listener != null)
                            listener.Stop();
                        //throw Exception;
                    }
            }
        }        

        private Point DecodePoint(string pPointReceived) {
            Point myPoint;
            string[] coordinates = Regex.Split(pPointReceived, ";");
            string[] X = Regex.Split(coordinates[0], "=");
            string[] Y = Regex.Split(coordinates[1], "=");
            myPoint = new Point(int.Parse(X[1])-lostinLeft, int.Parse(Y[1])-lostInTop);
            return myPoint;
        }

        private Control FindControlByAxis(Point GivenPoint) {
            Control FoundControl = null;            
            foreach(Control CurrentControl in this.InvokerForm.Controls) {
                if((GivenPoint.X >= CurrentControl.Left && GivenPoint.X<=(CurrentControl.Left + CurrentControl.Width)) &&
                   (GivenPoint.Y >= CurrentControl.Top && GivenPoint.Y <= (CurrentControl.Top + CurrentControl.Height))) {
                    FoundControl = CurrentControl;
                    break;
                }
            }
            return FoundControl; 
        }        
    }
}
