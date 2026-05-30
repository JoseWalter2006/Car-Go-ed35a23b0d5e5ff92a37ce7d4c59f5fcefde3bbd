using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorSom : MonoBehaviour
{
   [SerializeField] private AudioSource FundoMusica;

    public void VolumeMusica(float value)
    {
        FundoMusica.volume = value;
    }
}
