using Accord.MachineLearning.DecisionTrees;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Controls;
using Accord.Statistics.Models.Regression.Linear;

namespace RedWineQuality
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");
            List<Wine> wines;
            using (var stream = new StreamReader(".\\winequality-red.csv"))
            using (var helper = new CsvHelper.CsvReader(stream))
            {
                helper.Configuration.RegisterClassMap<WineMap>();
                wines = helper.GetRecords<Wine>().ToList();
            }

            var testingSet = wines.Take(400).ToList();
            var trainingSet = wines.Skip(400).ToList();
            double[] result = LinearRegression(testingSet, trainingSet);

            decimal good = result.Zip(testingSet, (x, y) => Math.Abs(x - y.Quality) <= 0.2).Where(x => x).Count();
            decimal all = 400;
            Debug.WriteLine($"Correctness: {good / all}");
            ScatterplotBox.Show("Expected results", result.Select(x => (double)x).ToArray(), testingSet.Select(x => (double)x.Quality).ToArray()).Hold();
        }

        private static double[] RandomForest(List<Wine> testingSet, List<Wine> trainingSet)
        {
            var teacher = new RandomForestLearning()
            {
                NumberOfTrees = 4
            };
            var forest = teacher.Learn(trainingSet.Select(x => x.GetParams()).ToArray(), trainingSet.Select(x => x.Quality).ToArray());
            var result = forest.Decide(testingSet.Select(x => x.GetParams()).ToArray());
            return result.Select(x => (double)x).ToArray() ;
        }

        private static double[] LinearRegression(List<Wine> testingSet, List<Wine> trainingSet)
        {
            var teacher = new OrdinaryLeastSquares();
            var forest = teacher.Learn(trainingSet.Select(x => x.GetParams()).ToArray(), trainingSet.Select(x => (double)x.Quality).ToArray());
            var result = forest.Transform(testingSet.Select(x => x.GetParams()).ToArray());
            return result;
        }
    }
}
