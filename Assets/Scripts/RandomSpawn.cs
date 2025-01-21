using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSpawn : MonoBehaviour
{
    public GameObject originalObject; // The prefab to instantiate
    public List<Transform> specifiedPositions; // List of specified positions to spawn the prefab
    private List<int> usedPositionIndices = new List<int>(); // Tracks used spawn positions
    private List<int> usedTextNumbers = new List<int>(); // Tracks used numbers for text

    void Start()
    {
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

            GameObject instance = Instantiate(originalObject, position.position, position.rotation);
            RandomTextAssigner textAssigner = instance.AddComponent<RandomTextAssigner>();

            GameObject textParent = instance.GetComponentInChildren<Canvas>().gameObject;
            textAssigner.firstText = textParent.transform.GetChild(0).GetComponent<Text>();
            textAssigner.secondText = textParent.transform.GetChild(1).GetComponent<Text>();

            textAssigner.AssignRandomNumbers(usedTextNumbers);

            yield return new WaitForSeconds(1.5f);
        }
    }
}
