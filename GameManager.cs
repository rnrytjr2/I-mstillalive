using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public bool Gameoverb = false;
    public int stage;
    public GameObject[] gravityobject;
    private GameObject panel;
    public Player_Move player;
    Gravity_Manager gravitymanager;
    GameManager gamemanager;
    public Text_Manager textmanager;
    public StageManager stagemanager;
    SoundManager soundmanager;
    Rigidbody2D rb2d;
    public bool gameclear = true;
    public bool textstate = true;
    public bool coolercollid = false;
    public int dialognum = 0;
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
        soundmanager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        for (int i = 0; i < gamemanager.GetComponent<GameManager>().gravityobject.Length; i++)
        {
            rb2d = gravityobject[i].GetComponent<Rigidbody2D>();
            rb2d.bodyType = RigidbodyType2D.Dynamic;
        }
    }
    public void NextStage()
    {
        panel = GameObject.Find("TextUI").transform.Find("Panel").gameObject;
        player.rb2d.velocity = Vector3.zero;
        
        player.transform.position = GameObject.Find("Stage" + gamemanager.stage).transform.Find("stagecollider").position + new Vector3(2f, 1f, 0f);
        gravityobject = GameObject.FindGameObjectsWithTag(("Stage") + gamemanager.stage);
        for (int i = 0; i < gamemanager.gravityobject.Length; i++)
        {
            gravityobject[i].SetActive(false);
        }
        GameObject.Find("Stage" + gamemanager.stage).transform.Find("StageWall").gameObject.SetActive(true);
        gamemanager.stage++;
        gravityobject = GameObject.FindGameObjectsWithTag("Stage" + gamemanager.stage);
        gamemanager.gravityobject = gravityobject;
        gravitymanager.Change_Gravity_Object();
        for (int i = 0; i < gamemanager.gravityobject.Length; i++)
        {
            rb2d = gravityobject[i].GetComponent<Rigidbody2D>();
            rb2d.bodyType = RigidbodyType2D.Dynamic;
        }
        gravitymanager.gravity = Gravity_Manager.Gravity.down;
        player.transform.rotation = Quaternion.Euler(0, 0, 0);
        panel.gameObject.SetActive(true);
        Time.timeScale = 0f;
        textmanager.NextText();
      if(gamemanager.stage>8)
        {
            player.player_temperature=0.0f;
        }
       stagemanager.StageWall_Seting();
        Cameramove();
    }

    //1:16  2:35.26 3:54.52 4:73.78  5:93.04 6:112.3

    //19.26 각 스테이지별 거리

    // Use this for initialization
    public void Cameramove()
    {
        if (SceneManager.GetActiveScene().name == "Main")
            Camera.main.transform.position = GameObject.Find("Stage" + gamemanager.stage).transform.position - (new Vector3(3.54f, 0.66f, 10));
    }


    public void Gameover()
    {
        soundmanager.musicSource.clip = Resources.Load("Gameover_Sound") as AudioClip;
        soundmanager.musicSource.Play();
        gravitymanager.gravity = Gravity_Manager.Gravity.down;
        gamemanager.Gameoverb = true;
        SceneManager.LoadScene("Gameover");

    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {

        gamemanager.Cameramove();

    }

}
