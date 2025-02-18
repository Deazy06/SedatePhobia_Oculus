using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSpawn : MonoBehaviour
{
    public GameObject originalObject; // The prefab to instantiate
    public List<Transform> specifiedPositions; // List of specified positions to spawn the prefab
    private List<int> usedPositionIndices = new List<int>(); // Tracks used spawn positions
    private RandomNumberSelector numberSelector; // Reference to RandomNumberSelector

    void Start()
    {
        // Find the RandomNumberSelector script from GameManagement
        GameObject gameManager = GameObject.FindWithTag("GameManager"); // Make sure GameManagement has this tag
        if (gameManager != null)
        {
            numberSelector = gameManager.GetComponent<RandomNumberSelector>();
        }
        else
        {
            Debug.LogError("GameManagement object not found! Make sure it has the tag 'GameManager'.");
        }

        StartCoroutine(SpawnPrefabs());
    }

    private IEnumerator SpawnPrefabs()
    {
        if (specifiedPositions.Count == 0)
        {
            Debug.LogWarning("No positions available for spawning.");
            yield break;
        }

        int maxPrefabs = Mathf.Min(8, specifiedPositions.Count);
        for (int i = 0; i < maxPrefabs; i++)
        {
            int randomIndex = Random.Range(0, specifiedPositions.Count);
            while (usedPositionIndices.Contains(randomIndex))
            {
                randomIndex = Random.Range(0, specifiedPositions.Count);
            }

            usedPositionIndices.Add(randomIndex);
            Transform position = specifiedPositions[randomIndex];

            // Instantiate prefab
            GameObject instance = Instantiate(originalObject, position.position, position.rotation);

            // Get the text components from the spawned object
            Text[] textComponents = instance.GetComponentsInChildren<Text>();
            if (textComponents.Length >= 2 && numberSelector != null)
            {
                // Send the text components to the RandomNumberSelector script
                numberSelector.SetTextComponents(textComponents[0], textComponents[1]);
            }
            else
            {
                Debug.LogError("Not enough Text components found in the prefab OR numberSelector is null!");
            }

            yield return new WaitForSeconds(1.5f);
        }
    }
}
