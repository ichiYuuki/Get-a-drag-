using UnityEngine;
using System.Collections;

public class BGMSounds : MonoBehaviour {
//	public AudioClip[] bgmClip;
//	private AudioSource[] bgmScurce;

	public AudioClip bgmClip1;
	public AudioClip bgmClip2;
	public AudioClip bgmClip3;

	private AudioSource audioScurce1;
	private AudioSource audioScurce2;
	private AudioSource audioScurce3;

	void Start () {
//		bgmScurce = gameObject.GetComponents<AudioSource>();
		audioScurce1 = gameObject.GetComponent<AudioSource>();
		audioScurce2 = gameObject.GetComponent<AudioSource>();
		audioScurce3 = gameObject.GetComponent<AudioSource>();

		audioScurce1.clip = bgmClip1; 
		audioScurce2.clip = bgmClip2; 
		audioScurce3.clip = bgmClip3; 

		if(Application.loadedLevelName == "MainStage1"){
			Debug.Log("ステージ1");
			audioScurce1.Play();
		}else if(Application.loadedLevelName == "MainStage2"){
//			bgmScurce[0].Stop();
			if(BossStage.bossArea){
				Debug.Log("ステージ2" + BossStage.bossArea);
//				bgmScurce[1].Stop();
				audioScurce2.Play();
			}else{
				Debug.Log("ステージ2Boss");
//				bgmScurce[2].Play();
				audioScurce3.Play();
			}
		}
	}

	void Update () {



	}
}
