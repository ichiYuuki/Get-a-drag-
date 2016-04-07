using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClearZone : MonoBehaviour {

//	public Text clearText;
	public static bool gameClear;

	void Start(){
		gameClear = false;
	}

	void FixedUpdate () {
		if (gameClear) {
			Invoke ("CallStage", 4);
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Buyer") {
			gameClear = true;
		}
//		Debug.Log ("クリア");
	}

//	void CallTitle(){
//		if(Application.loadedLevelName == "test_ichi"){
//			Application.LoadLevel ("Title");
//		}
//	}

	void CallStage(){
		if(Application.loadedLevelName == "MainStage1"){
			Application.LoadLevel ("MainStage2");
		}
		if(Application.loadedLevelName == "test_ichi1"){
			Application.LoadLevel ("Title");
		}
		if (Application.loadedLevelName == "BondStage") {
			if (Player.ending == true){
				Application.LoadLevel ("BadEnding");
			} else {
				Application.LoadLevel ("Ending");
			}
		}
	}
}