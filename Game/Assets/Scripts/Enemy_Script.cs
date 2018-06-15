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

            if (Vector2.Distance(player.position, this.transform.position) < 8)
        {
            timer += 1;
            if (timer == 200)
            {
                AnimatorEnemy.SetInteger("Stage", 2);
                timer = 0;
            } else
            {
                AnimatorEnemy.SetInteger("Stage", 0);
            }

        }

        if ((Vector2.Distance(player.position, this.transform.position) > 8) && (Vector2.Distance(player.position, this.transform.position) < 15))
        {
            Vector2 velocity = new Vector2((transform.position.x - player.transform.position.x) * speed, (transform.position.y - player.transform.position.y) * speed);
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