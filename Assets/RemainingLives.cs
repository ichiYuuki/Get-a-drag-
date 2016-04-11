using UnityEngine;
using System.Collections;

public class RemainingLives : MonoBehaviour
{
    private GameObject lives;
    private GameObject life1;
    private GameObject life2;
    private int lifeCounter = 3;
    public Vector3 RevivePoint;
    public GameObject player;
    public GameOver gameOver;
    
    void Start()
    {
         //lives = GameObject.Find("Lives");
         life1 = GameObject.Find("life1");
         life2 = GameObject.Find("life2");
    }   

    public void LifeCounterDown()
    {
        lifeCounter--;
        Debug.Log("残機は"+ lifeCounter);
        RespawnCheck();
    }

    public void RespawnCheck()
    {
        if (lifeCounter == 2)
        {                    
            Destroy(life2);
            Invoke("Respawn", 1f);            
        }
        else if (lifeCounter == 1)
        {
            Destroy(life1);
            Invoke("Respawn", 1f);
        }
        else if (lifeCounter == 0)
        {           
            gameOver.gameOver();
            return;
        }
        
    }

    public void Respawn()
    {
        //復活させる      
        var Clone = Instantiate(player, RevivePoint, Quaternion.identity);
        //var Clone = Instantiate(Resources.Load("UnityChan"), RevivePoint, Quaternion.identity);        
        Clone.name = player.name;
        Debug.Log("復活");        
    }
}