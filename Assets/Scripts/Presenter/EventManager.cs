using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;
    public List<GameObject> eventList = new List<GameObject>();
    [SerializeField]int listNumber;
    bool isEventLive = false;
    [SerializeField]public GameObject currentEvent = null;
    
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Awake()
    {
        if (currentEvent == null)
        {
            listNumber = Random.Range(0, 5);
            currentEvent = eventList[listNumber];
            currentEvent.GetComponent<Event>();
            currentEvent.GetComponent<Animator>();
        }
    }

    void Update()
    {
        if (StepCounter.Instance.GetComponent<StepCounter>().Steps % 200 == 0 && !isEventLive)
        {
            SpawnEvent();
        }
        if (currentEvent.activeSelf == false)
        {
            isEventLive = false;
        }
    }

    void SpawnEvent()
    {
        listNumber = Random.Range(0, 5);
        currentEvent = eventList[listNumber];
        currentEvent.SetActive(true);
        isEventLive = true;
        currentEvent.GetComponent<Event>().canMove = true;
    }
}
