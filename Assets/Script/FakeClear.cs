using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FakeClear : MonoBehaviour {

	public Text clearText;
	private bool gameClear;
	
	void FixedUpdate () {
		if (gameClear) {
			clearText.enabled = true;
			Invoke ("CallFake", 4);
		}
	}
	
	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Buyer") {
			gameClear = true;
		}
	}
	
	void CallFake(){
		Application.LoadLevel ("Fake");
	}

}
