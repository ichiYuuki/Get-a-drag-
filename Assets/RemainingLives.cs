using UnityEngine;
using System.Collections;

public class RemainingLives : MonoBehaviour
{
    private GameObject lives;
    private GameObject life1;
    private GameObject life2;
    private int lifeCounter = 3;
    public GameObject RevivePoint;
    public GameObject player;
    // Use this for initialization
    void Start()
    {
         lives = GameObject.Find("Lives");
         life1 = GameObject.Find("life1");
         life2 = GameObject.Find("life2");
    }   

    public void LifeCounterDown()
    {
        lifeCounter--;
        Debug.Log(lifeCounter);
        RespawnCheck();
    }

    public void RespawnCheck()
    {
        if (lifeCounter == 2)
        {                    
            Destroy(life2);
        }
        else if (lifeCounter == 1)
        {
            Destroy(life1);          
        }
        else if (lifeCounter == 0)
        {
            Debug.Log("GameOver");
            return;
        }
        Respawn();
    }

    public void Respawn()
    {    
        //復活させる        
        var Clone = Instantiate(player, new Vector3(0,5,0), Quaternion.identity);
        Clone.name = player.name;        
        Debug.Log("復活");        
    }
}