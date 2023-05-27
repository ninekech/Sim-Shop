using UnityEngine;

[CreateAssetMenu(fileName = "ShopItem", menuName = "ScriptableObjects/ShopItem", order = 2)]
public class ShopItemSO : ScriptableObject
{
    public string Name;
    public int Price;
    public bool IsLocked;
    public ShopItemType Type;
    public MovingSpriteCollectionSO Data;
}
