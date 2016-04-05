using UnityEngine;
using System.Collections;

public class Ending : MonoBehaviour {

	IEnumerator Start () {
		yield return new WaitForSeconds(50);
		Application.LoadLevel("MainTitle");
	}
}
