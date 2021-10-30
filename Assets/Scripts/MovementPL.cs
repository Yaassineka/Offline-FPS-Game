using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPL : MonoBehaviour
{
    [SerializeField] GameObject p, Player;

    Vector3 velocity;
    public float gravity = -9.81f;

    public float groundDistance = 0.4f;
    public float jumpForce;
    public Transform groundCheck;
    public LayerMask groundMask;
    public bool isGrounded;


    private CharacterController controller;
    public float movementSpeed = 10f;
    Animator anim;

    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked; 
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

    }
    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Cursor.lockState = CursorLockMode.None;
            p.SetActive(true);
            //Player.SetActive(false);
            Time.timeScale = 0f;  
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity); 
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Run();
            movementSpeed = 20f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Move();
            movementSpeed = 8f;
        }

        float x = Input.GetAxisRaw("Horizontal");
        Vector3 moves = transform.right * x;
        controller.Move(moves * movementSpeed * Time.deltaTime);

        float z = Input.GetAxisRaw("Vertical");
        Vector3 move = transform.forward * z;
        controller.Move(move * movementSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity);

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            Cursor.lockState = CursorLockMode.None;
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {

            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {  
            SoundManager.PlaySound("walk");
        }
        if (Input.GetKey(KeyCode.S))
        {  
            SoundManager.PlaySound("walk");
        }
        if (Input.GetKey(KeyCode.A))
        {
            SoundManager.PlaySound("walk");
        }
        if (Input.GetKey(KeyCode.D))
        {
            SoundManager.PlaySound("walk");
        }
    }
    public void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift)) 
        {
            anim.SetBool("Run", true);
            SoundManager.PlaySound("walk");
        }
        else
        {
            anim.SetBool("Run", false);
        }
    }
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Run", false);
            anim.SetBool("Jump", true);
            SoundManager.PlaySound("Jump");
        }
        else
        {
            anim.SetBool("Run", true);
            anim.SetBool("Jump", false);
        }
    }
    public void ResumeGame()
    {
        p.SetActive(false);
       // Player.SetActive(true);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }
}


