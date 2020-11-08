using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // Start is called before the first frame update
    int index;
    void Start()
    {
        index = SceneManager.GetActiveScene().buildIndex;
        if (index == 0)
            StartCoroutine(DelayLoadScene(1));
    }

    private IEnumerator DelayLoadScene(int v)
    {
        yield return new WaitForSeconds(3);
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(index + 1);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public int GetScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
