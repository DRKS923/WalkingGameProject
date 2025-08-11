using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour, IDataPersistence
{
    public static EnemyManager Instance;
    public GameObject enemy;
    private bool isEnemyLive = false;
    public float spawnTimer;
    [SerializeField]private GameObject winPanel;
    [SerializeField]private GameObject losePanel;
    [SerializeField]private GameObject enemyWarning;
    [SerializeField]private AudioSource panelSound;
    [SerializeField]private AudioClip winSound;
    [SerializeField]private AudioClip loseSound;
    private string currentEnemyId;




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
        panelSound = GetComponent<AudioSource>();
        currentEnemyId = enemy.GetComponent<Enemy>().enemyId;
    }

    void Update()
    {
        if (spawnTimer > 0 && !StepCounter.Instance.isMenuOpen)
        {
            spawnTimer -= Time.deltaTime;
        }
            
     
        if (spawnTimer <= 0 && !isEnemyLive)
        {
            EnemySpawn();
            enemyWarning.SetActive(true);
        }
    }

    void EnemySpawn()
    {
        enemy.SetActive(true);
        isEnemyLive = true;
        enemy.GetComponent<Enemy>().canMove = true;
        enemy.GetComponent<Enemy>().LevelEnemy();
    }

    public void EnemyIsKill()
    {
        enemy.transform.position = enemy.GetComponent<Enemy>().originalPos.position;
        enemy.GetComponent<Enemy>().canMove = false;
        enemy.SetActive(false);
        isEnemyLive = false;
        spawnTimer = 300;
        enemyWarning.SetActive (false);
        DialogueManager.Instance.isDialogueActive = true;
        panelSound.clip = winSound;
        if (PlayerManager.Instance.allowSfx)
        {
            panelSound.Play();
        }
        winPanel.SetActive(true);
        Debug.Log("YOU ARE WINRAR!");
    }

    void PlayerIsKill()
    {
        Debug.Log("YOU LOSE, GOOD DAY SIR.");
        enemy.transform.position = enemy.GetComponent<Enemy>().originalPos.position;
        enemy.GetComponent<Enemy>().canMove = false;
        enemy.SetActive(false);
        isEnemyLive = false;
        spawnTimer = 300;
        enemyWarning.SetActive(false);
        DialogueManager.Instance.isDialogueActive = true;
        
        panelSound.clip = loseSound;
        if (PlayerManager.Instance.allowSfx)
        {
            panelSound.Play();
        }    
        losePanel.SetActive(true);
    }

    public static void Fight()
    {
        int playerLevel = PlayerManager.Instance.PlayerLevel;
        int enemyLevel = Instance.enemy.GetComponent<Enemy>().currentLevel;

        if (playerLevel < enemyLevel) 
        {
            
            Instance.PlayerIsKill();
        }
        else
        {
            Instance.EnemyIsKill();
        }
    }

    public void ClosePanel()
    {
        if (winPanel.activeSelf)
        {
            winPanel.SetActive(false);
        }
        if (losePanel.activeSelf)
        {
            losePanel.SetActive(false);
        }
        DialogueManager.Instance.isDialogueActive = false;
    }

    public void LoadData(GameData data)
    {
        spawnTimer = data.enemyTimer;
        data.enemyStatus.TryGetValue(currentEnemyId, out isEnemyLive);
        enemy.SetActive(isEnemyLive);
        enemy.transform.position = data.enemyPosition;
        enemy.GetComponent<Enemy>().currentLevel = data.enemyLevel;
        enemy.GetComponent<Enemy>().enemyCycle = data.enemyCycle;
    }

    public void SaveData(GameData data)
    {
        data.enemyTimer = spawnTimer;
        data.enemyPosition = enemy.transform.position;
        if (data.enemyStatus.ContainsKey(currentEnemyId))
        {
            data.enemyStatus.Remove(currentEnemyId);
        }
        data.enemyStatus.Add(currentEnemyId, isEnemyLive);
        data.enemyLevel = enemy.GetComponent<Enemy>().currentLevel;
        data.enemyCycle = enemy.GetComponent<Enemy>().enemyCycle;
    }
}
