﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignPost : ActionItem
{
    public override void Interact()
    {
        base.Interact();
        Debug.Log("Interacting with sign post");
    }
}