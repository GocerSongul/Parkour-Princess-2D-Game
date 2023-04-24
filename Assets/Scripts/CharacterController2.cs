using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2 : MonoBehaviour
{
    // Start is called before the first frame update
    private bool jump;
    private float jumpForce=7.0f;
    private Rigidbody2D rigidbody2D;
    private Animator anim;
    private bool grounded = true;
    private float speed = 3.0f;
    private bool moving;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        anim= GetComponent<Animator>();//caching
    }
    void Start()
    {
        rigidbody2D= GetComponent<Rigidbody2D>();
        spriteRenderer= GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {
        if (rigidbody2D.velocity != Vector2.zero) //hareket ediyorsa
        {
            moving= true;
        }
        else
        {
            moving = false;
        }
        rigidbody2D.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), rigidbody2D.velocity.y);

        if (jump==true)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
            jump= false;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(grounded==true && Input.GetAxis("Horizontal")!=0.0f)
        {
            
            if (Input.GetAxis("Horizontal")>0.1f)
            {
                spriteRenderer.flipX = false;
            }

            else if (Input.GetAxis("Horizontal") < -0.1f)
            {
                spriteRenderer.flipX = true;
            }
            anim.SetFloat("speed", 1.0f);
        }
        else if(grounded == true)
        {
            anim.SetFloat("speed", 0.0f);
        }
        if(grounded==true && Input.GetKey(KeyCode.W)) 
        {
            jump = true;
            grounded= false;
            anim.SetTrigger("jump");
            anim.SetBool("grounded", false);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision) // çarpma yaþandýðýnda çalýþýr
    {
        if (collision.gameObject.tag == "zemin")
        {
            anim.SetBool("grounded",true);
            grounded = true; //grounded trueyken zýplayabiliytouz sadece
        }
    }
}
