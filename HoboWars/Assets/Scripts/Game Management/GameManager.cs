using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    //player1 info
    public GameObject _player1;
    public static GameObject player1;
    private static GameObject player1AtBin;
    private static bool running = true;

    //player2 info
    public GameObject _player2;
    public static GameObject player2;
    private static GameObject player2AtBin;

    public GameObject _gameWinGUI;
    public GameObject _gameWinScoreGUI;
    public static GameObject gameWinGUI;
    public static GameObject gameWinScoreGUI;

    public GameObject _gameTimeGUI;
    public static GameObject gameTimeGUI;
    public int gameTimerValue, currentGameTimerValue;

    private static bool gameIsOver;

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }


        //DontDestroyOnLoad (this);

        player1 = _player1;
        player2 = _player2;

        gameWinGUI = _gameWinGUI;
        gameWinScoreGUI = _gameWinScoreGUI;
        gameTimeGUI = _gameTimeGUI;

        StartCoroutine(scoreTimer());

        gameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        //game is running, check if any player presses bin buttons
        if (running)
        {
            InputManager.Player1CheckBinButton();
            InputManager.Player2CheckBinButton();
            InputManager.Player1CheckThrowButton();
            InputManager.Player2CheckThrowButton();
            InputManager.Player1CheckCycleButton();
            InputManager.Player2CheckCycleButton();
            InputManager.Player1CheckMovement();
            InputManager.Player2CheckMovement();
        }
    }

    public static GameObject getPlayer1AtBin()
    {
        return player1AtBin;
    }

    public static void setPlayer1AtBin(GameObject x)
    {
        player1AtBin = x;
    }

    public static GameObject getPlayer1()
    {
        return player1;
    }

    public static GameObject getPlayer2AtBin()
    {
        return player2AtBin;
    }

    public static void setPlayer2AtBin(GameObject x)
    {
        player2AtBin = x;
    }

    public static GameObject getPlayer2()
    {
        return player2;
    }

    public static void finishGame(GameObject player)
    {
        if (!gameIsOver) {
            gameIsOver = true;
            string gamewintext;
            string timerscoretext;
            int timeCompleted = GameObject.FindGameObjectWithTag("manager").GetComponent<GameManager>().gameTimerValue - GameObject.FindGameObjectWithTag("manager").GetComponent<GameManager>().currentGameTimerValue;

            running = false;
            player1.GetComponent<simpleMove>().enabled = false;
            player1.GetComponent<PlayerActions>().enabled = false;

            player2.GetComponent<simpleMove>().enabled = false;
            player2.GetComponent<PlayerActions>().enabled = false;


            GameObject.Find("Music Player").GetComponent<AudioSource>().Stop();
            GameObject.FindGameObjectWithTag("manager").GetComponent<AudioManager>().playSound("Win");

            if (player.tag == "player1") {
                gamewintext = "Player 1 wins the game!";
                timerscoretext = "You defeated player 2 in " + timeCompleted + " seconds!";
                player1.GetComponent<simpleMove>().anim.SetTrigger("youDied");
            } else if (player.tag == "player2") {
                gamewintext = "Player 2 Wins the game!";
                timerscoretext = "You defeated player 1 in " + timeCompleted + " seconds!";
                player2.GetComponent<simpleMove>().anim.SetTrigger("youDied");

            } else {
                gamewintext = "It's a draw you fools!";
                timerscoretext = "The time ran out you pussies!";
            }

            gameWinGUI.GetComponent<Text>().text = gamewintext;
            gameWinGUI.SetActive(true);
            gameWinScoreGUI.GetComponent<Text>().text = timerscoretext;
            gameWinScoreGUI.SetActive(true);
        }     

    }

    public IEnumerator scoreTimer()
    {
        string gametimertext;

        while (true)
        {
            yield return new WaitForSeconds(1);
            gametimertext = currentGameTimerValue.ToString();
            if (currentGameTimerValue > 0) {
                currentGameTimerValue--;
            }            
            gameTimeGUI.GetComponent<Text>().text = gametimertext;
            gameTimeGUI.SetActive(true);
            
            if (currentGameTimerValue < 1)
            {
                if (GameObject.FindGameObjectWithTag("player1").GetComponent<PlayerHealth>().currentHealth > GameObject.FindGameObjectWithTag("player2").GetComponent<PlayerHealth>().currentHealth)
                {
                    finishGame(GameObject.FindGameObjectWithTag("player2"));
                    StartCoroutine(StopGame());
                }
                else if (GameObject.FindGameObjectWithTag("player2").GetComponent<PlayerHealth>().currentHealth > GameObject.FindGameObjectWithTag("player1").GetComponent<PlayerHealth>().currentHealth)
                {
                    finishGame(GameObject.FindGameObjectWithTag("player1"));
                    StartCoroutine(StopGame());
                }
                else if (GameObject.FindGameObjectWithTag("player1").GetComponent<PlayerHealth>().currentHealth == GameObject.FindGameObjectWithTag("player2").GetComponent<PlayerHealth>().currentHealth)
                {
                    finishGame(new GameObject("draw"));
                    StartCoroutine(StopGame());
                }
            }
        }
    }

    public static IEnumerator StopGame() {
        yield return new WaitForSeconds(5);
        Time.timeScale = 0f;
		//goto scene menu
		Application.Quit();
    }
}
