using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    private float time = 5;
    private GameObject gameEnd;
    private GameObject unity;
	// Use this for initialization
	void Start () {
        //float型からint型へCastし、String型に変換して表示
        GetComponent<Text>().text = ((int)time).ToString();
        gameEnd = GameObject.Find("GameEnd");
        unity = GameObject.Find("UnityChan");
        gameEnd.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        //1秒に1ずつ減らしていく
        time -= Time.deltaTime;
        //マイナスは表示しない
        if (time < 0)
        {
            //ゲームオーバーになった時の処理
            Debug.Log("ゲームオーバー");
            gameEnd.SetActive(true);
            time = 0;
            Destroy(unity);
        }
        GetComponent<Text>().text = ((int)time).ToString();        
    }
}
