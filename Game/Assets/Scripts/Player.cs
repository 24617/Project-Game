using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    

    public Rigidbody2D rb;
    public AudioSource JumpSound;

    public float speedwalk = 0.1f;
    public float jumpheight = 12f;
    public bool isgrounded = true;
    public bool isshooting = false;
    public float PlayerX = 0f;


    void Start()

    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        anim = GetComponent<Animator>();

    }

    void Update()
    {

        PlayerX = transform.position.x;

        //Moving Right
        if (Input.GetKey(KeyCode.D))
        {
            //Is he shooting?
            if (isshooting == false)
            {
                anim.SetInteger("State", 4);
                transform.Translate(speedwalk, 0, 0 * Time.deltaTime);
            }
    

            spriteRenderer.flipX = true;
            
        }

        //Moving Left
        if (Input.GetKey(KeyCode.A))
        {
            //Is he shooting?
            if (isshooting == false)
            {
                anim.SetInteger("State", 4);
                transform.Translate(-speedwalk, 0, 0 * Time.deltaTime);
            }


            spriteRenderer.flipX = false;
           
        }


        //jump
        if (isgrounded == true && Input.GetKeyDown(KeyCode.W))
        {

            {
                rb.velocity = new Vector3(0, jumpheight, 0);
                JumpSound.Play();
                anim.SetInteger("State", 2);

               

            }
        }

        //Standing Idle
        if (Input.anyKey == false)
        {
            anim.SetInteger("State", 1);

        }


        if (Input.GetKeyDown(KeyCode.V))
        {
            anim.SetInteger("State", 5);
        }
        
        //shoot
        if (Input.GetKeyDown(KeyCode.B))
        {
            anim.SetInteger("State", 3);
        }

       
    }


    void OnCollisionStay2D(Collision2D theCollision)
    {
        if (theCollision.gameObject.tag == "Platform" || theCollision.gameObject.tag == "Moving_Platform")
        {
            isgrounded = true;
            

        }
        if (theCollision.gameObject.tag == "Floor")
        {

            isgrounded = true;
           

        }

        if (theCollision.gameObject.tag == "Lava")
        {
            
            transform.position = new Vector3(-23, 2, 0);
            int newhealth = 3;
            HealthBar.health = newhealth;
            
           
        }

        if (theCollision.gameObject.tag == "enemy")
        {
            animator.SetBool("hit", true);
        }

    }


    void OnCollisionExit2D(Collision2D theCollision)
    {
        if (theCollision.gameObject.tag == "Platform" || theCollision.gameObject.tag == "Moving_Platform")
        {
            isgrounded = false;
            this.transform.parent = theCollision.transform;
           
       
        }
        if (theCollision.gameObject.tag == "Floor")
        {
            isgrounded = false;
            this.transform.parent = null;

        }

    }
    

  
}