using UnityEngine;

public class GameSettings : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
