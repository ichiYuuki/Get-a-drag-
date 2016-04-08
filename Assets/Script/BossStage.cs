using UnityEngine;
using System.Collections;

public class BossStage : MonoBehaviour {
	
	public GameObject Camera;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D c){
		if(c.gameObject.tag == "Buyer"){
			c.gameObject.GetComponent<Player>().SetLim(true);
			Camera.GetComponent<MainCamera> ().BattleStart();
		}

	}
}
