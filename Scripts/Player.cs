using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField] float xSpeed = 8f;
    [SerializeField] float ySpeed = 6f;
    private bool isAlive = true;
    [SerializeField] GameObject deathVFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void Update()
    {
        if (!isAlive)
            return;

        Move();
        //Fire();

    }

    private void Fire()
    {
        bool isFiring = CrossPlatformInputManager.GetButton("Fire");
        var guns = GetComponentsInChildren<ParticleSystem>();
        Debug.Log(guns.Length);

        foreach (ParticleSystem gun in guns)
        {
            if (isFiring)
                gun.Play();
            else
                gun.Stop();

        }



    }

    private void Move()
    {
        float horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float verticalThrow = CrossPlatformInputManager.GetAxis("Vertical");


        float xOffset = xSpeed * horizontalThrow * Time.deltaTime;
        float yOffset = ySpeed * verticalThrow * Time.deltaTime;

        float localX = Mathf.Clamp(transform.localPosition.x + xOffset, -4.5f, 4.5f);
        float localy = Mathf.Clamp(transform.localPosition.y + yOffset, -2f, 2f);
        float yRotation = localX / 0.15f; //divede by 0.15 to get +-30 deg rotation
        float xRotation = -verticalThrow * 25f + localy / -0.2f; //divede by 0.2 to get +-10 deg rotation


        transform.localRotation = Quaternion.Euler(xRotation, yRotation, -horizontalThrow * 30);
        transform.localPosition = new Vector3(localX, localy, transform.localPosition.z);
    }

    public void PlayerDead()
    {
        isAlive = false;
        deathVFX.SetActive(true);
    }

}
