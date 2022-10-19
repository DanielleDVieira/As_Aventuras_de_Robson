using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Grid 
{
    private int width;
    private int height;
    private float cellSize;
    private Vector3 originPosition;

    // Definir a matriz que conterá grid
    private int[,] gridArray;
    private TextMesh[,] debugTextArray;

    // Construtor que recebe a largura e altura
    public Grid(int width, int height, float cellSize, Vector3 originPosition) {
        // Largura e altura da grid
        this.width = width;
        this.height = height; 

        // Tamanho da célula (quadradinho na grid)
        this.cellSize = cellSize;

        // Posição onde irá começar a grid
        this.originPosition = originPosition;

        gridArray = new int[width, height];
        debugTextArray = new TextMesh[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++) {
            for (int y = 0; y < gridArray.GetLength(1); y++) {
                // Criar texto
                debugTextArray[x, y] = UtilsClass.CreateWorldText(gridArray[x, y].ToString(), null, GetWorldPosition(x, y) + new Vector3(cellSize, cellSize) * .5f, 5, Color.black, TextAnchor.MiddleCenter);
                // Desenhar linhas da grid
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.black, 100f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.black, 100f);
            }
        }

        // Desenhar linhas do topo e da lateral direita
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.black, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.black, 100f);
        

        // Setar valor de cada quadrado na grid na mão, copiados do arquivo txt
        SetValue(0, 0, 0);
        SetValue(0, 1, 0);
        SetValue(0, 2, 0);
        SetValue(0, 3, 0);
        SetValue(0, 4, 0);
        SetValue(0, 5, 0);
        SetValue(0, 6, 0);
        SetValue(0, 7, 0);
        SetValue(0, 8, 0);
        SetValue(0, 9, 0);
        SetValue(0, 10, 0);
        SetValue(0, 11, 0);
        SetValue(0, 12, 0);
        SetValue(0, 13, 0);
        SetValue(0, 14, 0);
        SetValue(0, 15, 0);
        SetValue(0, 16, 0);
        SetValue(0, 17, 0);
        SetValue(0, 18, 0);
        SetValue(0, 19, 0);
        SetValue(1, 0, 0);
        SetValue(1, 1, 0);
        SetValue(1, 2, 0);
        SetValue(1, 3, 0);
        SetValue(1, 4, 0);
        SetValue(1, 5, 0);
        SetValue(1, 6, 1);
        SetValue(1, 7, 0);
        SetValue(1, 8, 0);
        SetValue(1, 9, 1);
        SetValue(1, 10, 0);
        SetValue(1, 11, 0);
        SetValue(1, 12, 0);
        SetValue(1, 13, 0);
        SetValue(1, 14, 0);
        SetValue(1, 15, 0);
        SetValue(1, 16, 1);
        SetValue(1, 17, 0);
        SetValue(1, 18, 0);
        SetValue(1, 19, 0);
        SetValue(2, 0, 0);
        SetValue(2, 1, 0);
        SetValue(2, 2, 0);
        SetValue(2, 3, 0);
        SetValue(2, 4, 0);
        SetValue(2, 5, 0);
        SetValue(2, 6, 1);
        SetValue(2, 7, 0);
        SetValue(2, 8, 0);
        SetValue(2, 9, 1);
        SetValue(2, 10, 0);
        SetValue(2, 11, 0);
        SetValue(2, 12, 0);
        SetValue(2, 13, 0);
        SetValue(2, 14, 0);
        SetValue(2, 15, 0);
        SetValue(2, 16, 1);
        SetValue(2, 17, 0);
        SetValue(2, 18, 0);
        SetValue(2, 19, 0);
        SetValue(3, 0, 0);
        SetValue(3, 1, 0);
        SetValue(3, 2, 0);
        SetValue(3, 3, 0);
        SetValue(3, 4, 0);
        SetValue(3, 5, 0);
        SetValue(3, 6, 1);
        SetValue(3, 7, 0);
        SetValue(3, 8, 0);
        SetValue(3, 9, 1);
        SetValue(3, 10, 0);
        SetValue(3, 11, 0);
        SetValue(3, 12, 0);
        SetValue(3, 13, 0);
        SetValue(3, 14, 0);
        SetValue(3, 15, 1);
        SetValue(3, 16, 1);
        SetValue(3, 17, 0);
        SetValue(3, 18, 0);
        SetValue(3, 19, 0);
        SetValue(4, 0, 0);
        SetValue(4, 1, 0);
        SetValue(4, 2, 0);
        SetValue(4, 3, 0);
        SetValue(4, 4, 0);
        SetValue(4, 5, 0);
        SetValue(4, 6, 1);
        SetValue(4, 7, 0);
        SetValue(4, 8, 0);
        SetValue(4, 9, 1);
        SetValue(4, 10, 0);
        SetValue(4, 11, 0);
        SetValue(4, 12, 0);
        SetValue(4, 13, 0);
        SetValue(4, 14, 0);
        SetValue(4, 15, 1);
        SetValue(4, 16, 0);
        SetValue(4, 17, 0);
        SetValue(4, 18, 0);
        SetValue(4, 19, 0);
        SetValue(5, 0, 0);
        SetValue(5, 1, 0);
        SetValue(5, 2, 0);
        SetValue(5, 3, 0);
        SetValue(5, 4, 0);
        SetValue(5, 5, 0);
        SetValue(5, 6, 1);
        SetValue(5, 7, 2);
        SetValue(5, 8, 2);
        SetValue(5, 9, 2);
        SetValue(5, 10, 2);
        SetValue(5, 11, 0);
        SetValue(5, 12, 0);
        SetValue(5, 13, 0);
        SetValue(5, 14, 0);
        SetValue(5, 15, 1);
        SetValue(5, 16, 0);
        SetValue(5, 17, 0);
        SetValue(5, 18, 0);
        SetValue(5, 19, 0);
        SetValue(6, 0, 0);
        SetValue(6, 1, 0);
        SetValue(6, 2, 0);
        SetValue(6, 3, 0);
        SetValue(6, 4, 0);
        SetValue(6, 5, 0);
        SetValue(6, 6, 1);
        SetValue(6, 7, 0);
        SetValue(6, 8, 0);
        SetValue(6, 9, 0);
        SetValue(6, 10, 0);
        SetValue(6, 11, 2);
        SetValue(6, 12, 0);
        SetValue(6, 13, 0);
        SetValue(6, 14, 0);
        SetValue(6, 15, 1);
        SetValue(6, 16, 0);
        SetValue(6, 17, 0);
        SetValue(6, 18, 0);
        SetValue(6, 19, 0);
        SetValue(7, 0, 0);
        SetValue(7, 1, 0);
        SetValue(7, 2, 0);
        SetValue(7, 3, 0);
        SetValue(7, 4, 0);
        SetValue(7, 5, 0);
        SetValue(7, 6, 1);
        SetValue(7, 7, 0);
        SetValue(7, 8, 0);
        SetValue(7, 9, 0);
        SetValue(7, 10, 0);
        SetValue(7, 11, 1);
        SetValue(7, 12, 0);
        SetValue(7, 13, 0);
        SetValue(7, 14, 0);
        SetValue(7, 15, 2);
        SetValue(7, 16, 0);
        SetValue(7, 17, 0);
        SetValue(7, 18, 0);
        SetValue(7, 19, 0);
        SetValue(8, 0, 0);
        SetValue(8, 1, 0);
        SetValue(8, 2, 0);
        SetValue(8, 3, 0);
        SetValue(8, 4, 0);
        SetValue(8, 5, 0);
        SetValue(8, 6, 1);
        SetValue(8, 7, 0);
        SetValue(8, 8, 0);
        SetValue(8, 9, 0);
        SetValue(8, 10, 0);
        SetValue(8, 11, 0);
        SetValue(8, 12, 2);
        SetValue(8, 13, 0);
        SetValue(8, 14, 2);
        SetValue(8, 15, 2);
        SetValue(8, 16, 0);
        SetValue(8, 17, 0);
        SetValue(8, 18, 0);
        SetValue(8, 19, 0);
        SetValue(9, 0, 0);
        SetValue(9, 1, 0);
        SetValue(9, 2, 0);
        SetValue(9, 3, 0);
        SetValue(9, 4, 0);
        SetValue(9, 5, 0);
        SetValue(9, 6, 1);
        SetValue(9, 7, 0);
        SetValue(9, 8, 0);
        SetValue(9, 9, 0);
        SetValue(9, 10, 0);
        SetValue(9, 11, 0);
        SetValue(9, 12, 2);
        SetValue(9, 13, 2);
        SetValue(9, 14, 0);
        SetValue(9, 15, 0);
        SetValue(9, 16, 0);
        SetValue(9, 17, 0);
        SetValue(9, 18, 0);
        SetValue(9, 19, 0);
        SetValue(10, 0, 0);
        SetValue(10, 1, 0);
        SetValue(10, 2, 0);
        SetValue(10, 3, 0);
        SetValue(10, 4, 0);
        SetValue(10, 5, 0);
        SetValue(10, 6, 2);
        SetValue(10, 7, 0);
        SetValue(10, 8, 0);
        SetValue(10, 9, 0);
        SetValue(10, 10, 0);
        SetValue(10, 11, 0);
        SetValue(10, 12, 1);
        SetValue(10, 13, 0);
        SetValue(10, 14, 0);
        SetValue(10, 15, 0);
        SetValue(10, 16, 0);
        SetValue(10, 17, 0);
        SetValue(10, 18, 0);
        SetValue(10, 19, 0);
        SetValue(11, 0, 0);
        SetValue(11, 1, 0);
        SetValue(11, 2, 0);
        SetValue(11, 3, 0);
        SetValue(11, 4, 0);
        SetValue(11, 5, 2);
        SetValue(11, 6, 0);
        SetValue(11, 7, 0);
        SetValue(11, 8, 0);
        SetValue(11, 9, 0);
        SetValue(11, 10, 0);
        SetValue(11, 11, 0);
        SetValue(11, 12, 1);
        SetValue(11, 13, 0);
        SetValue(11, 14, 0);
        SetValue(11, 15, 0);
        SetValue(11, 16, 0);
        SetValue(11, 17, 0);
        SetValue(11, 18, 0);
        SetValue(11, 19, 0);
        SetValue(12, 0, 0);
        SetValue(12, 1, 0);
        SetValue(12, 2, 0);
        SetValue(12, 3, 0);
        SetValue(12, 4, 0);
        SetValue(12, 5, 1);
        SetValue(12, 6, 0);
        SetValue(12, 7, 0);
        SetValue(12, 8, 0);
        SetValue(12, 9, 0);
        SetValue(12, 10, 0);
        SetValue(12, 11, 0);
        SetValue(12, 12, 1);
        SetValue(12, 13, 0);
        SetValue(12, 14, 0);
        SetValue(12, 15, 0);
        SetValue(12, 16, 0);
        SetValue(12, 17, 0);
        SetValue(12, 18, 0);
        SetValue(12, 19, 0);
        SetValue(13, 0, 0);
        SetValue(13, 1, 0);
        SetValue(13, 2, 1);
        SetValue(13, 3, 2);
        SetValue(13, 4, 2);
        SetValue(13, 5, 2);
        SetValue(13, 6, 0);
        SetValue(13, 7, 0);
        SetValue(13, 8, 0);
        SetValue(13, 9, 0);
        SetValue(13, 10, 0);
        SetValue(13, 11, 0);
        SetValue(13, 12, 0);
        SetValue(13, 13, 2);
        SetValue(13, 14, 0);
        SetValue(13, 15, 0);
        SetValue(13, 16, 0);
        SetValue(13, 17, 0);
        SetValue(13, 18, 0);
        SetValue(13, 19, 0);
        SetValue(14, 0, 0);
        SetValue(14, 1, 0);
        SetValue(14, 2, 1);
        SetValue(14, 3, 0);
        SetValue(14, 4, 0);
        SetValue(14, 5, 0);
        SetValue(14, 6, 2);
        SetValue(14, 7, 0);
        SetValue(14, 8, 0);
        SetValue(14, 9, 0);
        SetValue(14, 10, 0);
        SetValue(14, 11, 0);
        SetValue(14, 12, 0);
        SetValue(14, 13, 2);
        SetValue(14, 14, 0);
        SetValue(14, 15, 0);
        SetValue(14, 16, 0);
        SetValue(14, 17, 0);
        SetValue(14, 18, 0);
        SetValue(14, 19, 0);
        SetValue(15, 0, 0);
        SetValue(15, 1, 0);
        SetValue(15, 2, 1);
        SetValue(15, 3, 0);
        SetValue(15, 4, 0);
        SetValue(15, 5, 0);
        SetValue(15, 6, 0);
        SetValue(15, 7, 2);
        SetValue(15, 8, 0);
        SetValue(15, 9, 0);
        SetValue(15, 10, 0);
        SetValue(15, 11, 0);
        SetValue(15, 12, 2);
        SetValue(15, 13, 0);
        SetValue(15, 14, 0);
        SetValue(15, 15, 0);
        SetValue(15, 16, 0);
        SetValue(15, 17, 0);
        SetValue(15, 18, 0);
        SetValue(15, 19, 0);
        SetValue(16, 0, 0);
        SetValue(16, 1, 0);
        SetValue(16, 2, 1);
        SetValue(16, 3, 0);
        SetValue(16, 4, 0);
        SetValue(16, 5, 0);
        SetValue(16, 6, 0);
        SetValue(16, 7, 1);
        SetValue(16, 8, 0);
        SetValue(16, 9, 0);
        SetValue(16, 10, 0);
        SetValue(16, 11, 0);
        SetValue(16, 12, 1);
        SetValue(16, 13, 0);
        SetValue(16, 14, 0);
        SetValue(16, 15, 0);
        SetValue(16, 16, 0);
        SetValue(16, 17, 0);
        SetValue(16, 18, 0);
        SetValue(16, 19, 0);
        SetValue(17, 0, 0);
        SetValue(17, 1, 0);
        SetValue(17, 2, 1);
        SetValue(17, 3, 0);
        SetValue(17, 4, 0);
        SetValue(17, 5, 0);
        SetValue(17, 6, 0);
        SetValue(17, 7, 1);
        SetValue(17, 8, 0);
        SetValue(17, 9, 0);
        SetValue(17, 10, 0);
        SetValue(17, 11, 0);
        SetValue(17, 12, 1);
        SetValue(17, 13, 0);
        SetValue(17, 14, 0);
        SetValue(17, 15, 0);
        SetValue(17, 16, 0);
        SetValue(17, 17, 0);
        SetValue(17, 18, 0);
        SetValue(17, 19, 0);
        SetValue(18, 0, 0);
        SetValue(18, 1, 0);
        SetValue(18, 2, 1);
        SetValue(18, 3, 0);
        SetValue(18, 4, 0);
        SetValue(18, 5, 0);
        SetValue(18, 6, 0);
        SetValue(18, 7, 1);
        SetValue(18, 8, 2);
        SetValue(18, 9, 0);
        SetValue(18, 10, 0);
        SetValue(18, 11, 0);
        SetValue(18, 12, 2);
        SetValue(18, 13, 2);
        SetValue(18, 14, 0);
        SetValue(18, 15, 0);
        SetValue(18, 16, 0);
        SetValue(18, 17, 0);
        SetValue(18, 18, 0);
        SetValue(18, 19, 0);
        SetValue(19, 0, 0);
        SetValue(19, 1, 0);
        SetValue(19, 2, 1);
        SetValue(19, 3, 0);
        SetValue(19, 4, 0);
        SetValue(19, 5, 0);
        SetValue(19, 6, 0);
        SetValue(19, 7, 0);
        SetValue(19, 8, 0);
        SetValue(19, 9, 2);
        SetValue(19, 10, 0);
        SetValue(19, 11, 0);
        SetValue(19, 12, 2);
        SetValue(19, 13, 0);
        SetValue(19, 14, 2);
        SetValue(19, 15, 0);
        SetValue(19, 16, 0);
        SetValue(19, 17, 0);
        SetValue(19, 18, 0);
        SetValue(19, 19, 0);
        SetValue(20, 0, 0);
        SetValue(20, 1, 0);
        SetValue(20, 2, 1);
        SetValue(20, 3, 0);
        SetValue(20, 4, 0);
        SetValue(20, 5, 0);
        SetValue(20, 6, 0);
        SetValue(20, 7, 0);
        SetValue(20, 8, 0);
        SetValue(20, 9, 0);
        SetValue(20, 10, 0);
        SetValue(20, 11, 2);
        SetValue(20, 12, 0);
        SetValue(20, 13, 0);
        SetValue(20, 14, 1);
        SetValue(20, 15, 0);
        SetValue(20, 16, 0);
        SetValue(20, 17, 0);
        SetValue(20, 18, 0);
        SetValue(20, 19, 0);
        SetValue(21, 0, 0);
        SetValue(21, 1, 0);
        SetValue(21, 2, 1);
        SetValue(21, 3, 0);
        SetValue(21, 4, 0);
        SetValue(21, 5, 0);
        SetValue(21, 6, 0);
        SetValue(21, 7, 0);
        SetValue(21, 8, 0);
        SetValue(21, 9, 0);
        SetValue(21, 10, 1);
        SetValue(21, 11, 0);
        SetValue(21, 12, 0);
        SetValue(21, 13, 0);
        SetValue(21, 14, 1);
        SetValue(21, 15, 0);
        SetValue(21, 16, 0);
        SetValue(21, 17, 0);
        SetValue(21, 18, 0);
        SetValue(21, 19, 0);
        SetValue(22, 0, 0);
        SetValue(22, 1, 0);
        SetValue(22, 2, 1);
        SetValue(22, 3, 0);
        SetValue(22, 4, 0);
        SetValue(22, 5, 0);
        SetValue(22, 6, 0);
        SetValue(22, 7, 0);
        SetValue(22, 8, 0);
        SetValue(22, 9, 0);
        SetValue(22, 10, 2);
        SetValue(22, 11, 0);
        SetValue(22, 12, 0);
        SetValue(22, 13, 0);
        SetValue(22, 14, 2);
        SetValue(22, 15, 0);
        SetValue(22, 16, 0);
        SetValue(22, 17, 0);
        SetValue(22, 18, 0);
        SetValue(22, 19, 0);
        SetValue(23, 0, 0);
        SetValue(23, 1, 0);
        SetValue(23, 2, 0);
        SetValue(23, 3, 2);
        SetValue(23, 4, 0);
        SetValue(23, 5, 0);
        SetValue(23, 6, 0);
        SetValue(23, 7, 1);
        SetValue(23, 8, 2);
        SetValue(23, 9, 2);
        SetValue(23, 10, 0);
        SetValue(23, 11, 2);
        SetValue(23, 12, 0);
        SetValue(23, 13, 0);
        SetValue(23, 14, 2);
        SetValue(23, 15, 0);
        SetValue(23, 16, 0);
        SetValue(23, 17, 0);
        SetValue(23, 18, 0);
        SetValue(23, 19, 0);
        SetValue(24, 0, 0);
        SetValue(24, 1, 0);
        SetValue(24, 2, 0);
        SetValue(24, 3, 2);
        SetValue(24, 4, 0);
        SetValue(24, 5, 0);
        SetValue(24, 6, 0);
        SetValue(24, 7, 1);
        SetValue(24, 8, 0);
        SetValue(24, 9, 0);
        SetValue(24, 10, 0);
        SetValue(24, 11, 0);
        SetValue(24, 12, 2);
        SetValue(24, 13, 2);
        SetValue(24, 14, 0);
        SetValue(24, 15, 0);
        SetValue(24, 16, 0);
        SetValue(24, 17, 0);
        SetValue(24, 18, 0);
        SetValue(24, 19, 0);
        SetValue(25, 0, 0);
        SetValue(25, 1, 0);
        SetValue(25, 2, 0);
        SetValue(25, 3, 2);
        SetValue(25, 4, 0);
        SetValue(25, 5, 0);
        SetValue(25, 6, 0);
        SetValue(25, 7, 1);
        SetValue(25, 8, 0);
        SetValue(25, 9, 0);
        SetValue(25, 10, 0);
        SetValue(25, 11, 0);
        SetValue(25, 12, 2);
        SetValue(25, 13, 0);
        SetValue(25, 14, 0);
        SetValue(25, 15, 0);
        SetValue(25, 16, 0);
        SetValue(25, 17, 0);
        SetValue(25, 18, 0);
        SetValue(25, 19, 0);
        SetValue(26, 0, 0);
        SetValue(26, 1, 0);
        SetValue(26, 2, 1);
        SetValue(26, 3, 0);
        SetValue(26, 4, 0);
        SetValue(26, 5, 0);
        SetValue(26, 6, 0);
        SetValue(26, 7, 1);
        SetValue(26, 8, 0);
        SetValue(26, 9, 0);
        SetValue(26, 10, 0);
        SetValue(26, 11, 0);
        SetValue(26, 12, 1);
        SetValue(26, 13, 0);
        SetValue(26, 14, 0);
        SetValue(26, 15, 0);
        SetValue(26, 16, 0);
        SetValue(26, 17, 0);
        SetValue(26, 18, 0);
        SetValue(26, 19, 0);
        SetValue(27, 0, 0);
        SetValue(27, 1, 0);
        SetValue(27, 2, 1);
        SetValue(27, 3, 0);
        SetValue(27, 4, 0);
        SetValue(27, 5, 0);
        SetValue(27, 6, 0);
        SetValue(27, 7, 2);
        SetValue(27, 8, 2);
        SetValue(27, 9, 0);
        SetValue(27, 10, 0);
        SetValue(27, 11, 0);
        SetValue(27, 12, 1);
        SetValue(27, 13, 0);
        SetValue(27, 14, 0);
        SetValue(27, 15, 0);
        SetValue(27, 16, 0);
        SetValue(27, 17, 0);
        SetValue(27, 18, 0);
        SetValue(27, 19, 0);
        SetValue(28, 0, 0);
        SetValue(28, 1, 0);
        SetValue(28, 2, 1);
        SetValue(28, 3, 0);
        SetValue(28, 4, 0);
        SetValue(28, 5, 0);
        SetValue(28, 6, 0);
        SetValue(28, 7, 2);
        SetValue(28, 8, 0);
        SetValue(28, 9, 2);
        SetValue(28, 10, 0);
        SetValue(28, 11, 0);
        SetValue(28, 12, 1);
        SetValue(28, 13, 0);
        SetValue(28, 14, 0);
        SetValue(28, 15, 0);
        SetValue(28, 16, 0);
        SetValue(28, 17, 0);
        SetValue(28, 18, 0);
        SetValue(28, 19, 0);
        SetValue(29, 0, 0);
        SetValue(29, 1, 0);
        SetValue(29, 2, 1);
        SetValue(29, 3, 2);
        SetValue(29, 4, 2);
        SetValue(29, 5, 2);
        SetValue(29, 6, 2);
        SetValue(29, 7, 0);
        SetValue(29, 8, 0);
        SetValue(29, 9, 0);
        SetValue(29, 10, 2);
        SetValue(29, 11, 0);
        SetValue(29, 12, 2);
        SetValue(29, 13, 2);
        SetValue(29, 14, 0);
        SetValue(29, 15, 0);
        SetValue(29, 16, 0);
        SetValue(29, 17, 0);
        SetValue(29, 18, 0);
        SetValue(29, 19, 0);
        SetValue(30, 0, 0);
        SetValue(30, 1, 0);
        SetValue(30, 2, 1);
        SetValue(30, 3, 0);
        SetValue(30, 4, 0);
        SetValue(30, 5, 1);
        SetValue(30, 6, 0);
        SetValue(30, 7, 0);
        SetValue(30, 8, 0);
        SetValue(30, 9, 0);
        SetValue(30, 10, 2);
        SetValue(30, 11, 0);
        SetValue(30, 12, 2);
        SetValue(30, 13, 0);
        SetValue(30, 14, 2);
        SetValue(30, 15, 0);
        SetValue(30, 16, 0);
        SetValue(30, 17, 0);
        SetValue(30, 18, 0);
        SetValue(30, 19, 0);
        SetValue(31, 0, 0);
        SetValue(31, 1, 0);
        SetValue(31, 2, 1);
        SetValue(31, 3, 2);
        SetValue(31, 4, 2);
        SetValue(31, 5, 2);
        SetValue(31, 6, 0);
        SetValue(31, 7, 0);
        SetValue(31, 8, 0);
        SetValue(31, 9, 0);
        SetValue(31, 10, 2);
        SetValue(31, 11, 2);
        SetValue(31, 12, 0);
        SetValue(31, 13, 0);
        SetValue(31, 14, 0);
        SetValue(31, 15, 2);
        SetValue(31, 16, 0);
        SetValue(31, 17, 0);
        SetValue(31, 18, 0);
        SetValue(31, 19, 0);
        SetValue(32, 0, 0);
        SetValue(32, 1, 0);
        SetValue(32, 2, 1);
        SetValue(32, 3, 0);
        SetValue(32, 4, 0);
        SetValue(32, 5, 0);
        SetValue(32, 6, 0);
        SetValue(32, 7, 0);
        SetValue(32, 8, 0);
        SetValue(32, 9, 0);
        SetValue(32, 10, 2);
        SetValue(32, 11, 0);
        SetValue(32, 12, 0);
        SetValue(32, 13, 0);
        SetValue(32, 14, 0);
        SetValue(32, 15, 1);
        SetValue(32, 16, 0);
        SetValue(32, 17, 0);
        SetValue(32, 18, 0);
        SetValue(32, 19, 0);
        SetValue(33, 0, 0);
        SetValue(33, 1, 0);
        SetValue(33, 2, 1);
        SetValue(33, 3, 0);
        SetValue(33, 4, 0);
        SetValue(33, 5, 0);
        SetValue(33, 6, 0);
        SetValue(33, 7, 0);
        SetValue(33, 8, 0);
        SetValue(33, 9, 1);
        SetValue(33, 10, 0);
        SetValue(33, 11, 0);
        SetValue(33, 12, 0);
        SetValue(33, 13, 0);
        SetValue(33, 14, 0);
        SetValue(33, 15, 1);
        SetValue(33, 16, 0);
        SetValue(33, 17, 0);
        SetValue(33, 18, 0);
        SetValue(33, 19, 0);
        SetValue(34, 0, 0);
        SetValue(34, 1, 0);
        SetValue(34, 2, 1);
        SetValue(34, 3, 0);
        SetValue(34, 4, 0);
        SetValue(34, 5, 0);
        SetValue(34, 6, 0);
        SetValue(34, 7, 0);
        SetValue(34, 8, 0);
        SetValue(34, 9, 1);
        SetValue(34, 10, 0);
        SetValue(34, 11, 0);
        SetValue(34, 12, 0);
        SetValue(34, 13, 0);
        SetValue(34, 14, 0);
        SetValue(34, 15, 1);
        SetValue(34, 16, 0);
        SetValue(34, 17, 0);
        SetValue(34, 18, 0);
        SetValue(34, 19, 0);
        SetValue(35, 0, 0);
        SetValue(35, 1, 0);
        SetValue(35, 2, 1);
        SetValue(35, 3, 0);
        SetValue(35, 4, 0);
        SetValue(35, 5, 0);
        SetValue(35, 6, 0);
        SetValue(35, 7, 0);
        SetValue(35, 8, 0);
        SetValue(35, 9, 1);
        SetValue(35, 10, 0);
        SetValue(35, 11, 0);
        SetValue(35, 12, 0);
        SetValue(35, 13, 0);
        SetValue(35, 14, 0);
        SetValue(35, 15, 0);
        SetValue(35, 16, 0);
        SetValue(35, 17, 0);
        SetValue(35, 18, 0);
        SetValue(35, 19, 0);
        SetValue(36, 0, 0);
        SetValue(36, 1, 0);
        SetValue(36, 2, 1);
        SetValue(36, 3, 0);
        SetValue(36, 4, 0);
        SetValue(36, 5, 0);
        SetValue(36, 6, 0);
        SetValue(36, 7, 0);
        SetValue(36, 8, 0);
        SetValue(36, 9, 1);
        SetValue(36, 10, 0);
        SetValue(36, 11, 0);
        SetValue(36, 12, 0);
        SetValue(36, 13, 0);
        SetValue(36, 14, 0);
        SetValue(36, 15, 0);
        SetValue(36, 16, 0);
        SetValue(36, 17, 0);
        SetValue(36, 18, 0);
        SetValue(36, 19, 0);
        SetValue(37, 0, 0);
        SetValue(37, 1, 0);
        SetValue(37, 2, 0);
        SetValue(37, 3, 0);
        SetValue(37, 4, 0);
        SetValue(37, 5, 0);
        SetValue(37, 6, 0);
        SetValue(37, 7, 0);
        SetValue(37, 8, 0);
        SetValue(37, 9, 0);
        SetValue(37, 10, 0);
        SetValue(37, 11, 0);
        SetValue(37, 12, 0);
        SetValue(37, 13, 0);
        SetValue(37, 14, 0);
        SetValue(37, 15, 0);
        SetValue(37, 16, 0);
        SetValue(37, 17, 0);
        SetValue(37, 18, 0);
        SetValue(37, 19, 0);

        /*
        //Verificando se os vizinhos estão certo, lembrando do -1 para arrumar o erro do y
        List<Vector3> teste = findNeighbor(GetWorldPosition(31, 4));
        int tamanho = teste.Count;
        Debug.Log(GetWorldPosition(31, 3));
        Debug.Log("Tamanho: " + tamanho);

        for (int i = 0; i < tamanho; i++) {
            Debug.Log("Posicao: " + teste[i].ToString());
        }*/
    }

    /*
        Função que verifica quais vértices adjacêntes da posição atual é possível andar 
    */
    public List<Vector3> findNeighbor(Vector3 aux) {
        List<Vector3> vizinhos = new List<Vector3>();
        int x = 0;
        int y = 0;

        int a = 0;
        int b = 0;

        Debug.Log("Aux: " + aux);
        GetXY(aux, out a, out b);
        Vector3 posicao = new Vector3(a, b, 0);

        Debug.Log("A: " + a + " - B: " + b);

        // X: posicao[0]  width
        // Y: posicao[1]  height
        int yAlterado = (int) posicao[1];

        // Andar um quadrado a esquerda: x -1
        x = (int) posicao[0] - 1;
        y = yAlterado;
        if ((width > x && 0 <= x) && gridArray[x, y] != 0) {
            vizinhos.Add(GetWorldPosition(x, y));
        }

        // Andar para diagonal acima e esquerda: x -1 & y +1
        ++y;
        if ((width > x && 0 <= x) && (height > y && 0 <= y) && gridArray[x, y] != 0) {
            Debug.Log("Diagonal a esquerda: " + GetWorldPosition(x, y) + " valor: " + gridArray[x, y]);
            vizinhos.Add(GetWorldPosition(x, y));
        }

        // Andar para cima: y + 1
        x = (int) posicao[0];
        if ((height > y && 0 <= y) && gridArray[x, y] != 0) {
            Debug.Log("Em cima: " + GetWorldPosition(x, y) + " valor: " + gridArray[x, y]);
            vizinhos.Add(GetWorldPosition(x, y));
        }

        // Andar para diagonal acima e direita: x +1 & y +1
        x++;
        if ((width > x && 0 <= x) && (height > y && 0 <= y) && gridArray[x, y] != 0) {
            vizinhos.Add(GetWorldPosition(x, y));
        }

        // Andar para direita: x +1
        y = (int) yAlterado;
        if ((width > x && 0 <= x) && gridArray[x, y] != 0) {
            vizinhos.Add(GetWorldPosition(x, y));
        }

        // Andar para diagonal abaixo e direita: x +1 & y-1
        y--;
        if ((width > x && 0 <= x) && (height > y && 0 <= y) && gridArray[x, y] != 0) {
            vizinhos.Add(GetWorldPosition(x, y));
        }

        // Andar para baixo: y -1
        x = (int) posicao[0];
        if ((height > y && 0 <= y) && gridArray[x, y] != 0) {
            vizinhos.Add(GetWorldPosition(x, y));
        }

        // Andar para diagonal esquerda e abaixo: x -1 & y -1
        x--;
        if ((width > x && 0 <= x) && (height > y && 0 <= y) && gridArray[x, y] != 0) {
            vizinhos.Add(GetWorldPosition(x, y));
        }

        return vizinhos;
    }

    public Vector3 GetWorldPosition(int x, int y) {
        return new Vector3(x, y) * cellSize + originPosition;
    }

    public void GetXY(Vector3 worldPosition, out int x, out int y) {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
    }

    public void SetValue(int x, int y, int value) {
        // Ignorar quadrados fora do grid
        if (x >= 0 && y >= 0 && x < width && y < height) {
            
            
            /*
            // Alterar valores caso utilize o mouse
            if (gridArray[x, y] == 0) {
                gridArray[x, y] = 1;
                debugTextArray[x, y].text = gridArray[x, y].ToString(); 
            } else if (gridArray[x, y] == 1) {
                gridArray[x, y] = 2;
                debugTextArray[x, y].text = gridArray[x, y].ToString(); 
            } else {
                gridArray[x, y] = 0;
                debugTextArray[x, y].text = gridArray[x, y].ToString(); 
            }*/

            // Alterar valores os setando manualmente 
            gridArray[x, y] = value;
            debugTextArray[x, y].text = gridArray[x, y].ToString(); 
        }
    }

    public void SetValue(Vector3 worldPosition, int value) {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }

    public int GetValue(int x, int y) {
        if (x >= 0 && y >= 0 && x < width && y < height) {
            return gridArray[x, y];
        } else {
            return 0;
        }
    }

    public int GetValue(Vector3 worldPosition) {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetValue(x, y);
    }
}
