using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopElement : MonoBehaviour
{
    [Header("Scene References")]
    [SerializeField] private Image contentImage;
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private GameObject locker;
    [Header("Project References")]
    [SerializeField] private CurrentOutfitSO currentOutfitSO;

    private ShopItemSO _shopItem;
    private bool _isItemLoaded;
    private bool _isLocked;
    private int _price;

    public void LoadData(ShopItemSO item)
    {
        contentImage.sprite = item.Data.DownSprites[0];
        priceText.text = item.Price.ToString();
        priceText.gameObject.SetActive(item.IsLocked);
        locker.SetActive(item.IsLocked);

        _shopItem = item;
        _isLocked = item.IsLocked;
        _price = item.Price;

        _isItemLoaded = true;
    }

    public void UnlockItem()
    {
        if (!_isItemLoaded || BalanceManager.Instance.Balance < _shopItem.Price) return;

        _shopItem.IsLocked = false;
        _isLocked = false;

        locker.SetActive(false);
        priceText.gameObject.SetActive(false);

        BalanceManager.Instance.Balance -= _shopItem.Price;
    }

    public void SellItem()
    {
        _shopItem.IsLocked = true;
        _isLocked = true;

        locker.SetActive(true);
        priceText.gameObject.SetActive(true);

        BalanceManager.Instance.Balance += _shopItem.Price;

        if (currentOutfitSO.PantsSprites == _shopItem.Data ||
            currentOutfitSO.HairSprites == _shopItem.Data ||
            currentOutfitSO.ShirtSprites == _shopItem.Data)
            PlayerCustomizationController.OnSoldEquippedItem?.Invoke(_shopItem.Type);
    }

    private void EquipItem()
    {
        switch (_shopItem.Type)
        {
            case ShopItemType.Hair:
                currentOutfitSO.HairSprites = _shopItem.Data;
                break;
            case ShopItemType.Shirts:
                currentOutfitSO.ShirtSprites = _shopItem.Data;
                break;
            case ShopItemType.Pants:
                currentOutfitSO.PantsSprites = _shopItem.Data;
                break;
        }

        currentOutfitSO.OnRefresh?.Invoke();
        PlayerCustomizationController.OnEquippedItem?.Invoke(_shopItem.Type);
    }

    public void Click()
    {
        if(_isLocked)
        {
            PopupManager.Instance.OpenBuyPopup();
            PopupManager.OnBuy += UnlockItem;
            PopupManager.OnClosePopup += RemoveListeners;
        }
        else
        {
            PopupManager.Instance.OpenEquipSellPopup();
            PopupManager.OnEquip += EquipItem;
            PopupManager.OnSell += SellItem;
            PopupManager.OnClosePopup += RemoveListeners;
        }
    }

    private void RemoveListeners()
    {
        PopupManager.OnClosePopup -= RemoveListeners;
        PopupManager.OnBuy -= UnlockItem;
        PopupManager.OnEquip -= EquipItem;
        PopupManager.OnSell -= SellItem;
    }

    public bool IsLocked() => _isLocked;
    public int GetPrice() => _price;
}
