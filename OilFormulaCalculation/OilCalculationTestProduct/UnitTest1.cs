using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OilCompanyFormulation;

namespace OilCalculationTestProduct
{
    [TestClass]
    public class UnitTest1
    {

        #region Tmax Calculation

        [TestMethod]
        public void TmaxCalculationWithAllValidInputReturnOk()
        {
            var input = MockData.ValidInput();
            var tmax = OilFormula.CalculateTmax(input.NumerbOfDrills, input.Period, input.InitialOutPut, input.DepreciationRate);
            
            Assert.AreEqual(tmax, 0);
        }

        [TestMethod]
        public void TmaxCalculationZeroDrilltmaxReturnOk()
        {
            var input = MockData.InputForZeroDrill();
            var tmax = OilFormula.CalculateTmax(input.NumerbOfDrills, input.Period, input.InitialOutPut, input.DepreciationRate);
            Assert.AreEqual(tmax, 0);
        }

        [TestMethod]
        public void TmaxCalculationWithNegativePeriodReturnOk()
        {
            var input = MockData.InputForZeroPeriod();
            var tmax = OilFormula.CalculateTmax(input.NumerbOfDrills, input.Period, input.InitialOutPut, input.DepreciationRate);
            Assert.AreEqual(tmax, 0);
        }

        [TestMethod]
        public void TmaxCalculationWithZeroDrillAndPeriodReturnOk()
        {
            var input = MockData.InputForZeroDrill();
            input.Period = 0;
            var tmax = OilFormula.CalculateTmax(input.NumerbOfDrills, input.Period, input.InitialOutPut, input.DepreciationRate);
            Assert.AreEqual(tmax, 0);
        }


        [TestMethod]
        public void TmaxCalculationWithInitialOutPutReturnOk()
        {
            var input = MockData.InputForZeroInitialOutPut();
            var tmax = OilFormula.CalculateTmax(input.NumerbOfDrills, input.Period, input.InitialOutPut, input.DepreciationRate);
            Assert.AreEqual(tmax, 0);
        }

        [TestMethod]
        public void TmaxCalculationWithZeroDepreciationReturnOk()
        {
            var input = MockData.InputForZeroDepreciationRate();
            var tmax = OilFormula.CalculateTmax(input.NumerbOfDrills, input.Period, input.InitialOutPut, input.DepreciationRate);
            Assert.AreEqual(tmax, 0);
        }

        #endregion

        #region Out(Tmax) Calculation Test case

        [TestMethod]
        public void OutTmaxCalculationWithAllValidInputReturnOk()
        {
            var input = MockData.ValidInput();

            var tmax = OilFormula.CalculateTmax(input.NumerbOfDrills, input.Period, input.InitialOutPut, input.DepreciationRate);

            var outTmax = OilFormula.CalculateOutTmax(input.NumerbOfDrills, tmax, input.Period, input.InitialOutPut,
                input.DepreciationRate);
            Assert.AreEqual(outTmax, 9595.0);
        }

        [TestMethod]
        public void OutTmaxCalculationZeroDrilltmaxReturnOk()
        {
            var input = MockData.InputForZeroDrill();
            var tmax = OilFormula.CalculateTmax(input.NumerbOfDrills, input.Period, input.InitialOutPut, input.DepreciationRate);

            var outTmax = OilFormula.CalculateOutTmax(input.NumerbOfDrills, tmax, input.Period, input.InitialOutPut,
                 input.DepreciationRate);
            Assert.AreEqual(outTmax, 0);
        }

        [TestMethod]
        public void OutTmaxCalculationWithZeroPeriodReturnOk()
        {
            var input = MockData.InputForZeroPeriod();
            var tmax = OilFormula.CalculateTmax(input.NumerbOfDrills, input.Period, input.InitialOutPut, input.DepreciationRate);

            var outTmax = OilFormula.CalculateOutTmax(input.NumerbOfDrills, tmax, input.Period, input.InitialOutPut,
                 input.DepreciationRate);
            Assert.AreEqual(outTmax, 12750.0);
        }

        [TestMethod]
        public void OutTmaxCalculationWithZeroDrillAndPeriodReturnOk()
        {
            var input = MockData.InputForZeroDrill();
            input.Period = 0;
            var tmax = OilFormula.CalculateTmax(input.NumerbOfDrills, input.Period, input.InitialOutPut, input.DepreciationRate);

            var outTmax = OilFormula.CalculateOutTmax(input.NumerbOfDrills, tmax, input.Period, input.InitialOutPut,
                input.DepreciationRate);
            Assert.AreEqual(outTmax, 0.0);
        }


        [TestMethod]
        public void OutTmaxCalculationWithInitialOutPutReturnOk()
        {
            var input = MockData.InputForZeroInitialOutPut();
            var tmax = OilFormula.CalculateTmax(input.NumerbOfDrills, input.Period, input.InitialOutPut, input.DepreciationRate);

            var outTmax = OilFormula.CalculateOutTmax(input.NumerbOfDrills, tmax, input.Period, input.InitialOutPut,
                input.DepreciationRate);
            Assert.AreEqual(outTmax, 0.0);
        }

        [TestMethod]
        public void OutTmaxCalculationWithZeroDepreciationReturnOk()
        {
            var input = MockData.InputForZeroDepreciationRate();
            var tmax = OilFormula.CalculateTmax(input.NumerbOfDrills, input.Period, input.InitialOutPut, input.DepreciationRate);

            var outTmax = OilFormula.CalculateOutTmax(input.NumerbOfDrills, tmax, input.Period, input.InitialOutPut,
                input.DepreciationRate);
            Assert.AreEqual(outTmax, 9000.0);
        }

        #endregion
    }
}
