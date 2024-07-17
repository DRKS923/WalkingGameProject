using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static object instance;
    public List<GameObject> eventList = new List<GameObject>();
    [SerializeField]int listNumber;
    public StepCounter stepCounter;
    bool isEventLive = false;
    [SerializeField]GameObject currentEvent;
    
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        if (stepCounter.Steps % 200 == 0 && !isEventLive)
        {
            spawnEvent();
        }
        if (currentEvent.activeSelf == false)
        {
            isEventLive = false;
        }
    }

    void spawnEvent()
    {
        listNumber = Random.Range(0, 5);
        currentEvent = eventList[listNumber];
        currentEvent.SetActive(true);

        StepCounter.eventScroll = currentEvent.GetComponent<Event>();
        isEventLive = true;
    }
}
