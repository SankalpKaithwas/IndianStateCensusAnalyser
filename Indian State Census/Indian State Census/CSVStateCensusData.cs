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

        public CSVStateCensusData(string state, string population, string area, string density)
        {
            this.state = state;
            this.population = Convert.ToInt32(population);
            this.area = Convert.ToInt32(area);
            this.density = Convert.ToInt32(density);
        }

    }
}
