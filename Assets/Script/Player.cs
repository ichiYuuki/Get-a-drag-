using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;

public class Player : MonoBehaviour {
	
	public float speed = 4f;
	public float jumpPower = 700;
	public LayerMask groundLayer;
	
	public GameObject explosion;
	public GameObject mainCamera;
	public GameObject bullet;
	//	public Life life;
	public Death death;
	public Energy energy;
	
	private Rigidbody2D rigidbody2D;
	private Animator anim;
	private bool isGrounded;
	private Renderer renderer;
	private bool gameClear = false;
	//	public Text clearText;
	
	public Text gameOverText;
	private bool gameOver = false;
	public Canvas canvas;
	//	Text time = GameObject.Find ("Time").GetComponent<Text> ();
	void Start () {
		
		anim = GetComponent<Animator> ();
		rigidbody2D = GetComponent<Rigidbody2D>();
		renderer = GetComponent<Renderer>();
		death = GetComponent<Death>();
		energy = GetComponent<Energy>();
		//		Text time = GameObject.Find ("Time").GetComponent<Text> ();
		//		GetComponent<Text> ().text = ((int)time).ToString();
	}
	
	void Update(){
		Text time = GameObject.Find ("Time").GetComponent<Text> ();
		string times = Convert.ToString(time.text);
		float sum;
		float.TryParse (times, out sum);
		//		Debug.Log(time.text);
		//		Debug.Log(times);
		//		Debug.Log(sum);
		isGrounded = Physics2D.Linecast (
			transform.position + transform.up * 1,
			transform.position - transform.up * 0.07f,
			groundLayer);
		
		if (!gameClear) {
			if (Input.GetKeyDown ("space")) {
				if (isGrounded) {
					if(sum == 0){
						anim.SetBool ("Dash", false);
						anim.SetTrigger ("Jump");
						isGrounded = false;
						rigidbody2D.AddForce (Vector2.up * jumpPower*2/3);
						
					}else{
						anim.SetBool ("Dash", false);
						anim.SetTrigger ("Jump");
						isGrounded = false;
						rigidbody2D.AddForce (Vector2.up * jumpPower);
					}
				}
			}
			float velY = rigidbody2D.velocity.y;
			bool isJumping = velY > 0.1f ? true : false;
			bool isFalling = velY < -0.1f ? true : false;
			anim.SetBool ("isJumping", isJumping);
			anim.SetBool ("isFalling", isFalling);
			
			if(!gameClear){
				if (Input.GetKeyDown ("z")) {
					anim.SetTrigger ("Shot");
					Instantiate (bullet, transform.position + new Vector3 (0f, 1.2f, 0f), transform.rotation);
				}
			}
		}
	}
	
	void FixedUpdate () {
		Text time = GameObject.Find ("Time").GetComponent<Text> ();
		string times = Convert.ToString(time.text);
		float sum;
		float.TryParse (times, out sum);
		if (!gameClear) {
			float x = Input.GetAxisRaw ("Horizontal");
			if (x != 0) {
				if(sum == 0){
					rigidbody2D.velocity = new Vector2 (x * speed/2, rigidbody2D.velocity.y);
					Vector2 temp = transform.localScale;
					temp.x = x;
					transform.localScale = temp;
					anim.SetBool ("Dash", true);
				}else{
					rigidbody2D.velocity = new Vector2 (x * speed, rigidbody2D.velocity.y);
					Vector2 temp = transform.localScale;
					temp.x = x;
					transform.localScale = temp;
					anim.SetBool ("Dash", true);
				}
				//				if (transform.position.x > mainCamera.transform.position.x - 4) {
				//					Vector3 cameraPos = mainCamera.transform.position;
				//					cameraPos.x = transform.position.x + 4;
				//					mainCamera.transform.position = cameraPos;
				//				}
				//
				//				Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
				//				Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
				//				Vector2 pos = transform.position;
				//				pos.x = Mathf.Clamp (pos.x, min.x + 0.5f, max.x);
				//
				//				transform.position = pos;
				
			} else {
				rigidbody2D.velocity = new Vector2 (0, rigidbody2D.velocity.y);
				anim.SetBool ("Dash", false);
			}
		} 
		else {
			anim.SetBool ("Dash", true);
			rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
		}
	}
	
	void OnCollisionEnter2D(Collision2D col){
		
		if (col.gameObject.tag == "Enemy") {
			Destroy(col.gameObject);
			if(gameOver == false){
				Instantiate(explosion,transform.position + new Vector3(0,1,0),transform.rotation);
			}
			GameOver();
		}
		if (col.gameObject.tag == "DestroyArea") {
			GameOver();
		}
	}
	
	
	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "ClearZone") {
			gameClear = true;
		}
		
	}
	
	public void GameOver(){
		//		gameOver = true;
		Destroy (gameObject);
		//		gameOverText.enabled = true;
		Debug.Log (canvas);
		foreach (Transform child in canvas.transform){
			if(child.name == "GameOver"){
				child.gameObject.SetActive(true);
			}
		}
	}
	
	
}
