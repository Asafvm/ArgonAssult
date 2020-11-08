using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;
    [SerializeField] int points = 50;

    BoxCollider collider;
    // Start is called before the first frame update
    void Start()
    {
        collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = false;
    }


    private void OnParticleCollision(GameObject other)
    {
        GameObject g = Instantiate(deathVFX, transform.position, Quaternion.identity);
        g.transform.parent = parent.transform;
        FindObjectOfType<ScoreBoard>().AddScore(points);
        Destroy(gameObject);

    }
}
