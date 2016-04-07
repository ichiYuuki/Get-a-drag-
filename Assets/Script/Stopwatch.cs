using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Diagnostics;
using System;

public class Stopwatch : MonoBehaviour {
	
	public float timeCount = 0;
	public static float DecCount;
	public static int MinCount;
	public static int SecCount;
	public GameObject player;
	public GameObject boss;
	public bool clear;

	void Start () {
		//シーンごとにタイムリセットに必要
		DecCount = 0;
		MinCount = 0;
		SecCount = 0;
		player = GameObject.Find ("UnityChan");
		boss = GameObject.Find ("BossHone");
		clear = false;

		UnityEngine.Debug.Log(Application.loadedLevelName);
	}

	void Update () {
		Text Min = GameObject.Find ("Min").GetComponent<Text> ();
		Text Sec = GameObject.Find ("Sec").GetComponent<Text> ();
		Text Decimal = GameObject.Find ("Decimal").GetComponent<Text> ();

		if(Application.loadedLevelName == "MainStage2"){
			if (boss == null){
				clear = true;
				UnityEngine.Debug.Log("スタート");
			}
		}

		//ゲームクリアしてなければカウントアップ
		if (player == true) {
			if (clear == false  && ClearZone.gameClear == false) {
				timeCount += 1.0f * Time.deltaTime;
				DecCount = timeCount * 100;
			}
		} 
		if (timeCount >= 0.96) {
			timeCount = 0;
			SecCount = SecCount + 1;
		} else if (SecCount >= 60) {
			SecCount = 0;
			MinCount = MinCount + 1;
		}
		
		if (MinCount < 10) {
			Min.text = string.Format ("0{0}", MinCount.ToString ());

		} else {
			Min.text = string.Format ("{0}", MinCount.ToString ());
		}
		if (SecCount < 10) {
			Sec.text = string.Format ("0{0}", SecCount.ToString ());
		} else {
			Sec.text = string.Format ("{0}", SecCount.ToString ());
		}
		if (DecCount >= 0 && DecCount < 9.9) {
			Decimal.text = string.Format ("0{0}", DecCount.ToString ("f0"));
		} else if (DecCount < 99.9) {
			Decimal.text = string.Format ("{0}", DecCount.ToString ("f0"));
		}

	}

}
