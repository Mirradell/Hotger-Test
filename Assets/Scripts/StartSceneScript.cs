using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSceneScript : MonoBehaviour
{
    public Button startButton;
    public Dropdown levelDropdown;

    private List<string> levels = new List<string>() { "Низкая", "Средняя", "Высокая" };

    private void Start()
    {
        startButton.onClick.AddListener(OnStartClick);

        levelDropdown.ClearOptions();
        levelDropdown.AddOptions(levels);
        levelDropdown.value = 0;
        levelDropdown.RefreshShownValue();
    }
    public void OnStartClick()
    {
        switch (levelDropdown.value)
        {
            case 0:
                ScenesDataStaticScript.speed = 5;
                break;
            case 1:
                ScenesDataStaticScript.speed = 9;
                break;
            case 2:
                ScenesDataStaticScript.speed = 16;
                break;
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainGame");
    }
    
}
