using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct Contexts
{
    public string name;
    public string text;
    public Contexts(string name, string text)
    {
        this.name = name;
        this.text = text;
    }
};
public class Text_Manager : MonoBehaviour
{
    public bool textstate;
    public static Text_Manager instance;
    public Text message, speaker;
    public List<string> dialog_name;
    public List<string> dialog_text;
    Gravity_Manager gravitymanager;
    GameManager gamemanager;
    Text_Manager textmanager;
    SoundManager soundmanager;
    private GameObject panel;


    // Use this for initialization
    void Start()
    {

        textstate = false;
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gamemanager.textmanager = GameObject.Find("TextManager").GetComponent<Text_Manager>();
        panel = GameObject.Find("TextUI").transform.Find("Panel").gameObject;
        speaker = panel.transform.Find("Name").GetComponent<Text>();
        message = panel.transform.Find("Message").GetComponent<Text>();
        if (gamemanager.textstate)
        {
            
            panel.SetActive(true);
            gamemanager.GetComponent<GameManager>().textstate = false;
            speaker.text = dialog_name[gamemanager.dialognum].ToString();
            message.text = dialog_text[gamemanager.dialognum].ToString();
            Time.timeScale = 0f;
        }
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {


    }

    public void Textstate(bool state)
    {
        if (state == true)
        {
            panel.SetActive(false);


        }
        else if (state == false)
        {
            panel.SetActive(true);
        }
    }
    public void NextText()
    {

        if (dialog_text[gamemanager.dialognum].ToString() == "ENDTEXT")
        {
            panel.gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            speaker.text = dialog_name[gamemanager.dialognum].ToString();
            message.text = dialog_text[gamemanager.dialognum].ToString();
        }
        gamemanager.dialognum++;
    }

}
