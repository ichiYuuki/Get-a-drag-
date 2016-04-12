using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {
	
	public int hp = 10; 
	public float speed = 4f;
	public float jumpPower = 700;
	public LayerMask groundLayer;
	
	public GameObject explosion;
	public GameObject mainCamera;
	public GameObject[] bullet = new GameObject[1];
	public int bulletNum = 0;
	public GameObject laser;
	bool canLaser = true;
	int laserCount = 1;
	public GameObject chargeEffect;
	private float chargeTime = 0; 

	//	public Life life;
	public Death death;
	public Energy energy;
	
	private Rigidbody2D rigidbody2D;
	private Animator anim;
	private bool isGrounded;
	private Renderer renderer;
	private bool gameClear = false;
	//	public Text clearText;
	private bool moveLim = false;
	
	public Text gameOverText;
	private bool gameOver = false;
	public Canvas canvas;
	public static bool ending;

	//	Text time = GameObject.Find ("Time").GetComponent<Text> ();
	void Start () {
		anim = GetComponent<Animator> ();
		rigidbody2D = GetComponent<Rigidbody2D>();
		renderer = GetComponent<Renderer>();
		death = GetComponent<Death>();
		energy = GetComponent<Energy>();
		ending = false;
		if(GameObject.Find("/Stage/BossStage/Floor")){
			Debug.Log("bbb");
			if(GameObject.Find("/Stage/BossStage/Floor").GetComponent<BossStage>().GetBool() == true){
				moveLim = true;
				Debug.Log("aaa");
			}
		}
		//		Text time = GameObject.Find ("Time").GetComponent<Text> ();
		//		GetComponent<Text> ().text = ((int)time).ToString();
//		GameObject.Find("BulletType").GetComponent<Text>().text = "Bullet:Type" + (bulletNum+1).ToString();
	}
	
	void Update(){
		isGrounded = Physics2D.Linecast (
			transform.position + transform.up * 1,
			transform.position - transform.up * 0.07f,
			groundLayer);
		

			if (Input.GetKeyDown ("space")) {
				if (isGrounded) {
					if(gameClear == true || Stopwatch.clear == true){
						jumpPower = 0;
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
		if (!gameClear && !Stopwatch.clear) {
			if (Input.GetKeyDown ("z") && canLaser) {
				anim.SetTrigger ("Shot");
				shot (bullet[bulletNum]);
				GetComponent<AudioSource>().Play();
			}

			if(Input.GetKey ("z")){
				chargeTime += Time.deltaTime;
				if(chargeTime >= 2f && laserCount > 0 && !GameObject.Find("ChargeEffect(Clone)")){
					Instantiate(chargeEffect,transform.position + new Vector3(0f,0.8f,0f),transform.rotation);
					ending =true;
//					Debug.Log(ending);
				}
			}
			
			if(Input.GetKeyUp ("z")){
				if(chargeTime >= 2f && laserCount > 0){
					shot (laser);
					laserCount -= 1;
				}
				chargeTime = 0;
			}

			if(Input.GetKeyDown ("x")){
				bulletNum += 1;
				if(bulletNum >= bullet.Length){
					bulletNum = 0;
				}
//				GameObject.Find("BulletType").GetComponent<Text>().text = "Bullet:Type" + (bulletNum+1).ToString();
			}


		}
	}
	
	void FixedUpdate () {
		if (!gameClear && !Stopwatch.clear) {
			float x = 0;
			if(Input.GetAxisRaw ("Horizontal") != 0){
				x = Input.GetAxisRaw ("Horizontal");
			}
			if(CrossPlatformInputManager.GetAxisRaw("Horizontal") != 0){
				x = CrossPlatformInputManager.GetAxisRaw("Horizontal");
			}
			if(x >= 0.5f){
				x = 1f;
			}else if(x <= -0.5f){
				x = -1f;
			}else{
				x = 0;
			}

			if(moveLim){
				MoveLimit();
			}

			if (x != 0) {
				rigidbody2D.velocity = new Vector2 (x * speed, rigidbody2D.velocity.y);
				Vector2 temp = transform.localScale;
				temp.x = x;
				transform.localScale = temp;
				anim.SetBool ("Dash", true);
			}
//			if (transform.position.x > mainCamera.transform.position.x - 4) {
//				Vector3 cameraPos = mainCamera.transform.position;
//				cameraPos.x = transform.position.x + 4;
//				mainCamera.transform.position = cameraPos;
//			}
//
//			Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
//			Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
//			Vector2 pos = transform.position;
//			pos.x = Mathf.Clamp (pos.x, min.x + 0.5f, max.x);
//
//			transform.position = pos;

			else {
				rigidbody2D.velocity = new Vector2 (0, rigidbody2D.velocity.y);
				anim.SetBool ("Dash", false);
			}
		} 
		else {
			anim.SetBool ("Dash", false);
			rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
		}
	}
	
	void OnCollisionEnter2D(Collision2D col){
		if (!gameClear) {
			if (col.gameObject.tag == "Enemy") {
                //hp -= 1;
                Debug.Log("衝突");
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
//				GameOver ();
			}

		}
	}
	
	
	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "ClearZone") {
			gameClear = true;
		}
	}

	void MoveLimit(){

		// 画面左下のワールド座標をビューポートから取得
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		
		// 画面右上のワールド座標をビューポートから取得
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

		Vector2 pos = transform.position;
		
		// プレイヤーの位置が画面内に収まるように制限をかける
		pos.x = Mathf.Clamp (pos.x, min.x + 0.5f, max.x - 0.5f);

		// 制限をかけた値をプレイヤーの位置とする
		transform.position = pos;
	}
	
	public void GameOver(){

		Destroy (gameObject);
		Instantiate (explosion, transform.position + new Vector3 (0, 1, 0), transform.rotation);
//
//		Debug.Log (canvas);
//		foreach (Transform child in canvas.transform){
//			if(child.name == "GameOver"){
//				child.gameObject.SetActive(true);
//			}
//		}
	}

	void shot(GameObject obj){
		Instantiate (obj, transform.position + transform.up + transform.right * transform.localScale.x, transform.rotation);
	}

	public void CanShotLaser(bool bo){
		canLaser = bo;
	}

	public void SetLim(bool bo){
		moveLim = bo;
	}

	public void OnClick(int i){
		switch(i){
		case 0:
			anim.SetTrigger ("Shot");
			shot (bullet[bulletNum]);
			GetComponent<AudioSource>().Play();
			break;
		case 1:
			if (isGrounded) {
				if(gameClear == true || Stopwatch.clear == true){
					jumpPower = 0;
				}else{
					anim.SetBool ("Dash", false);
					anim.SetTrigger ("Jump");
					isGrounded = false;
					rigidbody2D.AddForce (Vector2.up * jumpPower);
				}
			}
			break;
		case 2:
			bulletNum += 1;
			if(bulletNum >= bullet.Length){
				bulletNum = 0;
			}
			break;
		}
	}

	public void Charge(){
		chargeTime += Time.deltaTime;
		if(laserCount > 0 && !GameObject.Find("ChargeEffect(Clone)")){
			Instantiate(chargeEffect,transform.position + new Vector3(0f,0.8f,0f),transform.rotation);
			ending =true;
//			Debug.Log(ending);
		}
	}

	public void ShotLaser(){
		if(laserCount > 0){
			shot (laser);
			laserCount -= 1;
		}
		chargeTime = 0;
	}
}
