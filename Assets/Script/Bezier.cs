using UnityEngine;
using System.Collections;

public class Bezier : MonoBehaviour {
	Vector2 p0;
	public Vector2 p1 = new Vector2(0,1);
	public Vector2 p2 = new Vector2(1,1);
	Vector2 p3;

	GameObject player;
	GameObject enemy;
	
	public int power = 2;
	float speed = 2;
	
	float time = 0;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Buyer");
		p0 = player.transform.position;
		p1 = p0 + p1;
		if (GameObject.FindWithTag ("Enemy")) {
			enemy = GameObject.FindWithTag ("Enemy");
			p2 = p0 + p2;
			p3 = enemy.transform.position;
		} else {
			p2 = p0 + new Vector2 (p2.x * player.transform.localScale.x, p2.y);
			p3 = p0 + new Vector2(10 * player.transform.localScale.x ,1);
		}


	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		
		Vector2 m0 = Cal (p0,p1,time);
		Vector2 m1 = Cal (p1,p2,time);
		Vector2 m2 = Cal (p2,p3,time);
		
		Vector2 b0 = Cal (m0, m1, time);
		Vector2 b1 = Cal (m1, m2, time);
		
		Vector2 b = Cal(b0,b1,time);
		
		transform.position = b;

	}
	
	Vector2 Cal(Vector2 v1, Vector2 v2, float t){
		return v1 + (v2 - v1).normalized * Vector2.Distance(v1, v2) * t * speed;
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