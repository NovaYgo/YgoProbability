# YgoProbability
A small library that helps with calculating the probability of certain YuGiOh opening hands through simulation. The YgoProbabilitySample project demonstrates how to use the library to calculate the odds of a dinosaur deck.

# Instructions
1. Create your own project and reference the YgoProbabilityCore library.
2. Implement your own IDeckDescriptor object which describes whether a certain opening hand is obtained.
3. Pass your IDeckDescriptor object into the ProbabilityCore.Simulate method which returns the % of the successfully obtained hands.

# Notes
Generics is used so that you could pass whatever type you wish to use to identify cards in your hand. This happens when the HasCombo method in your IDeckDecriptor class is executed. The YgoProbabilityCore library uses this type as a key in a dictionary, which means that you should override the GetHashCode method if you are using a custom class.
