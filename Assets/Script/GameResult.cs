using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
public class GameResult : MonoBehaviour {
	private float highScre01;
	private float highScre02;
	private float bondScre;
	//	List<int> highScre = new List<int> ();
	
	public Text clearTime;
	public Text bestTime;
	public GameObject parts;
	public GameObject Boss;
	
	void Start () {
		Boss = GameObject.Find ("BossHone");
		ClearZone.gameClear = false;
		if(Application.loadedLevelName == "MainStage1"){
			if (PlayerPrefs.HasKey ("HighScre_01")) {
				highScre01 = PlayerPrefs.GetFloat ("HighScre_01");
			} else {
				highScre01 = 5999;
			} 
		}

		if(Application.loadedLevelName == "MainStage2"){
			if (PlayerPrefs.HasKey ("HighScre_02")) {
				highScre02 = PlayerPrefs.GetFloat ("HighScre_02");
			} else {
				highScre02 = 5999;
			} 
		}

		if(Application.loadedLevelName == "BondStage"){
			if (PlayerPrefs.HasKey ("BondScre")) {
				bondScre = PlayerPrefs.GetFloat ("BondScre");
			} else {
				bondScre = 5999;
			} 
		}
//		Debug.Log (highScre + " StarthighScre");

	}
	
	
	void Update () {
		Debug.Log (ClearZone.gameClear);
		if (ClearZone.gameClear == true || Stopwatch.clear == true) {
			parts.SetActive(true);
			float Min = Mathf.FloorToInt(Stopwatch.MinCount);
			float Sec = Mathf.FloorToInt(Stopwatch.SecCount);
			float DecCount = Mathf.FloorToInt(Stopwatch.DecCount);
			float result = Min * 60 + Sec + DecCount /100;
			String Secs = String.Format ("{0:D2}", (int)Sec);
			String DecCounts = String.Format("{0:D2}",(int)DecCount);
			clearTime.text = "ClearTime:  " + Min + ":" + Secs + "." + DecCounts;

			if(Application.loadedLevelName == "BondStage"){
				bestTime.text = "BestTime:   " + keisan(bondScre);//keisan(highs)
			}
			if(Application.loadedLevelName == "BondStage"){
				if(bondScre > result){
					PlayerPrefs.SetFloat("BondStage",result);
				}
			}
//			Debug.Log(Secs + "Secs");
//			Debug.Log(clearTime.text);
//			Debug.Log(highScre + "highScre");

			if(Application.loadedLevelName == "MainStage1"){
				bestTime.text = "BestTime:   " + keisan(highScre01);
			}
			if(Application.loadedLevelName == "MainStage1"){
				if(highScre01 > result){
					PlayerPrefs.SetFloat("HighScre_01", result);
				}
			}

			if(Application.loadedLevelName == "MainStage2"){
				bestTime.text = "BestTime:   " + keisan(highScre02);//keisan(highs)
			}
			if(Application.loadedLevelName == "MainStage2"){
				if(highScre02 > result){
					PlayerPrefs.SetFloat("HighScre_02",result);
				}
			}
		}
//				PlayerPrefs.DeleteAll();//データ初期化
//				Debug.Log(Application.loadedLevelName);
//				Debug.Log (PlayerPrefs.GetInt ("HighScre00"));
	}
	String keisan(float aaa){
		double h = aaa / 60;
		double k = aaa % 60;
		double g = (aaa % 1 ) * 100;
//		String H = String.Format ("{0:D2}", (int)h);
		String K = String.Format ("{0:D2}", (int)k);
		String G = String.Format ("{0:D2}", (int)g);
//		Debug.Log(String.Format("{0:D2}",(int)k) + " debug K");
//		Debug.Log(g);
		return (int)h + ":" + K + "." + G;

	}
	
	public void OnRetry(){
		if(!Button.check){
			PlayerPrefs.DeleteAll();
			Debug.Log("データ初期化");
		}
	}
}
