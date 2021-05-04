using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [Tooltip("Tiempo inical en Seg")]
    public int tiempoInicial;

    [Tooltip("Escala del tiempo del Reloj")]
    [Range(-10.0f, 10.0f)]
    public float escalaDeTiempo = 1;

    private Text myText;
    private float tiempoDelFrameConTimeScale = 0f;
    private float TiempoAMosES = 0f;
    private float escalaAlPausar, escalaInicial;
    public string textoDelReloj;




    private void Start()
    {
        escalaInicial = escalaDeTiempo;

        myText = GetComponent<Text>();

        TiempoAMosES = tiempoInicial;

        ActualizarReloj(tiempoInicial);
    }

    private void Update()
    {
        tiempoDelFrameConTimeScale = Time.deltaTime * escalaDeTiempo;

        TiempoAMosES += tiempoDelFrameConTimeScale;
        ActualizarReloj(TiempoAMosES);
        
    }
    public void ActualizarReloj(float tiempoEnSeg)
    {
        int min = 0;
        int seg = 0;

        if (tiempoEnSeg < 0) tiempoEnSeg = 0;

        min = (int)tiempoEnSeg / 60;
        seg = (int)tiempoEnSeg % 60;


        textoDelReloj = min.ToString("00") + ":" + seg.ToString("00");

        myText.text = textoDelReloj;
    }
}
