using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;

public class Fake : MonoBehaviour {
	public Text gameOverText;
	private bool gameOver;
	public Canvas canvas;

	IEnumerator Start () {
		yield return new WaitForSeconds(3);
		gameOver = true;
		foreach (Transform child in canvas.transform){
			if(child.name == "GameOver"){
				child.gameObject.SetActive(true);
			}
		}
	}

}
