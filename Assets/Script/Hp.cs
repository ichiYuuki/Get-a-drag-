using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hp : MonoBehaviour {

    private Slider HpBar;
    private Player player;
    private Renderer re;
    private GameObject unity;
    private int hp;

    void Start () {
        HpBar = GameObject.Find("HpBar").GetComponent<Slider>();
        unity = GameObject.Find("UnityChan");
        player = unity.GetComponent<Player>();
        re = player.GetComponent<Renderer>();

    }

    void Update () {
        hp = player.hp;
        HpBar.value = hp;
        Debug.Log(hp);

        //hpが減ったら処理をする
        //まだ途中
        if (hp == 9)
        {
            Debug.Log("ダメージを受けた");
            StartCoroutine("Damage");
        }
	}

    IEnumerator Damage()
    {
        //レイヤーをPlayerDamageに変更
        gameObject.layer = LayerMask.NameToLayer("PlayerDamage");
        //while文を10回ループ
        int count = 10;

        while (count > 0)
        {
            //透明にする
            re.material.color = new Color(1, 1, 1, 0);
            //0.15秒待つ
            yield return new WaitForSeconds(0.15f);
            //元に戻す
            re.material.color = new Color(1, 1, 1, 1);
            //0.15秒待つ
            yield return new WaitForSeconds(0.15f);
            count--;
        }
        //レイヤーをPlayerに戻す
        gameObject.layer = LayerMask.NameToLayer("Player");
    }
}
