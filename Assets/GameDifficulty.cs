using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameDifficulty : MonoBehaviour
{
    public GameObject inGameTimeToggle;
    public GameObject inGameFireRateToggle;
    public GameObject inGameLifeToggle;

    
    // Start is called before the first frame update
    void Start()
    {
        inGameTimeToggle.GetComponent<Toggle>().isOn = true;
        inGameFireRateToggle.GetComponent<Toggle>().isOn = false;
        inGameLifeToggle.GetComponent<Toggle>().isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EasyModeButton()
    {
        inGameTimeToggle.GetComponent<Toggle>().isOn = true;
        inGameFireRateToggle.GetComponent<Toggle>().isOn = true;
        inGameLifeToggle.GetComponent<Toggle>().isOn = true;
        // inGameTimeToggle = true;
        // inGameFireRateToggle = true;
        // inGameLifeToggle = true;

        //set GameModifier
        GameMod.Modifier.SetBonusTime(true);
        GameMod.Modifier.SetBonusFireRate(true);
        GameMod.Modifier.SetBonusLife(true);
    }

    public void NormalModeButton()
    {
        inGameTimeToggle.GetComponent<Toggle>().isOn = true;
        inGameFireRateToggle.GetComponent<Toggle>().isOn = false;
        inGameLifeToggle.GetComponent<Toggle>().isOn = false;
        // inGameTimeToggle = true;
        // inGameFireRateToggle = false;
        // inGameLifeToggle = false;

        //set GameModifier
        GameMod.Modifier.SetBonusTime(true);
        GameMod.Modifier.SetBonusFireRate(false);
        GameMod.Modifier.SetBonusLife(false);
    }

    public void HardModeButton()
    {
        inGameTimeToggle.GetComponent<Toggle>().isOn = false;
        inGameFireRateToggle.GetComponent<Toggle>().isOn = false;
        inGameLifeToggle.GetComponent<Toggle>().isOn = false;
        // inGameTimeToggle = false;
        // inGameFireRateToggle = false;
        // inGameLifeToggle = false;

        //set GameModifier
        GameMod.Modifier.SetBonusTime(false);
        GameMod.Modifier.SetBonusFireRate(false);
        GameMod.Modifier.SetBonusLife(false);
    }

    // public void SetBonusTime(bool isBonusTime)
    // {
    //     // for toggle clicked event
    //     // update GameModifier
    //     // if (isBonusTime = true)
    //     // {
    //     //     GameModifier.Modifier.SetBonusTime(true);
    //     // }
    //     // else
    //     // {
    //     //     GameModifier.Modifier.SetBonusTime(false);
    //     // }
    //     if (isBonusTime = true)
    //     {
    //         SetBonusTime();
    //     }
    //     //GameModifier.Modifier.SetBonusTimeTrue();
    // }

    // public void SetBonusTime()
    // {
    //     if (inGameTimeToggle.GetComponent<Toggle>().isOn = true)
    //     {
    //         PersistentData.Instance.SetScore(1);

    //     }
    // }

    // public void SetBonusFireRate(bool isBonusFireRate)
    // {
    //     // for toggle clicked event
    //     // update GameModifier
    //     if (isBonusFireRate = true)
    //     {
    //         GameModifier.Modifier.SetBonusFireRate(true);
    //     }
    //     else
    //     {
    //         GameModifier.Modifier.SetBonusFireRate(false);
    //     }
    // }

    // public void SetBonusLife(bool isBonusLife)
    // {
    //     // for toggle clicked event
    //     // update GameModifier
    //     // if (isBonusLife != null)
    //     // {
    //     //     GameModifier.Modifier.SetBonusLife(isBonusLife);
    //     // }
    //     // else
    //     // {
    //     //     GameModifier.Modifier.SetBonusLife(isBonusLife);
    //     // }

    //     if (isBonusLife = true)
    //     {

    //     }
    // }
}
