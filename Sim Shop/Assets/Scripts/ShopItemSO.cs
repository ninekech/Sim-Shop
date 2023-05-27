using UnityEngine;

public class ShopItemSO : ScriptableObject
{
    public string Name;
    public int Price;
    public bool IsLocked;
    public MovingSpriteCollectionSO Data;
}
