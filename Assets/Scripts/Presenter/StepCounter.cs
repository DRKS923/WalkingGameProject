using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class StepCounter : MonoBehaviour
{
#if UNITY_ANDROID
    private AndroidJavaObject stepCounterPlugin;
  
    public TMP_Text counterText;
    [SerializeField] public Background background;
    public BackgroundScroll scroller;
    public int prevSteps;
    private int steps;
    public int Steps{
        get { return steps; }   // get method
        set 
        { 
            steps = value;
            HasStepsChanged();
        }  // set method
    }

    void Start()    
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        stepCounterPlugin = new AndroidJavaObject("com.drks.stepcounterlibrary.StepCounterClass", currentActivity);
        background = gameObject.GetComponent<Background>();
        scroller = gameObject.GetComponent<BackgroundScroll>();
        prevSteps = Steps;
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
        Steps = GetStepCount();
        counterText.text = "Steps: " + Steps.ToString();
    }
    private void OnBecameInvisible()
    {
        
    }

    private void HasStepsChanged()
    {
        if(Steps != prevSteps)
        {
            prevSteps = Steps;
            scroller.moveBG();
        }
        
    }

    public void TakeStep() 
    {
        Steps++;
    }

#else
    public int GetStepCount()
    {
        Debug.LogWarning("Step counter only works on Android devices.");
        return 1313;
    }
#endif

}
