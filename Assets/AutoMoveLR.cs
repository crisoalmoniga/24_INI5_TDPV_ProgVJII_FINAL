using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoveLR : MonoBehaviour
{
    [SerializeField] private float velocidad = 2f; // Velocidad del movimiento
    [SerializeField] private float distanciaMovimiento = 5f; // Distancia máxima hacia la izquierda/derecha

    private Vector3 posicionInicial; // Posición inicial del GameObject
    private int direccion = 1; // Dirección del movimiento: 1 para derecha, -1 para izquierda

    private void Start()
    {
        // Guarda la posición inicial del GameObject
        posicionInicial = transform.position;
    }

    private void Update()
    {
        // Calcula el nuevo movimiento en base a la dirección y la velocidad
        transform.Translate(Vector3.right * direccion * velocidad * Time.deltaTime);

        // Verifica si el objeto ha alcanzado los límites definidos por la distancia de movimiento
        if (Vector3.Distance(posicionInicial, transform.position) >= distanciaMovimiento)
        {
            direccion *= -1; // Cambia la dirección al alcanzar el límite
        }
    }
}
