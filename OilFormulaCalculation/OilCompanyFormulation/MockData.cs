using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilCompanyFormulation
{
    
    public static class MockData
    {
        public static OilInputModel ValidInput()
        {
            return new OilInputModel
            {
                NumerbOfDrills = 10,
                DepreciationRate = 5,
                Period = 39,
                InitialOutPut = 97
            };
        }

        public static OilInputModel InputForZeroDrill()
        {
            return new OilInputModel
            {
                NumerbOfDrills = 0,
                DepreciationRate = 10,
                Period = 1,
                InitialOutPut = 100
            };
        }

        public static OilInputModel InputForZeroPeriod()
        {
            return new OilInputModel
            {
                NumerbOfDrills = 10,
                DepreciationRate = 1,
                Period = 0,
                InitialOutPut = 50
            };
        }

        public static OilInputModel InputForZeroInitialOutPut()
        {
            return new OilInputModel
            {
                NumerbOfDrills = 10,
                DepreciationRate = 1,
                Period = 4,
                InitialOutPut = 0
            };
        }

        public static OilInputModel InputForZeroDepreciationRate()
        {
            return new OilInputModel
            {
                NumerbOfDrills = 10,
                DepreciationRate = 0,
                Period = 4,
                InitialOutPut = 30
            };
        }
    }
}
