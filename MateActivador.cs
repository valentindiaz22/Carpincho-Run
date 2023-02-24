using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MateActivador : MonoBehaviour
{
    [SerializeField] private GameObject mateActivador;
    private void OnTriggerEnter2D()
    {
        mateActivador.SetActive(true);
    }
}
