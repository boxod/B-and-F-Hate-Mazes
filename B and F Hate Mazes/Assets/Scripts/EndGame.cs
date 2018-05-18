using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {

    public GameObject Player;
    public string LoadLevel = "End Game Scene";
    public AudioSource EndSound;
    public Image PlainBlack;
    public Animator fadeAnimator;

    //private Image PlainBlack;
    //private Animator fadeAnimator;

    private void OnTriggerEnter(Collider collision)
    {
        EndSound.Play();

        if (collision.tag == "Player")
        {
            SceneManager.LoadScene("End Game Scene");
            //StartCoroutine(Fading());
        }
    } 
    IEnumerator Fading()
    {

        fadeAnimator.SetBool("Fade",true);
        yield return new WaitUntil(() => PlainBlack.color.a == 1);
        SceneManager.LoadScene("End Game Scene");
    }
}
