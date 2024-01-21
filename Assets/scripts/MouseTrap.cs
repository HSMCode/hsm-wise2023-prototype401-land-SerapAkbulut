using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTrap : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Wenn der Spieler den Spawner mit dem Tag "Obstacle" ber�hrt, verliert er
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Du hast verloren!");
            // Hier k�nntest du weitere Aktionen f�r den Verlust hinzuf�gen

            // Zerst�re den Spieler oder deaktiviere sein GameObject
            Destroy(gameObject);
        }
    }
}