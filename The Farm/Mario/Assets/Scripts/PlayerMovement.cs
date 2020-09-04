using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private bool left, right, jump;

    public float speed;
    public float jumpForce;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(left)
        {
            rb.velocity = new Vector2(-speed, 0f);
            anim.SetFloat("Speed", 1f);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        } else if(right)
        {
            rb.velocity = new Vector2(speed, 0f);
            anim.SetFloat("Speed", 1f);
            transform.localScale = new Vector3(1f, 1f, 1f);
        } else if(jump)
        {
            rb.velocity = new Vector2(0f, jumpForce);
            anim.SetBool("Jump", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            anim.SetBool("Death", true);
        }
    }

    
    public void Left()
    {
        left = true;
    }

    public void LeftUp()
    {
        left = false;
        rb.velocity = Vector2.zero;
        anim.SetFloat("Speed", 0f);
    }

    public void Right()
    {
        right = true;
    }

    public void RightUp()
    {
        right = false;
        rb.velocity = Vector2.zero;
        anim.SetFloat("Speed", 0f);
    }

    public void Jump()
    {
        jump = true;
    }

    public void JumpUp()
    {
        jump = false;
        rb.velocity = Vector2.zero;
        anim.SetBool("Jump", false);
    }
}
