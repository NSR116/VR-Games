using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{
    public static GameEnd instance;
    public GameObject popUp;
    [SerializeField] private TMP_Text textWin;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }

    public void setWin(string s)
    {
        if(string.Equals(s, "NO WINNER!"))
        {
            textWin.text = s;
        }

        else
        {
            textWin.text = s + " IS WINNER";
        }
    }
}
