using System;
using YgoProbabilityCore;
using YgoProbabilitySample.Cards;
using YgoProbabilitySample.DeckDescriptors;

namespace YgoProbabilitySample
{
    class Program
    {
        static void Main(string[] args)
        {
            DinosaurMainDescriptor dino = new DinosaurMainDescriptor();
            double dinoOdds = ProbabilityCore.Simulate<DinosaurCard>(dino);
            Console.WriteLine($"Dino Simorgh Combo Success Rate: {dinoOdds}%");

            DinosaurBackupDescriptor dino2 = new DinosaurBackupDescriptor();
            double dinoOdds2 = ProbabilityCore.Simulate<DinosaurCard>(dino2);
            Console.WriteLine($"Dino Lost World Combo Success Rate After Failing Simorgh Combo: {dinoOdds2}%");

            Console.ReadLine();
        }
    }
}
