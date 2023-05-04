using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellInfo : MonoBehaviour
{
    [SerializeField] private int x;
    [SerializeField] private int y;


public void set(GameObject button)
    {
        CellManager.instance.setCell(x, y, button);
        button.GetComponent<Button>().interactable = false;
    }
}
