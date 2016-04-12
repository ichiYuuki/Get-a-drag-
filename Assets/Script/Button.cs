using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class Button : MonoBehaviour {
	private GameObject _Start;
	private float _Step = 0.05f;
	public static bool check;

	private AudioSource[] seScorce;

	void Start(){
		this._Start = GameObject.Find ("Button");
		check = false;
		seScorce = gameObject.GetComponents<AudioSource>();
	}

	void Update(){
		if(Application.loadedLevelName == "MainTitle"){
			if (check) {
				float toColor = this._Start.GetComponent<Image> ().color.a;
				if (toColor < 0 || toColor > 1) {
					_Step = _Step * -1;
				}
				this._Start.GetComponent<Image> ().color = new Color (255, 255, 255, toColor + _Step);
			}
		}


	}
	public void ButtonPushu(){
		check = true;
		Application.LoadLevel("MainTitle");
//		Debug.Log ("test");

	}

	public void GameStart(){
		if(!check){
			int x = UnityEngine.Random.Range (0, seScorce.Length);
			seScorce [x].Play ();
		}
		check = true;
		StartCoroutine("change");
	}
	public void SETest(){
		if(!check){
			int x = UnityEngine.Random.Range (0, seScorce.Length);
			seScorce [x].Play ();
		}
	}

//	public void RandSE(params AudioClip[] clips){
//
//		int randomSe = UnityEngine.Random.Range (0,clips.Length);
//		seScorce.clip = clips[randomSe];
//		Debug.Log("プッシュされたよ！");
//	}
	public void RandSE(){
		
	}
	IEnumerator change(){
		yield return new WaitForSeconds(5);
		Application.LoadLevel("MainStage1");
		Application.LoadLevel("Description");
//		Application.LoadLevel("BondStage");
//		Application.LoadLevel("Description");
	}
}
