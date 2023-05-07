using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class CellManager : MonoBehaviour
{
    public static CellManager instance;
    [SerializeField] TextMeshProUGUI[] arrayText = new TextMeshProUGUI[9];
    private bool isX = true;
    private int[,] cells = { {0,0,0}, {0,0,0}, {0,0,0} };
    private int count = 0;
    
  private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }


   
   public void setCell(int x, int y, GameObject button)
    {
        count = count + 1;

        if (isX)
        {
            cells[x, y] = 1;
            button.GetComponentInChildren<TextMeshProUGUI>().text = "X";
            isX = false;
            
        }
        else
        {
            cells[x, y] = -1;
            button.GetComponentInChildren<TextMeshProUGUI>().text = "O";
            isX = true;
        }

        checkWin(x,y);
    }

    
    
    void checkWin(int x, int y)
    {
        int row = 0;
        int col = 0;
        int dia = 0;

        row = rowSum(x);
        col = columnSum(y);

        if (x == y || (x == (cells.GetLength(0))-1 && y == 0) || (y == (cells.GetLength(0)) - 1 && x == 0) 
            || ((x>0 && x<(cells.GetLength(1)) - 1) && (y > 0 && y < (cells.GetLength(1)) - 1)) )
        {
            dia = diagonalSum(x, y);
        }

        if (row == cells.GetLength(0) || col == cells.GetLength(0) || dia == cells.GetLength(0) )
        {
            GameEnd.instance.popUp.SetActive(true);
            GameEnd.instance.setWin("X");
            LeanTween.scale(GameEnd.instance.popUp, Vector3.one, 0.3f).setEaseInSine();
        }

       else if (row == -1*cells.GetLength(0) || col == -1*cells.GetLength(0) || dia == -1*cells.GetLength(0))
        {
            GameEnd.instance.popUp.SetActive(true);
            GameEnd.instance.setWin("O");
            LeanTween.scale(GameEnd.instance.popUp, Vector3.one, 0.3f).setEaseInSine();
        }

        else if (count == cells.GetLength(0)*cells.GetLength(1))
        {
            GameEnd.instance.popUp.SetActive(true);
            GameEnd.instance.setWin("NO WINNER!");
            LeanTween.scale(GameEnd.instance.popUp, Vector3.one, 0.3f).setEaseInSine();
        }
        
    }

    private int rowSum(int r)
    {
        int x = 0;

        for(int i=0; i<cells.GetLength(1); i++)
        {
            x += cells[r, i];
        }
        return x;
    }

    private int columnSum(int c)
    {
        int x = 0;

        for (int i = 0; i < cells.GetLength(0); i++)
        {
            x += cells[i, c];
        }
        return x;
    }

    private int diagonalSum(int d1, int d2)
    {
        int x = 0;
        int j = cells.GetLength(0) - 1;

        if (d1 == d2)
        {
            for (int i = 0; i < cells.GetLength(0) ; i++)
            {
                x += cells[i, i];
            }
        }

        else {

            for (int i = 0; i < cells.GetLength(0); i++)
            {
                x += cells[i, j];
                j = j - 1;
            }
        }
        return x;
    }

    public void changeVolume(GameObject s)
    {
        gameObject.GetComponent<AudioSource>().volume = s.GetComponent<Slider>().value;
    }

    public void replay()
    {
        for (int i = 0; i < cells.GetLength(0); i++)
        {
            for (int k = 0; k < cells.GetLength(1); k++)
            {
                cells[i, k] = 0;
            }
        }

        for(int i =0; i<arrayText.Length; i++)
        {
            arrayText[i].text = "";
        }
            
    }
}
