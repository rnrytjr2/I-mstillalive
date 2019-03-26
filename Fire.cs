using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SpriteRenderer sprite = collision.gameObject.GetComponent<SpriteRenderer>();
        if(sprite != null)
        {
            sprite.color = new Color(1.0f, 0, 0);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        SpriteRenderer sprite = collision.gameObject.GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.color = new Color(1.0f, 1.0f, 1.0f);
        }
    }
}
