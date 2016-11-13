using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static int LIFE = 10;
    public GameObject Life_Canvas;
    public Text LifeText;

    public static int WAVE = 1;
    public GameObject Wave_Canvas;
    public Text WaveText;

    public static int KILLS = 0;

    public Text countdownText;
    public int counter = 3;

    public GameObject EM;
    
    private float time = 1;
    private float timer = 0;

    private bool StartCount = false;
    public static bool GameOver = false;
    
    void UpdateText()
    {
        LifeText.text = "" + LIFE;
        WaveText.text = "" + WAVE;
    }

    void IfGameOver()
    {
        if(LIFE <= 0)
        {
            GameOver = true;
        }
    }

    void OnCounter()
    {
        if (StartCount && counter > -1)
        {
            timer += Time.deltaTime;
            if (timer >= time)
            {
                timer = 0;
                counter--;
                countdownText.text = (counter <= 0 ? "GO!!" : "" + counter);
            }
        }

        if (counter <= -1 && StartCount)
        {
            countdownText.text = "";
            StartCount = false;
            EM.SetActive(true);
            Life_Canvas.SetActive(true);
            Wave_Canvas.SetActive(true);
        }
    }

    void WaveCalculator()
    {
        WAVE = KILLS / 10 + 1;
    }

    void checkEnemyonStage()
    {
        int enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if(enemyCount >= 0 && EnemyManager.ENEMY_LIMIT >= 0)
        {

        }
    }

	void Update () {

        UpdateText();

        IfGameOver();

        OnCounter();

        WaveCalculator();

        checkEnemyonStage();
	}

    public void Count()
    {
        StartCount = true;
    }
}
