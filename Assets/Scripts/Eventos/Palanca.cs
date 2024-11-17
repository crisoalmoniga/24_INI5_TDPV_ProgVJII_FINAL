using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Palanca : MonoBehaviour
{
    [SerializeField] private UnityEvent OnPalancaTriggered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Algo ha colisionado con la palanca"); // Mensaje para confirmar cualquier colisión con el trigger

        if (collision.CompareTag("Player"))
        {
            Debug.Log("El jugador ha activado la palanca"); // Mensaje para confirmar que el jugador ha activado la palanca
            OnPalancaTriggered.Invoke();
        }
        else
        {
            Debug.Log("La colisión no es con el jugador"); // Mensaje para otros objetos que podrían colisionar
        }
    }
}