using UnityEngine;
using System.Collections;

public class MoveFloor : MonoBehaviour {

	private Vector3 pos;
	private float time;
	public float dis = 2f;
	public float speed = 1f; 
	// Use this for initialization
	void Start () {
		pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		transform.position = new Vector3(pos.x + Mathf.Sin(90f * speed * time * Mathf.Deg2Rad) * dis, pos.y, pos.z);
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
