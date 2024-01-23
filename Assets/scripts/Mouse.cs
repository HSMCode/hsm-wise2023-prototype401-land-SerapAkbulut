using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 10.0f;
    private bool canJump = true;
    private Rigidbody rb;
    public LogicScript logic;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void EnableRagdoll()
    {
        rb.isKinematic = true;
        rb.detectCollisions = false;
    }

    void Update()
    {
       
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && canJump)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        canJump = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }


         if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Du hast verloren!");
            logic.GameOver();
            Destroy(gameObject);

        }
    }
}