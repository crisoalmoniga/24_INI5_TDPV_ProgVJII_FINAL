using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herir : MonoBehaviour
{
    // Variables a configurar desde el editor
    [Header("Configuracion")]
    [SerializeField] int puntos = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Jugador jugador = collision.gameObject.GetComponent<Jugador>();

            // Validación para asegurar que el componente Jugador no es null
            if (jugador != null)
            {
                jugador.ModificarVida(-puntos);
                Debug.Log("PUNTOS DE DAÑO REALIZADOS AL JUGADOR: " + puntos);

                // Opcional: Desactiva el objeto después de aplicar el daño
                gameObject.SetActive(false);
            }
            else
            {
                Debug.LogError("No se encontró el componente Jugador en el objeto de colisión.");
            }
        }
    }
}
