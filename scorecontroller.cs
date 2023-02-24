using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scorecontroller : MonoBehaviour
{
    [SerializeField] private GameObject MenuFinal;

    public static scorecontroller controller;

    public int score = 0;


    void Start()
    {
        controller = this;
    }

    public void RaiseScore(int s)
    {
        score += s;
        if (score == 5){
            MenuFinal.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    
}
