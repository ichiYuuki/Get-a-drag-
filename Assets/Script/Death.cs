using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    public RemainingLives remainingLives;    
    public GameObject player;
    public GameObject explosion;

    void Start()
    {
        //player = GameObject.Find("UnityChan");
        //explosion = GetComponent<Explosion>();       
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Buyer" && col.tag != "Enemy")
        {
            player = GameObject.Find("UnityChan");
            Instantiate(explosion, player.transform.position, player.transform.rotation);
            Destroy(player);
            remainingLives.LifeCounterDown();
       }
    }
}
