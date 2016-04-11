using UnityEngine;
using System.Collections;

public class VanishBlock : MonoBehaviour {
	public bool block;
	public GameObject vblock;
	public GameObject parts;

	void Start () {
		vblock = GameObject.Find ("VBrock");
		parts.SetActive(false);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Invoke ("CallFinal", 4);
	}
	void Vanish(){

	}
}
