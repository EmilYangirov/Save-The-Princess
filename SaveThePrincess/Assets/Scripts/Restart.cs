using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private PlayerMoneys playerMoneys;
    private SceneInfo sceneInfo;
    private int rebirthPrice;
    private bool freeRessurect;

    [SerializeField]
    private Text costText;
    private void Start()
    {
        GameObject character = GameObject.FindGameObjectWithTag("Character");
        playerMoneys = character.GetComponent<PlayerMoneys>();

        GameObject levelManager = GameObject.FindGameObjectWithTag("levelmanager");
        sceneInfo = levelManager.GetComponent<SceneInfo>();
    }
    public void SetRebirthPrice()
    {
        if (!freeRessurect)
        {
            int currentMoneys = playerMoneys.moneys;
            rebirthPrice = currentMoneys / 2;
        } else
        {
            rebirthPrice = 0;
        }

        costText.text = rebirthPrice.ToString();
    }

    public void NewGameResurrect()
    {
        sceneInfo.DeleteKey();
        Resurrect();
    }

    public void PriceResurrect()
    {
        SetRebirthPrice();
        playerMoneys.Buy(rebirthPrice);
        sceneInfo.Save();

        Resurrect();
    }
    public void ChangeResurrectStatus()
    {
        freeRessurect = true;
        SetRebirthPrice();
    }
    private void Resurrect()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
