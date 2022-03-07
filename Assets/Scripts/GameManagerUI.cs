using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerUI : MonoBehaviour
{
    public int rows;
    public int columns;
    public CellGrids cellGrid;
    public GameObject boxPrefab;
    public RectTransform canvasTransform;

    private float horizontalSpacing = 2.0f;
    private float verticalSpacing = 2.0f;
    private int counter = 0;

    private void Start()
    {
        InitializeCellGrid();
    }

    void InitializeCellGrid()
    {
        cellGrid = new CellGrids(rows, columns);
        cellGrid.cellCreated += CellInstantiate;
        cellGrid.InitializeCell();
    }

    private void CellInstantiate(Cell cell)
    {
        GameObject temp;
        CellPositionSetUp();
        temp = Instantiate(boxPrefab);
        temp.transform.SetParent(canvasTransform, false);
        temp.GetComponent<RectTransform>().localPosition = new Vector3(horizontalSpacing,verticalSpacing,0);
        counter++;
        temp.GetComponent<UnityUICell>().setCell(cell);

    }

    void CellPositionSetUp()
    {
        if (counter == rows)
        {
            verticalSpacing -= 200.0f;
            counter = 0;
            horizontalSpacing = -150.0f;
        }
        else
        {
            horizontalSpacing -= 150.0f;
        }
    }


}

