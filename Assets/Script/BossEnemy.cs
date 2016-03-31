using UnityEngine;
using System.Collections;

public class BossEnemy : MonoBehaviour {

	public int hp = 100;
	public int attackPoint = 2; 
	private bool battleStart = false;
	public float shotDelay = 2f;
	public GameObject bullet;
	public GameObject[] shotPoint;
	public bool canMove = false;
	public int num = 0;
	float time = 0;
	Vector3 pos;

	// Use this for initialization
	IEnumerator Start () {
		pos = transform.position;

//		while(!battleStart){
//
//			yield return new WaitForEndOfFrame();
//		}

		while(true){
			for(int i = 0; i < shotPoint.Length; i++){
				shot (bullet, shotPoint[i].transform);
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
}
