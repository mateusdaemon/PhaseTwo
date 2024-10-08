using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour, ICollectible
{
    private GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void Collect()
    {
        gameManager.AddPoints(1);
        Destroy(gameObject);
    }
}
