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
            Status.Text = "Projector is now:" + c.powerQuery().ToString();
            
        }

        private void Off_Click(object sender, EventArgs e)
        {
            //turn off, update status
            Status.Text = "Turning Projector Off";
            c.turnOff();
            Status.Text = "Projector is now:" + c.powerQuery().ToString();
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
                c = new PJLinkConnection(ipAddress.Text, "JBMIAProjectorLink");
                
                LampStatusCommand l = new LampStatusCommand();
                int hours = l.getHoursOfLamp(1);
                string status = l.getStatusOfLamp(1).ToString();
                string power = c.powerQuery().ToString();
                ProjectorInfo pi = new ProjectorInfo();
                Status.Text = "Connected. \n Projector is now: " + power + "\n" + "\nstatus: " + status + "\nlamphours: " + hours;
                Status.Text += "\nFan:" + pi.FanStatus;
                Status.Text += " Lamp:" + pi.LampStatus;
                Status.Text += " Input:" + pi.Input;
                Status.Text += "\nCover:" + pi.CoverStatus;
                Status.Text += " Filter:" + pi.FilterStatus;
                Status.Text += " NumLamps:" + pi.NumOfLamps;
                Status.Text += "\nOthers:" + pi.PowerStatus;


                
                

            }
            else
            {
                Status.Text = "Invalid IP Address Entered";
            }


            
        }
        


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //c.sendCommand(
        }


        private void change_Input(rv.InputCommand.InputType x, int i)
        {
            InputCommand ic2 = new InputCommand(x, i);

            if (c.sendCommand(ic2) == Command.Response.SUCCESS)
                Console.WriteLine(ic2.dumpToString());
            else
                Console.WriteLine("Communication Error");

        }

        private void button_video_Click(object sender, EventArgs e)
        {
            change_Input(InputCommand.InputType.VIDEO,1);
        }

        private void button_vga_Click(object sender, EventArgs e)
        {
            change_Input(InputCommand.InputType.RGB,1);
        }

        private void button_digital_Click(object sender, EventArgs e)
        {
            change_Input(InputCommand.InputType.DIGITAL, 1);
        }

        private void button_network_Click(object sender, EventArgs e)
        {
            change_Input(InputCommand.InputType.NETWORK, 1);
        }

    }
}
