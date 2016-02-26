using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 4f;
	private Rigidbody2D rigidbody2D;
	private Animator anim;

	void Start () {
		anim = GetComponent<Animator> ();
		rigidbody2D = GetComponent<Rigidbody2D>();
	}
	

	void FiexdUpdate () {
		float x = Input.GetAxisRaw("Horizontal");
		if (x != 0) {
			rigidbody2D.velocity = new Vector2 (x * speed, rigidbody2D.velocity.y);
			Vector2 temp = transform.localScale;
			temp.x = x;
			transform.localScale = temp;
			anim.SetBool ("Dash", true);
		} else {
			rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
			anim.SetBool ("Dash", false);
		}
	}
}
