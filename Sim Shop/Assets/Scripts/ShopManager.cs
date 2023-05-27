using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private List<ShopItemSO> shopItems;
    [Header("References")]
    [SerializeField] private Transform shopContentParent;
    [SerializeField] private ShopElement shopElementPrefab;
    [SerializeField] private Button[] headerButtons;

    private ShopItemType _currentlySelectedItemType;
    private ShopItemType currentlySelectedItemType
    {
        get { return _currentlySelectedItemType; }
        set
        {
            CleanContent();
            headerButtons[(int)_currentlySelectedItemType].interactable = true;
            _currentlySelectedItemType = value;
            headerButtons[(int)_currentlySelectedItemType].interactable = false;
            AddContent();
        }
    }

    private void OnEnable()
    {
        currentlySelectedItemType = ShopItemType.Hair;
    }

    private void CleanContent()
    {
        foreach(Transform junk in shopContentParent)
            Destroy(junk.gameObject);
    }

    private void AddContent()
    {
        foreach (ShopItemSO item in shopItems)
        {
            if (item.Type == currentlySelectedItemType)
            {
                ShopElement shopElement = Instantiate(shopElementPrefab, shopContentParent);
                shopElement.LoadData(item);
            }
        }
    }

    public void SwitchHeaderTab(int id)
    {
        currentlySelectedItemType = (ShopItemType)id;
    }
}
