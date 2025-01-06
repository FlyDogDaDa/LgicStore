using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Money : Invokeble
{
    public string money_tag = "Money";
    public Sprite[] sprite_level;
    public int[] money_level;
    private int level_index = 0;
    public uint money = 1;
    private SpriteRenderer this_sprite;

    public override void Click()
    {
    }
    public void UpdateSprite()
    {
        for (int i = money_level.Length-1; i > 0; i--)
        {
            if (money >= money_level[i])
            {
                level_index = i;
                break;
            }
        }
        this_sprite.sprite = sprite_level[level_index];
    }

    public override void Drop(GameObject visitor)
    {
        if (visitor.tag != money_tag) return;//對方不是錢
        money += visitor.GetComponent<Money>().money;
        UpdateSprite();
        Destroy(visitor); // 刪掉對方
    }

    public override bool IsDroppable(GameObject visitor)
    {
        if (visitor.tag != money_tag) return false;//對方不是錢
        //if (sprite_level.Length - 1 == level_index) return false;//已經最高級
        //if (money + visitor.GetComponent<Money>().money > money_level[money_level.Length - 1]) return false;//會超出範圍
        return true;
    }

    void Start()
    {
        this_sprite = GetComponent<SpriteRenderer>();
        if (sprite_level.Length != money_level.Length) throw new MissingReferenceException("錢分級必須對應圖片分級");
        UpdateSprite();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
