using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameModifier : MonoBehaviour
{
    // [SerializeField] GameObject inGameToggle;

    // public GameObject inGameTimeToggle;
    // public GameObject inGameFireRateToggle;
    // public GameObject inGameLifeToggle;


    // [SerializeField] Toggle inGameTimeToggle;
    // [SerializeField] Toggle inGameFireRateToggle;
    // [SerializeField] Toggle inGameLifeToggle;

    [SerializeField] bool BonusTimeToggle;
    [SerializeField] bool BonusFireRateToggle;
    [SerializeField] bool BonusLifeToggle;

    [SerializeField] float bonusTime;
    [SerializeField] int bonusFireRate;
    [SerializeField] int bonusLife;

    public static GameModifier Modifier;

    void Awake()
    {
        if (Modifier == null)
        {
            DontDestroyOnLoad(this);
            Debug.Log("GameModifier.sc Don't Destory On Load");
            Modifier = this;
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("Destroy(gameObject)");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // inGameTimeToggle = true;
        // inGameFireRateToggle = false;
        // inGameLifeToggle = false;
        // inGameTimeToggle.GetComponent<Toggle>().isOn = true;
        // inGameFireRateToggle.GetComponent<Toggle>().isOn = false;
        // inGameLifeToggle.GetComponent<Toggle>().isOn = false;
        // bonusTime = 3f;
        // bonusFireRate = 2;
        // bonusLife = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // public void EasyModeButton()
    // {
    //     inGameTimeToggle.GetComponent<Toggle>().isOn = true;
    //     inGameFireRateToggle.GetComponent<Toggle>().isOn = true;
    //     inGameLifeToggle.GetComponent<Toggle>().isOn = true;
    //     // inGameTimeToggle = true;
    //     // inGameFireRateToggle = true;
    //     // inGameLifeToggle = true;
    //     SetBonusTime(true);
    //     SetBonusFireRate(true);
    //     SetBonusLife(true);
    // }

    // public void NormalModeButton()
    // {
    //     inGameTimeToggle.GetComponent<Toggle>().isOn = true;
    //     inGameFireRateToggle.GetComponent<Toggle>().isOn = false;
    //     inGameLifeToggle.GetComponent<Toggle>().isOn = false;
    //     // inGameTimeToggle = true;
    //     // inGameFireRateToggle = false;
    //     // inGameLifeToggle = false;
    //     SetBonusTime(true);
    //     SetBonusFireRate(false);
    //     SetBonusLife(false);
    // }

    // public void HardModeButton()
    // {
    //     inGameTimeToggle.GetComponent<Toggle>().isOn = false;
    //     inGameFireRateToggle.GetComponent<Toggle>().isOn = false;
    //     inGameLifeToggle.GetComponent<Toggle>().isOn = false;
    //     // inGameTimeToggle = false;
    //     // inGameFireRateToggle = false;
    //     // inGameLifeToggle = false;
    //     SetBonusTime(false);
    //     SetBonusFireRate(false);
    //     SetBonusLife(false);
    // }

    public void SetBonusTime(bool isBonusTime)
    {
        if (isBonusTime)
        {
            bonusTime = 3f;
        }
        else
        {
            bonusTime = 0f;
        }
    }

    public void SetBonusFireRate(bool isBonusFireRate)
    {
        if (isBonusFireRate)
        {
            bonusFireRate = 1;
        }
        else
        {
            bonusFireRate = 0;
        }
    }

    public void SetBonusLife(bool isBonusLife)
    {
        if (isBonusLife)
        {
            bonusLife = 1;
        }
        else
        {
            bonusLife = 0;
        }
    }

    public float GetBonusTime()
    {
        return bonusTime;
    }

    public int GetBonusFireRate()
    {
        return bonusFireRate;
    }

    public int BonusLife()
    {
        return bonusLife;
    }
}
