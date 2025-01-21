using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomNumberSelector : MonoBehaviour
{
    private List<int> list1;
    private List<int> list2;

    public Text firstText; // Reference to the first Text component
    public Text secondText; // Reference to the second Text component

    private void Start()
    {
        // Initialize the lists
        list1 = new List<int>();
        list2 = new List<int>();

        // Fill list1 with numbers 0-9
        for (int i = 0; i <= 9; i++)
        {
            list1.Add(i);
        }

        // Fill list2 with numbers 1-8
        for (int i = 1; i <= 8; i++)
        {
            list2.Add(i);
        }

        // Shuffle and print random numbers from both lists
        PrintRandomNumbers();
    }

    public void AssignRandomNumbers()
    {
        print("assignranodmnumbers");
        firstText.text = list1[i].ToString();
        secondText.text = list2.ToString();
    }
    private void PrintRandomNumbers()
    {
        // Shuffle the lists
        Shuffle(list1);
        Shuffle(list2);

        // Get the minimum length to avoid index out of range
        int minLength = Mathf.Min(list1.Count, list2.Count);

        // Print random numbers from both lists
        for (int i = 0; i < minLength; i++)
        {
            print(list1);
            print(list2);
        }
    }

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
}