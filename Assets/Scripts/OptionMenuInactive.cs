﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenuInactive : MonoBehaviour

{

    public GameObject settingsMenu;
    // Start is called before the first frame update
    void Start()
    {
        settingsMenu.SetActive(false);
    }

}
