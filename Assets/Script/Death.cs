using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Death : MonoBehaviour {

	public GameObject explosion;

	public void Explosion(){
		Instantiate(explosion,transform.position + new Vector3(0,1,0),transform.rotation);
	}
}
