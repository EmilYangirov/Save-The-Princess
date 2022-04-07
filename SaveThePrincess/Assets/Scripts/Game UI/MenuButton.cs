using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class MenuButton : MonoBehaviour
{
    protected Image buttonImage;

    [SerializeField]
    protected Sprite activeImage, inactiveImage;

    protected bool imageChangeble;

    protected virtual void Start()
    {
        buttonImage = GetComponent<Image>();

        if (activeImage != null && inactiveImage != null)
            imageChangeble = true;

        if (imageChangeble)
            buttonImage.sprite = activeImage;
    }
    public virtual void OnButtonClick()
    {
        if (imageChangeble)
            ChangeButtonImage();
    }
    protected virtual void ChangeButtonImage()
    {
        if(buttonImage.sprite == inactiveImage)
            buttonImage.sprite = activeImage;
        else
            buttonImage.sprite = inactiveImage;
    }
}
