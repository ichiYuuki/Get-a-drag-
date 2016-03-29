using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Energy : MonoBehaviour {
	private float time = 20;
//	public GameObject player;
	void Start () {
		GetComponent<Text> ().text = ((int)time).ToString();
	}

	void Update () {
		//time -= Time.deltaTime;
		if (time < 0)time = 0;
		GetComponent<Text> ().text = ((int)time).ToString ();
	}

	public void Zero(float time){
		time = 0;
		GetComponent<Text> ().text = ((int)time).ToString ();
	} 

	public void EnergyUp(float ht){
		time += (ht);
		if (time > 60)time = 60;
		GetComponent<Text> ().text = ((int)time).ToString ();
	}

//	void EnergyDown(){
//		rt.sizeDelta -= new Vector2 (0, time);
//	}
}
