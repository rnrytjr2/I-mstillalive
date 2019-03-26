using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Goal : MonoBehaviour {
    // Use this for initialization
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name=="player")
        StartCoroutine("FinalStory");

    }
    IEnumerator FinalStory()
    {
        GameObject.Find("Canvas").transform.Find("FadeOut").gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("End_Story");
    }
}
