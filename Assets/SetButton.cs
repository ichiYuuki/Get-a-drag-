using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetButton : MonoBehaviour {

	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Buyer");
	}
	
	// Update is called once per frame
	void Update () {
		if(!player){
			player = GameObject.FindWithTag("Buyer");
		}
	}

	public void OnClick(int num){
		player.GetComponent<Player> ().OnClick (num);
	}
}
