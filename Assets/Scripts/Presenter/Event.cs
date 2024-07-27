using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    [SerializeField]private float _x;
    public Transform originalPos;
    public DialogueTrigger dialogueTrigger;
    public bool canMove = false;
    public Animator animator;
    public AudioSource spawnNotif;
    public GameObject playerCharacter;
    public PlayerLevel playerLevelScript;

    void OnEnable()
    {
        canMove = true;
        transform.position = originalPos.position;
        dialogueTrigger = GetComponent<DialogueTrigger>();
        animator = GetComponent<Animator>();
        spawnNotif = GetComponent<AudioSource>();
        spawnNotif.Play();
        playerCharacter = GameObject.FindGameObjectWithTag("Player");
        playerLevelScript = playerCharacter.GetComponent<PlayerLevel>();
    }

    public void MoveEvent()
    {
        if (canMove)
        {
            transform.position += new Vector3(_x, 0, 0);
            animator.Play("VillagerWalk");
        }
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogueTrigger.TriggerDialogue();
            playerLevelScript.currentExp += ExpCalc(playerLevelScript.playerLevel); ;
        }
        if (collision.CompareTag("Barrier"))
        {
            canMove = false;
            transform.position = originalPos.position;
            this.gameObject.SetActive(false);
        }
    }

    int ExpCalc(int level)
    {
        int expToGive = 50 + ((level - 1) * 10);
        return expToGive;
    }
}
