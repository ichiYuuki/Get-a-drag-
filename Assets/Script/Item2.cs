using UnityEngine;
using System.Collections;

public class Item2 : MonoBehaviour {

	public float healtime = 5;
	private Energy energy;

	void Start () {
//		energy = GameObject.FindGameObjectWithTag ("Time").GetComponent<Energy> ();
	}
	
//	void OnCollisionEnter2D(Collision2D col){
//		if (col.gameObject.tag == "Buyer") {
//			energy.EnergyUp(healtime);
//			Destroy(gameObject);
//		}
//	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Buyer") {
			energy.EnergyUp(healtime);
			Destroy(gameObject);
		}
	}
}
