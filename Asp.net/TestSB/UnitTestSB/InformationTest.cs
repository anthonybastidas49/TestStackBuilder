using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SBAL.Model;
using SBBL.Catalogs;

namespace UnitTestSB
{
    [TestClass]
    public class InformationTest
    {
        private InformationBL bl = new InformationBL();

        /// <summary>
        /// Exception test in business layer
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void placa_ShouldThrowException()
        {
            String placa = null;
            bl.validatePlate(placa);
        }
        /// <summary>
        /// Bad plate test
        /// </summary>
        [TestMethod]
        public void placa_ShouldInvalid()
        {
            String placa = "A";
            Boolean result;
            result = bl.validatePlate(placa);
            Assert.AreEqual(false,result);
            placa = "ABC123A";
            result = bl.validatePlate(placa);
            Assert.AreEqual(false, result);
            placa = "ABC123";
            result = bl.validatePlate(placa);
            Assert.AreEqual(false, result);
            placa = "ABC12345";
            result = bl.validatePlate(placa);
            Assert.AreEqual(false, result);
            placa = "ABC123A";
            result = bl.validatePlate(placa);
            Assert.AreEqual(false, result);
            placa = "DBC1234";
            result = bl.validatePlate(placa);
            Assert.AreEqual(false, result);
            //VALID
            placa = "ABC1234";
            result = bl.validatePlate(placa);
            Assert.AreEqual(true, result);
        }
        /// <summary>
        /// Test does not circulate
        /// </summary>
        [TestMethod]
        public void placa_ShouldNoCirculate()
        {
            Boolean result;
            DateTime dateTime=Convert.ToDateTime("21/08/2020 08:00");
            Information information = new Information();
            information.plate = "ABC1230";
            information.lastDigit = 0;
            information.dateTime = dateTime;
            result=bl.canCirculate(information);
            Assert.AreEqual(false, result);
            dateTime = Convert.ToDateTime("21/08/2020 17:00");
            information = new Information();
            information.plate = "ABC1239";
            information.lastDigit = 0;
            information.dateTime = dateTime;
            result = bl.canCirculate(information);
            Assert.AreEqual(false, result);
            dateTime = Convert.ToDateTime("20/08/2020 17:00");
            information = new Information();
            information.plate = "ABC1237";
            information.lastDigit = 7;
            information.dateTime = dateTime;
            result = bl.canCirculate(information);
            Assert.AreEqual(false, result);
            dateTime = Convert.ToDateTime("19/08/2020 17:00");
            information = new Information();
            information.plate = "ABC1236";
            information.lastDigit = 6;
            information.dateTime = dateTime;
            result = bl.canCirculate(information);
            Assert.AreEqual(false, result);
        }
        /// <summary>
        /// Test circulate
        /// </summary>
        [TestMethod]
        public void placa_ShouldCirculate()
        {
            Boolean result;
            DateTime dateTime = Convert.ToDateTime("21/08/2020 10:00");
            Information information = new Information();
            information.plate = "ABC1230";
            information.lastDigit = 0;
            information.dateTime = dateTime;
            result = bl.canCirculate(information);
            Assert.AreEqual(true, result);
            dateTime = Convert.ToDateTime("19/08/2020 06:58");
            information = new Information();
            information.plate = "ABC1236";
            information.lastDigit = 6;
            information.dateTime = dateTime;
            result = bl.canCirculate(information);
            Assert.AreEqual(true, result);
            dateTime = Convert.ToDateTime("19/08/2020 07:20");
            information = new Information();
            information.plate = "ABC1231";
            information.lastDigit = 1;
            information.dateTime = dateTime;
            result = bl.canCirculate(information);
            Assert.AreEqual(true, result);
        }
    }
}
