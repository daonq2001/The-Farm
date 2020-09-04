using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 move;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("Horizontal", move.x);
        anim.SetFloat("Vertical", move.y);

        anim.SetFloat("Speed", move.magnitude);

        if(move.x == 1f || move.x == -1f)
        {
            anim.SetFloat("FaceX", move.x);
            anim.SetFloat("FaceY", 0f);
        }
        if(move.y == 1f || move.y == -1f)
        {
            anim.SetFloat("FaceY", move.y);
            anim.SetFloat("FaceX", 0f);
        }

        rb.MovePosition(rb.position + speed * move * Time.fixedDeltaTime);
    }
}
