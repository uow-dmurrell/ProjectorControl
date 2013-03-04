// The C# PJLink library.
// Copyright (C) 2010 RV realtime visions GmbH (www.realtimevisions.com)
// 
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
// 
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rv
{
    public class ProjectorNameCommand : Command
    {
        private string _name = "";

        public ProjectorNameCommand()
        {            
           
        }

        internal override string getCommandString()
        {
            return "%1NAME ?"; 
        }

        internal override bool processAnswerString(string a)
        {
            if (!base.processAnswerString(a))
            {
                return false;
            }

            a = a.Replace("%1NAME=", "");

            byte[] dec = Encoding.ASCII.GetBytes(a);
            _name = Encoding.UTF8.GetString(dec); 

            return true;
        }


        public override string dumpToString()
        {
            return "Name: " + _name;             
        }

        public string Name
        {
            get { return _name; }
        }
    }

}
