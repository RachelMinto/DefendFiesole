﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour {

    public void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach(DefenderButton button in buttons) {
            button.GetComponent<SpriteRenderer>().color = new Color32(53, 53, 53, 255);
        }
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
