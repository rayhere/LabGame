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
        GameModifier.Modifier.SetBonusTime(true);
        GameModifier.Modifier.SetBonusFireRate(true);
        GameModifier.Modifier.SetBonusLife(true);
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
        GameModifier.Modifier.SetBonusTime(true);
        GameModifier.Modifier.SetBonusFireRate(false);
        GameModifier.Modifier.SetBonusLife(false);
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
        GameModifier.Modifier.SetBonusTime(false);
        GameModifier.Modifier.SetBonusFireRate(false);
        GameModifier.Modifier.SetBonusLife(false);
    }

    public void SetBonusTime(bool isBonusTime)
    {
        // for toggle clicked event
        // update GameModifier
        GameModifier.Modifier.SetBonusTime(isBonusTime);
    }

    public void SetBonusFireRate(bool isBonusFireRate)
    {
        // for toggle clicked event
        // update GameModifier
        GameModifier.Modifier.SetBonusFireRate(isBonusFireRate);
    }

    public void SetBonusLife(bool isBonusLife)
    {
        // for toggle clicked event
        // update GameModifier
        GameModifier.Modifier.SetBonusLife(isBonusLife);
    }
}
