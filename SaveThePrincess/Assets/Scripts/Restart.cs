using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Restart : MonoBehaviour
{
    private PlayerMoneys playerMoneys;
    private CharacterLvl playerLvl;
    private SceneInfo sceneInfo;
    private int rebirthPrice, levelPrice;
    private bool freeRessurect;

    [SerializeField]
    private TextMeshProUGUI costText, levelText;
    private void Start()
    {
        GameObject character = GameObject.FindGameObjectWithTag("Character");
        playerMoneys = character.GetComponent<PlayerMoneys>();
        playerLvl = character.GetComponent<CharacterLvl>();

        GameObject levelManager = GameObject.FindGameObjectWithTag("levelmanager");
        sceneInfo = levelManager.GetComponent<SceneInfo>();
    }
    public void SetRebirthPrice()
    {
        if (!freeRessurect)
        {
            int currentMoneys = playerMoneys.moneys;
            rebirthPrice = currentMoneys / 2;
            levelPrice = 1;
        } else
        {
            rebirthPrice = 0;
            levelPrice = 0;
        }

        if(costText!=null)
            costText.text = rebirthPrice.ToString();

        if (levelText != null)
            levelText.text = levelPrice.ToString();
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
        playerLvl.DecreaseLevel(levelPrice);
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
