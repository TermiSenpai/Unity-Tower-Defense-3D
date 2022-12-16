using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopPrice : MonoBehaviour
{
    [SerializeField] private Turret turret;
    [SerializeField] private TextMeshProUGUI priceTxt;

    private void Start()
    {
        updateCostTxt();
    }

    private void updateCostTxt()
    {
        priceTxt.text = turret.cost.ToString();
    }

    private void Update()
    {
        if (Currency.Money < turret.cost)
            priceTxt.color = Color.red;
        else priceTxt.color = Color.green;
    }
}
