using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {

//	private GameObject player;
	public int speed = 10;
	public int power = 3;
	public float destroyTime = 5f;
	
	void Start () {
//		player = GameObject.FindWithTag ("Enemy");

		GetComponent<Rigidbody2D>().velocity = transform.right * -1 * speed;
		Destroy (gameObject, destroyTime);
	}
	
	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag == "Buyer") {
			Destroy(gameObject);
			int hp = col.gameObject.GetComponent<Player>().hp;
			hp  -= power;
			if(hp <= 0){
				col.gameObject.GetComponent<Player>().GameOver();
			}else{
				col.gameObject.GetComponent<Player>().hp = hp;
			}
		}
//		if (col.gameObject.tag == "BreakBlock") {
//			Destroy(gameObject);
//		}
	}
	
}
