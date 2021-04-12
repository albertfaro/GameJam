﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
  public void playGame()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }



    public void quitGame()
    {
        Debug.Log("Quitting the game!");
        Application.Quit(0);
    }
}
