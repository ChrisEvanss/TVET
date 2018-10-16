using UnityEngine;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour
{
    public static GameManagement instance;

    // Amounts for text UI
    public Text moneyIndicator;

    [Header("Amount Indicators")]
    public Text level1Indicator;
    public Text level2Indicator;
    public Text level3Indicator;
    public Text level4Indicator;
    public Text level5Indicator;

    [Header("Cost Indicators")]
    public Text level1costIndicator;
    public Text level2costIndicator;
    public Text level3costIndicator;
    public Text level4costIndicator;
    public Text level5costIndicator;

    // Storage for how much of each
    public float moneyCurrent;

    public int level1Current;
    public int level2Current;
    public int level3Current;
    public int level4Current;
    public int level5Current;

    public float level1Cost;
    public float level2Cost;
    public float level3Cost;
    public float level4Cost;
    public float level5Cost;

    public float Upgrade1;

    public Sprite level1Icon;

    // Use this for initialization
    void Start()
    {
        level1Cost = 10;
        level2Cost = 100;
        level3Cost = 1000;
        level4Cost = 10000;
        level5Cost = 100000;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        moneyCurrent += 0.0165f//*
           //(level1Current * Upgrade1) +
           //(level2Current * Upgrade2) +
           //(level3Current * Upgrade3) +
           //(level4Current * Upgrade4) +
           //(level5Current * Upgrade5);

        moneyIndicator.text = "" + (int)moneyCurrent;
        level1Indicator.text = "" + level1Current;
        level2Indicator.text = "" + level2Current;
        level3Indicator.text = "" + level3Current;
        level4Indicator.text = "" + level4Current;
        level5Indicator.text = "" + level5Current;

        level1costIndicator.text = "" + (int)level1Cost;
        level2costIndicator.text = "" + (int)level2Cost;
        level3costIndicator.text = "" + (int)level3Cost;
        level4costIndicator.text = "" + (int)level4Cost;
        level5costIndicator.text = "" + (int)level5Cost;
    }

    // Function to givemoney on click
    public void GiveMoney()
    {
        moneyCurrent += 1;
    }

    public void Upgrade1()
    {
        Upgrade1 +;
    }

    // Function to give purchase on click
    public void GivePurchase1()
    {
        if (moneyCurrent > level1Cost)
        {
            level1Current += 1;
            moneyCurrent -= level1Cost;
            level1Cost = level1Cost * 1.15f;
        }
    }

    public void GivePurchase2()
    {
        if (moneyCurrent > 100 * level2Current)
        {
            level2Current += 1;
            moneyCurrent -= 100 * level2Current;
        }
    }

    public void GivePurchase3()
    {
        if (moneyCurrent > 1000 * level3Current)
        {
            level3Current += 1;
            moneyCurrent -= 1000 * level3Current;
        }
    }

    public void GivePurchase4()
    {
        if (moneyCurrent > 10000 * level4Current)
        {
            level4Current += 1;
            moneyCurrent -= 10000 * level4Current;
        }
    }

    public void GivePurchase5()
    {
        if (moneyCurrent > 100000 * level5Current)
        {
            level5Current += 1;
            moneyCurrent -= 100000 * level5Current;
        }
    }
}
