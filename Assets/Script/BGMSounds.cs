using UnityEngine;
using System.Collections;

public class BGMSounds : MonoBehaviour {
	public AudioClip bgmClip1;
	public AudioClip bgmClip2;
	private AudioSource audioScurce1;
	private AudioSource audioScurce2;
	void Start () {
		audioScurce1 = gameObject.GetComponent<AudioSource>();
		audioScurce2 = gameObject.GetComponent<AudioSource>();


		if(Application.loadedLevelName == "MainStage1"){
//			Debug.Log("ステージ1");
			audioScurce1.clip = bgmClip1; 
			audioScurce1.Play();
		}
		if(Application.loadedLevelName == "MainStage2"){
			audioScurce2.clip = bgmClip2; 
			audioScurce2.Play();
//			Debug.Log("ステージ2");
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
