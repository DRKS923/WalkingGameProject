using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueArea;

    private Queue<DialogueLine> lineQueue;

    public bool isDialogueActive = false;
    public float typingSpeed = 0.2f;
    public Animator animator;
    public StepCounter stepCounter;
    
    void Start()
    {
        if (Instance == null)
            Instance = this;

        lineQueue = new Queue<DialogueLine>();
    }
    
    public void StartDialogue(Dialogue dialogue)
    {
        isDialogueActive = true;
        stepCounter.enabled = false;
        animator.Play("DialogueOpen");
        lineQueue.Clear();

        foreach (DialogueLine dialogueLine in dialogue.dialogueLines) 
        {
            lineQueue.Enqueue(dialogueLine);
        }

        DisplayNextDialogueLine();
    }    

    public void DisplayNextDialogueLine()
    {
        if (lineQueue.Count == 0) 
        {
            EndDialogue();
            return;
        }

        DialogueLine currentLine = lineQueue.Dequeue();
        characterName.text = currentLine.character.name;

        StopAllCoroutines();

        StartCoroutine(TypeSentence(currentLine) );
    }
    
    IEnumerator TypeSentence(DialogueLine dialogueLine) 
    {
        dialogueArea.text = "";
        foreach (char letter in dialogueLine.line.ToCharArray() )
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void EndDialogue()
    {
        isDialogueActive = false;
        stepCounter.enabled = true;
        animator.Play("DialogueClose");
    }
}