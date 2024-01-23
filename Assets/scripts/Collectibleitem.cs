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

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Cheese"))
        {
            collectionSoundEffect.Play();
            pickup.Play();
            Debug.Log("Objekt aufgesammelt!");
            Destroy(collision.gameObject);
            logic.addscore();
        }
    }
}