using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shoot : MonoBehaviour {

    public float bulletspeed;
    private float timer;

    // Update is called once per frame
    void Update()
    {


        transform.Translate(bulletspeed, 0, 0);

        timer += Time.deltaTime;
        if (timer >= 2)
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

    }
}
