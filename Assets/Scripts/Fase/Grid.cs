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
        this.width = width;
        this.height = height; 
        this.cellSize = cellSize;
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

        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.black, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.black, 100f);

        SetValue(2, 1, 2);
    }

    private Vector3 GetWorldPosition(int x, int y) {
        return new Vector3(x, y) * cellSize + originPosition;
    }

    public void GetXY(Vector3 worldPosition, out int x, out int y) {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
    }

    public void SetValue(int x, int y, int value) {
        // Ignorar quadrados fora do grid
        if (x >= 0 && y >= 0 && x < width && y < height) {
            
            if (gridArray[x, y] == 0) {
                gridArray[x, y] = 1;
                debugTextArray[x, y].text = gridArray[x, y].ToString(); 
            } else if (gridArray[x, y] == 1) {
                gridArray[x, y] = 2;
                debugTextArray[x, y].text = gridArray[x, y].ToString(); 
            } else {
                gridArray[x, y] = 0;
                debugTextArray[x, y].text = gridArray[x, y].ToString(); 
            }

            //gridArray[x, y] = value;
            //debugTextArray[x, y].text = gridArray[x, y].ToString(); 
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
