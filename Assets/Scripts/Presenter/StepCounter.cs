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
    public BackgroundScroll scroller;
    public static Event eventScroll;
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
    public float waitTime = 0.1f;
    public DialogueManager dialogueManager;
    public Animator playerCharacter;
    public int prevStepCounter;

    void Start()    
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        stepCounterPlugin = new AndroidJavaObject("com.drks.stepcounterlibrary.StepCounterClass", currentActivity);
        scroller = gameObject.GetComponent<BackgroundScroll>();
        prevSteps = Steps;
        prevStepCounter = stepCounterPlugin.Call<int>("getStepCount");
    }

    public void GetStepCount()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (stepCounterPlugin.Call<int>("getStepCount") != prevStepCounter)
            {
                prevStepCounter = stepCounterPlugin.Call<int>("getStepCount");
                TakeStep();
            }
        }
        else
        {
            Debug.LogWarning("Step counter only works on Android devices.");
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
        GetStepCount();
        counterText.text = "Steps: " + Steps.ToString();
    }

    private void HasStepsChanged()
    {
        if(Steps != prevSteps)
        {
            prevSteps = Steps;
            scroller.moveBG();
            eventScroll.MoveEvent();
            playerCharacter.Play("PlayerWalk");
        }
        
    }

    public void TakeStep() 
    {
        if (!dialogueManager.isDialogueActive)
        {
            Steps++;
        }
    }

    public void Take100()
    {
        waitTime = 0.1f;
        StartCoroutine(hundredSteps());
    }

    public void Take1K()
    {
        waitTime = 0.05f;
        StartCoroutine(thousandSteps());
    }

    IEnumerator hundredSteps()
    {
        int i = 0;
        while (i < 100 && !dialogueManager.isDialogueActive)
        {
            yield return new WaitForSecondsRealtime(waitTime);
            TakeStep(); ;
            i++;
        }
        
    }
    IEnumerator thousandSteps()
    {
        int i = 0;
        while (i < 1000 && !dialogueManager.isDialogueActive)
        {
            yield return new WaitForSecondsRealtime(waitTime);
            TakeStep(); ;
            i++;
        }

    }




#else
    public int GetStepCount()
    {
        Debug.LogWarning("Step counter only works on Android devices.");
        return 1313;
    }
#endif

}
