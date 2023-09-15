using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class StepCounterPresenter : MonoBehaviour
{
#if UNITY_ANDROID
    private AndroidJavaObject stepCounterPlugin;
    public int steps;
    public TMP_Text counterText;

    void Start()    
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        stepCounterPlugin = new AndroidJavaObject("com.drks.stepcounterlibrary.StepCounterClass", currentActivity);
    }

    public int GetStepCount()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            return stepCounterPlugin.Call<int>("getStepCount");
        }
        else
        {
            Debug.LogWarning("Step counter only works on Android devices.");
            return 6969;
        }
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            // Unregister the listener when the application is paused
            stepCounterPlugin.Call("stop");
        }
        else
        {
            // Re-register the listener when the application resumes
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            stepCounterPlugin.Call("start", currentActivity);
        }
    }

    private void Update()
    {
        steps = GetStepCount();
        counterText.text = "Steps: " + steps.ToString();
    }
#else
    public int GetStepCount()
    {
        Debug.LogWarning("Step counter only works on Android devices.");
        return 1313;
    }
#endif
}
