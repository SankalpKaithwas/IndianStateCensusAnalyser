using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Indian_State_Census
{
    public class StateCensusAnalyser
    {
        public Dictionary<string, CSVStateCensusData> dataDictionary;

        public Dictionary<string, CSVStateCensusData> WriteData(string filePath, string dataHeader)
        {
            dataDictionary = new Dictionary<string, CSVStateCensusData>();
            //File exists or not
            if (!File.Exists(filePath))
                throw new StateCensusCustomException(StateCensusCustomException.ExceptionType.FileNotExists, "File does not exists");


            //File extension is correct or not
            if (Path.GetExtension(filePath) != ".csv")
                throw new StateCensusCustomException(StateCensusCustomException.ExceptionType.ImproperExtension, "File extension is wrong");


            //Data header is correct or not
            string[] csvData = File.ReadAllLines(filePath);
            if (csvData[0] != dataHeader)
                throw new StateCensusCustomException(StateCensusCustomException.ExceptionType.ImproperHeader, "Improper Header");


            // Delimiter
            foreach (var item in csvData.Skip(1))
            {
                if (!item.Contains(','))
                    throw new StateCensusCustomException(StateCensusCustomException.ExceptionType.DelimiterNotFound, "Delimiter not found");
                else
                {
                    string[] column = item.Split(',');
                    dataDictionary.Add(column[0], new CSVStateCensusData(column[0], column[1], column[2], column[3]));
                }
            }
            return dataDictionary;
        }
    }
}
