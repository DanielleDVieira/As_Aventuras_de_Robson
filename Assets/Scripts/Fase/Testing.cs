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
        // Se clicado no botão esquerdo do mouse
        if (Input.GetMouseButtonDown(0)) {
            grid.SetValue(UtilsClass.GetMouseWorldPosition(), 1);
        }

        // Se clicado no botão direito do mouse
        if (Input.GetMouseButtonDown(1)) {
            string gridParaArquivo = "";

            // Formar texto com cada linha com as posições e os valores dos quadrados da grid
            for (int x = 0; x < 38; x++) {
                for (int y = 0; y < 20; y++) {
                    gridParaArquivo += "SetValue("+x+", "+y+", "+grid.GetValue(x, y)+");\n";
                }
            }
            // salvar text após concatenação
            salvaGridArquivo(gridParaArquivo);

            // Teste para salvar apenas uma linha no arquivo .txt e também debugar
            //int x, y;
            //grid.GetXY(UtilsClass.GetMouseWorldPosition(), out x, out y);
            //salvaGridArquivo("SetValue("+x+", "+y+", "+grid.GetValue(UtilsClass.GetMouseWorldPosition())+");");
            //Debug.Log(grid.GetValue(UtilsClass.GetMouseWorldPosition()));
        }
    }

    // Salvar text em arquivo .txt
    private void salvaGridArquivo(string text) {
        string myfile = @"grid3.txt";
        if (!File.Exists(myfile)) {
            using(StreamWriter sw = File.AppendText(myfile)){
                sw.WriteLine(text);
            }
        }
    }
}
