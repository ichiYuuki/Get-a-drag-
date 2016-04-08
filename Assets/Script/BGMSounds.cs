using UnityEngine;
using System.Collections;

public class BGMSounds : MonoBehaviour {
//	public AudioClip[] bgmClip;
//	private AudioSource[] bgmScurce;

	public AudioClip bgmClip1;
	public AudioClip bgmClip2;
	public AudioClip bgmClip3;

	private AudioSource audioScurce;

	void Start () {
//		bgmScurce = gameObject.GetComponents<AudioSource>();
		audioScurce = gameObject.GetComponent<AudioSource>();
		if(Application.loadedLevelName == "MainStage1"){
			Debug.Log("ステージ1");
			Debug.Log(audioScurce);
			audioScurce.clip = bgmClip1; 
			audioScurce.Play();
		}
		if(Application.loadedLevelName == "MainStage2"){
			if (BossStage.bossArea) 
			Debug.Log("ステージ2 スタート"+BossStage.bossArea);
			Debug.Log(audioScurce);
			audioScurce.clip = bgmClip2; 
			audioScurce.Play();
		}

	}

	void Update () {
		if (Application.loadedLevelName == "MainStage2") {
			if (BossStage.bossArea == true) {
				Debug.Log ("ステージ2" + BossStage.bossArea);
				//bgmScurce[1].Stop();
				audioScurce.clip = bgmClip3; 
				audioScurce.Play ();

			} 
//			else {
//				audioScurce.clip = bgmClip3; 
//				audioScurce.Play ();
//			}
		}

	}
}
