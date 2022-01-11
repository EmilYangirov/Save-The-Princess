using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class CharacterBar : MonoBehaviour
{
    
    public float maxValue, value;
    public GameObject barGO;
    public GameObject barElementGO;
    public List<Transform> barElements;
    public int elementCount;
 
    public virtual void CheckBar()
    {
        float barArgument = value * elementCount / maxValue;
        float valueDifference = barArgument - Mathf.Floor(barArgument);

        for (int i = 0; i < barElements.Count; i++)
        {
            Transform child = barElements[i].GetChild(0);
            Image imageElement = child.GetComponent<Image>();
            imageElement.fillAmount = 1f;
            if(i > Mathf.Floor(barArgument)-1)
            {
                if(i == Mathf.Floor(barArgument))
                {
                    imageElement.fillAmount *= valueDifference;
                }else
                {
                    imageElement.fillAmount = 0;
                }
            }
        }
    }
    public void CreateBar()
    {
        for (int i = 0; i< elementCount; i++)
        {
            GameObject newGO = Instantiate(barElementGO, new Vector2(0, 0), Quaternion.identity);
            barElements.Add(newGO.transform);
            RectTransform newTransform = newGO.GetComponent<RectTransform>();
            newTransform.transform.SetParent(barGO.transform);
            newTransform.offsetMax = new Vector2(0, 0);
            newTransform.offsetMin = new Vector2(0, 0);
        }
    }
   
}
