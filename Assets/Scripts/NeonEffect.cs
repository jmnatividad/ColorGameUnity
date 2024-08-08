using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NeonEffect : MonoBehaviour
{
    // the image you want to fade, assign in inspector
    public Image img;
    public Sprite neonSprite;
    private void Start() {
         StartCoroutine(FadeImage(true));
    }

    public IEnumerator FadeImage(bool fadeAway)
    {
        for(float time = 0f; time < 10f; time+=0.02f){
            while (fadeAway)
            {
                // loop over 1 second backwards
                for (float i = 1; i >= 0.7f; i -= Time.deltaTime * 0.5f)
                {
                    // set color with i as alpha
                    img.color = new Color(1, 1, 1, i);
                    fadeAway = false;
                    yield return null;
                }
            }
            // fade from transparent to opaque
            while (!fadeAway)
            {
                // loop over 1 second
                for (float i = 0.7f; i <= 1; i += Time.deltaTime * 0.5f)
                {
                    // set color with i as alpha
                    img.color = new Color(1, 1, 1, i);
                    fadeAway = true;
                    yield return null;
                }
            }
        }
        // fade from opaque to transparent
  
    }
}
