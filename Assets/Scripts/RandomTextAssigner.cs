using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class RandomTextAssigner : MonoBehaviour
{
    public Text firstText; // Reference to the first Text component
    public Text secondText; // Reference to the second Text component

    public void AssignRandomNumbers(HashSet<int> usedNumbers)
    {
        // Generate a unique random number for the first text (0-9)
        int firstNumber;
        do
        {
            firstNumber = Random.Range(0, 9);
        } while (usedNumbers.Contains(firstNumber));
        usedNumbers.Add(firstNumber); // Add to the used numbers

        // Generate a unique random number for the second text (1-9)
        int secondNumber;
        do
        {
            secondNumber = Random.Range(1, 9);
        } while (usedNumbers.Contains(secondNumber));
        usedNumbers.Add(secondNumber); // Add to the used numbers

        // Assign the random numbers to the text components
        firstText.text = firstNumber.ToString();
        secondText.text = secondNumber.ToString();
    }
}