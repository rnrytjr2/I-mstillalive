using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ClickText : MonoBehaviour,IPointerClickHandler {
    public int textnum;
    Text_Manager textmanager;
    GameManager gamemanager;
    // Use this for initialization
    void Start () {
        textnum = 0;
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        textmanager = GameObject.Find("TextManager").GetComponent<Text_Manager>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnPointerClick(PointerEventData eventData)
    {
        textmanager.NextText();
    }
}
