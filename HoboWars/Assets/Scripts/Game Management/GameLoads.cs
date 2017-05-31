using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoads : MonoBehaviour {

    public void OnClickStartGame() {
        SceneManager.LoadScene(1);        
    }

    public void OnClickHowToPlay() {
        SceneManager.LoadScene(2);
    }

    public void OnClickExitGame() {
        Application.Quit();
    }
}
