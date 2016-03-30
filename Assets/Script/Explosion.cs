using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
    public GameObject player;
    public GameObject explosion;

    void Start()
    {
        player = GameObject.Find("UnityChan");
    }
    public void DeleteExplosion (){
		Destroy(gameObject);
	}

    public void PlayerExplosion()
    {
        //プレイヤーが存在する時だけ処理をする
        if (player != null)
        {
            Instantiate(explosion, player.transform.position, player.transform.rotation);
            Destroy(player);
        }
    }
}
