using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [HideInInspector]
    public bool die = false;
    public float speed = 5f;
    private bool quaylai = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!die)
        {
            if (quaylai)
            {
                rb.velocity = new Vector2(speed * Time.fixedDeltaTime, 0f);
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else
            {
                rb.velocity = new Vector2(-speed * Time.fixedDeltaTime, 0f);
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
            anim.SetBool("Died", true);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Point"))
        {
            if (quaylai)
            {
                quaylai = false;
            }
            else
            {
                quaylai = true;
            }
        }
    }
}
