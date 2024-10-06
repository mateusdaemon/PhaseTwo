using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    private HudManager hudManager;
    public event Action OnPlayBtn;
    public event Action OnReturnBtn;

    // Start is called before the first frame update
    void Start()
    {
        hudManager = GetComponent<HudManager>();
        hudManager.playBtn.onClick.AddListener(HandlePlay);
        hudManager.returnBtn.onClick.AddListener(HandleReturn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void HandlePlay()
    {
        OnPlayBtn.Invoke();
    }

    private void HandleReturn()
    {
        OnReturnBtn.Invoke();
    }
}
