using System;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject buyPopup;
    [SerializeField] private GameObject equipSellPopup;

    public static PopupManager Instance;
    public static Action OnBuy;
    public static Action OnEquip;
    public static Action OnSell;
    public static Action OnClosePopup;

    private GameObject _activePopup;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(gameObject);
    }

    public void CloseActivePopup()
    {
        if (_activePopup is null) return;

        _activePopup.SetActive(false);
        OnClosePopup?.Invoke();
    }

    public void OpenBuyPopup()
    {
        buyPopup.SetActive(true);
        _activePopup = buyPopup;
    }

    public void OpenEquipSellPopup()
    {
        equipSellPopup.SetActive(true);
        _activePopup = equipSellPopup;
    }

    public void BuyItem() => OnBuy?.Invoke();
    public void SellItem() => OnSell?.Invoke();
    public void EquipItem() => OnEquip?.Invoke();
}
