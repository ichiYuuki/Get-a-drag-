using UnityEngine;
using System.Collections;

public class BossStage : MonoBehaviour {
	
	public GameObject Camera;
	public static bool bossArea;
	// Use this for initialization
	void Start () {
		bossArea = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D c){
		if(c.gameObject.tag == "Buyer"){
			c.gameObject.GetComponent<Player>().SetLim(true);
			Camera.GetComponent<MainCamera> ().BattleStart();
			bossArea = true;
		}

	}
}
