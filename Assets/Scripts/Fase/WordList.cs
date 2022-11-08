using System;
using System.Linq;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordList
{
    System.Random generator;
    List<Word> words;
    SavedGame saved;
    string dataPath;

    public WordList()
    {
        generator = new System.Random();
        words = new List<Word>();
        dataPath = Application.dataPath;
    }

    // Carregar as palavras do arquivo de registro para a memória.
    public void Load()
    {
        saved = new SavedGame();

        var lines = new StreamReader(dataPath + "/Words.csv").ReadToEnd().TrimEnd().Split("\n");

        // Se o arquivo 'Saved.json' existir, então devemos carregar o progresso dele.
        if (File.Exists(dataPath + "/Saved.json"))
        {
            using (var sr = new StreamReader(dataPath + "/Saved.json"))
            {
                var json = sr.ReadToEnd().TrimEnd();
                saved = JsonUtility.FromJson<SavedGame>(json);
            }

            if (saved.words.Count >= lines.Count() - 1)
            {
                saved = new SavedGame();
                SaveGame(saved);
            }
        }

        // Popular o registro com as palavras carregadas.
        foreach (var line in lines)
        {
            var temp = line.Split(",");

            // Ignorar as palavras presentes no arquivo de save game.
            if (!saved.words.Contains(temp[0]))
            {
                words.Add(new Word(temp[0], temp[1]));
            }
        }
    }

    // Obter uma palavra aleatória do registro.
    public Word Next()
    {
        if (words.Count > 1)
        {
            return words[generator.Next(words.Count)];
        }
        else
        {
            return words[0];
        }
    }

    // Remover palavra do registro e salvar o progresso do jogo em arquivo.
    public void RemoveAndSave(Word word)
    {
        words.Remove(word);
        saved.words.Add(word.Ingles);
        SaveGame(saved);
        Load();
    }

    public void SaveGame(SavedGame saved)
    {
        string json = JsonUtility.ToJson(saved);

        using (var sw = new StreamWriter(dataPath + "/Saved.json"))
        {
            sw.Write(json);
        }
    }
}
