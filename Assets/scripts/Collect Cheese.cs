using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCheese : MonoBehaviour
{
    public ParticleSystem pickup;
    void Start()
    {
        pickup = GetComponent<ParticleSystem>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("capsule")) // Überprüfe, ob das kollidierte Objekt ein "Capsule"-Tag hat
        {
            Destroy(other.gameObject); // Zerstöre die Kapsel
            Debug.Log("Capsule aufgesammelt!");
            pickup.Play();
        }
    }
}

