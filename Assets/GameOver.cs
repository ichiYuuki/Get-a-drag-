using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

    private GameObject gameEnd;
    public Timer timer;

    // Use this for initialization
    void Start () {
        gameEnd = GameObject.Find("GameEnd");
        gameEnd.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void gameOver()
    {
        timer.time = 0;
        gameEnd.SetActive(true);
    }
}
