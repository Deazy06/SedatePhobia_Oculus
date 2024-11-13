using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSpawn : MonoBehaviour
{
    public GameObject originalObject; // The prefab to instantiate
    public List<Transform> specifiedPositions; // List of specified positions to spawn the prefab
    private HashSet<int> usedNumbers = new HashSet<int>(); // Set to keep track of used positions

    void Start()
    {
        // Start the spawning process
        StartCoroutine(SpawnPrefabs());
    }

    private IEnumerator SpawnPrefabs()
    {
        // Check if the list is empty
        if (specifiedPositions.Count == 0)
        {
            Debug.LogWarning("No specified positions available for spawning.");
            yield break; // Exit the coroutine if no positions are available
        }

        // Limit the number of prefabs to spawn
        int maxPrefabs = Mathf.Min(8, specifiedPositions.Count);

        for (int i = 0; i < maxPrefabs; i++)
        {
            // Generate a random index for the specified positions
            int randomIndex = Random.Range(0, specifiedPositions.Count);
            
            // Ensure that the position has not already been used
            while (usedNumbers.Contains(randomIndex))
            {
                randomIndex = Random.Range(0, specifiedPositions.Count);
            }

            // Mark this position as used
            usedNumbers.Add(randomIndex);

            // Get the position to spawn the prefab
            Transform position = specifiedPositions[randomIndex];

            // Spawn the prefab at the position's location and rotation
            GameObject instance = Instantiate(originalObject, position.position, position.rotation);

            // Optionally, add the RandomTextAssigner component to the instantiated prefab
            RandomTextAssigner textAssigner = instance.AddComponent<RandomTextAssigner>();

            // Find the Text components in the instantiated prefab
            GameObject textParent = instance.GetComponentInChildren<Canvas>().gameObject;
            textAssigner.firstText = textParent.transform.GetChild(0).GetComponent<Text>();
            textAssigner.secondText = textParent.transform.GetChild(1).GetComponent<Text>();

            // Assign random numbers ensuring uniqueness
            textAssigner.AssignRandomNumbers(usedNumbers);

            // Wait for 0.1 seconds before spawning the next prefab
            yield return new WaitForSeconds(1.5f);
        }
    }
}