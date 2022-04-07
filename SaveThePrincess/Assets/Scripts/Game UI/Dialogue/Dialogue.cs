using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
   [SerializeField]
    private TextWriter[] dialogueTexts;
	private TextWriter thatText;
	private Transform person;

	private int textCount = -1;

	[HideInInspector]
	public bool dialogueEnd;
	

	private void ChangeText()
    {
		textCount++;
		
		for(int i =0 ; i < dialogueTexts.Length ; i++)
        {
			if (i == textCount)
			{
				dialogueTexts[i].gameObject.SetActive(true);
				thatText = dialogueTexts[i];
				ChangePerson();
				thatText.NewText();
			}
			else
            {
				dialogueTexts[i].gameObject.SetActive(false);
			}				
        }

		if (textCount >= dialogueTexts.Length)
			LeaveDialogue();
	}

	private void ChangePerson()
    {
		person = thatText.transform.parent;

		foreach(var text in dialogueTexts)
        {
			if(text.transform.parent != person)
				text.transform.parent.gameObject.SetActive(false);
			else
				text.transform.parent.gameObject.SetActive(true);
		}		
	}
	
	public void OnClick()
    {
		if (thatText.coroutineIsRunning)
			thatText.ShowAll();
		else
			ChangeText();
	}

	public void StartDialogue()
    {
		gameObject.SetActive(true);
		textCount = -1;
		dialogueEnd = false;
		ChangeText();
    }

	private void LeaveDialogue()
    {
		dialogueEnd = true;
		gameObject.SetActive(false);
	}
}
