using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    //This code is to test out the screen flash is working properly
    //Add this script to an empty game object and hit space to test.

    //Copy and paste this code on any object you wish to trigger a flash
    [Header("Image Canvas")]
    [SerializeField] FlashImage _flashImage = null;
    [Header("Flash Settings")]
    [SerializeField] Color _newColor = Color.red;
    [SerializeField][Tooltip("How long your screen with flash")][Range(0,1)] float _secondsForFlash = 0f;
    [SerializeField][Tooltip("The opacity of your flash")][Range(0,1)] float _maxAlpha = 0f;

void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Copy and paste this code on any object you wish to trigger a flash
            _flashImage.StartFlash(_secondsForFlash, _maxAlpha, _newColor);
        }
    }
}
