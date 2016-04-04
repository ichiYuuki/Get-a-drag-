using UnityEngine;
using System.Collections;

public class Enemy1 : MonoBehaviour {

	public int hp = 3;
	Rigidbody2D rigidbody2D;
	public int speed = -3;
	public GameObject explosion;
	public GameObject item;
	public int attackPoint = 10;
	private Life life;
	private const string MAIN_CAMERA_NAME = "MainCamera";
	private bool _isRendered = false;

	public GameObject bullet;

	//shot
	public float shotDelay = 1f;
	public bool canShot = false;
	private bool shotbool = false;

	IEnumerator Start () {
		rigidbody2D = GetComponent<Rigidbody2D>();

		while(shotbool == false){

			yield return new WaitForEndOfFrame();
		}

		while (canShot == true) {
			Shot ();
			
			yield return new WaitForSeconds (shotDelay);
		}


//		life = GameObject.FindGameObjectWithTag ("HP").GetComponent<Life> ();
	}

	void Update () {
		if(_isRendered){
			rigidbody2D.velocity = new Vector2 (speed, rigidbody2D.velocity.y);
		}

		if(gameObject.transform.position.y < Camera.main.transform.position.y -8 || gameObject.transform.position.x < Camera.main.transform.position.x -10){
			Destroy(gameObject);
		}

	}

	void OnTriggerEnter2D (Collider2D col){
		if(_isRendered){
			if(col.tag == "Bullet"){
				int bulletPower = col.gameObject.GetComponent<Bullet>().power;
				hp -= bulletPower;
				if(hp <= 0){
					Destroy(gameObject);
					Instantiate(explosion, transform.position, transform.rotation);
				}
				if(col.tag == "DestroyArea"){
					Destroy(gameObject);
				}

//				if(Random.Range(0,4) == 0){
//					Instantiate(item, transform.position, transform.rotation);
//				}
			}
		}

	}

//	void OnCollisionEnter2D(Collision2D col){
//		if (col.gameObject.tag == "Buyer") {
//			life.LifeDown(attackPoint);
//		}
//	}

	void OnWillRenderObject(){
		if (Camera.current.tag == MAIN_CAMERA_NAME) {
			_isRendered = true;
			shotbool = true;
		}
	}

	void Shot(){
//		AudioSource.Play();
		bullet.GetComponent<EnemyBullet> ().power = attackPoint;
		Instantiate (bullet, transform.position, transform.rotation);
	}

	public void DestroyEnemy(){
		Destroy (gameObject);
		Instantiate (explosion, transform.position, transform.rotation);
	}
}
