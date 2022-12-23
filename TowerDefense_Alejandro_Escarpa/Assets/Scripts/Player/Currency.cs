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
        StartCoroutine(IUpdateMoneyToUI());
    }

    private void Update()
    {
        

        if (Money <= 0)
            Money = 0;
    }

    private IEnumerator IUpdateMoneyToUI()
    {
        while (true)
        {
            if (Money != lastAmountOfMoney)
            {
                moneyToUI.SetMoneyToUI(Money.ToString());
                lastAmountOfMoney = Money;
            }
            yield return null;
        }
    }
}
