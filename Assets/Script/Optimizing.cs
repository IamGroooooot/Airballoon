﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Optimizing : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
    }
	
}
