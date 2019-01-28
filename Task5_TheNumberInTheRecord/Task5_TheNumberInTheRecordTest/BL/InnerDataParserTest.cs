using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task5_TheNumberInTheRecord.BL;

namespace Task5_TheNumberInTheRecordTest.BL
{
    [TestClass]
    public class InnerDataParserTest
    {
        InnerDataParser _innerDataParser;
        [TestInitialize]
        public void Initialize()
        {
            long maxValue = 999999999999;
            _innerDataParser = new InnerDataParser(maxValue);
        }


        [TestMethod]
        [DataRow("99", 99)]
        [DataRow("-99", -99)]
        [DataRow("0", 0)]
        public void ConvertStringToValidNumber_ValidData_True(string number, long result)
        {
            long num;
            bool validResult = _innerDataParser.ConvertStringToValidNumber(number, out num);

            Assert.AreEqual(num, result);
            Assert.IsTrue(validResult);
        }

        [TestMethod]
        [DataRow("99999999999999")]
        [DataRow("-99999999999999")]
        [DataRow("aaa")]
        [DataRow(" ")]
        [DataRow("")]
        public void ConvertStringToValidNumber_InvalidData_False(string number)
        {
            long num;
            bool validResult = _innerDataParser.ConvertStringToValidNumber(number, out num);

            Assert.IsFalse(validResult);
        }

        [TestMethod]
        public void ValidateInputArray_NullReferense_False()
        {
            string[] arr = null;

            bool validResult = _innerDataParser.ValidateInputArray(arr);

            Assert.IsFalse(validResult);
        }

        [TestMethod]
        public void ValidateInputArray_OneElementIsNull_False()
        {
            string[] arr = {"2", "22", null, "3245" };

            bool validResult = _innerDataParser.ValidateInputArray(arr);

            Assert.IsFalse(validResult);
        }

        [TestMethod]
        public void ValidateInputArray_ValidData_True()
        {
            string[] arr = { "2", "22", "345", "3245" };

            bool validResult = _innerDataParser.ValidateInputArray(arr);

            Assert.IsTrue(validResult);
        }
    }
}
