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
    public class ErrorStatusCommand : Command
    {
        public enum Status
        {
            OK,
            WARNING, 
            ERROR, 
            UNKNOWN
        }

        public enum SysComponent
        {
            FAN,
            LAMP,
            TEMP,
            COVER,
            FILTER,
            OTHER
        }

        private List<Status> _status = new List<Status>(6); 

        public ErrorStatusCommand()
        {            
            for (int i = 0; i < 6; ++i)
                _status.Add(Status.UNKNOWN); 
        }

        internal override string getCommandString()
        {
            return "%1ERST ?"; 
        }

        internal override bool processAnswerString(string a)
        {
            if (!base.processAnswerString(a))
            {
                return false;
            }

            a = a.Replace("%1ERST=", "");
            for (int i = 0; i < a.Length; ++i )
            {                
                _status[i] = (Status)int.Parse(a[i].ToString()); 
            }

            return true;
        }

        public List<Status> StatusList
        {
            get { return _status; }
        }

        public Status FanStatus
        {
            get { return _status[(int)SysComponent.FAN]; }
        }

        public Status LampStatus
        {
            get { return _status[(int)SysComponent.LAMP]; }
        }

        public Status TempStatus
        {
            get { return _status[(int)SysComponent.TEMP]; }
        }

        public Status CoverStatus
        {
            get { return _status[(int)SysComponent.COVER]; }
        }

        public Status FilterStatus
        {
            get { return _status[(int)SysComponent.FILTER]; }
        }

        public Status OtherStatus
        {
            get { return _status[(int)SysComponent.OTHER]; }
        }

        public override string dumpToString()
        {
            string toRet = "";
             
            toRet += "Fan:    " + FanStatus.ToString();
            toRet += "\nLamp:   " + LampStatus.ToString();
            toRet += "\nTemp:   " + TempStatus.ToString();
            toRet += "\nCover:  " + CoverStatus.ToString();
            toRet += "\nFilter: " + FilterStatus.ToString();
            toRet += "\nOther:  " + OtherStatus.ToString();
            return toRet;
        }
    }
}
