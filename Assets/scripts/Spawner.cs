using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objectToSpawnArray;
    public float spawnInterval = 1.0f;
    public float spawnSpeed = 5.0f;
    public Vector3 minScale = new Vector3(1.0f, 1.0f, 1.0f);
    public Vector3 maxScale = new Vector3(3.0f, 3.0f, 3.0f);
    public float spawnZPosition = 0.0f;
    public float minXPosition = -10.0f;
    public float maxXPosition = 10.0f;

    private void Start()
    {
        InvokeRepeating("SpawnObject", 0.0f, spawnInterval);
    }

    private void SpawnObject()
    {
        GameObject selectedObject = objectToSpawnArray[Random.Range(0, objectToSpawnArray.Length)];

        GameObject spawnedObject = Instantiate(selectedObject, transform.position, Quaternion.identity);

        Vector3 spawnPosition = new Vector3(Random.Range(minXPosition, maxXPosition), transform.position.y, spawnZPosition);
        spawnedObject.transform.position = spawnPosition;

        Vector3 randomScale = new Vector3(Random.Range(minScale.x, maxScale.x), Random.Range(minScale.y, maxScale.y), Random.Range(minScale.z, maxScale.z));
        spawnedObject.transform.localScale = randomScale;

        spawnedObject.AddComponent<MoveLeft>();
        MoveLeft moveLeftScript = spawnedObject.GetComponent<MoveLeft>();

        moveLeftScript.speed = spawnSpeed;
    }
}

public class MoveLeft : MonoBehaviour
{
    public float speed = 5.0f;

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}

public class PlayerController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Du hast verloren!");
            
        }
    }
}