using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MenuButton
{
    public void CloseGame()
    {
        Application.Quit();
    }
}
