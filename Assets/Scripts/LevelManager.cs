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
    public bool safe;
    public int nightcount;
    public float timeLeft; //Definir segundos para que acabe la partida
    [SerializeField]private Text uiText;
    [SerializeField] private Text murderedCiv;
    [SerializeField] private Text remainingCiv;
    [SerializeField] private Text nightCountText;



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
        nightcount = 0;
        civToWin = 30;
        civKilled = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        civLeft = civToWin - civKilled;
        timeLeft -= Time.deltaTime;
        uiText.text = "Time left: " + timeLeft.ToString("F");
        murderedCiv.text = "You have killed " + civKilled + " people";
        remainingCiv.text = civLeft + " people left";
        nightCountText.text = "Night " + (nightcount + 1) + "/3"; 
        

        if(civKilled >= civToWin)
        {
            victory();
        }

        if(timeLeft < 0)
        {
            if(safe)
            {
                endNight();
            }
            else
            {
                defeat();
            }
            
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

    public void endNight()
    {
        timeLeft = 120;
        nightcount++;
        if(nightcount >= 1)
        {
            defeat();
        }
    }
}
