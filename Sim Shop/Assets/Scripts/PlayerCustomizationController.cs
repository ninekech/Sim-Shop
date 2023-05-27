using System.Collections.Generic;
using UnityEngine;

public partial class PlayerCustomizationController : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private int animationFrameRate = 8;
    [Header("References")]
    [SerializeField] private CurrentOutfitSO currentOutfitSO;
    [SerializeField] private SpriteRenderer bodyRenderer;
    [SerializeField] private SpriteRenderer shirtRenderer;
    [SerializeField] private SpriteRenderer pantsRenderer;
    [SerializeField] private SpriteRenderer hairRenderer;

    private float _counter = 0f;
    private List<Sprite> _currentBodySprites;
    private List<Sprite> _currentShirtSprites;
    private List<Sprite> _currentPantsSprites;
    private List<Sprite> _currentHairSprites;
    private AnimationState _currentAnimationState;

    public AnimationState CurrentAnimationState 
    {
        get { return _currentAnimationState; }
        set
        {
            if(_currentAnimationState != value)
                UpdateUsedSprites(value);

            _currentAnimationState = value;
        }
    }

    public void SetMovement(Vector2 movement)
    {
        if (movement.y > 0)
            CurrentAnimationState = AnimationState.WalkUp;
        else if (movement.x > 0)
            CurrentAnimationState = AnimationState.WalkRight;
        else if (movement.x < 0)
            CurrentAnimationState = AnimationState.WalkLeft;
        else if (movement.y < 0)
            CurrentAnimationState = AnimationState.WalkDown;
        else CurrentAnimationState = AnimationState.Idle;
    }

    private void Start()
    {
        CurrentAnimationState = AnimationState.Idle;
    }

    private void Update()
    {
        // Reset
        if (CurrentAnimationState == AnimationState.Idle)
        {
            _counter = 0;
            return;
        }

        // Animate
        if (_counter <= 0)
        {
            _counter = animationFrameRate;

            bodyRenderer.sprite = _currentBodySprites[currentOutfitSO.CurrentBodyIndex];
            shirtRenderer.sprite = _currentShirtSprites[currentOutfitSO.CurrentShirtIndex];
            pantsRenderer.sprite = _currentPantsSprites[currentOutfitSO.CurrentPantsIndex];
            hairRenderer.sprite = _currentHairSprites[currentOutfitSO.CurrentHairIndex];

            IncrementSpriteIndexes();
        }
        else _counter--;
    }

    private void UpdateUsedSprites(AnimationState newAnimState)
    {
        currentOutfitSO.CurrentBodyIndex = 0;
        currentOutfitSO.CurrentShirtIndex = 0;
        currentOutfitSO.CurrentPantsIndex = 0;
        currentOutfitSO.CurrentHairIndex = 0;

        switch (newAnimState)
        {
            case AnimationState.WalkUp:
                _currentBodySprites = currentOutfitSO.BodySprites.UpSprites;
                _currentShirtSprites = currentOutfitSO.ShirtSprites.UpSprites;
                _currentPantsSprites = currentOutfitSO.PantsSprites.UpSprites;
                _currentHairSprites = currentOutfitSO.HairSprites.UpSprites;
                break;
            case AnimationState.WalkDown:
                _currentBodySprites = currentOutfitSO.BodySprites.DownSprites;
                _currentShirtSprites = currentOutfitSO.ShirtSprites.DownSprites;
                _currentPantsSprites = currentOutfitSO.PantsSprites.DownSprites;
                _currentHairSprites = currentOutfitSO.HairSprites.DownSprites;
                break;
            case AnimationState.WalkLeft:
                _currentBodySprites = currentOutfitSO.BodySprites.LeftSprites;
                _currentShirtSprites = currentOutfitSO.ShirtSprites.LeftSprites;
                _currentPantsSprites = currentOutfitSO.PantsSprites.LeftSprites;
                _currentHairSprites = currentOutfitSO.HairSprites.LeftSprites;
                break;
            case AnimationState.WalkRight:
                _currentBodySprites = currentOutfitSO.BodySprites.RightSprites;
                _currentShirtSprites = currentOutfitSO.ShirtSprites.RightSprites;
                _currentPantsSprites = currentOutfitSO.PantsSprites.RightSprites;
                _currentHairSprites = currentOutfitSO.HairSprites.RightSprites;
                break;
        }
    }

    private void IncrementSpriteIndexes()
    {
        // Body
        if (currentOutfitSO.CurrentBodyIndex >= _currentBodySprites.Count - 1)
            currentOutfitSO.CurrentBodyIndex = 0;
        else currentOutfitSO.CurrentBodyIndex++;
        // Shirt
        if (currentOutfitSO.CurrentShirtIndex >= _currentShirtSprites.Count - 1)
            currentOutfitSO.CurrentShirtIndex = 0;
        else currentOutfitSO.CurrentShirtIndex++;
        // Pants
        if (currentOutfitSO.CurrentPantsIndex >= _currentPantsSprites.Count - 1)
            currentOutfitSO.CurrentPantsIndex = 0;
        else currentOutfitSO.CurrentPantsIndex++;
        // Hair
        if (currentOutfitSO.CurrentHairIndex >= _currentHairSprites.Count - 1)
            currentOutfitSO.CurrentHairIndex = 0;
        else currentOutfitSO.CurrentHairIndex++;
    }
}
