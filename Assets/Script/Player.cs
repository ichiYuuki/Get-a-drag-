using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;

public class Player : MonoBehaviour {
	
	public int hp = 10; 
	public float speed = 4f;
	public float jumpPower = 700;
	public LayerMask groundLayer;
	
	public GameObject explosion;
	public GameObject mainCamera;
	public GameObject[] bullet = new GameObject[3];
	private int bulletNum = 0;

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
		isGrounded = Physics2D.Linecast (
			transform.position + transform.up * 1,
			transform.position - transform.up * 0.07f,
			groundLayer);
		
		if (!gameClear) {
			if (Input.GetKeyDown ("space")) {
				if (isGrounded) {
					anim.SetBool ("Dash", false);
					anim.SetTrigger ("Jump");
					isGrounded = false;
					rigidbody2D.AddForce (Vector2.up * jumpPower);
				}
			}
			float velY = rigidbody2D.velocity.y;
			bool isJumping = velY > 0.1f ? true : false;
			bool isFalling = velY < -0.1f ? true : false;
			anim.SetBool ("isJumping", isJumping);
			anim.SetBool ("isFalling", isFalling);
			
//			if(!gameClear){
			if (Input.GetKeyDown ("z")) {
				anim.SetTrigger ("Shot");
				shot (bullet[bulletNum]);
				GetComponent<AudioSource>().Play();
			}

//			if(なんかのボタン押されたらのif文){
//				bulletNum += 1;
//				if(bulletNum >= bullet.Length){
//					bulletNum = 0;
//				}
//			}

		}
	}
	
	void FixedUpdate () {
		if (!gameClear) {
			float x = Input.GetAxisRaw ("Horizontal");
			if (x != 0) {
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
			else {
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
		if (!gameClear) {
			if (col.gameObject.tag == "Enemy") {
				hp -= 1;
				if(hp > 0){
					return;
				}
				
				Destroy (col.gameObject);
				if (gameOver == false) {
					//					Instantiate (explosion, transform.position + new Vector3 (0, 1, 0), transform.rotation);
				}
				GameOver ();
			}
			if (col.gameObject.tag == "DestroyArea") {
				GameOver ();
			}
		}
	}
	
	
	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "ClearZone") {
			gameClear = true;
		}
	}

//	void MoveLimit(){
//		// 画面左下のワールド座標をビューポートから取得
//		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
//		
//		// 画面右上のワールド座標をビューポートから取得
//		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
//		
//		// プレイヤーの座標を取得
//		Vector2 pos = transform.position;
//		
//		speed = spaceship.speed;
//		
//		// 移動量を加える
//		pos += direction  * speed * Time.deltaTime;
//		
//		// プレイヤーの位置が画面内に収まるように制限をかける
//		pos.x = Mathf.Clamp (pos.x, min.x, max.x);
//		pos.y = Mathf.Clamp (pos.y, min.y, max.y);
//		
//		// 制限をかけた値をプレイヤーの位置とする
//		transform.position = pos;
//	}
	
	public void GameOver(){
		//		gameOver = true;
		Destroy (gameObject);
		Instantiate (explosion, transform.position + new Vector3 (0, 1, 0), transform.rotation);
		//		gameOverText.enabled = true;
		Debug.Log (canvas);
		foreach (Transform child in canvas.transform){
			if(child.name == "GameOver"){
				child.gameObject.SetActive(true);
			}
		}
	}

	void shot(GameObject obj){
		Instantiate (obj, transform.position + new Vector3 (0f, 1.0f, 0f), transform.rotation);
	}
}
