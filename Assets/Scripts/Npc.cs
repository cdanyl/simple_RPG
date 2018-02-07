using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : Interactable
{
    public string Name;
    public string[] Dialogue;

    public override void Interact()
    {
        DialogueSystem.Instance.AddNewDialogue(Dialogue, Name);

        Debug.Log("Interacting with NPC");
    }
}