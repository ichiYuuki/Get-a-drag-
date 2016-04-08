using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {
	public GameObject player;
	public GameObject bossStage;
	public float speed = 3f;
	private bool bossBattleStart = false;
	public GameObject Boss;
	private bool bossStart = false;
	public GameObject startPoint;
	private float center;

//	private Transform playerTrans;
	// Use this for initialization
	void Start () {
//		playerTrans = player.GetComponent<Transform>();
		center = GetComponent<Camera> ().ScreenToWorldPoint (new Vector3 (Screen.width / 2, 0f, 0f)).x - GetComponent<Camera> ().ScreenToWorldPoint (Vector3.zero).x;
	}
	
	// Update is called once per frame
	void Update () {
		if (player) {
			if (!bossBattleStart) {
				Target ();
			} else {
				BossBattle ();
			}
		} else if (GameObject.FindWithTag ("Buyer")) {
			player = GameObject.FindWithTag ("Buyer");
		}
	}

	void Target(){
		center = GetComponent<Camera> ().ScreenToWorldPoint (new Vector3 (Screen.width / 2, 0f, 0f)).x - GetComponent<Camera> ().ScreenToWorldPoint (Vector3.zero).x;
		transform.position = new Vector3 (player.transform.position.x, 5,-10);
		if (transform.position.x < startPoint.transform.position.x + center) {
//			Debug.Log (center);
//			Debug.Log(transform.position.x + "," + (startPoint.transform.position.x + center));
			transform.position = new Vector3(startPoint.transform.position.x + center, 5, -10);
		}
		if (transform.position.x >= 100) {
			transform.position = new Vector3(100, 5, -10);
		}
		float playerHeight = player.transform.position.y;
		float currentCameraHeight = transform.position.y;
//		Debug.Log(playerHeight + "," + currentCameraHeight);
		float newHeight = Mathf.Lerp (currentCameraHeight, playerHeight, 0.5f);
		transform.position = new Vector3 (transform.position.x, newHeight, transform.position.z);
//		if (playerHeight > currentCameraHeight) {
//			transform.position = new Vector3 (transform.position.x, newHeight, transform.position.z);
//		}
//		if(playerHeight < currentCameraHeight){
//			transform.position = new Vector3 (transform.position.x, newHeight, transform.position.z);
//		}
	}

//	ボスステージの中心にカメラのｘ軸の中心を向けるやつ
	void BossBattle(){
		if (transform.position.x < bossStage.transform.position.x) {
			transform.position = transform.position + Vector3.right * speed * Time.deltaTime;
		} else if(!bossStart){
			Boss.GetComponent<BossEnemy> ().BattleStart ();
			bossStart = true;
		}
		//カメラ遷移が終わったらボスの挙動スタート？
	}

	public void BattleStart(){
		bossBattleStart = true;
	}
}
