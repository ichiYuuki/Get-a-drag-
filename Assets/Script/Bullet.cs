﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	private GameObject player;
	private int speed = 10;

	void Start () {
		player = GameObject.FindWithTag ("Buyer");
		Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D> ();
		rigidbody2D.velocity = new Vector2 (speed * player.transform.localScale.x, rigidbody2D.velocity.y);
		Vector2 temp = transform.localScale;
		temp.x = player.transform.localScale.x;
		transform.localScale = temp;
		Destroy (gameObject, 5);
	}

	void OnTrigger2D(Collider col){
		if (col.gameObject.tag == "Enemy") {
			Destroy(gameObject);
		}
	}
	
}
