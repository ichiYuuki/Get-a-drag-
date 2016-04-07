using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CallEnding : MonoBehaviour {

	void FixedUpdate () {
		if (Stopwatch.clear == true) {
			Invoke ("CallFinal", 4);
		}
	}

	void CallFinal(){
		if (Application.loadedLevelName == "MainStage2") {
			if (Player.ending == true){
				Application.LoadLevel ("BadEnding");
			} else {
				Application.LoadLevel ("Ending");
			}
		}
	}

}
