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
    public class ManufacturerNameCommand : Command
    {
        private string _name = "";

        public ManufacturerNameCommand()
        {            
           
        }

        internal override string getCommandString()
        {
            return "%1INF1 ?"; 
        }

        internal override bool processAnswerString(string a)
        {
            if (!base.processAnswerString(a))
            {
                return false;
            }

            _name = a.Replace("%1INF1=", "");

            return true;
        }


        public override string dumpToString()
        {
            string toRet = "Manufacturer: " + _name;             
            return toRet;
        }

        public string Manufacturer
        {
            get { return _name; }
        }
    }

}
