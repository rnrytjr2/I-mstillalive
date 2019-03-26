using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StageManager : MonoBehaviour
{
    private GameObject panel;
    Player_Move player;
    Gravity_Manager gravitymanager;
    GameManager gamemanager;
    Text_Manager textmanager;
    // Use this for initialization
    Rigidbody2D rb2d;
    void Start()
    {

        player = GameObject.Find("player").GetComponent<Player_Move>();
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        panel = GameObject.Find("TextUI").transform.Find("Panel").gameObject;
        gravitymanager = GameObject.Find("GravityManager").GetComponent<Gravity_Manager>();
        textmanager = GameObject.Find("TextManager").GetComponent<Text_Manager>();
        gamemanager.stagemanager= GameObject.Find("StageManager").GetComponent<StageManager>();
        gravitymanager.player = player;
        gamemanager.player = player;
        rb2d = GameObject.Find("player").GetComponent<Rigidbody2D>();
        gravitymanager.Return_rb2d(rb2d);
        gravitymanager.Change_Gravity_Object();
        StageWall_Seting();

    }
    public void StageWall_Seting()
    {
        if (gamemanager.gameclear == true)
            GameObject.Find("Stage" + gamemanager.stage).transform.Find("StageWall").gameObject.SetActive(false);
        else
            GameObject.Find("Stage" + gamemanager.stage).transform.Find("StageWall").gameObject.SetActive(true);

    }
    // FixedUpdate is called once per frame
    void FixedUpdate()
    {


    }
}
