using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour
{
    public static GameManagement instance;

    // Amounts for text UI
    public Text moneyIndicator;
    public Text level1Indicator;
    public Text level2Indicator;
    public Text level3Indicator;
    public Text level4Indicator;
    public Text level5Indicator;


    // Storage for how much of each
    public float moneyCurrent;
    public int level1Current;
    public int level2Current;
    public int level3Current;
    public int level4Current;
    public int level5Current;

    // Use this for initialization
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        moneyCurrent += 0.0165f * 2 * level1Current;
        moneyIndicator.text = "" + moneyCurrent;
        level1Indicator.text = "" + level1Current;
        level2Indicator.text = "" + level2Current;
        level3Indicator.text = "" + level3Current;
        level4Indicator.text = "" + level4Current;
        level5Indicator.text = "" + level5Current;
    }

    // Function to givemoney on click
    public void GiveMoney()
    {
        moneyCurrent += 1;
    }

    // Function to givepurchase on click
    public void GivePurchase()
    {
        if (moneyCurrent > 10)
        {
            level1Current += 1;
            moneyCurrent -= 10 * level1Current;
        }
        if (moneyCurrent > 100)
        {
            level2Current += 1;
            moneyCurrent -= 100;
        }
        if (moneyCurrent > 1000)
        {
            level3Current += 1;
            moneyCurrent -= 1000;
        }
        if (moneyCurrent > 10000)
        {
            level4Current += 1;
            moneyCurrent -= 10000;
        }
        if (moneyCurrent > 100000)
        {
            level5Current += 1;
            moneyCurrent -= 100000;
        }
    }
}
