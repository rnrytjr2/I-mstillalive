using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
 class ButtonManager : MonoBehaviour {
    static ButtonManager instance;
    public bool GamePause = false;
    SoundManager soundmanager;
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
    private void Start()
    {
        soundmanager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }
    public void GotoMain()
    {
        soundmanager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        soundmanager.GetComponent<SoundManager>().musicSource.clip = Resources.Load("Royalty Free Music Track - 8bit Symphony")as AudioClip;
        soundmanager.GetComponent<SoundManager>().musicSource.Play();
        SceneManager.LoadScene("Main");

    }
    // Use this for initialization
    public void OnPauseButtonClicked()//버튼을 눌렀을시 시간이 정지되고 여타 다른 버튼이 눌러도 동작하지 않게 만들어준다.
    {

            GameObject.Find("Pause").GetComponent<Image>().sprite = Resources.Load<Sprite>("ButtonsStyle13_03");
            GameObject.Find("ButtonManager").GetComponent<ButtonManager>().GamePause = true;
            Time.timeScale = 0.0f;
    }
    public void Goto_FIrst_Story()
    {
        SceneManager.LoadScene("First_Story");
    }
    public void OnQuitPauseButtonClicked()
    {
        GameObject.Find("Pause").GetComponent<Image>().sprite = Resources.Load<Sprite>("ButtonsStyle13_02");
        GameObject.Find("ButtonManager").GetComponent<ButtonManager>().GamePause = false;
        Time.timeScale = 1.0f;
    }
    public void QuitGameButtonClicked()
    {
        Application.Quit();
    }
}
