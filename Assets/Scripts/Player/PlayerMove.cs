using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    CharacterController controller;
    [Range (15f, 100f)]public float speed;
    float gravity = -25f;
    float jumpHeight = 4.5f;


    [SerializeField] public Transform groundCheck;
    float groundDistane = 0.4f;
    [SerializeField] public LayerMask groundMask;

    bool isGrounded;
    Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistane, groundMask);
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;
        
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        
        Vector3 move = transform.right * xMove + transform.forward * zMove;
        
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    
}
