using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextLocalization))]
public class TextWriter : MonoBehaviour
{
	private TextMeshProUGUI text;
	private string story;

	[HideInInspector]
	public bool coroutineIsRunning;

    private void OnEnable()
    {
		text = GetComponent<TextMeshProUGUI>();
	}

    public void NewText()
	{
		story = text.text;
		text.text = "";
		StartCoroutine(PlayText());
	}

	private IEnumerator PlayText()
	{
		coroutineIsRunning = true;
		foreach (char c in story)
		{
			text.text += c;
			yield return new WaitForSecondsRealtime(0.03f);
		}
		coroutineIsRunning = false;
	}

	public void ShowAll()
    {
		StopAllCoroutines();
		coroutineIsRunning = false;
		text.text = story;
	}

}
