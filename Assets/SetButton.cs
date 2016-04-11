using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetButton : MonoBehaviour {

	private GameObject player;
	float chargeTime = 0;
	bool startTimer = false;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Buyer");
	}
	
	// Update is called once per frame
	void Update () {
		if(!player){
			player = GameObject.FindWithTag("Buyer");
		}
		if(startTimer){
			chargeTime += Time.deltaTime;
			if(chargeTime >= 2f){
				player.GetComponent<Player> ().Charge();
			}
		}
	}

	public void OnClick(int num){
		player.GetComponent<Player> ().OnClick (num);
	}

	public void PushDown(){
		startTimer = true;
	}

	public void PushUp(){
		Debug.Log (chargeTime);
		if (chargeTime >= 2f) {
			player.GetComponent<Player> ().ShotLaser();
		}
		startTimer = false;
		chargeTime = 0;
	}
}
