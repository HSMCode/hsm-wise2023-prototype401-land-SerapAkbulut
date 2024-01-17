using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // Bewege das GameObject nur nach links
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}