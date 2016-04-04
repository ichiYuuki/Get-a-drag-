using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Death : MonoBehaviour {

	private Explosion explosion;
	private GameObject gameEnd;
	private GameObject player;

	void Start(){
		gameEnd = GameObject.Find("GameEnd");
		player = GameObject.Find("UnityChan");
		explosion = GetComponent<Explosion>();
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Buyer") {
			explosion.PlayerExplosion();

		}
	}
}
