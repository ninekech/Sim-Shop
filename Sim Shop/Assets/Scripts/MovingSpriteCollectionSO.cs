using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MovingSpriteCollection", menuName = "ScriptableObjects/MovingSpriteCollection", order = 1)]
public class MovingSpriteCollectionSO : ScriptableObject
{
    public List<Sprite> UpSprites;
    public List<Sprite> RightSprites;
    public List<Sprite> DownSprites;
    public List<Sprite> LeftSprites;
}
