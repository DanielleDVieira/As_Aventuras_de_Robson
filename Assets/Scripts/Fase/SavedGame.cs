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

    public static SavedGame Load()
    {
        var saved = new SavedGame();

        if (File.Exists(Application.persistentDataPath + "/Saved.json"))
        {
            using (var sr = new StreamReader(Application.persistentDataPath + "/Saved.json"))
            {
                var json = sr.ReadToEnd().TrimEnd();
                saved = JsonUtility.FromJson<SavedGame>(json);
            }
        }

        return saved;
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(this);

        using (var sw = new StreamWriter(Application.persistentDataPath + "/Saved.json"))
        {
            sw.Write(json);
        }
    }
}
