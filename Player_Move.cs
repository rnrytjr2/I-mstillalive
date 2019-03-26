using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Move : MonoBehaviour
{
    Player_Move player;
    Gravity_Manager gravitymanager;
    GameManager gamemanager;
    Text_Manager textmanager;
    SoundManager soundmanager;
    public float player_temperature;
    public static Player_Move instance = null;
    enum PlayerMove { up, left, right }
    public Rigidbody2D rb2d;
    public Vector2 playerstate;
    public bool player_Jump = true;
    private Animator animator;
    AudioClip[] jumpsound;
    public float timescale;
    private void Awake()
    {

        //if (instance == null)
        //{
        //    instance = this;
        //}
        //else if (instance != this)
        //{
        //    Destroy(gameObject);
        //}

        //DontDestroyOnLoad(gameObject);
    }
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("player").GetComponent<Player_Move>();
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gravitymanager = GameObject.Find("GravityManager").GetComponent<Gravity_Manager>();
        textmanager = GameObject.Find("TextManager").GetComponent<Text_Manager>();
        soundmanager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        player_temperature = 0;
        rb2d = GetComponent<Rigidbody2D>();
        gravitymanager.player_rb2d = rb2d;
        animator = gameObject.GetComponent<Animator>();
        jumpsound= new AudioClip[12];
        player.transform.position = GameObject.Find("Stage" + gamemanager.stage).transform.position + new Vector3(-11.7f, -5.063f, 0f);
        for (int i=0;i<12;i++)
        {
            jumpsound[i] = Resources.Load ( "Jump & Attack " + i )as AudioClip;
        }
    }
    void playerleft()
    {
        gameObject.transform.localScale=(new Vector3(-0.5f,0.5f,1));
        animator.SetFloat("run", 10);
        if (gravitymanager.GetComponent<Gravity_Manager>().gravity == Gravity_Manager.Gravity.down)
        {
            playerstate.x += -4;
            if (playerstate.x < -16)
                playerstate.x = -16;
        }
        else if (gravitymanager.GetComponent<Gravity_Manager>().gravity == Gravity_Manager.Gravity.up)
        {
            playerstate.x += 4;
            if (playerstate.x > 16)
                playerstate.x = 16;
        }
        else if (gravitymanager.GetComponent<Gravity_Manager>().gravity == Gravity_Manager.Gravity.left)
        {
            playerstate.y += 4;
            if (playerstate.y > 16)
                playerstate.y = 16;
        }
        else if (gravitymanager.GetComponent<Gravity_Manager>().gravity == Gravity_Manager.Gravity.right)
        {
            playerstate.y += -4;
            if (playerstate.y < -16)
                playerstate.y = -16;
        }
    }
    void playerright()
    {
        gameObject.transform.localScale = (new Vector3(0.5f, 0.5f, 1));
        animator.SetFloat("run", 10);
        if (gravitymanager.GetComponent<Gravity_Manager>().gravity == Gravity_Manager.Gravity.up)
        {
            playerstate.x += -4;
            if (playerstate.x < -16)
                playerstate.x = -16;
        }
        else if (gravitymanager.GetComponent<Gravity_Manager>().gravity == Gravity_Manager.Gravity.down)
        {
            playerstate.x += 4;
            if (playerstate.x > 16)
                playerstate.x = 16;
        }
        else if (gravitymanager.GetComponent<Gravity_Manager>().gravity == Gravity_Manager.Gravity.right)
        {
            playerstate.y += 4;
            if (playerstate.y > 16)
                playerstate.y = 16;
        }
        else if (gravitymanager.GetComponent<Gravity_Manager>().gravity == Gravity_Manager.Gravity.left)
        {
            playerstate.y += -4;
            if (playerstate.y < -16)
                playerstate.y = -16;
            
        }
    }
    // FixedUpdate is called once per frame
    void FixedUpdate()
    {

        if (SceneManager.GetActiveScene().name == "Main" && gamemanager.stage > 2&& gamemanager.stage < 8)
        {
            if (player_temperature <= 15)
            {
                player_temperature += Time.deltaTime;
            }
            else
            {
                gamemanager.GetComponent<GameManager>().Gameover();

            }
        }
        if (player_temperature > 0)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1, 1 - (player_temperature * 16 / 255), 1 - (player_temperature * 16 / 255));
        }
        else if (player_temperature < 0)
        { 
            this.GetComponent<SpriteRenderer>().color = new Color(1 + (player_temperature * 16 / 255), 1 + (player_temperature * 16 / 255), 1);
        }
        rb2d.AddForce(playerstate);
        if(Input.GetKeyDown("space"))
        {
            textmanager.NextText();
            
        }
        
        if (Input.GetKey("left"))
        {

            playerleft();

        }
        if (Input.GetKey("right"))
        {
            playerright();
        }
        if (!Input.GetKey("right") && !Input.GetKey("left"))
        {
            playerstate = new Vector2(0, 0);
        }
        if(player.GetComponent<Player_Move>().rb2d.velocity == Vector2.zero)
        {
            animator.SetFloat("run", 0);
        }
        

    }
    private void Update()
    {
        timescale=Time.timeScale;
        if (Input.GetKeyDown("up"))
        {

            if (player_Jump == true)
            {
                soundmanager.GetComponent<SoundManager>().RandomizeSfx(jumpsound[0], jumpsound[1], jumpsound[2], jumpsound[3], jumpsound[4], jumpsound[5], jumpsound[6], jumpsound[7], jumpsound[10], jumpsound[11]);
                if (gravitymanager.GetComponent<Gravity_Manager>().gravity == Gravity_Manager.Gravity.down)
                    rb2d.AddForce(new Vector2(0.0f, 10f), ForceMode2D.Impulse);
                else if (gravitymanager.GetComponent<Gravity_Manager>().gravity == Gravity_Manager.Gravity.up)
                    rb2d.AddForce(new Vector2(0.0f, -10f), ForceMode2D.Impulse);
                else if (gravitymanager.GetComponent<Gravity_Manager>().gravity == Gravity_Manager.Gravity.left)
                    rb2d.AddForce(new Vector2(10f, 0f), ForceMode2D.Impulse);
                else if (gravitymanager.GetComponent<Gravity_Manager>().gravity == Gravity_Manager.Gravity.right)
                    rb2d.AddForce(new Vector2(-10f, 0f), ForceMode2D.Impulse);
                player_Jump = false;
                animator.SetTrigger("playerjump");
            }
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.name=="cooler")
        {
            player_temperature -= (3 * Time.deltaTime);
            if(player_temperature<-15)
            {
                gamemanager.GetComponent<GameManager>().Gameover();
            }
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{


    //    player_Jump = true;


    //}
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.layer == 8)
    //    {
    //        player_Jump = false;
    //    }
    //}
}
