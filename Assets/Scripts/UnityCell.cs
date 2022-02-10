using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityCell : MonoBehaviour
{
    public List<GameObject> states;
    Cell cell;

    private void Start()
    {
        //cell = new Cell();
       //InitializeUnityCell();

    }
    void InitializeUnityCell()
    {
        //cell.nextStatus += SettingUpStatus;
    }
    private void SettingUpStatus(Cell.Status status)
    {
        for (int i = 0; i < states.Count; i++)
        {
            if((int)status == i)
            {
                states[i].SetActive(true);
            }
            else
            {
                states[i].SetActive(false);
            }
        }
    }
    public void setCell(Cell cell)
    {
        this.cell = cell;

    }
    private void OnMouseDown()
    {
        cell.nextStatus += SettingUpStatus;
        cell.ClickedOnCell();
        Debug.Log("What?");
    }

}
