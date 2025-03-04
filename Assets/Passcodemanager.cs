using UnityEngine;
using System.Collections.Generic;

public class PasscodeManager : MonoBehaviour
{
    private List<int> usedNumbers; // List to store used numbers
    private List<int> passcode; // List to store the passcode

    private void Start()
    {
        usedNumbers = new List<int>();
        passcode = new List<int>();
    }

    // Call this method to add numbers to the used numbers list
    public void AddUsedNumbers(int number1, int number2)
    {
        if (!usedNumbers.Contains(number1))
        {
            usedNumbers.Add(number1);
        }

        if (!usedNumbers.Contains(number2))
        {
            usedNumbers.Add(number2);
        }

        GeneratePasscode();
    }

    // Shuffle the used numbers to create a passcode
    private void GeneratePasscode()
    {
        passcode.Clear();
        passcode.AddRange(usedNumbers);
        Shuffle(passcode);
        print(string.Join(",", passcode));
    }

    // Shuffle a list using Fisher-Yates algorithm
    private void Shuffle(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(0, list.Count);
            // Swap the elements
            int temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    // Method to check if the input matches the passcode
    public bool CheckPasscode(List<int> input)
    {
        if (input.Count != passcode.Count)
        {
            return false; // Input length must match passcode length
        }

        for (int i = 0; i < passcode.Count; i++)
        {
            if (input[i] != passcode[i])
            {
                return false; // Mismatch found
            }
        }

        return true; // Passcode matches
    }

    // Optional: Method to get the current passcode for debugging
    public List<int> GetPasscode()
    {
        return new List<int>(passcode);
    }
}