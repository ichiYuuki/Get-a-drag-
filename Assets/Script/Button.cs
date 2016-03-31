using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class Button : MonoBehaviour {
	private GameObject _Start;
	private float _Step = 0.05f;
	private bool check;
	void Start(){
		this._Start = GameObject.Find ("Button");
		check = false;

	}

	void Update(){
		if (check) {
			float toColor = this._Start.GetComponent<Image> ().color.a;
			if (toColor < 0 || toColor > 1) {
				_Step = _Step * -1;
			}
			this._Start.GetComponent<Image> ().color = new Color (255, 255, 255, toColor + _Step);
		}

	}
	public void ButtonPushu(){
		Application.LoadLevel("Title");
	}

	public void GameStart(){
		if(Application.loadedLevelName == "MainTitle"){
			check = true;
//			Application.LoadLevel("MainStage1");
//			Invoke("MainTitle",3);
			StartCoroutine("change");
		}
	}

	IEnumerator change(){
		yield return new WaitForSeconds(5);
		Application.LoadLevel("MainStage1");
	}
}
