using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RDPServer;

namespace RDPForm {    

    public partial class TestForm : Form {
        RDPEngine myRemoteEngine = null;

        public TestForm() {
            InitializeComponent();            
        }

        private void Form1_Load(object sender, EventArgs e) {
            txtDate.Text = System.DateTime.Now.ToString();
            LblDate.Text = "Value Sent: "+System.DateTime.Now.ToString();            
            myRemoteEngine = new RDPEngine(this,"127.0.0.1",1400,1450);                                                
        }
    }
}
