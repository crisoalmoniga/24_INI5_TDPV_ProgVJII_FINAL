using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI miTexto;

    [SerializeField] GameObject iconoVida;
    [SerializeField] GameObject contenedorIconosVida;


    private void OnEnable()
    {
        GameEvents.OnPause += Pausar;
        GameEvents.OnResume += Reanudar;
    }

    private void OnDisable()
    {
        GameEvents.OnPause -= Pausar;
        GameEvents.OnResume -= Reanudar;
    }

    private void Pausar()
    {

        ActualizarTextoHUD("PAUSADO");
    }

    private void Reanudar()
    {
        ActualizarTextoHUD(GameManager.Instance.GetScore().ToString());

    }

    public void ActualizarTextoHUD(string nuevoTexto)
    {
        Debug.Log("SE LLAMA " + nuevoTexto);
        miTexto.text = nuevoTexto;
    }

    public void ActualizarVidasHUD(int vidas)
    {
        Debug.Log("Llamada a ActualizarVidasHUD con " + vidas + " vidas.");
        if (EstaVacioContenedor())
        {
            CargarContenedor(vidas);
            Debug.Log("Cantidad de iconos tras cargar: " + CantidadIconosVidas());
            return;
        }

        if (CantidadIconosVidas() > vidas)
        {
            EliminarUltimoIcono();
        }
        else
        {
            CrearIcono();
        }
        Debug.Log("Cantidad de iconos tras actualización: " + CantidadIconosVidas());
    }

    private bool EstaVacioContenedor()
    {
        return contenedorIconosVida.transform.childCount == 0;
    }

    private int CantidadIconosVidas()
    {
        return contenedorIconosVida.transform.childCount;
    }

    private void EliminarUltimoIcono()
    {
        Transform contenedor = contenedorIconosVida.transform;
        GameObject.Destroy(contenedor.GetChild(contenedor.childCount - 1).gameObject);
    }

    private void CargarContenedor(int cantidadIconos)
    {
        for (int i = 0; i < cantidadIconos; i++)
        {
            CrearIcono();
        }
    }

    private void CrearIcono()
    {
        Debug.Log("Instanciando un nuevo icono de vida");
        Instantiate(iconoVida, contenedorIconosVida.transform);    
    }
}

