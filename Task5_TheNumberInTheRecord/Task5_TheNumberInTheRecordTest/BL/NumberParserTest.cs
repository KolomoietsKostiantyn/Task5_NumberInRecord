using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task5_TheNumberInTheRecord.BL;

namespace Task5_TheNumberInTheRecordTest.BL
{
    [TestClass]
    public class NumberParserTest
    {
        private NumberParser _numberParser;

        [TestInitialize]
        public void Initialize()
        {
            long maxValue = 999999999999;
            _numberParser = new NumberParser(maxValue);
        }


        [TestMethod]
        [DataRow(1, 1)]
        [DataRow(11, 1)]
        [DataRow(111, 1)]
        [DataRow(1111, 2)]
        [DataRow(11111, 2)]
        [DataRow(0, 1)]
        [DataRow(-1, 1)]
        [DataRow(-1111, 2)]
        [DataRow(-1111111, 3)]
        public void NumberDigitsOFThousands_ValidData_OK(long inner, int expected)
        {
            int result = _numberParser.NumberDigitsOFThousands(inner);

            Assert.AreEqual(result, expected);

        }


        [TestMethod]
        public void HundredsConverter_MinusNumber_Null()
        {
            long inner = -5;
            string result = _numberParser.HundredsConverter(inner);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void HundredsConverter_TooBigNumber_Null()
        {
            long inner = 1000;
            string result = _numberParser.HundredsConverter(inner);

            Assert.IsNull(result);
        }

        [TestMethod]
        [DataRow("zero", 0)]
        [DataRow("three hundred", 300)]
        [DataRow("five hundred", 500)]
        [DataRow("nine hundred ninety-nine", 999)]
        public void HundredsConverter_ValidData_OK(string request, int num)
        {
            string result = _numberParser.HundredsConverter(num);

            Assert.AreEqual(request, result);
        }

        [TestMethod]
        public void Parse_TooBigNumber_Null()
        {
            long num = 9999999999999;
            string result = _numberParser.Parse(num);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Parse_TooLowNumber_Null()
        {
            long num = -9999999999999;
            string result = _numberParser.Parse(num);

            Assert.IsNull(result);
        }

        [TestMethod]
        [DataRow("zero", 0)]
        [DataRow("minus three hundred", -300)]
        [DataRow("three hundred", 300)]
        [DataRow("nine hundred ninety-nine thousand six hundred fifty-three", 999653)]
        [DataRow("minus nine hundred ninety-nine thousand six hundred fifty-three", -999653)]
        [DataRow("minus nine hundred ninety-nine billion nine hundred ninety-nine million nine hundred ninety-nine thousand nine hundred ninety-nine", -999999999999)]
        [DataRow("nine hundred ninety-nine billion nine hundred ninety-nine million nine hundred ninety-nine thousand nine hundred ninety-nine", 999999999999)]
        public void Parse_ValidData_OK(string request, long num)
        {

            string result = _numberParser.Parse(num);

            Assert.AreEqual(request, result);

        }


    }
}
