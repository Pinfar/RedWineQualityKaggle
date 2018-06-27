using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedWineQuality
{
    class WineMap : ClassMap<Wine>
    {
        public WineMap()
        {
            Map(x => x.FixedAcidity).Name("fixed acidity");
            Map(x => x.VolatileAcidity).Name("volatile acidity");
            Map(x => x.CitricAcid).Name("citric acid");
            Map(x => x.ResidualSugar).Name("residual sugar");
            Map(x => x.Chlorides).Name("chlorides");
            Map(x => x.FreeSulfurDioxide).Name("free sulfur dioxide");
            Map(x => x.TotalSulfurDioxide).Name("total sulfur dioxide");
            Map(x => x.Density).Name("density");
            Map(x => x.PH).Name("pH");
            Map(x => x.Sulphates).Name("sulphates");
            Map(x => x.Alcohol).Name("alcohol");
            Map(x => x.Quality).Name("quality");
        }
    }
}
