using UnityEngine;
using System.Collections;

public class Ending : MonoBehaviour {

	IEnumerator Start () {
		yield return new WaitForSeconds(25);
		Application.LoadLevel("MainTitle");
	}
}
