using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DragTutorial : MonoBehaviour
{
    public Grid grid;
    public Tilemap tilemap;
    public GameObject prefab;
    public float y_offset = 0.5f, x_offset = 0.5f;
    void Start()
    {
        GameObject moneyObj;
        Items items;
        Money MoneyS;
        for (int y = -4; y < 1; y++)
        {
            for (int x = -1; x < 1; x++)
            {
                moneyObj = Instantiate(prefab);
                items = moneyObj.GetComponent<Items>();
                items.grid = grid;
                items.tilemap = tilemap;
                items.Init();
                moneyObj.transform.position = new Vector3(x + x_offset, y + y_offset);
                uint money = 5;
                if (y == -6) money = 1;
                for (int i = 0; i < y + 6; i++)
                {
                    money <<= 1;
                }
                MoneyS = moneyObj.GetComponent<Money>();
                MoneyS.money = money;
                MoneyS.UpdateSprite();
                moneyObj.SetActive(true);
            }
        }
    }
    void Update()
    {

    }
}
