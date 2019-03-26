using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_Story_Controller : MonoBehaviour
{
    GameObject panel;
    GameManager gamemanager;
    // Use this for initialization
    void Start()
    {
        panel = GameObject.Find("Canvas").transform.Find("Panel").gameObject;
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (gamemanager.Gameoverb == true)
        {
            panel.transform.Find("End_Story_Death").gameObject.SetActive(true);
        }
        else
        {
            panel.transform.Find("End_Story_NoDeath").gameObject.SetActive(true);
        }
    }


}
