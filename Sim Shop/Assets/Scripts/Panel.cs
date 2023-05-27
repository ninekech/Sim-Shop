using UnityEngine;

public class Panel : MonoBehaviour
{
    private Camera _cam;
    private Vector2 _startPosition;

    private void Awake()
    {
        _cam = Camera.main;
        _startPosition = transform.localPosition;
    }

    private void OnEnable()
    {
        transform.localPosition = _startPosition;
    }

    public void StartDrag()
    {
        Vector2 dragPosition = _cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector3.Lerp(transform.position, dragPosition, Time.deltaTime * 30);
    }
}
