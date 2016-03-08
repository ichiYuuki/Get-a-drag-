using UnityEngine;
using System.Collections;

public class BreakBlock : MonoBehaviour {


	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Buyer") {
			Destroy(gameObject);
		}
		if (col.gameObject.tag == "Bullet") {
			Destroy(gameObject);
		}
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Bullet") {
			Destroy(gameObject);
		}
		
	}
}
