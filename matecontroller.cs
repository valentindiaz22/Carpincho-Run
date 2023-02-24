using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matecontroller : MonoBehaviour
{
    public AudioClip matesuli;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        scorecontroller.controller.RaiseScore(1);
        AudioSource.PlayClipAtPoint(matesuli, transform.position);
        Destroy(gameObject);
        

    }
    
}
