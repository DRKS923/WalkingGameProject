using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Android;

public class StepCounter : MonoBehaviour, IDataPersistence
{
    public static StepCounter Instance { get; private set; }
    [SerializeField] private TMP_Text counterText;
    [SerializeField] private BackgroundScroll scroller;
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private Animator playerCharacter;
    [SerializeField] private float waitTime = 0.1f;
    public bool isMenuOpen = false;
    private int prevSteps;
    private int steps;
    private int prevStepCounter;

    public int Steps{
        get { return steps; }   // get method
        set 
        { 
            steps = value;
            HasStepsChanged();
        }  // set method
    }

    #if UNITY_ANDROID
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        RequestPermissions();
        prevSteps = Steps;
        prevStepCounter = AndroidStepCounter.current.stepCounter.ReadValue();
    }

    private void OnEnable()
    {
        if(!AndroidStepCounter.current.enabled)
        {
            InputSystem.EnableDevice(AndroidStepCounter.current);
            AndroidStepCounter.current.MakeCurrent();
        }
    }

    public void GetStepCount()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            
            if (AndroidStepCounter.current.stepCounter.ReadValue() != prevStepCounter){
                TakeStep();
                prevStepCounter = AndroidStepCounter.current.stepCounter.ReadValue();
            }
        }
        else
        {
            Debug.LogWarning("Step counter only works on Android devices.");
        }
    }

    private void Update()
    {
        GetStepCount();
        counterText.text = $"Steps: {Steps}";
    }

    private void HasStepsChanged()
    {
        if (Steps != prevSteps)
        {
            prevSteps = Steps;
            scroller?.moveBG();
            EventManager.Instance?.currentEvent?.GetComponent<Event>()?.MoveEvent();
            playerCharacter?.Play("PlayerWalk");
            EnemyManager.Instance?.enemy?.GetComponent<Enemy>()?.MoveEnemy();
        }
    }

    public void TakeStep() 
    {
        if (!dialogueManager.isDialogueActive && !isMenuOpen)
        {
            Steps++;
        }
    }
    public void LoadData(GameData data)
    {
        Steps = data.steps;
    }

    public void SaveData(GameData data)
    {
        data.steps = steps;
    }

    //testing functions
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
    
    private void RequestPermissions() 
    {
        if (!Permission.HasUserAuthorizedPermission("android.permission.ACTIVITY_RECOGNITION"))
        {
            Permission.RequestUserPermission("android.permission.ACTIVITY_RECOGNITION");
        }
        if (!Permission.HasUserAuthorizedPermission("android.permission.WRITE_EXTERNAL_STORAGE"))
        {
            Permission.RequestUserPermission("android.permission.WRITE_EXTERNAL_STORAGE");
        }
        if (!Permission.HasUserAuthorizedPermission("android.permission.READ_EXTERNAL_STORAGE"))
        {
            Permission.RequestUserPermission("android.permission.READ_EXTERNAL_STORAGE");
        }
    }
#endif

}
