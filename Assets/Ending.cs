using UnityEngine;
using System.Collections;

public class Ending : MonoBehaviour {

	IEnumerator Start () {
		yield return new WaitForSeconds(5);
		Application.LoadLevel("MainTitle");
	}
}
