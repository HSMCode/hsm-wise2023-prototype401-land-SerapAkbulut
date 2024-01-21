using UnityEngine;

public class SpawnerCheese : MonoBehaviour
{
    public GameObject itemPrefab;
    public float spawnInterval = .0f; 
    public float growSpeed = 1.0f;
    public float moveSpeed = 2.0f; 

    private int spawnCount = 0;

    private void Start()
    {
        InvokeRepeating("SpawnItem", 0.0f, spawnInterval);
    }

    private void Update()
    {
        
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }

    private void SpawnItem()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        GameObject spawnedItem = Instantiate(itemPrefab, spawnPosition, Quaternion.identity);

       
        CollectibleItem collectibleItemScript = spawnedItem.AddComponent<CollectibleItem>();

        
        collectibleItemScript.growSpeed = growSpeed;

        
        spawnPosition.x += spawnInterval;
        transform.position = spawnPosition;

        spawnCount++;

        
        if (spawnCount >= 10) 
        {
            CancelInvoke("SpawnItem");
        }
    }
}