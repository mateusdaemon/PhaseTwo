using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollect : MonoBehaviour, ICollectible
{
    private GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void Collect()
    {
        gameManager.AddPoints(5);
        Destroy(gameObject);
    }
}
