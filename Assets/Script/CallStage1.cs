using UnityEngine;
using System.Collections;

public class CallStage1 : MonoBehaviour {

	void FixedUpdate () {
		Invoke ("CallStage", 4);
	}
	void CallStage(){
		if(Application.loadedLevelName == "Description"){
			Application.LoadLevel ("Description2");
		}
		if(Application.loadedLevelName == "tDescription2"){
			Application.LoadLevel ("MainStage1");
		}
	}
}
