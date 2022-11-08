using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SavedGame
{
    public List<string> words;

    public SavedGame()
    {
        words = new List<string>();
    }
}
