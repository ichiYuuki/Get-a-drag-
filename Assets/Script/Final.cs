using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Final : MonoBehaviour {

	IEnumerator Start () {
		if(Application.loadedLevelName == "Ending") {
			yield return new WaitForSeconds(5);
			Application.LoadLevel("MainTitle");
		}

	}

	void Update(){

	}
}
