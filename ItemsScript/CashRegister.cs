using UnityEngine;


public class CashRegister : Invokeble
{
    public MoneyManager moneyManager;
    public string money_tag = "Money";
    private bool show_money = true;
    public override void Click()
    {
        show_money = !show_money;
        if (show_money) moneyManager.show_money();
        else moneyManager.hide_money();
    }

    public override void Drop(GameObject visitor)
    {
        if (visitor.tag == money_tag)
        {
            uint money = visitor.GetComponent<Money>().money;
            moneyManager.Recharge(money);
            Destroy(visitor);
            return;
        }

    }

    public override bool IsDroppable(GameObject visitor)
    {
        if (visitor.tag == money_tag) return true;
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
