using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {
	public GameObject player;
	public GameObject bossStage;
	public float speed = 3f;

	private Transform playerTrans;
	// Use this for initialization
	void Start () {
		playerTrans = player.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log (GetComponent<Camera>().WorldToViewportPoint(Vector3.zero));
		if (player) {
			Target();
			//bossステージ来たらifとboolか何かでBossBattle()に切り替え
		}
	}

	void Target(){
		transform.position = new Vector3 (player.transform.position.x, 5,-10);
		if (transform.position.x < -2) {
			transform.position = new Vector3(-2, 5, -10);
		}
		if (transform.position.x >= 100) {
			transform.position = new Vector3(100, 5, -10);
		}
		float playerHeight = playerTrans.position.y;
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
		}
		//カメラ遷移が終わったらボスの挙動スタート？
	}
}
