using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        var musicPlayers = FindObjectsOfType<BackgroundMusic>();
        if (musicPlayers.Length > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
        int scene = FindObjectOfType<LevelLoader>().GetScene();
        if (scene == 0)
            GetComponent<AudioSource>().volume = 0.4f;
        else
            GetComponent<AudioSource>().volume = 0.13f;
    }
}
