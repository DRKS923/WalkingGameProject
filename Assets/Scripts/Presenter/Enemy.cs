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

    private void Awake()
    {
        canMove = true;
        transform.position = originalPos.position;
        LevelEnemy();
    }

    
    public void MoveEnemy()
    {
        if (canMove)
        {
            transform.position += new Vector3(_x, 0, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision detected");
        if (collision.tag == "Player")
        {
            EnemyManager.Fight(collision.gameObject);
            Debug.Log("Fight Detected");
        }
        if (collision.tag == "Barrier")
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