using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class FlashImage : MonoBehaviour
{
    //This script contains the code to run your screen flash
    //Attach this script to any blank canvas image

    Image _image = null;
    Coroutine _currentFlashRoutine = null;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void StartFlash(float secondsForOneFlash, float maxAlpha, Color newColor)
    {
        _image.color = newColor;

        //Ensure Alpha isnt above 1
        maxAlpha = Mathf.Clamp(maxAlpha, 0, 1);

        if (_currentFlashRoutine != null)
        {
            StopCoroutine(_currentFlashRoutine);
        }
        _currentFlashRoutine = StartCoroutine(Flash(secondsForOneFlash, maxAlpha));
    }

    IEnumerator Flash(float secondsForOneFlash, float maxAlpha)
    {

        //Flash In
        float flashInDuration = secondsForOneFlash / 2;
        for (float t = 0; t < flashInDuration; t += Time.deltaTime)
        {
            Color colorThisFrame = _image.color;
            colorThisFrame.a = Mathf.Lerp(0, maxAlpha, t / flashInDuration);
            _image.color = colorThisFrame;

            //Wait until next frame
            yield return null;
        }

        //Flash Out
        float flashOutDuration = secondsForOneFlash / 2;
        for (float t = 0; t < flashOutDuration; t += Time.deltaTime)
        {

            Color colorThisFrame = _image.color;
            colorThisFrame.a = Mathf.Lerp(maxAlpha, 0, t / flashOutDuration);
            _image.color = colorThisFrame;

            yield return null;

        }

        //Ensure maxAlpha is set to 0
        _image.color = new Color32(0, 0, 0, 0);
    }
}
