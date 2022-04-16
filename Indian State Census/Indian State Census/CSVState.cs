using System;
using System.Collections.Generic;
using System.Text;

namespace Indian_State_Census
{
    public class CSVState
    {
        public string stateName;
        public string stateCode;
        public int tin;
        public int serialNumber;

        public CSVState(string serialNumber, string stateName, string tin, string stateCode)
        {
            this.stateCode = stateCode;
            this.stateName = stateName;
            this.tin = Convert.ToInt32(tin);
            this.serialNumber = Convert.ToInt32(serialNumber);
        }
    }
}
