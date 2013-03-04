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
    public class Command
    {
        public delegate void CommandResultHandler(Command sender, Response response);

        protected Response _cmdResponse;

        public enum Response
        {
            SUCCESS,
            UNDEFINED_CMD,
            OUT_OF_PARAMETER,
            UNVAILABLE_TIME,
            PROJECTOR_FAILURE,
            AUTH_FAILURE,
            COMMUNICATION_ERROR
        }

        internal virtual string getCommandString(){
            //NOOP
            return ""; 
        }

        internal virtual bool processAnswerString(string a)
        {

            if (a.IndexOf("=ERR1") >= 0)
                _cmdResponse = Response.UNDEFINED_CMD;
            else if (a.IndexOf("=ERR2") >= 0)
                _cmdResponse = Response.UNDEFINED_CMD;
            else if (a.IndexOf("=ERR3") >= 0)
                _cmdResponse = Response.UNVAILABLE_TIME;
            else if (a.IndexOf("=ERR4") >= 0)
                _cmdResponse = Response.PROJECTOR_FAILURE;
            else if (a.IndexOf(" ERRA") >= 0)
                _cmdResponse = Response.AUTH_FAILURE;
            else //OK or query answer...
                _cmdResponse = Response.SUCCESS; 

            return _cmdResponse == Response.SUCCESS; 
        }

        public Response CmdResponse
        {
            get { return _cmdResponse; }
        }

        public virtual string dumpToString()
        {
            return "";
        }
    }
}
