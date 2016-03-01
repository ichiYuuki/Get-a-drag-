using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	public int healPoint = 20;
	private Life life;

	void Start(){
		life = GameObject.FindGameObjectWithTag("HP").GetComponent<Life>();
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Buyer") {
			life .LifeUp(healPoint);
			Destroy(gameObject);
		}
	}
}
