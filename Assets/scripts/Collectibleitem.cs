using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public float growSpeed = 1.0f;
    public ParticleSystem pickup;
    [SerializeField] private AudioSource collectionSoundEffect;

    void Start()
    {
        pickup = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        
        transform.localScale += Vector3.one * growSpeed * Time.deltaTime;

        
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            Vector3 directionToPlayer = player.transform.position - transform.position;

            
            transform.Translate(directionToPlayer.normalized * growSpeed * Time.deltaTime, Space.World);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            collectionSoundEffect.Play();
            pickup.Play();
            Debug.Log("Objekt aufgesammelt!");
            Destroy(gameObject);
        }
    }
}