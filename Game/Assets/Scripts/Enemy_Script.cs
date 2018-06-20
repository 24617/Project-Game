using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Script : MonoBehaviour {

    Animator AnimatorEnemy;
    private SpriteRenderer spriteRenderer;

    public Transform player;
    int timer = 150;
    int enemyHealth = 3;
    Vector2 velocity;
    float speed = 0.5f;

    public bool isshooting = false;
    public bool iJustShot = false;
    public float PlayerX = 0f;
    public GameObject shot;
    private float nextFire;



    private void Start()
    {
        AnimatorEnemy = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }


    void Update () {

        if (player.position.x <= this.transform.position.x)
        {
            spriteRenderer.flipX = false;
        } else
        {
            spriteRenderer.flipX = true;
        }


        if (enemyHealth == 0)
        {
            AnimatorEnemy.SetInteger("Stage", 4);
        }

        if (Vector2.Distance(player.position, this.transform.position) < 8 && isshooting == false)
        {
            timer += 1;
            if (timer == 200)
            {
                AnimatorEnemy.SetInteger("Stage", 2);
                iJustShot = true;
                isshooting = true;
                timer = 0;
            }

        }

        if (iJustShot == true)
        {
            nextFire += 1;
            if (nextFire == 100)
            {
                nextFire = 0;
                iJustShot = false;
            }
            if ((nextFire == 0) || (nextFire >= 25))
            {
                isshooting = false;
                AnimatorEnemy.SetInteger("Stage", 0);
            }
            if (nextFire == 40)
            {
                if (spriteRenderer.flipX == false)
                {
                    Quaternion spawnpoint = new Quaternion(0, 0, 180, 1);
                    Instantiate(shot, this.transform.position, spawnpoint);
                }
                if (spriteRenderer.flipX == true)
                {
                    Quaternion spawnpoint = new Quaternion(0, 0, 0, 1);
                    Instantiate(shot, this.transform.position, spawnpoint);
                }
            }
        }


        if ((Vector2.Distance(player.position, this.transform.position) > 8) && (Vector2.Distance(player.position, this.transform.position) < 15))
        {
            
                Vector2 velocity = new Vector2((transform.position.x - player.transform.position.x) * speed, 0);
                GetComponent<Rigidbody2D>().velocity = -velocity;
                AnimatorEnemy.SetInteger("Stage", 1);
            
        }

        if (Vector2.Distance(player.position, this.transform.position) >   15)
        {
            AnimatorEnemy.SetInteger("Stage", 0);
        }



    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            AnimatorEnemy.SetInteger("Stage", 3);
            enemyHealth -= 1;
        }
    }
}