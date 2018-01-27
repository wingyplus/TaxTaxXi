using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneNavigation : MonoBehaviour {

    public void GotoSinglePlayerGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void GotoTwoPlayerGame()
    {
        SceneManager.LoadScene("TwoPlayersGame02");
    }

    public void GotoMainmenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
