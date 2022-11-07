using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordList
{
    System.Random Generator;
    List<Word> Words;
    string DataPath;

    public WordList()
    {
        Words = new List<Word>();
        DataPath = Application.dataPath;
    }

    public void Load()
    {
        Generator = new System.Random();
        Words = new List<Word>();
        DataPath = Application.dataPath;

        //Words.Add(new Word("Rice", "Arroz"));
        //Words.Add(new Word("Car", "Carro"));
        //Words.Add(new Word("Rain", "Chuva"));
        //Words.Add(new Word("Dog", "Cachorro"));
        Words.Add(new Word("River", "Rio"));
        //Words.Add(new Word("Ocean", "Oceano"));
       // Words.Add(new Word("Book", "Livro"));

        /*
        var reader = new StreamReader(DataPath + "/Words.csv");
        var lines = reader.ReadToEnd().TrimEnd().Split("\n");

        foreach (var line in lines)
        {
            var temp = line.Split(";");
            Debug.Log($"Word: {temp[0]} {temp[1]}");
            Words.Add(new Word(temp[0], temp[1]));
        }
        */
    }

    public Word Next()
    {
        return Words[Generator.Next(Words.Count)];
    }
}
