using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovimento : MonoBehaviour
{
    public static float move;
    [SerializeField] private float movespeed = 6f;

    [SerializeField] private bool jumping; 
    [SerializeField] private float jumpspeed = 8f;

    [SerializeField] private bool isGrounded;
    public Transform feetposition;
    public float sizeRadius;
    public LayerMask whatGround;

    [SerializeField] private bool ataquebool;
    public float ataquerangr = 0.5f;
    public Transform ataquepoint;
    public LayerMask enemylayer;

    public bool moveR, moveL;

    private Rigidbody2D rb;
    SpriteRenderer sprite;

    Animator animationplayer; 
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animationplayer = GetComponent<Animator>();
    }

    
    void Update()
    {
        //reconhecer chao
        //isGrounded = Physics2D.OverlapCircle(feetposition.position, sizeRadius, whatGround);
        print(isGrounded);


        move = Input.GetAxis("Horizontal"); 
        
        

        //flipagem de movimento 
        if(move < 0)
        {
            sprite.flipX = true;
        }
        else if(move >0)
        {
            sprite.flipX = false;
        }

        //input do pulo
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumping = true;
            isGrounded = false;
        }

       
        //ataque personagem
        if (Input.GetButtonDown("Fire3"))
        {
            ataca();
        
        
        }

        if(ataquebool == true && isGrounded)
        {
            move = 0;  
        }

        //animaçao pulo
        if (isGrounded)
        {
            animationplayer.SetBool("jumpup", false);

            if(rb.velocity.x !=0 && move != 0)
            {
                animationplayer.SetBool("walk", true);  
            }
            else
            {
                animationplayer.SetBool("walk", false);
            }
        }
        else
        {
             if( Mathf.Abs(rb.velocity.y) > 0)
            {
                animationplayer.SetBool("walk", false);
                animationplayer.SetBool("jumpup", true);
                

            }


        }



    }


    public void ataca()
    {
        ataquebool = true;

        if (isGrounded) 
        {
            animationplayer.SetBool("atacando", true);
        }
        else
        {
            animationplayer.SetBool("atacando", false);
        }

        Collider2D[] hitEnimies = Physics2D.OverlapCircleAll(ataquepoint.position, ataquerangr, enemylayer);
        
        foreach(Collider2D enemy in hitEnimies)
        {
            enemy.GetComponent<inimigo2vida>().DanoNoInimigo(20);
        }


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(ataquepoint.position, ataquerangr);
    }

    void FixedUpdate()
    {
        //touch
        if(moveR == true)
        {
            
            rb.velocity = new Vector2(movespeed, rb.velocity.y);
            sprite.flipX = false;
           

           

        }
        else if(moveL == true)
        {
            
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);
            sprite.flipX = true;

            
        }
        else
        {
            //teclado
          
            rb.velocity = new Vector2(move * movespeed, rb.velocity.y);
        }
        

        //pulo
        if(jumping)
        {
            rb.AddForce(new Vector2(0f, jumpspeed), ForceMode2D.Impulse);

            jumping = false;
            isGrounded = false;
        }

    }
    private void OnCollisionEnter2D(Collision2D col)
    {
         if(col.gameObject.layer == 7)
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision col)
    {
        if (col.gameObject.layer == 7)
        {
            isGrounded = false;
        }
    }


    void EndAnimationATK()
    {
        animationplayer.SetBool("atacando", false);

        ataquebool = false;

    }

    public void Jump()
    {
        rb.velocity = Vector2.up * jumpspeed;
    }


    public void MoveRTrue()
    { 
        moveR = true;
        
    }
    public void MoveRFalse()
    {
        moveR = false;
    }
    public void MoveLTrue()
    {
        moveL = true;
    }
    public void MoveLFalse()
    {
        moveL = false;
    }
 
}
