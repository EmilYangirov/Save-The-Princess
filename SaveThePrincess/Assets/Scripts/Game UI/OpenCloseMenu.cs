using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseMenu : MonoBehaviour
{
    public float offsetY;
    [HideInInspector]
    public List<RectTransform> menuElements;
    private bool opened;

    private void Start()
    {
        //add all buttons to list
        foreach (Transform child in transform)
        {
            menuElements.Add(child.GetComponent<RectTransform>());
        }
    }
    public  void OpenClose()
    {
        StopAllCoroutines();
        StartCoroutine(ChangeButtonsPosition());
        //change menu state
        if (opened)
            opened = false;
        else
            opened = true;
    }

    //change positions to all button if main button clicked
    private IEnumerator ChangeButtonsPosition()
    {
        //create list with new positions of all buttons
        List<Vector2> newPositions = PositionsList();
        //change buttons positions by the time
        float time = 0;
        while (time < 1.5)
        {
            for (int i = 0; i < menuElements.Count; i++)
            {              
                menuElements[i].anchoredPosition = Vector2.MoveTowards(menuElements[i].anchoredPosition, newPositions[i], 500*Time.deltaTime);               
            }
            time += Time.deltaTime;
            yield return null;
        }
        //set needed positions to buttons
        for (int i = 0; i < menuElements.Count; i++)
        {
            menuElements[i].anchoredPosition = newPositions[i];
        }        
    }

    //calculate position
    private Vector2 NewPosition(int index)
    {
        if (opened)
        {
            return Vector2.zero;
        } else {
            float x = 0;
            float y = (menuElements.Count - index - 1) * offsetY * -1;
            return new Vector2(x, y);
        }
    }

    //create list with new positions of all buttons 
    private List<Vector2> PositionsList()
    {
       List<Vector2> newPositions = new List<Vector2>();

       for(int i = 0; i < menuElements.Count; i++)
       {
            Vector2 position = NewPosition(i);
            newPositions.Add(position);
       }

        return newPositions;
    }
    
}

