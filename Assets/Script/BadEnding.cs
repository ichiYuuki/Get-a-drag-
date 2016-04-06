using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement; //unity5.3


public class BadEnding : MonoBehaviour {

	public GameObject gameobject;
	public GameObject gameobject2;
	public GameObject gameobject3;

	void Start () {
		// ２秒後にFadeIn()を、５秒後にFadeOut()を呼び出す
		Invoke("FadeIn", 1f);
		Invoke("FadeIn2", 1f);
		Invoke("FadeOut", 5f);
		Invoke("FadeIn3", 7f);
		Invoke("FadeOut2", 14f);
		Invoke("SceneTitle", 17f);
	}
	
	void FadeIn() {
		// SetValue()を毎フレーム呼び出して、１秒間に０から１までの値の中間値を渡す
		iTween.ValueTo(gameobject, iTween.Hash("from", 0f, "to", 1f, "time", 1f, "onupdate", "SetValue"));
	}
	void FadeIn2() {
		// SetValue()を毎フレーム呼び出して、１秒間に０から１までの値の中間値を渡す
		iTween.ValueTo(gameobject2, iTween.Hash("from", 0f, "to", 1f, "time", 1f, "onupdate", "SetValue2"));
	}
	void FadeIn3() {
		// SetValue()を毎フレーム呼び出して、１秒間に０から１までの値の中間値を渡す
		iTween.ValueTo(gameobject3, iTween.Hash("from", 0f, "to", 1f, "time", 1f, "onupdate", "SetValue3"));
	}
	void FadeOut() {
		// SetValue()を毎フレーム呼び出して、１秒間に１から０までの値の中間値を渡す
		iTween.ValueTo(gameObject, iTween.Hash("from", 1f, "to", 0f, "time", 1f, "onupdate", "SetValue"));
		iTween.ValueTo(gameObject, iTween.Hash("from", 1f, "to", 0f, "time", 1f, "onupdate", "SetValue2"));
	}
	void FadeOut2() {
		// SetValue()を毎フレーム呼び出して、１秒間に１から０までの値の中間値を渡す
		iTween.ValueTo(gameObject, iTween.Hash("from", 1f, "to", 0f, "time", 1f, "onupdate", "SetValue3"));
	}
	void SetValue(float alpha) {
		// iTweenで呼ばれたら、受け取った値をTextのアルファ値にセット
		gameobject.GetComponent<UnityEngine.UI.Text>().color = new Color(0,0,0, alpha);
	}
	void SetValue2(float alpha) {
		// iTweenで呼ばれたら、受け取った値をTextのアルファ値にセット
//		gameobject2.GetComponent<UnityEngine.UI.Text>().color = new Color(0,0,0 alpha);
	}
	void SetValue3(float alpha) {
		// iTweenで呼ばれたら、受け取った値をTextのアルファ値にセット
		gameobject3.GetComponent<UnityEngine.UI.Text>().color = new Color(0,0,0, alpha);
	}

	void SceneTitle(){
		Application.LoadLevel("MainTitle");
//        SceneManager.LoadScene("Title");
    }

}
