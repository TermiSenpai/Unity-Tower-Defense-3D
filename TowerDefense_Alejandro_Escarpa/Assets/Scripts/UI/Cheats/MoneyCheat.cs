using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCheat : MonoBehaviour
{
    public void AddMoney(int value)
    {
        Currency.Money += value;
    }
}
