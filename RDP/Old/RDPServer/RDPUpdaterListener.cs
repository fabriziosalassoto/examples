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
    class RDPUpdaterListener : BaseListener{                
        private const int lostInTop = 30;
        private const int lostinLeft = 10;        
        private delegate void SetTextCallback(string text);
        private Control myControlFound;

        public RDPUpdaterListener(Form pForm, string pIP, int pStartingPort, int pEndingPort)
            : base(pForm, pIP, pStartingPort, pEndingPort) {
        }

        public override void startListening() {
            while(!Stop) {
                try {                    
                    imageDelay = 1000;
                    listener = new TcpListener(this.GivenIPAddress, this.StartingPort + 2);
                    listener.Start();                    
                    mainSocket = listener.AcceptSocket();
                    
                    byte[] bytes = new byte[256];
                    myControlFound = null;

                    s = new NetworkStream(mainSocket);
                    int i;

                    while(true) {
                        /*int milliseconds = 50;
                        Thread.Sleep(milliseconds);*/
                        i = s.Read(bytes, 0, bytes.Length);
                        string StringReceived = System.Text.Encoding.ASCII.GetString(bytes, 0, i);                        
                        string[] ControlReceived = DecodeControl(StringReceived);
                        myControlFound = FindControlByName(ControlReceived[0]);
                        SetText(ControlReceived[1]);                                                    
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

        private void SetText(string NewValue) {            
            try {
                if(myControlFound.InvokeRequired) {
                    SetTextCallback d = new SetTextCallback(SetText);
                    myControlFound.Invoke(d, new object[] { NewValue });
                }
                else {
                    myControlFound.Text = NewValue;
                }
            }
            catch(Exception) { }
        }        

        private string[] DecodeControl(string pControlReceived) {
            string[] myControl = new String[2];
            string[] control = Regex.Split(pControlReceived, ";");
            string[] name = Regex.Split(control[0], "=");
            string[] value = Regex.Split(control[1], "=");
            myControl[0] = name[1];
            myControl[1] = value[1];
            return myControl;
        }        

        private Control FindControlByName(string pControlName) {
            Control FoundControl = null;            
            foreach(Control CurrentControl in this.InvokerForm.Controls) {
                if(CurrentControl.Name == pControlName){
                    FoundControl = CurrentControl;                    
                }
            }         
            return FoundControl;
        }              
    }
}