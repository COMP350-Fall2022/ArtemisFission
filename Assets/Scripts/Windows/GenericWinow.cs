using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GenericWinow : MonoBehaviour
{
    public GameObject firstSelected;
    
    protected EventSystem eventSystem
    {
        get
        {
            return GameObject.Find("EventSystem").GetComponent<EventSystem> ();
        }
    }

    public void OnFocus()
    {
        eventSystem.SetSelectedGameObject(firstSelected);
    }

    public void Display(bool value)
    {
        gameObject.SetActive(value);
    }

    public void Open()
    {
        Display(true);
        OnFocus();
    }

    public void Close () {
        Display(false);
    }

    public void Awake()
    {
        Close();
    }
}
