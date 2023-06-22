using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class jump : MonoBehaviour
{
    Rigidbody2D rb;
    private Animator anim;
    float movespeed;
    float dirX;
    bool facingRight = true;
    Vector3 localScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
        movespeed = 5f;
    }

    
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal") * movespeed;

        if (Input.GetButtonDown("Jump") && rb.velocity.y == 0)
        {
            rb.AddForce(Vector2.up * 700f);
        }
        if (Mathf.Abs(dirX) > 0 && rb.velocity.y == 0)
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }
         
        if(rb.velocity.y == 0)
        {
            anim.SetBool("jumpup", false);
        }

        if(rb.velocity.y > -3)
        {
            anim.SetBool("jumpup", true);
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, rb.velocity.y);
    }

    private void LateUpdate()
    {
        if(dirX > 0)
        {
            facingRight = true;
        }

        else if(dirX < 0)
        {
            facingRight = false;
        }

        if(((facingRight) && (localScale.x <0)) || ((!facingRight) && (localScale.x > 0)))
        {
            localScale.x *= -1;
        }

        transform.localScale = localScale;

    }



}
