using System;
using TMPro;
using UnityEngine;

public sealed class MoneyManager : MonoBehaviour
{
    public TextMeshProUGUI money_value;
    public GameObject display;

    public uint money { get; private set; }
    public void show_money()
    {
        display.SetActive(true);
    }
    public void hide_money()
    {
        display.SetActive(false);
    }

    private void UpdateText() { money_value.text = money.ToString(); }
    public bool IsDeductible(uint amount) { return money >= amount; }

    public void Recharge(uint amount) { money += amount; UpdateText(); }

    public void Deduct(uint amount)
    {
        if (!IsDeductible(amount)) throw new InvalidOperationException("æl√B§£®¨");
        money -= amount;
        UpdateText();
    }
}
