using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]private float _x;
    public int currentLevel = 0;
    [SerializeField]private int lastLevel = 1;
    public bool canMove = false;
    public Transform originalPos;
    public float timerSeconds;
    [SerializeField]private Animator animator;
    [SerializeField]private AudioSource spawnNotif;

    private void OnEnable()
    {
        canMove = true;
        transform.position = originalPos.position;
        LevelEnemy();
        animator = GetComponentInChildren<Animator>();
        spawnNotif = GetComponent<AudioSource>();
        spawnNotif.Play();
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
            EnemyManager.Fight(collision.gameObject);
            Debug.Log("Fight Detected");
        }
        if (collision.CompareTag("Barrier"))
        {
            canMove = false;
            transform.position = originalPos.position;
            this.gameObject.SetActive(false);
        }
    }

    void LevelEnemy()
    {
        currentLevel += lastLevel;
        lastLevel++;
    }

}
