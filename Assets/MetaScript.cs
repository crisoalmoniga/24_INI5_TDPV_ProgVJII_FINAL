using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto que colisiona es el jugador
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Llegaste a la meta. Ganaste!");
            GameManager.Instance.GanarJuego();
        }
    }
}
