using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;

public class Bullet : MonoBehaviour {

	private GameObject player;
	private int speed = 10;

	void Start () {
		Text time = GameObject.Find ("Time").GetComponent<Text> ();
		string times = Convert.ToString(time.text);
		float sum;
		float.TryParse (times, out sum);
		if (sum == 0) {
			player = GameObject.FindWithTag ("Buyer");
			Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D> ();
			rigidbody2D.velocity = new Vector2 (speed * player.transform.localScale.x, rigidbody2D.velocity.y);
			Vector2 temp = transform.localScale;
			temp.x = player.transform.localScale.x;
			transform.localScale = temp;
			Destroy (gameObject, 1/2);
		} else {
			player = GameObject.FindWithTag ("Buyer");
			Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D> ();
			rigidbody2D.velocity = new Vector2 (speed * player.transform.localScale.x, rigidbody2D.velocity.y);
			Vector2 temp = transform.localScale;
			temp.x = player.transform.localScale.x;
			transform.localScale = temp;
			Destroy (gameObject, 5);
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Enemy") {
			Destroy(gameObject);
		}
	}
	
}
