using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {
	
	float timer = 0.0f;
	float timerDelay = 0.0f;
	float effectDisplayTime = 0f;
	public float range = 6.0f;
	Ray shotRay;
	RaycastHit2D shotHit;  
	ParticleSystem beamParticle;
	LineRenderer lineRenderer;
	GameObject player;
	float i = 0.25f;
	public float LaserWidth = 0.9f;
	bool destroy = false;
	// Use this for initialization
	void Start () {
		beamParticle = GetComponent<ParticleSystem> ();
		effectDisplayTime = beamParticle.duration + beamParticle.startLifetime -1f;
		lineRenderer = GetComponent<LineRenderer> ();
		lineRenderer.enabled = false;
		player = GameObject.FindWithTag ("Player");
		Vector2 pos = transform.position;
		pos.y += 0.20f;
		transform.position = pos;
//		transform.parent = player.transform;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		
		if (lineRenderer.enabled == false && destroy == false) {

		}
		
		timerDelay += Time.deltaTime;
		if(lineRenderer.enabled == true && timerDelay >= 0.02f && i < LaserWidth && timer < effectDisplayTime && destroy == false){
			i += 0.05f;
			showLine(i);
			timerDelay = 0;
		}

		showLine (i);

		if (timer >= effectDisplayTime + 0.3f && lineRenderer.enabled == true && destroy == false) {
			timerDelay += Time.deltaTime;
			if(timerDelay >= 0.02f ){
				i -= 0.05f;
				showLine(i);
				if(i <= 0.25f){
					lineRenderer.enabled = false;
					lineRenderer.SetWidth (i, i);
					timer = 0;
					destroy = true;
				}
				timerDelay = 0;
			}
		}

		if (destroy == true ) {
			lineRenderer.enabled = false;
			//Destroy(this.gameObject);
		}
	}
	
	private void shot(){
		timer = 0f;
		beamParticle.Stop ();
		beamParticle.Play ();
		lineRenderer.enabled = true;
		lineRenderer.SetWidth (i, i);
		lineRenderer.SetPosition (0, transform.position);
		shotRay.origin = transform.position;
		shotRay.direction = transform.up;
		
		int layerMask = LayerMask.GetMask("Enemy");
		shotHit = Physics2D.Raycast ((Vector2)shotRay.origin, (Vector2)shotRay.direction, range, layerMask);
		if (shotHit.collider) {
//			Destroy(shotHit.collider.gameObject);
//			shotHit.collider.gameObject.GetComponent<Enemy>().Destroy();
		}
		layerMask = LayerMask.GetMask("Bullet (Enemy)");
		shotHit = Physics2D.Raycast ((Vector2)shotRay.origin, (Vector2)shotRay.direction, range, layerMask);
		if (shotHit.collider) {
			//Destroy(shotHit.collider.gameObject);
			Destroy(shotHit.collider.gameObject);
		}

//		if(Physics.Raycast(shotRay , out shotHit , range , layerMask)){
//			// hit 
//			Destroy(shotHit.collider.gameObject);
//		}

		lineRenderer.SetPosition(1 , shotRay.origin + shotRay.direction * range);
		
		
	}
	

//	private void disableEffect(){
//		beamParticle.Stop ();
//		//lineRenderer.enabled = false;
//		for (float i = 1; i > 0.0f; i -= 0.1f) {
//			lineRenderer.SetWidth (i, i);
//
//		}
//	}

	private void showLine(float wid){
		lineRenderer.SetWidth (wid, wid);
		lineRenderer.SetPosition (0, transform.position);
		shotRay.origin = transform.position;
		shotRay.direction = transform.up;
		
		int layerMask = LayerMask.GetMask("Enemy");
		shotHit = Physics2D.Raycast ((Vector2)shotRay.origin, (Vector2)shotRay.direction, range, layerMask);
		if (shotHit.collider) {
			//Destroy(shotHit.collider.gameObject);
			//shotHit.collider.gameObject.GetComponent<Enemy>().Destroy();
		}
		layerMask = LayerMask.GetMask("Bullet (Enemy)");
		shotHit = Physics2D.Raycast ((Vector2)shotRay.origin, (Vector2)shotRay.direction, range, layerMask);
		if (shotHit.collider) {
			//Destroy(shotHit.collider.gameObject);
			Destroy(shotHit.collider.gameObject);
		}

//		if(Physics.Raycast(shotRay , out shotHit , range , layerMask)){
//			// hit 
//			Destroy(shotHit.collider.gameObject);
//		}
		
		lineRenderer.SetPosition(1 , shotRay.origin + shotRay.direction * range);
		lineRenderer.enabled = false;
		lineRenderer.enabled = true;
	}
}
