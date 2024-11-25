using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HUDController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI miTexto;

    [SerializeField] GameObject iconoVida;
    [SerializeField] GameObject contenedorIconosVida;
    [SerializeField] GameObject menuConfig;

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
        menuConfig.SetActive(true);
    }

    private void Reanudar()
    {
        menuConfig.SetActive(false);
        ActualizarTextoHUD(GameManager.Instance.GetScore().ToString());
    }

    public void ActualizarTextoHUD(string nuevoTexto)
    {
        miTexto.text = nuevoTexto;
    }

    public void ActualizarVidasHUD(int vidas)
    {
        Debug.Log($"ActualizarVidasHUD llamado con vidas: {vidas}");

        if (vidas <= 0)
        {
            Debug.Log("Vidas agotadas. Regresando a la pantalla de inicio.");
            SceneManager.LoadScene("Portada");
            return;
        }

        if (EstaVacioContenedor())
        {
            CargarContenedor(vidas);
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
        if (cantidadIconos <= 0) return;

        for (int i = 0; i < cantidadIconos; i++)
        {
            CrearIcono();
        }
    }

    private void CrearIcono()
    {
        Instantiate(iconoVida, contenedorIconosVida.transform);
    }
}
