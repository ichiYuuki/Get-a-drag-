using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
public class GameResult : Stopwatch {
	private float highScre;
	private int highScre00;
	//	List<int> highScre = new List<int> ();
	
	public Text clearTime;
	public Text bestTime;
	public GameObject parts;
	
	void Start () {
//		if (PlayerPrefs.HasKey ("HighScre_a")) {
//			highScre = PlayerPrefs.GetFloat ("HighScre_a");
//		} 
//		//		if (PlayerPrefs.HasKey ("HighScre00")) {
//		//			highScre00 = PlayerPrefs.GetInt ("HighScre00");
//		//		}
//		else {
//			//			double a = 59;
//			//			double b = 59;
//			//			double c = 99;
//			highScre = 4000;
//			highScre00 = 999;
//		}
//		//		highScre = "59:59.99";
//		//		Debug.Log(highScre + "ハイスコア");
	}
	
	// Update is called once per frame
	void Update () {
		if (ClearZone.gameClear == true) {
			parts.SetActive(true);
			float Min = Mathf.FloorToInt(Stopwatch.MinCount);
			float Sec = Mathf.FloorToInt(Stopwatch.SecCount);
			float DecCount = Mathf.FloorToInt(Stopwatch.DecCount);
			float result = Min * 60 + Sec + DecCount /100;
			clearTime.text = "ClearTime   " + Min + ":" + Sec + "." + DecCount;

//			if(Application.loadedLevelName == "test_ichi"){
//				bestTime.text = "BestTime:   " + keisan(highScre);//keisan(highs)
//			}
//			if(Application.loadedLevelName == "test_ichi"){
//				if(highScre > result){
//					PlayerPrefs.SetFloat("HighScre_a",result);
//				}
//				
//			}
			Debug.Log(keisan(highScre) + "keisan");
			Debug.Log(clearTime.text);
			
			//			if(Application.loadedLevelName == "TestStage"){
			//				bestTime.text = "BestTime:" + highScre00;
			//			}
			//			if(Application.loadedLevelName == "TestStage"){
			//				if(highScre00 > result){
			//					PlayerPrefs.SetInt("HighScre00", result);
			//				}
			//			}
		}
		//		Debug.Log(Application.loadedLevelName);
		//		Debug.Log (PlayerPrefs.GetInt ("HighScre00"));
	}
	String keisan(float aaa){
		double g = aaa % 100;
		double k = aaa;
		double h = k / 60;
		return (int)h + ":" + (int)k + "." + (int)g;
	}
	
	//	public void OnRetry(){
	//		Application.LoadLevel ("ichikawa");
	//	}
}
