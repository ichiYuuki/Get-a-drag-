using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClearZone : MonoBehaviour {

	public Text clearText;
	private bool gameClear;
	
	void FixedUpdate () {
		if (gameClear) {
			clearText.enabled = true;
			Invoke ("CallStage2", 4);
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Buyer") {
			gameClear = true;
		}
	}

	void CallTitle(){
		Application.LoadLevel ("Title");
	}

	void CallStage2(){
		Application.LoadLevel ("Stage2");
	}
}
