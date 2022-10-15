using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rgb;
    [SerializeField] float speed = 5f;
    [SerializeField] float jump = 5f;
    [SerializeField] Transform groundingCheck;
    [SerializeField] LayerMask Ground;
    [SerializeField] AudioSource jumpSound;
    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rgb.velocity = new Vector3(horizontalInput * speed, rgb.velocity.y, verticalInput * speed);
        
        if (Input.GetButtonDown("Jump") && Grounded())
        {
            Jump();
        }    
    }

    void Jump()
    {
        rgb.velocity = new Vector3(rgb.velocity.x, jump, rgb.velocity.z);
        jumpSound.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }

    bool Grounded()
    {
        return Physics.CheckSphere(groundingCheck.position, .1f, Ground);
    }    
}
