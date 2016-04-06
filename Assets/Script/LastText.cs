using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LastText : MonoBehaviour {
	public GameObject canvas;
	public GameObject lastText;

	// Use this for initialization
	void Start () {
		canvas = GameObject.Find ("TextCanvas");
		lastText = GameObject.Find ("LastText");
		lastText.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(canvas == null){
			lastText.SetActive(true);
			Invoke ("MainTitle", 4);
//			Debug.Log("nullだよ");
		}

	}
	void MainTitle(){
		Application.LoadLevel ("MainTitle");
	}
}
