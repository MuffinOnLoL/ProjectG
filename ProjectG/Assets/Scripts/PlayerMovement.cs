//Colin Klein - PlayerMovement.cs
//August 22nd, 2023
//This script gives the player basic controls over the player object


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalInput;
    private Rigidbody2D body;
    public int speed;
    public int jumpPower;
    public float maxDistance;
    public Vector3 boxSize;
    public LayerMask layer;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        body.velocity = new Vector2(body.velocity.x, body.velocity.y * 0.5f);
    }
    void Update()
    {
        Run();
        Jump();
        Debug.Log(IsGrounded());

    }
    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        Run();
        Jump();
    }

    private void Run()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    private void Jump() //Announces the Jump() function that is able to be called throughout the script
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower); //The player is moved on the x axis as normal and moved on the y axis based on the jumpPower value that has been assigned
        }
        if (Input.GetButtonUp("Jump"))
        {
            body.velocity = new Vector2(body.velocity.x, body.velocity.y * 0.5f);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color=Color.red;
        Gizmos.DrawCube(transform.position-transform.up*maxDistance,boxSize);
    }
    private bool IsGrounded()
    {
        if(Physics2D.BoxCast(transform.position,boxSize,0,-transform.up,maxDistance,layer))
        {
            return true;
        }
        else{
            return false;
        }
    }

}
