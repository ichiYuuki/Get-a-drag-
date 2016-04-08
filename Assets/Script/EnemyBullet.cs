using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {

//	private GameObject player;
	public int speed = 10;
	public int power = 0;
	public float destroyTime = 5f;
    private GameObject player;
    private GameObject Lives;

    void Start () {
//		player = GameObject.FindWithTag ("Enemy");

		GetComponent<Rigidbody2D>().velocity = transform.right * -1 * speed;
		Destroy (gameObject, destroyTime);
	}
	
	void OnTriggerEnter2D(Collider2D col){
		
		Destroy(gameObject);

		if (col.gameObject.tag == "Buyer") {
			Destroy(gameObject);
			int hp = col.gameObject.GetComponent<Player>().hp;
			//hp  -= power;
			//if(hp <= 0){
   //             player = GameObject.Find("UnityChan");                
   //             Destroy(player);
   //             Lives = GameObject.Find("Lives");
   //             var zannki = Lives.GetComponent<RemainingLives>();
   //             zannki.LifeCounterDown();
   //         }
            col.gameObject.GetComponent<Player>().hp = hp;			
		}
		if (col.gameObject.tag == "BreakBlock") {
			Destroy(gameObject);
		}
	}
	
}
