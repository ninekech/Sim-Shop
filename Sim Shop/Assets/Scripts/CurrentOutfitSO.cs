using System;
using UnityEngine;

[CreateAssetMenu(fileName = "CurrentOutfitSO", menuName = "ScriptableObjects/CurrentOutfit", order = 0)]
public class CurrentOutfitSO : ScriptableObject
{
    public MovingSpriteCollectionSO BodySprites;
    public MovingSpriteCollectionSO ShirtSprites;
    public MovingSpriteCollectionSO PantsSprites;
    public MovingSpriteCollectionSO HairSprites;

    [HideInInspector] public int CurrentBodyIndex;
    [HideInInspector] public int CurrentShirtIndex;
    [HideInInspector] public int CurrentPantsIndex;
    [HideInInspector] public int CurrentHairIndex;
}
