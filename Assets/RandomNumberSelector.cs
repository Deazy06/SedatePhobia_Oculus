using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class RandomNumberSelector : MonoBehaviour
{
    private List<int> availableList1;
    private List<int> availableList2;

    private Text firstText;
    private Text secondText;

    public PasscodeManager passcodeManager;

    private void Start()
    {
        InitializeLists();
    }

    private void InitializeLists()
    {
        if (availableList1 == null || availableList1.Count == 0)
        {
            availableList1 = new List<int>();
            for (int i = 0; i <= 9; i++)
            {
                availableList1.Add(i);
            }
        }

        if (availableList2 == null || availableList2.Count == 0)
        {
            availableList2 = new List<int>();
            for (int i = 1; i <= 8; i++)
            {
                availableList2.Add(i);
            }
        }
    }

    public void SetTextComponents(Text text1, Text text2)
    {
        firstText = text1;
        secondText = text2;

        InitializeLists();
        AssignUniqueNumbers();
    }

    private void AssignUniqueNumbers()
    {
        if (availableList1.Count == 0 || availableList2.Count == 0)
        {
            Debug.LogError("No unique numbers left!");
            return;
        }

        int index1 = Random.Range(0, availableList1.Count);
        int selectedNumber1 = availableList1[index1];
        availableList1.RemoveAt(index1);  // Remove used number

        int index2 = Random.Range(0, availableList2.Count);
        int selectedNumber2 = availableList2[index2];
        availableList2.RemoveAt(index2);  // Remove used number

        firstText.text = selectedNumber1.ToString();
        secondText.text = selectedNumber2.ToString(); 
        
        passcodeManager.AddUsedNumbers(selectedNumber1, selectedNumber2);
        
    }
}
