using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    public int BatFormsLeft;
    public int civKilled;
    public int civToWin;
    public int civLeft;
    public bool safe;
    public int nightcount;
    public float timetodie;
    public float timeLeft;
    public bool dead;
    public bool takingDamage;
    //Definir segundos para que acabe la partida
    [SerializeField]private Text uiText;
    [SerializeField] private Text murderedCiv;
    //[SerializeField] private Text remainingCiv;
    [SerializeField] private Text nightCountText;
    [SerializeField] private Text time2die;
    [SerializeField] private Text batUses;




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
        BatFormsLeft = 3;
        nightcount = 0;
        civToWin = 40;
        civKilled = 0;
        timetodie = 99;
    }

    // Update is called once per frame
    void Update()
    {
        
        civLeft = civToWin - civKilled;
        timeLeft -= Time.deltaTime;
        uiText.text = timeLeft.ToString("F");
        murderedCiv.text = civKilled + ("/") + civToWin;
        //remainingCiv.text = civLeft + " people left";
        nightCountText.text = (nightcount + 1) + "/3";
        if (takingDamage)
        {
            time2die.text = "Dying in " + timetodie + " seconds!";
        }
        batUses.text = BatFormsLeft + ("/3");

        death();
        if (civKilled >= civToWin)
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
        timeLeft = 180;
        nightcount++;
        if(nightcount >= 3)
        {
            defeat();
        }

    }
    public void death()
    {
        if (timetodie<=0)
        {
            defeat();
        }
    }
}
