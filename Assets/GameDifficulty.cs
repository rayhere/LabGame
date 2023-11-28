using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameDifficulty : MonoBehaviour
{
    [SerializeField] TMP_Text TimeText;
    [SerializeField] TMP_Text FireRateText;

    public GameObject inGameTimeToggle;
    public GameObject inGameFireRateToggle;
    public GameObject inGameLifeToggle;

    // Start is called before the first frame update
    void Start()
    {
        inGameTimeToggle.GetComponent<Toggle>().isOn = true;
        inGameFireRateToggle.GetComponent<Toggle>().isOn = false;
        inGameLifeToggle.GetComponent<Toggle>().isOn = false;
        DisplayBonusTime();
        DisplayBonusFireRate();
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

        //set GameModifier
        GameMod.Modifier.SetBonusTime(true);
        GameMod.Modifier.SetBonusFireRate(true);
        GameMod.Modifier.SetBonusLife(true);

        DisplayBonusTime();
        DisplayBonusFireRate();
    }

    public void NormalModeButton()
    {
        inGameTimeToggle.GetComponent<Toggle>().isOn = true;
        inGameFireRateToggle.GetComponent<Toggle>().isOn = false;
        inGameLifeToggle.GetComponent<Toggle>().isOn = false;

        //set GameModifier
        GameMod.Modifier.SetBonusTime(true);
        GameMod.Modifier.SetBonusFireRate(false);
        GameMod.Modifier.SetBonusLife(false);

        DisplayBonusTime();
        DisplayBonusFireRate();
    }

    public void HardModeButton()
    {
        inGameTimeToggle.GetComponent<Toggle>().isOn = false;
        inGameFireRateToggle.GetComponent<Toggle>().isOn = false;
        inGameLifeToggle.GetComponent<Toggle>().isOn = false;

        //set GameModifier
        GameMod.Modifier.SetBonusTime(false);
        GameMod.Modifier.SetBonusFireRate(false);
        GameMod.Modifier.SetBonusLife(false);

        DisplayBonusTime();
        DisplayBonusFireRate();
    }

    private void DisplayBonusTime()
    {
        // method to get int from float
        // float someFloat = 42.7f;
        // int someInt = (int)Math.Round(someFloat);   // 43
        TimeText.SetText("+" + (int)Mathf.Round(GameMod.Modifier.GetBonusTime()+.1f) + "Sec/nEach next Level");
    }

    private void DisplayBonusFireRate()
    {
        FireRateText.SetText("FireRate " + (double)(Mathf.Round(GameMod.Modifier.GetBonusFireRate()*100f)/100f));
        //yourFloat = Mathf.Round(yourFloat * 100f) / 100f;
        //FireRateText.SetText("FireRate " + (double)Mathf.Round(GameMod.Modifier.GetBonusFireRate()));
    }

}
