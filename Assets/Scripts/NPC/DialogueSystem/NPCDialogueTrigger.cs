using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogueTrigger : MonoBehaviour
{
    public NPCDetails npcDetails;
    public Dialogue dialogue;

    public Canvas canvas;
    //if dialogue is active disable trigger
    public bool isActive;
    public bool playerInRange;
    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            DialogueManager.Instance.StartDialogue(dialogue, npcDetails);
            isActive = true;
        }
        if (isActive && Input.GetKeyDown(KeyCode.Space))
        {
            DialogueManager.Instance.DisplayNextSentence();
        }
    }
    private void Start()
    {
        canvas = GetComponentInChildren<Canvas>();
        canvas.enabled = false;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (true || other.gameObject.layer == 10)
        {
            playerInRange = true;
            canvas.enabled = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (true|| other.gameObject.layer == 10)
        {
            playerInRange = false;
            canvas.enabled = false;
        }
    }
}
public enum InteractionType
{
    DIALOGUE,
    QUEST
}