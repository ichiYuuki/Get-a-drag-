﻿using UnityEngine;
using System.Collections;

//InvincibleTime(訳:無敵時間)
public class InvincibleTime : MonoBehaviour
{
    private GameObject player;
    private Renderer re;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("UnityChan");
        re = player.GetComponent<Renderer>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //Enemyとぶつかった時にコルーチンを実行
        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Bullet")
        {
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