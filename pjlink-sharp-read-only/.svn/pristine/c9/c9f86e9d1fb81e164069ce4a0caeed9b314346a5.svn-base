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
    public class LampStatusCommand : Command
    {
        public enum Status
        {            
            OFF,
            ON,
            UNKNOWN
        }

        private List<Status> _status = new List<Status>();
        private List<int> _hours = new List<int>();

        public LampStatusCommand()
        {            

        }

        internal override string getCommandString()
        {
            return "%1LAMP ?"; 
        }

        internal override bool processAnswerString(string a)
        {
            if (!base.processAnswerString(a))
            {
                return false;
            }

            a = a.Replace("%1LAMP=", "");

            string [] arr = a.Split(' ');
            for (int i = 0; i < arr.Length; i+=2)
            {
                _hours.Add(int.Parse(arr[i]));
                _status.Add((Status)(int.Parse(arr[i + 1])));
            }

            return true;
        }

        public List<Status> StatusList
        {
            get { return _status; }
        }

        public List<int> HoursList
        {
            get { return _hours; }
        }
        
        public int NumOfLamps{
            get { return _hours.Count; }
        }

        public Status getStatusOfLamp(int l)
        {
            if (l < NumOfLamps)
                return _status[l];
            return Status.UNKNOWN; 
        }

        public int getHoursOfLamp(int l)
        {
            if (l < NumOfLamps)
                return _hours[l];
            return -1;
        }

        public override string dumpToString()
        {
            string toRet = "";

            toRet += "Num of Lamps: " + NumOfLamps.ToString();
            for (int i = 0; i < NumOfLamps; ++i) {
                toRet += "\n  Lamp " + i.ToString() + ": " + _status[i].ToString() + "(" + _hours[i].ToString() + "h)"; 
            }
            
            return toRet;
        }
    }
}
