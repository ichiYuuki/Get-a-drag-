using UnityEngine;
using System.Collections;

public class Bezier : MonoBehaviour {
	Vector2 p0;
	public Vector2 p1 = new Vector2(0,1);
	public Vector2 p2 = new Vector2(1,1);
	Vector2 p3;

	GameObject player;
	GameObject enemy;
	GameObject[] enemys;
	
//	public int power = 2;
	public float speed = 3;
	
	float time = 0;

	private int enemyLayer = 11;
	private int bossLayer = 18;
	private bool straight = false;
	private Camera mCamera;
	private float drc = 0;

	private Vector2 b;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Buyer");
		drc = player.transform.localScale.x;
		mCamera = GameObject.FindWithTag ("MainCamera").GetComponent<Camera> ();
		Vector2 leftbottom = mCamera.ScreenToWorldPoint (Vector2.zero);
		Vector2 righttop = mCamera.ScreenToWorldPoint (new Vector2(Screen.width, Screen.height));
		p0 = transform.position;
		p1 = p0 + p1;
		if (GameObject.FindWithTag ("Enemy")) {
//			enemy = GameObject.FindWithTag ("Enemy");
			enemys = GameObject.FindGameObjectsWithTag ("Enemy");
			for(int i = 0; i < enemys.Length; i++){
				if(enemys[i].layer == enemyLayer || enemys[i].layer == bossLayer){
					if(i == 0 || Vector2.Distance(p0, enemy.transform.position ) >= Vector2.Distance(p0,enemys[i].transform.position)){
						enemy = enemys[i];
					}
				}
			}


			if(!enemy || enemy.transform.position.x > righttop.x +1f || enemy.transform.position.y > righttop.y +1f
			   || enemy.transform.position.x < leftbottom.x -1f || enemy.transform.position.x < leftbottom.y -1f){
				straight = true;
			}

			p2 = p0 + p2;
			p3 = enemy.transform.position + new Vector3(0,0.2f,0);
		} else {
//			p2 = p0 + new Vector2 (p2.x * player.transform.localScale.x, p2.y);
//			p3 = p0 + new Vector2(10 * player.transform.localScale.x ,1);
			straight = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

		if (straight) {

			b = p0 + Vector2.right * time  * 10f * speed * drc;
		} else {
			Vector2 m0 = Cal (p0, p1, time);
			Vector2 m1 = Cal (p1, p2, time);
			Vector2 m2 = Cal (p2, p3, time);
			
			Vector2 b0 = Cal (m0, m1, time);
			Vector2 b1 = Cal (m1, m2, time);
			
			b = Cal (b0, b1, time);
		}

		transform.position = b;
	}
	
	Vector2 Cal(Vector2 v1, Vector2 v2, float t){
		return v1 + (v2 - v1).normalized * Vector2.Distance(v1, v2) * t * speed;
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Buyer"){
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