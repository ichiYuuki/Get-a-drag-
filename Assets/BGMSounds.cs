using UnityEngine;
using System.Collections;

public class BGMSounds : MonoBehaviour {
	private AudioSource[] bgmScorce;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Stage によって曲を変える
		if(Application.loadedLevelName == "MainStage1"){
			bgmScorce[0].Play();
		}
		if(Application.loadedLevelName == "MainStage1"){
			bgmScorce[1].Play();
		}
	}
}
