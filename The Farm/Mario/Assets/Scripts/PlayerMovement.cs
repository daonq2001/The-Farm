using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private bool left, right, jump, ground;

    public float speed;
    public float jumpForce;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    
    void FixedUpdate()
    {
        if(left)
        {
            rb.gravityScale = 10f;
            rb.velocity = new Vector2(-speed, 0f);
            anim.SetFloat("Speed", 1f);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        } else if(right)
        {
            rb.gravityScale = 10f;
            rb.velocity = new Vector2(speed, 0f);
            anim.SetFloat("Speed", 1f);
            transform.localScale = new Vector3(1f, 1f, 1f);
        } else if(jump && ground)
        {
            rb.velocity = new Vector2(0f, jumpForce);
            anim.SetBool("Jump", true);
            ground = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            anim.SetBool("Death", true);
            gameObject.GetComponent<Player>().Death = true;
        }
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Tree"))
        {
            ground = true;
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
        StartCoroutine(JumpDelay());
    }

    IEnumerator JumpDelay()
    {
        rb.gravityScale = 0f;
        jump = true;
        yield return new WaitForSeconds(0.4f);
        rb.gravityScale = 10f;
        jump = false;
        rb.velocity = Vector2.zero;
        anim.SetBool("Jump", false);
    }

    public void JumpUp()
    {
        rb.gravityScale = 10f;
        jump = false;
        rb.velocity = Vector2.zero;
        anim.SetBool("Jump", false);
    }
}
