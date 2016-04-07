using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float time = 50;
    private Explosion explosion;
    private GameObject gameEnd;
    private GameObject player;
    // Use this for initialization
    void Start()
    {
        //float型からint型へCastし、String型に変換して表示
        GetComponent<Text>().text = ((int)time).ToString();
        gameEnd = GameObject.Find("GameEnd");
        player = GameObject.Find("UnityChan");
        gameEnd.SetActive(false);
        explosion = GetComponent<Explosion>();
    }

    // Update is called once per frame
    void Update()
	{	//ClearZoneのgameClear　と　Stopwatchのclear　がfalse のとき
		if(ClearZone.gameClear == false && Stopwatch.clear == false){
	        //1秒に1ずつ減らしていく
	        time -= Time.deltaTime;
		}
        //マイナスは表示しない
        if (time < 0)
        {
            //ゲームオーバーになった時の処理
            Debug.Log("ゲームオーバー");
            time = 0;
            explosion.PlayerExplosion();
            gameEnd.SetActive(true);
//			Destroy(player);
        }
        GetComponent<Text>().text = ((int)time).ToString();   
		PlayerDeth ();
    }
	public void PlayerDeth(){
		if(player == null){
			time = 0;
		}
	}
}
