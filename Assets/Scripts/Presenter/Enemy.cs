using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]private float _x;
    public int currentLevel = 0;
    public int enemyCycle = 1;
    public bool canMove = false;
    public Transform originalPos;
    public float timerSeconds;
    [SerializeField]private Animator animator;
    [SerializeField]private AudioSource spawnNotif;
    public string enemyId;
    [SerializeField]private TMP_Text levelText;

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        enemyId = System.Guid.NewGuid().ToString();
    }

    private void OnEnable()
    {
        canMove = true;
        transform.position = originalPos.position;
        animator = GetComponentInChildren<Animator>();
        spawnNotif = GetComponent<AudioSource>();
        if (PlayerManager.Instance.allowSfx)
        {
            spawnNotif.Play();
        }
        
    }

    private void Update()
    {
        levelText.text = "Level: " + currentLevel.ToString();
    }


    public void MoveEnemy()
    {
        if (canMove)
        {
            transform.position += new Vector3(_x, 0, 0);
            animator.Play("walk");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision detected");
        if (collision.CompareTag("Player"))
        {
            EnemyManager.Fight();
            Debug.Log("Fight Detected");
        }
        if (collision.CompareTag("Barrier"))
        {
            canMove = false;
            transform.position = originalPos.position;
            this.gameObject.SetActive(false);
            EnemyManager.Instance.spawnTimer = 300;
        }
    }

    public void LevelEnemy()
    {
        if (enemyCycle < 30)
        {
            currentLevel++;
        }
        else if (enemyCycle >= 30)
        {
            currentLevel += 2;
        }
        else if (enemyCycle >= 40)
        {
            currentLevel += 3;
        }
        else if(enemyCycle >= 50)
        {
            currentLevel += 4;  
        }

        //better system
        
        enemyCycle++;
    }

}
