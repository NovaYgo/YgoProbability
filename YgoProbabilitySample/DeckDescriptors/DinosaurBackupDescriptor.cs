using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using YgoProbabilityCore.Abstractions;
using YgoProbabilityCore.Gameplay;
using YgoProbabilitySample.Cards;

namespace YgoProbabilitySample.DeckDescriptors
{
    public class DinosaurBackupDescriptor : IDeckDescriptor<DinosaurCard>
    {
        private const int SOULEATINGOVIRAPTOR_DECK_COUNT = 3;
        private const int MISCELLANEOUSAURUS_DECK_COUNT = 3;
        private const int BABYCERASAURUS_DECK_COUNT = 3;
        private const int PETITERANODON_DECK_COUNT = 3;
        private const int ANIMADORNEDARCHOSAUR_DECK_COUNT = 3;
        private const int FOSSILDIG_DECK_COUNT = 3;
        private const int DOUBLEEVOLUTIONPILL_DECK_COUNT = 2;
        private const int POTOFEXTRAVAGANCE_DECK_COUNT = 3;
        private const int LOSTWORLD_DECK_COUNT = 3;
        private const int TERRAFORMING_DECK_COUNT = 1;
        private const int ULTIMATECONDUCTORTYRANNO_DECK_COUNT = 2;

        private RNGCryptoServiceProvider _rng;
        private byte[] _rngData;

        public DinosaurBackupDescriptor()
        {
            _rng = new RNGCryptoServiceProvider();
            _rngData = new byte[sizeof(uint)];
            this.ExtravaganceSuccessRate = 100.0 * 4131.0 / 5005.0;
        }

        public bool HasCombo(IHand<DinosaurCard> hand)
        {
            if (HasSimorghCombo(hand))
                return false;

            return (hand.Has(DinosaurCard.LostWorld) && hand.Has(DinosaurCard.SoulEatingOviraptor)) ||
                (hand.Has(DinosaurCard.Terraforming) && hand.Has(DinosaurCard.SoulEatingOviraptor)) ||
                (hand.Has(DinosaurCard.LostWorld) && hand.Has(DinosaurCard.FossilDig)) ||
                (hand.Has(DinosaurCard.Terraforming) && hand.Has(DinosaurCard.FossilDig));
        }

        private bool HasSimorghCombo(IHand<DinosaurCard> hand)
        {
            hand.Draw(5);

            if (hand.Has(DinosaurCard.PotOfExtravagance))
            {
                _rng.GetBytes(_rngData);
                double result = 100.0 * (BitConverter.ToUInt32(_rngData, 0) / (double)UInt32.MaxValue);

                if (result > this.ExtravaganceSuccessRate)
                    return false;

                hand.Draw(2);
            }

            if (hand.Count(DinosaurCard.DoubleEvolutionPill) == DOUBLEEVOLUTIONPILL_DECK_COUNT)
                return false;

            return (hand.Has(DinosaurCard.SoulEatingOviraptor) && hand.Has(DinosaurCard.Miscellaneousaurus) && hand.Count(DinosaurCard.AnimadornedArchosaur) < ANIMADORNEDARCHOSAUR_DECK_COUNT) ||
               (hand.Has(DinosaurCard.SoulEatingOviraptor) && hand.Has(DinosaurCard.Babycerasaurus)) ||
               (hand.Has(DinosaurCard.Miscellaneousaurus) && hand.Has(DinosaurCard.Babycerasaurus)) ||
               (hand.Has(DinosaurCard.Miscellaneousaurus) && hand.Has(DinosaurCard.Petiteranodon)) ||
               (hand.Has(DinosaurCard.AnimadornedArchosaur) && hand.Has(DinosaurCard.Babycerasaurus)) ||
               (hand.Has(DinosaurCard.AnimadornedArchosaur) && hand.Has(DinosaurCard.Petiteranodon) && hand.Count(DinosaurCard.SoulEatingOviraptor) < SOULEATINGOVIRAPTOR_DECK_COUNT) ||
               (hand.Count(DinosaurCard.FossilDig) >= 2) ||
               (hand.Has(DinosaurCard.FossilDig) && hand.Has(DinosaurCard.SoulEatingOviraptor)) ||
               (hand.Has(DinosaurCard.FossilDig) && hand.Has(DinosaurCard.Miscellaneousaurus)) ||
               (hand.Has(DinosaurCard.FossilDig) && hand.Has(DinosaurCard.AnimadornedArchosaur)) ||
               (hand.Has(DinosaurCard.FossilDig) && hand.Has(DinosaurCard.Petiteranodon)) ||
               (hand.Has(DinosaurCard.FossilDig) && hand.Has(DinosaurCard.Babycerasaurus)) ||
               (hand.Has(DinosaurCard.LostWorld) && hand.Has(DinosaurCard.SoulEatingOviraptor) && hand.Has(DinosaurCard.Petiteranodon)) ||
               (hand.Has(DinosaurCard.Terraforming) && hand.Has(DinosaurCard.SoulEatingOviraptor) && hand.Has(DinosaurCard.Petiteranodon)) ||
               (hand.Has(DinosaurCard.LostWorld) && hand.Has(DinosaurCard.SoulEatingOviraptor) && hand.Has(DinosaurCard.UltimateConductorTyranno)) ||
               (hand.Has(DinosaurCard.Terraforming) && hand.Has(DinosaurCard.SoulEatingOviraptor) && hand.Has(DinosaurCard.UltimateConductorTyranno));
        }

        public double ExtravaganceSuccessRate { get; set; }

        public int DeckSize => 40;

        public int IterationCount => 200000;

        public DinosaurCard FillerCard => DinosaurCard.Filler;

        public HashSet<CardCount<DinosaurCard>> CardCounts => new HashSet<CardCount<DinosaurCard>>()
        {
            new CardCount<DinosaurCard>(DinosaurCard.SoulEatingOviraptor) { Count = SOULEATINGOVIRAPTOR_DECK_COUNT },
            new CardCount<DinosaurCard>(DinosaurCard.Miscellaneousaurus) { Count = MISCELLANEOUSAURUS_DECK_COUNT },
            new CardCount<DinosaurCard>(DinosaurCard.FossilDig) { Count = FOSSILDIG_DECK_COUNT },
            new CardCount<DinosaurCard>(DinosaurCard.Babycerasaurus) { Count = BABYCERASAURUS_DECK_COUNT },
            new CardCount<DinosaurCard>(DinosaurCard.Petiteranodon) { Count = PETITERANODON_DECK_COUNT },
            new CardCount<DinosaurCard>(DinosaurCard.AnimadornedArchosaur) { Count = ANIMADORNEDARCHOSAUR_DECK_COUNT },
            new CardCount<DinosaurCard>(DinosaurCard.DoubleEvolutionPill) { Count = DOUBLEEVOLUTIONPILL_DECK_COUNT },
            new CardCount<DinosaurCard>(DinosaurCard.PotOfExtravagance) { Count = POTOFEXTRAVAGANCE_DECK_COUNT },
            new CardCount<DinosaurCard>(DinosaurCard.LostWorld) { Count = LOSTWORLD_DECK_COUNT },
            new CardCount<DinosaurCard>(DinosaurCard.Terraforming) { Count = TERRAFORMING_DECK_COUNT },
            new CardCount<DinosaurCard>(DinosaurCard.UltimateConductorTyranno) { Count = ULTIMATECONDUCTORTYRANNO_DECK_COUNT }
        };
    }
}
