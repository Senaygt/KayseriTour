using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NewBehaviourScript : MonoBehaviour
{

    public Image fadeImage;
    public float fadeDuration=4f;
    public GameObject Player;
   
    
    void Start()
    {
        fadeImage.color=new Color(0,0,0,1);
        StartCoroutine(FadeIn());
    }


    IEnumerator FadeIn(){
        float t=0;
        while (t<fadeDuration){
            t+=Time.deltaTime;
            float alpha=1-(t/fadeDuration);
            fadeImage.color=new Color(0,0,0,alpha);
            yield return null;
        }
        fadeImage.gameObject.SetActive(false);
        if (Player != null)
        {
            Player.SetActive(true);
        }
        fadeImage.gameObject.SetActive(false);
    }

}
