using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using System;
using System.IO;

public class Testing : MonoBehaviour
{
    private Grid grid;

    // Start is called before the first frame update
    private void Start()
    {
        // Criar grid para testar
        grid = new Grid(38, 20, 1f, new Vector3(-19, -10));
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            grid.SetValue(UtilsClass.GetMouseWorldPosition(), 1);
        }

        if (Input.GetMouseButtonDown(1)) {
            string gridParaArquivo = "";

            for (int x = 0; x < 38; x++) {
                for (int y = 0; y < 20; y++) {
                    gridParaArquivo += "SetValue("+x+", "+y+", "+grid.GetValue(x, y)+");\n";
                }
            }
            salvaGridArquivo(gridParaArquivo);
            //int x, y;
            //grid.GetXY(UtilsClass.GetMouseWorldPosition(), out x, out y);
            //salvaGridArquivo("SetValue("+x+", "+y+", "+grid.GetValue(UtilsClass.GetMouseWorldPosition())+");");
            //Debug.Log(grid.GetValue(UtilsClass.GetMouseWorldPosition()));
        }
    }

    private void salvaGridArquivo(string text) {
        string myfile = @"grid.txt";
        if (!File.Exists(myfile)) {
            using(StreamWriter sw = File.AppendText(myfile)){
                sw.WriteLine(text);
            }
        }
    }
}
