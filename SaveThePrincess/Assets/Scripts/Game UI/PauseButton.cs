using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MenuButton
{
    public override void OnButtonClick()
    {
        if(Time.timeScale == 0)
            Time.timeScale = 1;
        else
            Time.timeScale = 0;        
    }
}
