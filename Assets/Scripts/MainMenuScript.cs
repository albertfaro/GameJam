using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
  public void playGame()
    {
        SceneManager.LoadScene("PreLevel", LoadSceneMode.Single);
    }



    public void quitGame()
    {
        Debug.Log("Quitting the game!");
        Application.Quit(0);
    }

    public void goToMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
