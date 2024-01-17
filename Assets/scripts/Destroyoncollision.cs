using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyoncollision : MonoBehaviour
{
    public bool Death;
    public Rigidbody rb;
    public Collider bc;
    public Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("cylinder")) // Überprüfe, ob das kollidierte Objekt ein "Cylinder"-Tag hat
        {
            Death = true;
        }
    }
}
