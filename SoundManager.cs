using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour {
    private GameObject panel;
    Gravity_Manager gravitymanager;
    GameManager gamemanager;
    Text_Manager textmanager;
    SoundManager soundmanager;
    public static SoundManager instance;
    public AudioSource efxSource;//효과음
    public AudioSource musicSource;//배경음악
    private Slider soundslider;//옵션.사운드조절바
    public float PitchRange;//현재사운드 크기

    public void Awake()
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
        
    }
    public void PlaySingle(AudioClip clip)
    {
        //하나의 효과음재생 soundmanager.GetComponent<SoundManager>().PlaySingle(Audio ***);
        efxSource.clip = clip;
        efxSource.Play();
        efxSource.pitch = PitchRange;
    }
    public void RandomizeSfx(params AudioClip[]clips)
    {
        //여러개의 효과음중 하나만 재생하고 싶을때 soundmanager.GetComponent<SoundManager>().RandomizeSfx(Audio***,*** ...);
        int randomIndex = Random.Range(0, clips.Length);
        efxSource.clip = clips[randomIndex];
        efxSource.Play();
        efxSource.pitch = PitchRange;
    }
    // Use this for initialization
    
    public void SoundController()//슬라이더가 움직일 때마다 호출되어 사운드의 조절을 해준다.
    {
        soundmanager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        soundmanager.PitchRange = soundslider.value;
        soundmanager.musicSource.volume = soundmanager.PitchRange;
    }
    public void SoundInit()//설정 버튼을 눌렀을 시 설정창의 슬라이더를 현재의 볼륨과 동기화 시켜준다.
    {
        soundmanager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        soundslider = GameObject.Find("SoundSlider").GetComponent<Slider>();
        soundslider.value = soundmanager.GetComponent<SoundManager>().PitchRange;
    }
    
}
