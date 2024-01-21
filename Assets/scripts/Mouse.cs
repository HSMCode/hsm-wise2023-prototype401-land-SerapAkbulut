using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 10.0f;
    private bool canJump = true;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Bewegung nach links und rechts auf der X-Achse
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);

        // Sprung mit Leertaste
        if (Input.GetButtonDown("Jump") && canJump)
        {
            Jump();
        }
    }

    void Jump()
    {
        // F�ge eine Aufw�rtskraft f�r den Sprung hinzu
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        // Setze die M�glichkeit zu springen auf false
        canJump = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Wenn der Spieler den Boden ber�hrt, erlaube einen weiteren Sprung
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }

        // Wenn der Spieler ein Hindernis ber�hrt, verliert er
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Du hast verloren!");
            // Hier k�nntest du weitere Aktionen f�r den Verlust hinzuf�gen
            // Zum Beispiel: Starte das Spiel neu oder zeige eine Verlieren-Bildschirm.
        }
    }
}