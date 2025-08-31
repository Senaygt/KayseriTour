using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTranstation: MonoBehaviour
{
    [Header("Fade Ayarları")]
    public Canvas fadeCanvas;
    public Image fadeImage;          
    public float fadeDuration = 0.0001f;  
    public float delay = 2f;         

    [Header("Sahne Ayarı")]
    public string nextSceneName = "kayseriMeydan";

    private bool isTransitioning = false;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTransitioning)
        {
            Debug.Log("Değdi");   
            isTransitioning = true;
            fadeCanvas.gameObject.SetActive(true);
            if(fadeImage != null)
            {
                Color c = fadeImage.color;
                c.a = 0f;
                fadeImage.color = c;
            }

            StartCoroutine(FadeAndLoadScene());
        }
    }

    IEnumerator FadeAndLoadScene()
    {
        float t = 0;
        Color color = fadeImage.color;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            color.a = Mathf.Clamp01(t / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(nextSceneName);
    }
}