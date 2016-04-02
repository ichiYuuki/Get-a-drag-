using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    private Slider hpBar;
    private Player player;
    private GameObject unity;
    private int hp;
    public GameObject Fill;
    private Color color;
    void Start()
    {
        hpBar = GameObject.Find("HpBar").GetComponent<Slider>();
        unity = GameObject.Find("UnityChan");
        player = unity.GetComponent<Player>();
        color = GameObject.Find("Fill").GetComponent<Image>().color;            
    }

    void Update()
    {
        hp = player.hp;
        hpBar.value = hp;
        Debug.Log(hp);
        HpColor();
    }

    //体力の値で色を変える
    private void HpColor()
    {       
        //hpが7～１０の時
        if (hp >= 7 && hp < 10)
        {
            //緑色
            color = Fill.GetComponent<Image>().color = new Color(0, 255, 0);
        }
        //hpが６～3の時
        else if (hp >= 4 && hp < 7)
        {
            //黄色
            color = Fill.GetComponent<Image>().color = new Color(255, 255, 0);
        }
        //hpが３～０の時
        else if (hp >= 0 && hp < 3)
        {
            //赤色
            color = Fill.GetComponent<Image>().color = new Color(255, 0, 0);
        }
    }
}