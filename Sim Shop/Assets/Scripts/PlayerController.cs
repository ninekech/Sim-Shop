using System;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private float movementSpeed = 3f;
    [Header("References")]
    [SerializeField] private GameObject hint;
    [SerializeField] private PlayerCustomizationController customizationController;

    public Action OnInteraction;
    private Rigidbody2D _rb;
    private Vector2 _move;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckForMoveInput();
        //CheckForInteractionInput();
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_move);
    }

    private void CheckForMoveInput()
    {
        bool isMoving = false;
        Vector2 inputVector = Vector2.zero;

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) &&
            !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.DownArrow))
        {
            isMoving = true;
            _move.y = transform.position.y + movementSpeed * Time.fixedDeltaTime;
            inputVector.y = 1;
        }

        if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) &&
            !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.UpArrow))
        {
            isMoving = true;
            _move.y = transform.position.y + -movementSpeed * Time.fixedDeltaTime;
            inputVector.y = -1;
        }

        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) &&
            !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.LeftArrow))
        {
            isMoving = true;
            _move.x = transform.position.x + movementSpeed * Time.fixedDeltaTime;
            inputVector.x = 1;
        }

        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) &&
            !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.RightArrow))
        {
            isMoving = true;
            _move.x = transform.position.x + -movementSpeed * Time.fixedDeltaTime;
            inputVector.x = -1;
        }

        if (!isMoving) inputVector = Vector2.zero;

        customizationController.SetMovement(inputVector);
    }

    private void CheckForInteractionInput()
    {
        bool hasInteractionAvailable = OnInteraction is not null && OnInteraction.GetInvocationList().Length > 0;
        hint.SetActive(hasInteractionAvailable);
        if (!hasInteractionAvailable) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnInteraction?.Invoke();
            hint.SetActive(false);
        }
    }
}
