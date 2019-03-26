using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverBox : MonoBehaviour {
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name=="player")
        {

            GameObject.Find("GameManager").GetComponent<GameManager>().Gameover();
        }
    }
}
