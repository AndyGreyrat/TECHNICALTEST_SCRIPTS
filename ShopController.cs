using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopController : MonoBehaviour
{
    public int Gold;
    public TMP_Text GoldUI;
    public ItemsShop[] itemsShop;
    public GameObject[] ShopPanels;
    public templatesShop[] ShopPanelsT;
    public Button[] Buy;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < itemsShop.Length; i++)
        {
            ShopPanels[i].SetActive(true);
            GoldUI.text = "GOLD: " + Gold.ToString();
        }
        LoadPanels();
        CheckBuy();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddGold()
    {
        Gold = Gold + 100;
        GoldUI.text = "GOLD: " + Gold.ToString();
        CheckBuy();
    }
    public void CheckBuy()
    {
        for (int i = 0; i < itemsShop.Length; i++)
        {
            if(Gold >= itemsShop[i].prize)
            {
                Buy[i].interactable = true;
            }
            else
            {
                Buy[i].interactable = false;
            }    
        }
    }
    public void BuyItems(int BTTNO)
    {
        if (Gold >= itemsShop[BTTNO].prize)
        {
            Gold = Gold - itemsShop[BTTNO].prize;
            GoldUI.text = "Gold: " + Gold.ToString();
            CheckBuy();
            //Unlock Item;

        }
    }
    public void LoadPanels()
    {
        for (int i = 0; i < itemsShop.Length; i++)
        {
            ShopPanelsT[i].Title.text = itemsShop[i].Title;
            ShopPanelsT[i].Description.text = itemsShop[i].Description;
            ShopPanelsT[i].Cost.text = "Gold: " + itemsShop[i].prize.ToString();
        }
    }
}
