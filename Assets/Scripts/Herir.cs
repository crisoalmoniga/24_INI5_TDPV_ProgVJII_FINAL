using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herir : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] int puntos = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Jugador jugador = collision.gameObject.GetComponent<Jugador>();

            if (jugador != null)
            {
                jugador.ModificarVida(-puntos);
                Debug.Log("PUNTOS DE DAÑO REALIZADOS AL JUGADOR: " + puntos);

                gameObject.SetActive(false);
            }
            else
            {
                Debug.LogError("No se encontró el componente Jugador en el objeto de colisión.");
            }
        }
    }
}
