using UnityEngine;
using System.Collections;

public class VanishBlock : MonoBehaviour {
	public bool block;
//	public GameObject vblock;
	public GameObject parts;

	private float timeleft;
	void Start () {
//		vblock = GameObject.Find ("VBrock");
		parts.SetActive(false);
	}

	void Update () {
//		Invoke ("Leave", 5);
//		Invoke ("Vanish", 10);
		timeleft += Time.deltaTime;
		if (timeleft >= 10.0) {
			Debug.Log(timeleft + "読み込み");
			Leave();
//			Vanish();
//			Invoke ("Leave", 5 + timeleft);
//			Invoke ("Vanish", 10 + timeleft);
			timeleft = 0.0f;
		}


	}
	void Vanish(){
		parts.SetActive(false);
	}
	void Leave(){
		parts.SetActive(true);
	}
}
