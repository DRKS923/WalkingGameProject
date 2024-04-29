using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    public float _x;
    Vector3 originalPos;
    public bool isColliding = false;
    public DialogueTrigger dialogueTrigger;
    public BoxCollider2D bc2D;

    void Start()
    {
        originalPos = transform.position;
        dialogueTrigger = GetComponent<DialogueTrigger>();
        bc2D = GetComponent<BoxCollider2D>();
    }

    public void MoveEvent()
    {
        transform.position += new Vector3(_x, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        isColliding = true;
        //this.gameObject.transform.position = originalPos;
        Debug.Log("Collision Detected");
        dialogueTrigger.TriggerDialogue();
        bc2D.enabled = false;
    }
}
