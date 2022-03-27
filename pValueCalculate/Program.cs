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

    
            // Genel ortalama ve genel standart sapma tanımı:
            double genelOrt = 79.3;
            double genelStandartSapma = 7.3;

            Console.WriteLine("Group 1 için test");

       
            var grup1 = Vector.Create(new double[] {
                62, 77, 61, 94, 75, 82, 86, 83, 64, 84
            });

            // Group 1'in ortalaması ve standart sapması
            Console.WriteLine("Grup1 Ortalama: ", grup1.Mean());
            Console.WriteLine("Standart Sapma: ", grup1.StandardDeviation());

        

            Console.WriteLine("\n Z-test kullanımı:");
 

            OneSampleZTest zTest = new OneSampleZTest(grup1, genelOrt, genelStandartSapma);
           
            Console.WriteLine("Test istatistik değeri: ", zTest.Statistic);
            Console.WriteLine("P değeri:  ", zTest.PValue);

            // Önem değeri default olarak 0.05 dir:
            Console.WriteLine("Önem Değeri:  ", zTest.SignificanceLevel);

            
            Console.WriteLine("Ho Hipotezini Reddetme Durumu ? {0}", zTest.Reject() ? "Reddet" : "Reddetme");
           

            Interval ortGuvenAralik = zTest.GetConfidenceInterval();
            Console.WriteLine("95%  Güven aralığı ortalaması: {0:F1} - {1:F1}",
                ortGuvenAralik.LowerBound, ortGuvenAralik.UpperBound);

          
            Console.WriteLine("Önem Değeri: ", 0.01);
            Console.WriteLine("Ho Hipotezini Reddetme Durumu ? {0}", zTest.Reject(0.01) ? "Reddet" : "Reddetme");
            

            //Güven aralığı
            ortGuvenAralik = zTest.GetConfidenceInterval(0.99);
            Console.WriteLine("99% Güven aralığı ortalaması: {0:F1} - {1:F1}",
                ortGuvenAralik.LowerBound, ortGuvenAralik.UpperBound);


            Console.WriteLine("\n T-test kullanımı:");
          
            OneSampleTTest tTest = new OneSampleTTest(grup1, genelOrt);
   
            Console.WriteLine("Test istatisliği: ", tTest.Statistic);
            Console.WriteLine("P değeri:  ", tTest.PValue);

            // Önem değeri default olarak 0.05 dir:
            Console.WriteLine("Önem Değeri: ", tTest.SignificanceLevel);
          
            Console.WriteLine("Ho Hipotezini Reddetme Durumu ? {0}", tTest.Reject() ? "Reddet" : "Reddetme");
           
            
            //Güven aralığı
            ortGuvenAralik = tTest.GetConfidenceInterval();
            Console.WriteLine("95% Güven aralığı ortalaması: {0:F1} - {1:F1}",
                ortGuvenAralik.LowerBound, ortGuvenAralik.UpperBound);


         

            Console.WriteLine("\n İki örnek kullanılarak yapılan T-test:");
            
            var grup2 = Vector.Create(new double[] {
                44, 80, 11, 80, 20, 65, 9, 75, 5, 86
            });

            
            var tTest2 = new TwoSampleTTest(grup1, grup2, SamplePairing.Paired, false);
        
            Console.WriteLine("Test istatistiği: ", tTest2.Statistic);
            Console.WriteLine("P değeri: ", tTest2.PValue);

            // Önem Değeri yine 0.05
            //tTest2.SignificanceLevel = 0.5 gibi setlenebilir.
            Console.WriteLine("Önem Değeri:     {0:F2}", tTest2.SignificanceLevel);
          
            Console.WriteLine("Ho Hipotezini Reddetme Durumu ? {0}", tTest2.Reject() ? "Reddet" : "Reddetme");

            Console.Write("Çıkış için bir tuşa bas..");
            Console.ReadLine();
        }
    }
}
