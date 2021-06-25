using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndSceneScript : MonoBehaviour
{
    public Text lastChanceTime;
    public Text chancesCount;
    public Button changeLevel;
    public Button startAgain;

    // Start is called before the first frame update
    void Start()
    {
        ScenesDataStaticScript.increaseCounter();
        chancesCount.text = ScenesDataStaticScript.counter.ToString();
        var time = Mathf.RoundToInt(ScenesDataStaticScript.timeFromStart);
        var minutes = time / 60;
        var seconds = time % 60;
        lastChanceTime.text = (minutes < 10 ? "0" + minutes.ToString() : minutes.ToString()) + ":" + 
                              (seconds < 10 ? "0" + seconds.ToString() : seconds.ToString());

        changeLevel.onClick.AddListener(onChangeLevelClick);
        startAgain.onClick.AddListener(onStartAgainClick);
    }

    public void onChangeLevelClick()
    {
        SceneManager.LoadScene("StartGame");
    }

    public void onStartAgainClick()
    {
        SceneManager.LoadScene("MainGame");
    }
}
