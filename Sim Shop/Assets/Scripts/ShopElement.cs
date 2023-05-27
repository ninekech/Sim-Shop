using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopElement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image contentImage;
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private GameObject locker;

    private ShopItemSO _shopItem;
    private bool _isItemLoaded;
    private bool _isLocked;
    private int _price;

    public void LoadData(ShopItemSO item)
    {
        contentImage.sprite = item.Data.DownSprites[0];
        priceText.text = item.Price.ToString();
        locker.SetActive(item.IsLocked);

        _shopItem = item;
        _isLocked = item.IsLocked;
        _price = item.Price;

        _isItemLoaded = true;
    }

    public void UnlockItem()
    {
        if (!_isItemLoaded) return;

        _shopItem.IsLocked = false;
        _isLocked = false;

        locker.SetActive(false);
        priceText.gameObject.SetActive(false);
    }

    public bool IsLocked() => _isLocked;
    public int GetPrice() => _price;
}
