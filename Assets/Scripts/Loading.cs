using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{

    [SerializeField] private Slider loadingScreenSlider;
    // [SerializeField] private Image fillAreaImage;
    // [SerializeField] private Gradient rainbowGradient;
    private float progressValue;

    void Start()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        loadingScreenSlider.value = progressValue;

        while (progressValue < 1f)
        {
            progressValue += 0.01f;
            loadingScreenSlider.value = progressValue;

            // fillAreaImage.color = rainbowGradient.Evaluate(progressValue);

            yield return new WaitForSeconds(0.1f);
        }

        Debug.Log("Loading complete!");
        SceneManager.LoadScene("UI_ColorGame");

        // AsyncOperation loadOperation = SceneManager.LoadSceneAsync("UI_ColorGame");

        // while(!loadOperation.isDone){
        //     progressValue = Mathf.Clamp01(loadOperation.progress / .9f);
        //     loadingScreenSlider.value = progressValue;
        //     yield return null;
        // }


    }
}
