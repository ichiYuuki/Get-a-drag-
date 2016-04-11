using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour {

	private Image img;
	private Player player;
	public Material mat1;
	public Material mat2;
	// Use this for initialization
	void Start () {
		img = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.FindWithTag ("Buyer")){
			player = GameObject.FindWithTag ("Buyer").GetComponent<Player> ();
			ChangeType (player.bulletNum);
		}
	}

	void ChangeType(int num){
		if (num == 0) {
			img.material = mat1;
		}else if(num == 1){
			img.material = mat2;
		}
	}
}
