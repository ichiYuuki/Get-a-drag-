using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;

public class Bullet : MonoBehaviour {

	private GameObject player;
	private int speed = 10;
	public int power = 2;

	void Start () {
		player = GameObject.FindWithTag ("Buyer");
		Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D> ();
		rigidbody2D.velocity = new Vector2 (speed * player.transform.localScale.x, rigidbody2D.velocity.y);
		Vector2 temp = transform.localScale;
		temp.x = player.transform.localScale.x;
		transform.localScale = temp;
		Destroy (gameObject, 5);
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Buyer" || col.gameObject.tag == "Bullet"){
			return;
		}

		Destroy(gameObject);
//		
//		if (col.gameObject.tag == "Enemy") {
//			Destroy(gameObject);
//		}
//		if (col.gameObject.tag == "BreakBlock") {
//			Destroy(gameObject);
//		}
	}
	
}
