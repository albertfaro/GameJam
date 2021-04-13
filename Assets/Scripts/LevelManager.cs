using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    public int civKilled;
    public int civToWin;
    public int civLeft;
    public float timeLeft = 120f; //Definir segundos para que acabe la partida
    [SerializeField]private Text uiText;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        civToWin = 30;
        civKilled = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        uiText.text = "Time left: " + timeLeft.ToString("F");
        civLeft = civToWin - civKilled;

        if(civKilled >= civToWin)
        {
            victory();
        }

        if(timeLeft < 0)
        {
            defeat();
        }
        

        
    }


    public void victory()
    {
        SceneManager.LoadScene("Victory", LoadSceneMode.Single);
    }


    public void defeat()
    {
        SceneManager.LoadScene("Defeat", LoadSceneMode.Single);
    }

    public void killedCiv()
    {
        civKilled++;
    }

    
}
