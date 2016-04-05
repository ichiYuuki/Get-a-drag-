using UnityEngine;
using System.Collections;

public class TextCon : MonoBehaviour {
	float speed = 1.0f;
	public GameObject canvas;
	
	void Start () {
		// TextCanvasを呼び出す
		canvas = GameObject.Find("TextCanvas");
	}
	
	void Update () {
//		// 上矢印キーをおした時の処理
//		if (Input.GetKeyDown(KeyCode.UpArrow)) {
//			speed++;
//		}
//		// 下矢印キーをおした時の処理
//		else if (Input.GetKeyDown(KeyCode.DownArrow) && speed > 1)  {
//			speed--;
//		}
		
		// 0.05ずつy軸マイナス方向にtextを動かしていく
		transform.Translate(0.0f, 0.9f*speed, 0.0f);
		// textのy座標が-55以下になったらcanvasを削除
		if (transform.localPosition.y >= 800) {
			Destroy(canvas);
		}
	}
}