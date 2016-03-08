using UnityEngine;
using System.Collections;

public class CallStage1 : MonoBehaviour {

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Application.LoadLevel("Stage1");
		}
	}
}
