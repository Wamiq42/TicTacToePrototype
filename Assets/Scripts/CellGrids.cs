using System.Collections.Generic;
using UnityEngine;
public class CellGrids : Matrices
{
    bool checkMatrixValue = false;
    bool checkWin = false;
    bool rowSame = false;
    bool columnSame = false;
    bool diagnolSame = false;
    bool matchDraw = false;
    List<List<Cell>> cell2dList;
    Cell.Status currentTurn = Cell.Status.cross;

    public delegate void CellCreated(Cell cell);
    public CellCreated cellCreated;

    public CellGrids(int rows, int columns):base(rows , columns)
    {
        cell2dList = new List<List<Cell>>();
     
    }

    public void InitializeCell()
    {
        for (int i = 0; i < rows; i++)
        {
            cell2dList.Add(new List<Cell>());
            for (int j = 0; j < columns; j++)
            {
                Cell tempCell = new Cell(i,j);
                cell2dList[i].Add(tempCell);
                cellCreated?.Invoke(cell2dList[i][j]);
                setElementsInMatrix(i, j, (int)Cell.Status.none);
                tempCell.positionRandC += setStatusWithPosition;
                //cell2dList[i][j].SetStatus(Cell.Status.none);
            }
        }
        //printMatrix();
    }

    public void setStatusWithPosition(int rows,int column)
    {

        if(cell2dList[rows][column].GetStatus() == Cell.Status.none)
        {
            if (!checkWin)
            {
                CheckDraw();
                if ((int)currentTurn == (int)Cell.Status.cross && !matchDraw)
                {
                    setElementsInMatrix(rows, column, (int)Cell.Status.circle);
                    cell2dList[rows][column].SetStatus(Cell.Status.circle);
                    Debug.Log(cell2dList[rows][column].GetStatus());
                    currentTurn = Cell.Status.circle;
                    CheckWin();
                }
                else if ((int)currentTurn == (int)Cell.Status.circle && !matchDraw)
                {
                    setElementsInMatrix(rows, column, (int)Cell.Status.cross);
                    cell2dList[rows][column].SetStatus(Cell.Status.cross);
                    Debug.Log(cell2dList[rows][column].GetStatus());
                    currentTurn = Cell.Status.cross;
                    CheckWin();
                }
            }
            else if (checkWin)
            {
                if ((int)currentTurn == (int)Cell.Status.circle)
                    Debug.Log("Circle Won!");
                else if ((int)currentTurn == (int)Cell.Status.cross)
                    Debug.Log("Cross Won!");
            }
        }
       
     
           
    }

    public void CheckWin()
    {
        
        for (int i = 0; i < rows; i++)
        {
            rowSame = IsRowSame(i);
            if(rowSame == true)
            {
                checkWin = true;
                break;
            }
            else
            {
                checkWin = false;
            }
        }
        if(!checkWin)
        {
            for (int i = 0; i < columns; i++)
            {
                columnSame = IsColumnSame(i);
                if(columnSame)
                {
                    checkWin = true;
                    break;
                }
                else
                {
                    checkWin = false;
                }
            }
        }

        else if(!checkWin && !columnSame)
        {
            diagnolSame = CheckDiagnolMatrix();
            if (diagnolSame)
            {
                checkWin = true;
            }
            else
                checkWin = false;
        }
        
    }
   
    public void CheckDraw()
    {
        CheckingMatrix();
        if (!checkMatrixValue)
        {
            Debug.Log("Game is not completed to confirm draw");
        }
        else
        {
            Debug.Log("Draw");
            matchDraw = true;
        }
            
    }
    public void CheckingMatrix()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (matrix[i][j] == 0)
                {
                    checkMatrixValue = false;
                    break;
                }
                else
                    checkMatrixValue = true;
            }
        }
    }
  

    //public override void onMatrixUpdate()
    //{
    //    for (int i = 0; i < rows; i++)
    //    {
    //        for (int j = 0; j < columns; j++)
    //        {
    //            cell2dList[i][j].nextStatus((Cell.Status)getElementInMatrix(i, j));
    //        }
    //    }
    //}


}
