using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {
	public GameObject player;

	private Transform playerTrans;
	// Use this for initialization
	void Start () {
		playerTrans = player.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		if (player) {
			
			transform.position = new Vector3 (player.transform.position.x, 5,-10);
			if (transform.position.x < -2) {
				transform.position = new Vector3(-2, 5, -10);
			}
			if (transform.position.x >= 100) {
				transform.position = new Vector3(100, 5, -10);
			}
			float playerHeight = playerTrans.position.y;
			float currentCameraHeight = transform.position.y;
			float newHeight = Mathf.Lerp (currentCameraHeight, playerHeight, 0.5f);
			if (playerHeight > currentCameraHeight) {
				transform.position = new Vector3 (transform.position.x, newHeight, transform.position.z);
			}
			if(playerHeight < currentCameraHeight){
				transform.position = new Vector3 (transform.position.x, newHeight, transform.position.z);
			}
		}

	}
}
