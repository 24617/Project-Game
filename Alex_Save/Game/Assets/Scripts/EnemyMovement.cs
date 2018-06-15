using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public Transform player;

	void Start () {
		
	}
	

	void Update () {
		if (Vector2.Distance(player.position, this.transform.position) < 10)
        {
            Debug.Log("omg");
        }
	}
}
