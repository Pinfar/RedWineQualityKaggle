using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedWineQuality
{
    class Wine
    {
        public double FixedAcidity { get; set; }
        public double VolatileAcidity { get; set; }
        public double CitricAcid { get; set; }
        public double ResidualSugar { get; set; }
        public double Chlorides { get; set; }
        public double FreeSulfurDioxide { get; set; }
        public double TotalSulfurDioxide { get; set; }
        public double Density { get; set; }
        public double PH { get; set; }
        public double Sulphates { get; set; }
        public double Alcohol { get; set; }
        public int Quality { get; set; }

        public double[] GetParams()
        {
            return new[] {
                FixedAcidity,
                VolatileAcidity,
                CitricAcid,
                ResidualSugar,
                Chlorides,
                FreeSulfurDioxide,
                TotalSulfurDioxide,
                Density,
                PH,
                Sulphates,
                Alcohol
            };
        }
    }
}
