using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net; 
using System.Net.Sockets;
using System.IO;
using System.Security.Cryptography; 
using rv; 

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            PJLinkConnection c = new PJLinkConnection("192.168.1.14", "rv");

            //shortcuts
            //c.turnOn();
            //System.Console.WriteLine(c.getProjectorInfo()); 

            //detailed command calls

            //PowerCommand pc1 = new PowerCommand(PowerCommand.Powr.QUERY);
            //if (c.sendCommand(pc1) == Command.Response.SUCCESS)
            //    Console.WriteLine("Projector is " + pc1.Status.ToString());
            //else
            //    Console.WriteLine("Communication Error");

            //PowerCommand pc2 = new PowerCommand(PowerCommand.Powr.ON);
            //if (c.sendCommand(pc2) == Command.Response.SUCCESS)
            //    Console.WriteLine("Switching on successful");
            //else
            //    Console.WriteLine("Communication Error");

            //PowerCommand pc3 = new PowerCommand(PowerCommand.Powr.QUERY);
            //if (c.sendCommand(pc3) == Command.Response.SUCCESS)
            //    Console.WriteLine("Projector is " + pc3.Status.ToString());
            //else
            //    Console.WriteLine("Communication Error");

            //ErrorStatusCommand esc = new ErrorStatusCommand();
            //if (c.sendCommand(esc) == Command.Response.SUCCESS)            
            //    Console.WriteLine(esc.dumpToString());            
            //else
            //    Console.WriteLine("Communication Error");

            //LampStatusCommand lsc = new LampStatusCommand();
            //if (c.sendCommand(lsc) == Command.Response.SUCCESS)            
            //    Console.WriteLine(lsc.dumpToString());            
            //else
            //    Console.WriteLine("Communication Error");

            //ProjectorNameCommand pnc = new ProjectorNameCommand();
            //if (c.sendCommand(pnc) == Command.Response.SUCCESS)           
            //    Console.WriteLine(pnc.dumpToString());            
            //else
            //    Console.WriteLine("Communication Error");

            //ManufacturerNameCommand mnc = new ManufacturerNameCommand();
            //if (c.sendCommand(mnc) == Command.Response.SUCCESS)            
            //    Console.WriteLine(mnc.dumpToString());            
            //else
            //    Console.WriteLine("Communication Error");

            //ProductNameCommand prnc = new ProductNameCommand();
            //if (c.sendCommand(prnc) == Command.Response.SUCCESS)            
            //    Console.WriteLine(prnc.dumpToString());            
            //else
            //    Console.WriteLine("Communication Error");

            //OtherInfoCommand oic = new OtherInfoCommand();
            //if (c.sendCommand(oic) == Command.Response.SUCCESS)            
            //    Console.WriteLine(oic.dumpToString());            
            //else
            //    Console.WriteLine("Communication Error");

            //InputCommand ic1 = new InputCommand();
            //if (c.sendCommand(ic1) == Command.Response.SUCCESS)            
            //    Console.WriteLine(ic1.dumpToString());            
            //else
            //    Console.WriteLine("Communication Error");

            //InputCommand ic2 = new InputCommand(InputCommand.InputType.RGB, 2); 
            //if (c.sendCommand(ic2) == Command.Response.SUCCESS)
            //    Console.WriteLine(ic2.dumpToString());
            //else
            //    Console.WriteLine("Communication Error");

            ProjectorInfo pi = ProjectorInfo.create(c);
            string s = pi.toXmlString();
            Console.WriteLine(s); 

            Console.ReadKey(); 
        }
    }
}
