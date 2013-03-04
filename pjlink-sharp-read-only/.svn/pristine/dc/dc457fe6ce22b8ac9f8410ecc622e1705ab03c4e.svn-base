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
    public class PowerCommand : Command
    {
        private PowerStatus _status = PowerStatus.UNKNOWN;
        private Power _cmdDetail; 

        public enum Power
        {
            QUERY, 
            ON,
            OFF
        }

        public enum PowerStatus
        {            
            OFF,
            ON,
            COOLING,
            WARMUP,
            UNKNOWN 
        }

        public PowerCommand(Power cmd)
        {
            _cmdDetail = cmd; 
        }

        internal override string getCommandString()
        {
            string cmdString = "%1POWR "; 

            switch(_cmdDetail){

                case Power.QUERY:
                    cmdString += "?"; 
                    break;
                case Power.OFF:
                    cmdString += "0"; 
                    break;
                case Power.ON:
                    cmdString += "1"; 
                    break; 
            }

            return cmdString; 
        }

        internal override bool processAnswerString(string a)
        {
            if (!base.processAnswerString(a))
            {
                _status = PowerStatus.UNKNOWN; 
                return false;
            }

            if(_cmdDetail == Power.QUERY){
                a = a.Replace("%1POWR=", "");
                int retVal = int.Parse(a);
                if (retVal >= (int)PowerStatus.OFF && retVal <= (int)PowerStatus.WARMUP)
                    _status = (PowerStatus)(retVal);
                else
                    _status = PowerStatus.UNKNOWN; 
            }

            return true; 
        }


        public PowerStatus Status
        {
            get { return _status; }
        } 


    }
}
