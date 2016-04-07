using UnityEngine;
using System.Collections;

public class MoveFloor : MonoBehaviour {

	private Vector3 pos;
	private float time;
	public float speed = 1f;
	public bool horizontal = true; //横
	public float disX = 2f;
	public float startAngleX = 0f;
	public bool Vertical = true; //縦
	public float disY = 2f;
	public float startAngleY = 0f;

	// Use this for initialization
	void Start () {
		pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

	void Move(){
		time += Time.deltaTime;
		float angleX = 0;
		float angleY = 0;
		if(horizontal){
			angleX = Mathf.Sin(90f * speed * time * Mathf.Deg2Rad + startAngleX) * disX;
		}
		if (Vertical) {
			angleY = Mathf.Sin(90f * speed * time * Mathf.Deg2Rad + startAngleY) * disY;
		}

		transform.position = new Vector3(pos.x + angleX, pos.y + angleY, pos.z);
	}

	void OnTriggerEnter2D(Collider2D c){
		if(c.gameObject.tag == "Buyer"){
			c.gameObject.transform.parent = transform;
		}

	}

	void OnTriggerExit2D(Collider2D c){
		if(c.gameObject.tag == "Buyer"){
			c.gameObject.transform.parent = null;
		}

	}
}
