using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    public RemainingLives remainingLives;
    private Explosion explosion;   
    public GameObject player;

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
            Destroy(player);
            remainingLives.LifeCounterDown();
       }
    }
}
