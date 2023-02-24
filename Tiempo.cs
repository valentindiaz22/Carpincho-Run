using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tiempo : MonoBehaviour
{
    public Text TimerText;
    float timer;
    void Update()
    {
        timer += Time.deltaTime;
        TimerText.text = timer + " segundos";
    }
}
