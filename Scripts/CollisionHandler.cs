﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float restartLevelDelay = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(StartDeathSequence());
    }

    private IEnumerator StartDeathSequence()
    {
        SendMessage("PlayerDead");
        yield return new WaitForSeconds(restartLevelDelay);
        FindObjectOfType<LevelLoader>().RestartScene();
    }
}
