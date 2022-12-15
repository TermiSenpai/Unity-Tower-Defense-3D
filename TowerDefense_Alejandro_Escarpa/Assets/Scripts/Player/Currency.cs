using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public static int Money;
    public int startMoney = 150;
    private MoneyToUI moneyToUI;
    private int lastAmountOfMoney;

    private void Start()
    {
        moneyToUI = MoneyToUI.instance;
        Money = startMoney;
        lastAmountOfMoney = Money;
        moneyToUI.SetMoneyToUI(Money.ToString());
    }

    private void Update()
    {
        if (Money != lastAmountOfMoney)
        {
            moneyToUI.SetMoneyToUI(Money.ToString());
            lastAmountOfMoney = Money;
        }
    }
}
