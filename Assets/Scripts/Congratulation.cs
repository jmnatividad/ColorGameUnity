using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Congratulation : MonoBehaviour
{
    // Start is called before the first frame update
    public BetManager betManagerVar;
    public TextMeshProUGUI winNumberText;
    public GameObject congratulationMiddleSection;
    public MusicAudio musicAudioVar;

    public void congratsWinningMoney(bool state)
    {
        if (betManagerVar.win > 0)
        {
            // winNumberText.text = $"{betManagerVar.win}";
            StartCoroutine(adjustVol());
            congratulationMiddleSection.SetActive(state);
            StartCoroutine(countToTargetNum(betManagerVar.win));
            Debug.Log($"YOU WON: ${betManagerVar.win}");
        }
    }

    IEnumerator countToTargetNum(int targetNum)
    {
        float time = 0f;
        int currentNumber = 0;

        while (time < 3.0f)
        {
            time += Time.deltaTime;
            // the countup for the targetnum
            currentNumber = Mathf.FloorToInt(Mathf.Lerp(0, targetNum, time / 3.0f));
            winNumberText.text = currentNumber.ToString();
            yield return null;
        }
        winNumberText.text = targetNum.ToString();
    }

    IEnumerator adjustVol()
    {
        musicAudioVar.adjustVolume(true);
        yield return new WaitForSeconds(5f);
        musicAudioVar.adjustVolume(false);
        yield return null;
    }



}
