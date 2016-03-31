using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hp : MonoBehaviour {

    private Slider HpBar;
    private Player player;
    private GameObject unity;
    private int hp;

    void Start () {
        HpBar = GameObject.Find("HpBar").GetComponent<Slider>();
        unity = GameObject.Find("UnityChan");
        player = unity.GetComponent<Player>();
        
    }

    void Update () {
        hp = player.hp;
        HpBar.value = hp;
        Debug.Log(hp);
	}
}
