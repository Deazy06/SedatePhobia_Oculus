using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSpawn : MonoBehaviour
{
    public GameObject originalObject; // The prefab to instantiate
    public List<Transform> specifiedPositions; // List of specified positions to spawn the prefab
    private HashSet<int> usedNumbers = new HashSet<int>(); // Set to keep track of used numbers

    void Start()
    {
        // Check if the list is empty
        if (specifiedPositions.Count == 0)
        {
            Debug.LogWarning("No specified positions available for spawning.");
            return;
        }

        // Iterate through the specified positions and instantiate the prefab at each location
        foreach (Transform position in specifiedPositions)
        {
            // Spawn the prefab at the position's location and rotation
            GameObject instance = Instantiate(originalObject, position.position, position.rotation);

            // Optionally, add the RandomTextAssigner component to the instantiated prefab
            RandomTextAssigner textAssigner = instance.AddComponent<RandomTextAssigner>();

            // Find the Text components in the instantiated prefab
            textAssigner.firstText = instance.GetComponentInChildren<Text>();
            textAssigner.secondText = instance.GetComponentInChildren<Text>();

            // Assign random numbers ensuring uniqueness
            textAssigner.AssignRandomNumbers(usedNumbers);
        }
    }
}