using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class RandomTextAssigner : MonoBehaviour
{
    public Text firstText; // Reference to the first Text component
    public Text secondText; // Reference to the second Text component

    public void AssignRandomNumbers(List<int> usedNumbers)
    {
        // Ensure enough unique numbers are available
        if (usedNumbers.Count > 8) // We need at least 2 unique numbers
        {
            Debug.LogError("Not enough unique numbers available for assignment.");
            return; // Exit if not enough unique numbers
        }

        // Generate a unique random number for the first text (0-9)
        int firstNumber;
        do
        {
            firstNumber = Random.Range(0, 10); // Random number between 0-9
        } while (usedNumbers.Contains(firstNumber));
        usedNumbers.Add(firstNumber); // Add to the used numbers

        // Generate a unique random number for the second text (0-9)
        int secondNumber;
        do
        {
            secondNumber = Random.Range(1, 9); // Random number between 0-9
        } while (usedNumbers.Contains(secondNumber));
        usedNumbers.Add(secondNumber); // Add to the used numbers

        // Assign the random numbers to the text components
        firstText.text = firstNumber.ToString();
        secondText.text = secondNumber.ToString();
    }
}
