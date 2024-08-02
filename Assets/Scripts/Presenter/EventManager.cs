using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour, IDataPersistence
{
    public static EventManager Instance;
    public List<GameObject> eventList = new();
    [SerializeField]int listNumber;
    bool isEventLive = false;
    [SerializeField]public GameObject currentEvent = null;
    private string currentEventId;

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
        currentEventId = currentEvent.GetComponent<Event>().eventId;
    }

    private void Awake()
    {
        if (currentEvent == null)
        {
            listNumber = Random.Range(0, 5);
            currentEvent = eventList[listNumber];
            currentEvent.GetComponent<Event>();
            currentEvent.GetComponent<Animator>();
            currentEventId = currentEvent.GetComponent<Event>().eventId;
        }
    }

    void Update()
    {
        if (StepCounter.Instance.Steps % 200 == 0 && !isEventLive)
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
        currentEventId = currentEvent.GetComponent<Event>().eventId;
    }

    public void LoadData(GameData data)
    {
        isEventLive = data.currentEventStatus;
        foreach (GameObject gO in eventList)
        {
            if (gO.GetComponent<Event>().eventId == currentEventId)
            {
                currentEvent = gO;
                currentEvent.GetComponent<Event>();
                currentEvent.GetComponent<Animator>();
                currentEvent.SetActive(isEventLive);
            }
        }
        currentEvent.GetComponent<Event>().canTalk = data.canTalk;
        currentEvent.transform.position = data.eventPosition;
       

    }

    public void SaveData(GameData data)
    {
        data.eventPosition = currentEvent.transform.position;
        data.currentEventStatus = isEventLive;
        data.currentEventId = currentEventId;
        data.canTalk = currentEvent.GetComponent<Event>().canTalk;
    }
}
