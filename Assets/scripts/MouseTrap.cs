using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTrap : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Wenn der Spieler den Spawner mit dem Tag "Obstacle" berührt, verliert er
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Du hast verloren!");
            // Hier könntest du weitere Aktionen für den Verlust hinzufügen

            // Zerstöre den Spieler oder deaktiviere sein GameObject
            Destroy(gameObject);
        }
    }
}