using System;

public class Cell
{
    private int row;
    private int column;
    Status status;

    public delegate void StatusChanged(Status status);
    public StatusChanged nextStatus;
    public delegate void postionRowAndColumn(int row, int column);
    public postionRowAndColumn positionRandC;

    public Cell()
    {
        status = Status.none;
        row = 0;
        column = 0;
    }
    public Cell(int row,int column)
    {
        status = Status.none;
        this.row = row;
        this.column = column;
    }

    public void SetStatus(Status status)
    {
        this.status = status;
        nextStatus?.Invoke(status);
    }
    
    public Status GetStatus()
    {
        return status;
    }

    internal void ClickedOnCell()
    {
  
        positionRandC?.Invoke(row, column); 
    }
   
    public enum Status { none, cross, circle, tick, lose }
}
