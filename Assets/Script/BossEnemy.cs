using UnityEngine;
using System.Collections;

public class BossEnemy : MonoBehaviour {

	private bool battleStart = false;
	public float shotDelay = 2f;
	public GameObject bullet;
	public GameObject[] shotPoint;
	public bool canMove = false;
	public int num = 0;

	// Use this for initialization
	IEnumerator Start () {

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

	}

	void shot(GameObject obj, Transform tf){
		Instantiate (obj, tf.position, tf.rotation);
	}

	void Move(int num){
		switch(num){
		case 0:
			break;
		}
	}
}
