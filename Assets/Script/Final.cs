using UnityEngine;
using System.Collections;

public class Final : MonoBehaviour {

	IEnumerator Start () {
		yield return new WaitForSeconds(5);
		Application.LoadLevel("Title");
	}
}
