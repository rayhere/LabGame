using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMod : MonoBehaviour
{
    // Reminder
    // set the toggle not only static parameters
    // but also dynamic bool
    [SerializeField] bool BonusTimeToggle;
    [SerializeField] bool BonusFireRateToggle;
    [SerializeField] bool BonusLifeToggle;

    [SerializeField] float bonusTime;
    [SerializeField] float bonusFireRate;
    [SerializeField] int bonusLife;

    public static GameMod Modifier;

    const float lowFireRate = .8f;
    const float highFireRate = 1.2f;
    const float shortTimeBonus = 1f;
    const float longTimeBonus = 3f;

    void Awake()
    {
        if (Modifier == null)
        {
            DontDestroyOnLoad(this);
            Debug.Log("GameMod.sc Don't Destory On Load");
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
        bonusTime = longTimeBonus;
        bonusFireRate = lowFireRate;
        //bonusLife = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBonusTime(bool isBonusTime)
    {
        if (isBonusTime)
        {
            //Debug.Log("bonusTime = longTimeBonus");
            bonusTime = longTimeBonus;
        }
        else
        {
            //Debug.Log("bonusTime = shortTimeBonus");
            bonusTime = shortTimeBonus;
        }
    }

    public void SetBonusFireRate(bool isBonusFireRate)
    {
        if (isBonusFireRate)
        {
            bonusFireRate = highFireRate;
        }
        else
        {
            bonusFireRate = lowFireRate;
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

    public float GetBonusFireRate()
    {
        return bonusFireRate;
    }

    public int BonusLife()
    {
        return bonusLife;
    }
}
