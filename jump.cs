using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    Player_Move player;
    GameManager gamemanager;
    public static jump instance = null;
    
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("player").GetComponent<Player_Move>();
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        player.GetComponent<Player_Move>().player_Jump = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {

        player.GetComponent<Player_Move>().player_Jump = false;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "stagecollider")
        {
            if (other.transform.position.x< player.transform.position.x)
            {
                gamemanager.GetComponent<GameManager>().NextStage();
                player.GetComponent<Player_Move>().player_Jump = (true);
            }
        }

    }
}
