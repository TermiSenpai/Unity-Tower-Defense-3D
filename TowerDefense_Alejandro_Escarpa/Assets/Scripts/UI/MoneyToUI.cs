using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MoneyToUI : MonoBehaviour
{
    public static MoneyToUI instance;
    [SerializeField] TextMeshProUGUI moneyTxt;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one MoneyToUI in scene");
        }
        instance = this;
    }

    public void SetMoneyToUI(string moneyToString)
    {
        moneyTxt.text = moneyToString;
    }
}
