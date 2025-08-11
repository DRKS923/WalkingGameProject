using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    [SerializeField]private float _x;
    public Transform originalPos;
    public DialogueTrigger dialogueTrigger;
    public bool canMove = false;
    public bool canTalk = false;
    public Animator animator;
    public AudioSource spawnNotif;
    public string eventId;

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        eventId = System.Guid.NewGuid().ToString();
    }

    void OnEnable()
    {
        canMove = true;
        canTalk = true;
        transform.position = originalPos.position;
        dialogueTrigger = GetComponent<DialogueTrigger>();
        animator = GetComponent<Animator>();
        spawnNotif = GetComponent<AudioSource>();
        if (PlayerManager.Instance.allowSfx)
        {
            spawnNotif.Play();
        }

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
            if (canTalk)
            {
                dialogueTrigger.TriggerDialogue();
                PlayerManager.Instance.AddExp(ExpCalc(PlayerManager.Instance.PlayerLevel));
                canTalk = false;
            }

            
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
