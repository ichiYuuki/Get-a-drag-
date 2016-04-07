using UnityEngine;
using System.Collections;

public class ChargeEffect : MonoBehaviour {

	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Buyer");
		transform.parent = player.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.Find ("Laser") || GameObject.Find ("Laser(Clone)")){
			Destroy(gameObject);
		}
	}
}
