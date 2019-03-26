using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gravity_Manager : MonoBehaviour
{
    public enum Gravity { up, down, left, right }
    public Gravity gravity = Gravity.down;
    public Rigidbody2D player_rb2d;
    Rigidbody2D box_rb2d;
    public static Gravity_Manager instance;
    public GameObject[] gravityobject;
    public float gravityscale = 30.81f;
    private GameObject panel;
    public Player_Move player;
    Gravity_Manager gravitymanager;
    GameManager gamemanager;
    // Use this for initialization
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }
    void Start()
    {
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gravitymanager = GameObject.Find("GravityManager").GetComponent<Gravity_Manager>();
    }
    public void Return_rb2d(Rigidbody2D rb2d)
    {
        player_rb2d = rb2d;
    }
    public void Change_Gravity_Object()
    {
        gravityobject = GameObject.FindGameObjectsWithTag("Stage" + gamemanager.stage);
    }
    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name == "Main" && Time.timeScale == 1.0f)
        {
            switch (gravity)
            {
                case Gravity.up:
                    {
                        player_rb2d.AddForce(new Vector2(0, gravityscale));
                        for (int i = 0; i < gravitymanager.GetComponent<Gravity_Manager>().gravityobject.Length; i++)
                        {
                            box_rb2d = gravityobject[i].GetComponent<Rigidbody2D>();
                            box_rb2d.AddForce(new Vector2(0, gravityscale));
                        }
                        break;
                    }
                case Gravity.down:
                    {
                        player_rb2d.AddForce(new Vector2(0, -gravityscale));
                        for (int i = 0; i < gravitymanager.GetComponent<Gravity_Manager>().gravityobject.Length; i++)
                        {
                            box_rb2d = gravityobject[i].GetComponent<Rigidbody2D>();
                            box_rb2d.AddForce(new Vector2(0, -gravityscale));
                        }
                        break;
                    }
                case Gravity.left:
                    {
                        player_rb2d.AddForce(new Vector2(-gravityscale, 0));
                        for (int i = 0; i < gravitymanager.GetComponent<Gravity_Manager>().gravityobject.Length; i++)
                        {
                            box_rb2d = gravityobject[i].GetComponent<Rigidbody2D>();
                            box_rb2d.AddForce(new Vector2(-gravityscale, 0));
                        }
                        break;
                    }
                case Gravity.right:
                    {
                        player_rb2d.AddForce(new Vector2(gravityscale, 0));
                        for (int i = 0; i < gravitymanager.GetComponent<Gravity_Manager>().gravityobject.Length; i++)
                        {
                            box_rb2d = gravityobject[i].GetComponent<Rigidbody2D>();
                            box_rb2d.AddForce(new Vector2(gravityscale, 0));
                        }
                        break;
                    }
            }
            if (Input.GetKeyUp("w"))
            {
                gravity = Gravity.up;
                player.transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            else if (Input.GetKeyUp("s"))
            {
                gravity = Gravity.down;
                player.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (Input.GetKeyUp("a"))
            {
                gravity = Gravity.left;
                player.transform.rotation = Quaternion.Euler(0, 0, -90);
            }
            else if (Input.GetKeyUp("d"))
            {
                player.transform.rotation = Quaternion.Euler(0, 0, 90);
                gravity = Gravity.right;
            }

        }
    }

}

