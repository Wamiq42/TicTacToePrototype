using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int rows;
    public int columns;
    public CellGrids cellGrid;
    public GameObject boxPrefab;

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
        temp = Instantiate(boxPrefab,new Vector3(horizontalSpacing,0,verticalSpacing),boxPrefab.transform.rotation);
        counter++;
        temp.GetComponent<UnityCell>().setCell(cell);
        
    }

    void CellPositionSetUp()
    {
        if (counter == rows)
        {
            verticalSpacing += 2.0f;
            counter=0;
            horizontalSpacing = 4.0f;
        }
        else
        {
            horizontalSpacing += 2.0f;
        }   
    }


}
