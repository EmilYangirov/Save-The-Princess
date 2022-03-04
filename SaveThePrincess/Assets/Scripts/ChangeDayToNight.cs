using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeDayToNight : MonoBehaviour
{
    private int daysCount;
    [HideInInspector] public List<SpriteRenderer> daySprites, nightSprites;
    private Transform dayParent, nightParent, moon, sun;
    public float moonAndSunY = 10.3f;
    public int dayCount, dayTime;
    public Text dayCounter;
    
    public bool night { get; private set; }
    private void Start()
    {
        dayParent = GameObject.FindWithTag("DaySprites").transform;
        nightParent = GameObject.FindWithTag("NightSprites").transform;
        moon = GameObject.FindWithTag("moon").transform;
        sun = GameObject.FindWithTag("sun").transform;
        GetChilds(dayParent, daySprites);
        GetChilds(nightParent, nightSprites);
        dayCounter.text = "Day: " + dayCount;
        StartCoroutine(TimeChanger(false));
    }

    //collect all child sprites from day and night parents
    private void GetChilds(Transform Parent, List<SpriteRenderer> ChildSprites)
    {
        foreach (Transform child in Parent)
        {
            if (child.GetComponent<SpriteRenderer>() != null)
            {
                ChildSprites.Add(child.GetComponent<SpriteRenderer>());
            }
            else
            {
                GetChilds(child, ChildSprites);
            }
        }
    }
    //change sun and moon
    private IEnumerator ChangeSunAndMoon(Transform thatTr)
    {
        float time = 0;
        moonAndSunY *= -1;
        Vector2 newPos = new Vector2(thatTr.localPosition.x, moonAndSunY);
        while (time < 1f)
        {
            thatTr.localPosition = Vector2.MoveTowards(thatTr.localPosition, newPos, 35f * Time.deltaTime);
            time += Time.deltaTime;
            yield return null;
        }
        thatTr.localPosition = newPos;
        if (moonAndSunY < 0)
        {
            if (thatTr != moon)
            {
                StartCoroutine(ChangeSunAndMoon(moon));
                StartCoroutine(ChangeDayAndNightSprites(daySprites, nightSprites));
            } else
            {
                StartCoroutine(ChangeSunAndMoon(sun));
                StartCoroutine(ChangeDayAndNightSprites(nightSprites, daySprites));
            }
        }
    }
    //change color of child day and night sprites
    private IEnumerator ChangeDayAndNightSprites(List<SpriteRenderer> thatTime, List<SpriteRenderer> nextTime)
    {
        float time = 0;
        while (time < 1.5f)
        {
            for (int i = 0; i < thatTime.Count; i++)
            {
                thatTime[i].color = Vector4.MoveTowards(thatTime[i].color, new Vector4(thatTime[i].color.r, thatTime[i].color.g, thatTime[i].color.b, 0), 0.02f);
            }
            for (int i = 0; i < nextTime.Count; i++)
            {
                nextTime[i].color = Vector4.MoveTowards(nextTime[i].color, new Vector4(nextTime[i].color.r, nextTime[i].color.g, nextTime[i].color.b, 1), 0.02f);
            }
            time += Time.deltaTime;
            yield return null;
        }
        for (int i = 0; i < thatTime.Count; i++)
        {
            thatTime[i].color = new Vector4(thatTime[i].color.r, thatTime[i].color.g, thatTime[i].color.b, 0);
        }
        for (int i = 0; i < nextTime.Count; i++)
        {
            nextTime[i].color = new Vector4(nextTime[i].color.r, nextTime[i].color.g, nextTime[i].color.b, 1);
        }
    }
    private IEnumerator TimeChanger(bool endOfDay)
    {        
        yield return new WaitForSeconds(dayTime);
        if (!endOfDay)
        {
            StartCoroutine(ChangeSunAndMoon(sun));
            StartCoroutine(TimeChanger(true));
            night = true;
        } else
        {
            StartCoroutine(ChangeSunAndMoon(moon));
            StartCoroutine(TimeChanger(false));
            dayCount++;
            dayCounter.text = "Day: " + dayCount;
            night = false;
        }
    }

}
