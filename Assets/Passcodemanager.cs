using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class PasscodeManager : MonoBehaviour
{
    public List<(int number1, int number2)> numberPairs; // Stores linked pairs
    public List<int> passcode; // Final ordered passcode

    public Text keypadText;

    private void Awake()
    {
        numberPairs = new List<(int, int)>();
        passcode = new List<int>();
    }

    // Call this method to add numbers
    public void AddUsedNumbers(int number1, int number2)
    {
        Debug.Log($"Added Pair -> Number 1: {number1}, Number 2: {number2}");
        numberPairs.Add((number1, number2));
        if (numberPairs.Count == 8)
        {
            Debug.Log("Generate");
            GeneratePasscode();
        }
    }

    // Generate the passcode based on sorted number2 values
    public void GeneratePasscode()
    {
        passcode.Clear();

        // Sort by number2 and extract number1 in that order
        var sortedPairs = numberPairs.OrderBy(pair => pair.number2).ToList();
        passcode = sortedPairs.Select(pair => pair.number1).ToList();

        Debug.Log("Final Passcode Order: " + string.Join(", ", passcode));
    }

    // Check if input matches the passcode order
    public bool CheckPasscode(List<int> input)
    {
        return input.SequenceEqual(passcode);
    }

    // Get the current passcode
    public List<int> GetPasscode()
    {
        return new List<int>(passcode);
    }
}
