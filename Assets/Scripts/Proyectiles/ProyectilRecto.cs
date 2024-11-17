using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilRecto : Proyectil
{
    [SerializeField]
    private float fuerza = 10f; // Fuerza ajustable desde el Inspector

    protected override void Mover()
    {
        // Establece la dirección del proyectil (por ejemplo, hacia la izquierda en X)
        Vector2 direction = Vector2.left;
        // Aplica la fuerza al Rigidbody multiplicada por la dirección y la velocidad base
        rb.velocity = direction * fuerza;
    }
}
