using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text countdownText;
    public int counter = 3;

    public GameObject EM;

    private float time = 1;
    private float timer = 0;

    private bool StartCount = false;
    private bool GameOver = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
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

        if(counter <= -1 && StartCount)
        {
            countdownText.text = "";
            StartCount = false;
            EM.SetActive(true);
        }
	}

    public void Count()
    {
        StartCount = true;
    }
}
