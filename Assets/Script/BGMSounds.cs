using UnityEngine;
using System.Collections;

public class BGMSounds : MonoBehaviour {
	private AudioSource[] bgmScurce;

	void Start () {
		bgmScurce = gameObject.GetComponents<AudioSource>();
	}

	void Update () {
		bgmScurce[0].Play();
//		if(Application.loadedLevelName == "MainStage1"){
//			Debug.Log("ステージ1" + bgmScurce[0].name);
//			bgmScurce[0].Play();
//		}else if(Application.loadedLevelName == "MainStage2"){
//			bgmScurce[0].Stop();
//			if(BossStage.bossArea){
//				Debug.Log("ステージ2" + BossStage.bossArea);
//				bgmScurce[1].Stop();
//			}else{
//				Debug.Log("ステージ2Boss");
//				bgmScurce[2].Play();
//			}
//		}
	}
}
