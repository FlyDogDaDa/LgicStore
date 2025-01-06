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
        if (visitor.tag != money_tag) return;//��褣�O��
        money += visitor.GetComponent<Money>().money;
        UpdateSprite();
        Destroy(visitor); // �R�����
    }

    public override bool IsDroppable(GameObject visitor)
    {
        if (visitor.tag != money_tag) return false;//��褣�O��
        //if (sprite_level.Length - 1 == level_index) return false;//�w�g�̰���
        //if (money + visitor.GetComponent<Money>().money > money_level[money_level.Length - 1]) return false;//�|�W�X�d��
        return true;
    }

    void Start()
    {
        this_sprite = GetComponent<SpriteRenderer>();
        if (sprite_level.Length != money_level.Length) throw new MissingReferenceException("�����ť��������Ϥ�����");
        UpdateSprite();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
