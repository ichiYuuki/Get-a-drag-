using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hp : MonoBehaviour {
    private Slider slider;
    private float hp = 100; //初期体力

    void Start () {
        slider = GameObject.Find("Slider").GetComponent<Slider>();
    }

    void Update () {
        //hp -= 1f;
        slider.value = hp;
	}
}
