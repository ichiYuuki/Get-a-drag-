using UnityEngine;
using System.Collections;

public class BGMSounds : MonoBehaviour {
//	public AudioClip[] bgmClip;
//	private AudioSource[] bgmScurce;

	public AudioClip bgmClip1;
	public AudioClip bgmClip2;
	public AudioClip bgmClip3;
	public bool bgmone;
	private AudioSource audioScurce;

	void Start () {
		bgmone = true;
		BossStage.bossArea = false;
		Debug.Log(BossStage.bossArea + "ステージ2 スタート Boss");
		Debug.Log (bgmone + "スタート");

//		bgmScurce = gameObject.GetComponents<AudioSource>();
		audioScurce = gameObject.GetComponent<AudioSource>();
		if(Application.loadedLevelName == "MainStage1"){
//			Debug.Log("ステージ1");
//			Debug.Log(audioScurce);
			audioScurce.clip = bgmClip1; 
			audioScurce.Play();
		}
		if(Application.loadedLevelName == "MainStage2"){
//			Debug.Log("ステージ2 スタート"+BossStage.bossArea);
			if (BossStage.bossArea == false){ 
				if(bgmone = true){
					Debug.Log("ステージ2 スタート BGM"+bgmone);
					Debug.Log("ステージ2 スタート Boss"+BossStage.bossArea);
//					Debug.Log(audioScurce);
					audioScurce.clip = bgmClip2; 
					audioScurce.Play();
				}
			}
		}
	}

	IEnumerator Bgm(){
		audioScurce.clip = bgmClip3; 
		audioScurce.Play ();
		yield return null;
	}

	void Update () {

		if (Application.loadedLevelName == "MainStage2") {
			Debug.Log (bgmone + "アップデート");
			if (BossStage.bossArea == true) {
				if(bgmone){

					Debug.Log ("ステージ2" + BossStage.bossArea);
					StartCoroutine("Bgm");
					bgmone = false;
				}
			} 
		}
	}
}
