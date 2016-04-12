using UnityEngine;
using System.Collections;

public class VanishBlock : MonoBehaviour {
	public bool block;
	public GameObject parts;
	private float timeleft;
	void Start () {
		parts.SetActive(false);
		block = false;
	}
	
	void Update () {
		timeleft += Time.deltaTime;
		if (timeleft >= 5.0) {
			if(block == false){
				parts.SetActive(true);
				block = true;
			}
			else if(block == true){
				parts.SetActive(false);
				block = false;
			}
			Debug.Log(block);
			timeleft = 0.0f;
		}
	}
}
