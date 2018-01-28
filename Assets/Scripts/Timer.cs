using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public Text screentime;
    public float timer;

    private float remainingTime;
	private bool count;

    public GameObject[] CarControllerObjects;
    public GameObject PlayerOneScore;
    public GameObject PlayerTwoScore;
    public GameObject PlayerOneResultText;
    public GameObject PlayerTwoResultText;
    public GameObject MainMenuButton;

    private int p1Score, p2Score;

	// Use this for initialization
	void Start () {
        remainingTime = timer;
        count = true;

        MainMenuButton.SetActive(false);
        PlayerOneResultText.SetActive(false);
        if(PlayerTwoResultText != null)
        {
            PlayerTwoResultText.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {

		if(count){
            remainingTime -= Time.deltaTime;
		    screentime.text = Mathf.Round (remainingTime).ToString();
		}

		if (remainingTime <= 0) {
			count = false;
            foreach(GameObject car in CarControllerObjects)
            {
                car.GetComponent<CarController>().forceGameOver();
            }

            if (PlayerTwoScore == null)
            {
                // TODO: implement behaviour on single game
            }
            else
            {
                p1Score = int.Parse(PlayerOneScore.GetComponent<Text>().text);
                p2Score = int.Parse(PlayerTwoScore.GetComponent<Text>().text);

                if (p1Score > p2Score)
                {
                    PlayerOneResultText.GetComponent<Text>().text = "WIN!!";
                    PlayerTwoResultText.GetComponent<Text>().text = "LOSE";
                }
                else if (p1Score < p2Score)
                {
                    PlayerOneResultText.GetComponent<Text>().text = "LOSE";
                    PlayerTwoResultText.GetComponent<Text>().text = "WIN!!";
                }
                else
                {
                    PlayerOneResultText.GetComponent<Text>().text = "DRAW";
                    PlayerTwoResultText.GetComponent<Text>().text = "DRAW";
                }

                PlayerOneResultText.SetActive(true);
                PlayerTwoResultText.SetActive(true);
                MainMenuButton.SetActive(true);
            }
		}
	}
}
