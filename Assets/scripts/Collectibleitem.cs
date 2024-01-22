using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public ParticleSystem pickup;
    public LogicScript logic;
    [SerializeField] private AudioSource collectionSoundEffect;

    void Start()
    {
        pickup = GetComponent<ParticleSystem>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
          
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Cheese"))
        {
            collectionSoundEffect.Play();
            pickup.Play();
            Debug.Log("Objekt aufgesammelt!");
            Destroy(gameObject);
        }
    }
}