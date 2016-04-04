using UnityEngine;
using System.Collections;

public class Description : MonoBehaviour {

	IEnumerator Start () {
		yield return new WaitForSeconds(2);
		Application.LoadLevel("BondStage");
	}
}
