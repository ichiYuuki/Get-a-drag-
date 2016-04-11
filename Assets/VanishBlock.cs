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
		if (timeleft >= 5.0) {
			Debug.Log(timeleft + "出す");
			Leave();
//			Vanish();
			timeleft = 0.0f;
		}
		else if (timeleft >= 10.0) {
			Debug.Log(timeleft + "消す");
//				Leave();
				Vanish();
			timeleft = 0.0f;
		}


	}
	public void SwitchActive(){
		parts.SetActive(true);
		parts.SetActive(false);
	}
	void Vanish(){
		parts.SetActive(false);
	}
	void Leave(){
		parts.SetActive(true);
	}
}
