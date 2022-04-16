using Indian_State_Census;
using NUnit.Framework;

namespace StateCensusTests
{
    public class Tests
    {
        string filePath = @"F:\FRP .net Git\IndianStateCensusAnalyser\Indian State Census\Indian State Census\CSV Files\";
        string validCSVStateCensusFile = "IndiaStateCensusData.csv";
        string invalidIndianStateCensusFileExtension = "IndiaStateCensusData.txt";
        string invalidDelimiter = "DelimiterIndiaStateCensusData.csv";
        string validIndianStateCodeFile = "IndiaStateCode.csv";
        string invalidStateCodeFileExtension = "IndiaStateCodeFile.txt";
        StateCensusAnalyser stateCensusAnalyser;

        [SetUp]
        public void Setup()
        {
            stateCensusAnalyser = new StateCensusAnalyser();
        }
        /// <summary>
        /// TC 1.1 Valid number of records in file
        /// </summary>
        [Test]
        public void GivenCSVFile_CheckNUmberOfRecords()
        {
            stateCensusAnalyser.dataDictionary = stateCensusAnalyser.LoadData(
                filePath + validCSVStateCensusFile, "State,Population,AreaInSqKm,DensityPerSqKm");
            Assert.AreEqual(29, stateCensusAnalyser.dataDictionary.Count);
        }

        /// <summary>
        /// TC 1.2 Incorrect file Name
        /// </summary>
        [Test]
        public void IncorrectFileName_ThrowException()
        {
            StateCensusCustomException exception = Assert.Throws<StateCensusCustomException>(() => stateCensusAnalyser.LoadData(
                                filePath + "File", "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(StateCensusCustomException.ExceptionType.FileNotExists, exception.type);
        }

        /// <summary>
        /// TC 1.3 Incorrect File Extension
        /// </summary>
        [Test]
        public void IncorrectFileExtension_ThrowException()
        {
            StateCensusCustomException exception = Assert.Throws<StateCensusCustomException>(() => stateCensusAnalyser.LoadData(
                                filePath + invalidIndianStateCensusFileExtension, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(StateCensusCustomException.ExceptionType.ImproperExtension, exception.type);
        }

        /// <summary>
        /// TC 1.4 Incorrect Delimiter
        /// </summary>
        [Test]
        public void GivenIncorrectDelimiter_ThrowException()
        {
            StateCensusCustomException exception = Assert.Throws<StateCensusCustomException>(() => stateCensusAnalyser.LoadData(
                filePath + invalidDelimiter, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(StateCensusCustomException.ExceptionType.DelimiterNotFound, exception.type);
        }

        /// <summary>
        /// TC 1.5 Incorrect header
        /// </summary>
        [Test]
        public void GivenIncorrectHeader_ThrowException()
        {
            StateCensusCustomException exception = Assert.Throws<StateCensusCustomException>(() => stateCensusAnalyser.LoadData(
                filePath + invalidDelimiter, "State,Population,AreaInSqKm,Density"));
            Assert.AreEqual(StateCensusCustomException.ExceptionType.ImproperHeader, exception.type);
        }
        /// <summary>
        /// TC 2.1 Valid number of records in file
        /// </summary>
        [Test]
        public void GivenStateCodeCSVFile_CheckNumberOfRecords()
        {
            stateCensusAnalyser.dataDictionary = stateCensusAnalyser.LoadData(
                filePath + validIndianStateCodeFile, "SrNo,State Name,TIN,StateCode");
            Assert.AreEqual(37, stateCensusAnalyser.dataDictionary.Count);
        }

        /// <summary>
        /// TC 2.2 Incorrect file Name or not exists
        /// </summary>
        [Test]
        public void IncorrectStateCodeCSVFileName_ThrowException()
        {
            StateCensusCustomException exception = Assert.Throws<StateCensusCustomException>(() => stateCensusAnalyser.LoadData(
                                filePath + "File", "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(StateCensusCustomException.ExceptionType.FileNotExists, exception.type);
        }
        /// <summary>
        /// TC 2.3 Improper Header
        /// </summary>
        [Test]
        public void GivenStateCodeCSVFile_ImproperHeader()
        {
            StateCensusCustomException exception = Assert.Throws<StateCensusCustomException>(() => stateCensusAnalyser.LoadData(
               filePath + validIndianStateCodeFile, "SrNo,State Name,TIN,StateCodea"));
            Assert.AreEqual(StateCensusCustomException.ExceptionType.ImproperHeader, exception.type);
        }
        /// <summary>
        /// TC 2.4 Improper file Extension
        /// </summary>
        [Test]
        public void IncorrectFileExtension_StateScode_ThrowException()
        {
            StateCensusCustomException exception = Assert.Throws<StateCensusCustomException>(() => stateCensusAnalyser.LoadData(
                                filePath + invalidStateCodeFileExtension, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(StateCensusCustomException.ExceptionType.ImproperExtension, exception.type);
        }
    }
}