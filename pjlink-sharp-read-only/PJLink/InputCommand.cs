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
    public class InputCommand : Command
    {
        private InputType _type = InputType.UNKNOWN;
        private int _port = -1;        

        public enum InputType
        {
            UNKNOWN,
            RGB,
            VIDEO,
            DIGITAL,
            STORAGE,
            NETWORK
        }

        ///ports start with 1 !!!
        public InputCommand(InputType type, int port)
        {
            _type = type;
            _port = port; 
        }

        ///Query
        public InputCommand()
        {
            
        }

        internal override string getCommandString()
        {
            string cmdString = "%1INPT "; 

            if(_port > 0){
                cmdString += ((int)_type).ToString() + _port.ToString(); 
            }
            else{
                cmdString += "?";  
            }                        

            return cmdString; 
        }

        internal override bool processAnswerString(string a)
        {
            if (!base.processAnswerString(a))
                return false;            

            if(_port < 0)
            {
                a = a.Replace("%1INPT=", "");
                int retVal = int.Parse(a);

                _type = (InputType)(retVal / 10);
                _port = retVal % 10; 
            }

            return true; 
        }


        public InputType Input
        {
            get { return _type; }
        }

        public int Port
        {
            get { return _port; }
        }

        public override string dumpToString()
        {
            string toRet = "Input: " + _type.ToString()+_port.ToString();
            return toRet;
        }

    }
}
