using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private Dialogue[] dialogues;

    [SerializeField]
    private CanvasGroup dialogueCanvas, uiCanvas;

    private Dialogue thatDialogue;


    public void ShowDialogue(int dialogueIndex)
    {
        HideUICanvas();

        thatDialogue = dialogues[dialogueIndex];

        foreach(var dialogue in dialogues)
        {
            if(dialogue.gameObject != thatDialogue.gameObject)
            {
                dialogue.gameObject.SetActive(false);
            }
        }

        thatDialogue.StartDialogue();
    }    

    public void OnClick()
    {
        thatDialogue.OnClick();

        if (thatDialogue.dialogueEnd)
        {
            thatDialogue = null;
            ShowUICanvas();
        }
    }

    private void HideUICanvas()
    {
        Time.timeScale = 0;

        ChangeCanvas(dialogueCanvas, uiCanvas);        
    }

    private void ShowUICanvas()
    {
        Time.timeScale = 1;

        ChangeCanvas(uiCanvas, dialogueCanvas);
    }

    private void ChangeCanvas(CanvasGroup show, CanvasGroup hide)
    {
        show.alpha = 1;
        show.blocksRaycasts = true;
        show.interactable = true;

        hide.alpha = 0;
        hide.blocksRaycasts = false;
        hide.interactable = false;
    }
}
