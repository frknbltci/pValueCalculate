using System;
using Extreme.Mathematics;
using Extreme.Statistics;
using Extreme.Statistics.Tests;

namespace pValueCalculate
{
    class Program
    {
        static void Main(string[] args)
        {

            // This QuickStart Sample uses the scores obtained by the students
            // in two groups of students on a national test.
            // 
            // We want to know if the scores for these two groups of students
            // are significantly different from the national average, and
            // from each other.

            // The mean and standard deviation of the complete population:

            double genelOrt = 79.3;
            double genelStandartSapma = 7.3;

            Console.WriteLine("Group 1 için test");

            // First we create a NumericalVariable that holds the test scores.
            var grup1 = Vector.Create(new double[] {
                62, 77, 61, 94, 75, 82, 86, 83, 64, 84
            });

            // Group 1'in ortalaması ve standart sapması
            Console.WriteLine("Grup1 Ortalama: {0:F1}", grup1.Mean());
            Console.WriteLine("Standard deviation: {0:F1}", grup1.StandardDeviation());

            //
            // One Sample z-test
            //

            Console.WriteLine("\n Z-test kullanımı:");
            // We know the population standard deviation, so we can use the z-test,
            // implemented by the OneSampleZTest group. We pass the sample variable
            // and the population parameters to the constructor.
            OneSampleZTest zTest = new OneSampleZTest(grup1, genelOrt, genelStandartSapma);
            // We can obtan the value of the test statistic through the Statistic property,
            // and the corresponding P-value through the Probability property:
            Console.WriteLine("Test statistic: {0:F4}", zTest.Statistic);
            Console.WriteLine("P-value:        {0:F4}", zTest.PValue);

            // The significance level is the default value of 0.05:
            Console.WriteLine("Significance level:     {0:F2}", zTest.SignificanceLevel);
            // We can now print the test scores:
            Console.WriteLine("Reject null hypothesis? {0}", zTest.Reject() ? "yes" : "no");
            // We can get a confidence interval for the current significance level:
            Interval meanInterval = zTest.GetConfidenceInterval();
            Console.WriteLine("95% Confidence interval for the mean: {0:F1} - {1:F1}",
                meanInterval.LowerBound, meanInterval.UpperBound);

            // We can get the same scores for the 0.01 significance level by explicitly
            // passing the significance level as a parameter to these methods:
            Console.WriteLine("Significance level:     {0:F2}", 0.01);
            Console.WriteLine("Reject null hypothesis? {0}", zTest.Reject(0.01) ? "yes" : "no");
            // The GetConfidenceInterval method needs the confidence level, which equals
            // 1 - the significance level:
            meanInterval = zTest.GetConfidenceInterval(0.99);
            Console.WriteLine("99% Confidence interval for the mean: {0:F1} - {1:F1}",
                meanInterval.LowerBound, meanInterval.UpperBound);


            // 
            // One sample t-test
            //

            Console.WriteLine("\nUsing t-test:");
            // Suppose we only know the mean of the national scores, 
            // not the standard deviation. In this case, a t-test is 
            // the appropriate test to use.
            OneSampleTTest tTest = new OneSampleTTest(grup1, genelOrt);
            // We can obtan the value of the test statistic through the Statistic property,
            // and the corresponding P-value through the Probability property:
            Console.WriteLine("Test statistic: {0:F4}", tTest.Statistic);
            Console.WriteLine("P-value:        {0:F4}", tTest.PValue);

            // The significance level is the default value of 0.05:
            Console.WriteLine("Significance level:     {0:F2}", tTest.SignificanceLevel);
            // We can now print the test scores:
            Console.WriteLine("Reject null hypothesis? {0}", tTest.Reject() ? "yes" : "no");
            // We can get a confidence interval for the current significance level:
            meanInterval = tTest.GetConfidenceInterval();
            Console.WriteLine("95% Confidence interval for the mean: {0:F1} - {1:F1}",
                meanInterval.LowerBound, meanInterval.UpperBound);


            // 
            // Two sample t-test
            //

            Console.WriteLine("\nUsing two-sample t-test:");
            // We want to compare the scores of the first group to the scores 
            // of a second group from the same school. Once again, we start
            // by creating a NumericalVariable containing the scores:
            var group2Results = Vector.Create(new double[] {
                61, 80, 98, 90, 94, 65, 79, 75, 74, 86,
                76, 85, 78, 72, 76, 79, 65, 92, 76, 80
            });

            // To compare the means of the two groups, we need the two sample
            // t test, implemented by the TwoSampleTTest group:
            var tTest2 = new TwoSampleTTest(grup1, group2Results, SamplePairing.Paired, false);
            // We can obtan the value of the test statistic through the Statistic property,
            // and the corresponding P-value through the Probability property:
            Console.WriteLine("Test statistic: {0:F4}", tTest2.Statistic);
            Console.WriteLine("P-value:        {0:F4}", tTest2.PValue);

            // The significance level is the default value of 0.05:
            Console.WriteLine("Significance level:     {0:F2}", tTest2.SignificanceLevel);
            // We can now print the test scores:
            Console.WriteLine("Reject null hypothesis? {0}", tTest2.Reject() ? "yes" : "no");

            Console.Write("Press any key to exit.");
            Console.ReadLine();
        }
    }
}
