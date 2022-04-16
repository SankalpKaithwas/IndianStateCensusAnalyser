using System;
using System.Collections.Generic;
using System.Text;

namespace Indian_State_Census
{
    public class CSVStateCensusData
    {
        string state;
        int area;
        int population;
        int density;
        int SrNo;
        string StateName;
        int tin;
        string StateCode;

        public CSVStateCensusData(string state, string population, string area, string density)
        {
            this.state = state;
            this.population = Convert.ToInt32(population);
            this.area = Convert.ToInt32(area);
            this.density = Convert.ToInt32(density);
        }
        public CSVStateCensusData(CSVState censusStateCode)
        {
            StateName = censusStateCode.stateName;
            StateCode = censusStateCode.stateCode;
            tin = censusStateCode.tin;
            SrNo = censusStateCode.serialNumber;
        }
    }
}
