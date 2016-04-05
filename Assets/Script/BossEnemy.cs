using UnityEngine;
using System.Collections;

public class BossEnemy : MonoBehaviour {

	public int hp = 100;
	public int attackPoint = 2; 
	private bool battleStart = false;
	public float shotDelay = 2f;
	public GameObject bullet;
	public GameObject[] shotPoint;
	public GameObject[] homingShot;
	public GameObject target;
	public GameObject explosion;
	public bool canMove = false;
	public int num = 0;
	float time = 0;
	Vector3 pos;
	bool canHit = false;

	// Use this for initialization
	IEnumerator Start () {
		pos = transform.position;

		while(!battleStart){

			yield return new WaitForEndOfFrame();
		}

		canHit = true;
		yield return new WaitForSeconds(1f);

		while(true){
			for(int i = 0; i < shotPoint.Length; i++){
				shot (bullet, shotPoint[i].transform);
			}
			if(GameObject.FindWithTag("Buyer")){
				for(int i = 0; i < homingShot.Length; i++){
					homingShot[i].transform.eulerAngles = new Vector3(0,0,Homing(homingShot[i].transform.position, target.transform.position));

					shot (bullet, homingShot[i].transform);
					homingShot[i].transform.eulerAngles = Vector3.zero;
				}
			}

			yield return new WaitForSeconds(shotDelay);
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (canMove) {
			Move (0);
		}
	}

	void shot(GameObject obj, Transform tf){
		bullet.GetComponent<EnemyBullet> ().power = attackPoint;
		Instantiate (obj, tf.position, tf.rotation);
	}

	void Move(int num){
		time += Time.deltaTime;

		switch(num){
		case 0:
			transform.position = new Vector3(pos.x, pos.y + Mathf.Sin(90 * time * Mathf.Deg2Rad), pos.z);
			break;
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (canHit){
			if (col.tag == "Bullet") {
				int bulletPower = col.gameObject.GetComponent<Bullet> ().power;
				hp -= bulletPower;
				if (hp <= 0) {
					Destroy (gameObject);
					Instantiate (explosion, transform.position, transform.rotation);
				}
			}
		}
	}

	float Homing(Vector3 p1, Vector3 p2){
		float dx = p1.x - p2.x;
		float dy = p1.y - (p2.y + 0.5f);
		float rad = Mathf.Atan2(dy, dx);
		return rad * Mathf.Rad2Deg;
	}

	public void BattleStart(){
		battleStart = true;
	}

	public void DestroyEnemy(){
		if (canHit) {
			Destroy (gameObject);
			Instantiate (explosion, transform.position, transform.rotation);
		}
	}
}
