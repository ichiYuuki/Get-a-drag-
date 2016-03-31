using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
public class GameResult : Stopwatch {
	private float highScre;
	private float highScre00;
	//	List<int> highScre = new List<int> ();
	
	public Text clearTime;
	public Text bestTime;
	public GameObject parts;
	
	void Start () {
		if(Application.loadedLevelName == "test_ichi"){
			if (PlayerPrefs.HasKey ("HighScre_a")) {
				highScre = PlayerPrefs.GetFloat ("HighScre_a");
			} else {
				highScre = 1000;
			} 
		}

		if(Application.loadedLevelName == "test_ichi1"){
			if (PlayerPrefs.HasKey ("HighScre_b")) {
				highScre00 = PlayerPrefs.GetFloat ("HighScre_b");
			} else {
				highScre00 = 1000;
			} 
		}
		Debug.Log (highScre + " StarthighScre");
	}
	
	
	void Update () {
		if (ClearZone.gameClear == true) {
			parts.SetActive(true);
			float Min = Mathf.FloorToInt(Stopwatch.MinCount);
			float Sec = Mathf.FloorToInt(Stopwatch.SecCount);
			float DecCount = Mathf.FloorToInt(Stopwatch.DecCount);
			float result = Min * 60 + Sec + DecCount /100;
			String Secs = String.Format ("{0:D2}", (int)Sec);
			String DecCounts = String.Format("{0:D2}",(int)DecCount);
			clearTime.text = "ClearTime:  " + Min + ":" + Secs + "." + DecCounts;

			if(Application.loadedLevelName == "test_ichi"){
				bestTime.text = "BestTime:   " + keisan(highScre);//keisan(highs)
			}
			if(Application.loadedLevelName == "test_ichi"){
				if(highScre > result){
					PlayerPrefs.SetFloat("HighScre_a",result);
				}
			}
			Debug.Log(Secs + "Secs");
			Debug.Log(clearTime.text);
			Debug.Log(highScre + "highScre");

			if(Application.loadedLevelName == "test_ichi1"){
				bestTime.text = "BestTime:   " + keisan(highScre00);
			}
			if(Application.loadedLevelName == "test_ichi1"){
				if(highScre00 > result){
					PlayerPrefs.SetFloat("HighScre_b", result);
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
		Debug.Log(String.Format("{0:D2}",(int)k) + " debug K");
//		Debug.Log(g);
		return (int)h + ":" + K + "." + G;

	}
	
	//	public void OnRetry(){
	//		Application.LoadLevel ("ichikawa");
	//	}
}
