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
    string savePath;

    public WordList()
    {
        generator = new System.Random();
        words = new List<Word>();
        dataPath = Application.dataPath;
        savePath = Application.persistentDataPath;
    }

    // Carregar as palavras do arquivo de registro para a memória.
    public void Load()
    {
        saved = SavedGame.Load();

        var lines = new StreamReader(dataPath + "/Words.csv").ReadToEnd().TrimEnd().Split("\n");

        if (saved.words.Count >= lines.Count() - 1)
        {
            saved = new SavedGame();
            saved.Save();
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
        saved.Save();
        Load();
    }
}
