using System;
using System.Collections.Generic;
using System.Text;
using YgoProbabilityCore.Abstractions;
using YgoProbabilityCore.Gameplay;

namespace YgoProbabilityCore
{
    public static class ProbabilityCore
    {
        public static double Simulate<T>(IDeckDescriptor<T> des)
        {
            int successCount = 0;

            using (IDeck<T> deck = new Deck<T>(des))
            {
                IHand<T> hand = new Hand<T>(deck);

                for (int i = 0; i < des.IterationCount; i++)
                {
                    hand.Reset();
                    deck.Shuffle();

                    if (des.HasCombo(hand))
                        successCount++;
                }
            }

            return 100.0 * successCount / des.IterationCount;
        }
    }
}
