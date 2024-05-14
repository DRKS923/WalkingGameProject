using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    public float _x;
    public Transform originalPos;
    public bool isColliding = false;
    public DialogueTrigger dialogueTrigger;
    public BoxCollider2D bc2D;
    private bool canMove = true;
    public Animator animator;

    void Start()
    {
        canMove = true;
        transform.position = originalPos.position;
        dialogueTrigger = GetComponent<DialogueTrigger>();
        bc2D = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
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
        if (collision.tag == "Player")
        {
            dialogueTrigger.TriggerDialogue();
        }
        if (collision.tag == "Barrier")
        {
            canMove = false;
            this.gameObject.SetActive(false);
        }
    }
}
