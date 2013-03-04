using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;


using rv;


namespace ProjectorControl
{
    public partial class Form1 : Form
    {
        public PJLinkConnection c = null;

        public Form1()
        {
            InitializeComponent();

            
            Status.Text = "Program Started";

        }



        private void On_Click(object sender, EventArgs e)
        {
            //turn on, update status
            Status.Text = "Turning Projector On";
            c.turnOn();
        }

        private void Off_Click(object sender, EventArgs e)
        {
            //turn off, update status
            Status.Text = "Turning Projector Off";
            c.turnOff();
        }




        private void ipAddress_TextChanged(object sender, EventArgs e)
        {
            Status.Text = "New Address Set";
        }

        private void connect_Click(object sender, EventArgs e)
        {

            System.Net.IPAddress address = null;

            if (System.Net.IPAddress.TryParse(ipAddress.Text, out address))
            {
                Status.Text = "Connecting to " + address.ToString();
                c = new PJLinkConnection(ipAddress.Text, "rv");
                c.powerQuery();
            }
            else
            {
                Status.Text = "Invalid IP Address Entered";
            }


            
        }



        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

    }
}
