using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;
    public GameObject enemy;
    private bool isEnemyLive = false;
    public float spawnTimer;
    [SerializeField]private GameObject winPanel;
    [SerializeField]private GameObject losePanel;
    [SerializeField]private GameObject enemyWarning;




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
        //enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    void Update()
    {
        if (spawnTimer > 0)
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
    }

    public void EnemyIsKill()
    {
        enemy.transform.position = enemy.GetComponent<Enemy>().originalPos.position;
        enemy.GetComponent<Enemy>().canMove = false;
        enemy.SetActive(false);
        isEnemyLive = false;
        spawnTimer = 300;
        enemyWarning.SetActive (false);
        DialogueManager.Instance.GetComponent<DialogueManager>().isDialogueActive = true;
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
        DialogueManager.Instance.GetComponent<DialogueManager>().isDialogueActive = true;
        losePanel.SetActive(true);
    }

    public static void Fight(GameObject player)
    {
        int playerLevel = player.GetComponent<PlayerLevel>().playerLevel;
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
        DialogueManager.Instance.GetComponent<DialogueManager>().isDialogueActive = false;
    }

}
