using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilParabolico : Proyectil
{
    [SerializeField]
    [Range(0f, 90f)]
    private float launchAngle = 45f; // Ángulo de lanzamiento en grados

    [SerializeField]
    private float fuerzaLanzamiento = 10f; // Fuerza de lanzamiento ajustable desde el Inspector

    protected override void Mover()
    {
        // Convierte el ángulo de lanzamiento de grados a radianes
        float launchAngleInRadians = launchAngle * Mathf.Deg2Rad;

        // Calcula la velocidad inicial usando el ángulo y la fuerza de lanzamiento
        Vector2 launchVelocity = new Vector2(
            Mathf.Cos(launchAngleInRadians) * fuerzaLanzamiento,
            Mathf.Sin(launchAngleInRadians) * fuerzaLanzamiento
        );

        // Aplica la velocidad inicial al Rigidbody del proyectil
        rb.velocity = launchVelocity;
    }
}
