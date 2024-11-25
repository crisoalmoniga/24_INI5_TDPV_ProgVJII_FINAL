using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saltar : MonoBehaviour
{
    private Jugador jugador;

    private bool puedoSaltar = true;
    private bool saltando = false;

    private Rigidbody2D miRigidbody2D;
    private AudioSource miAudioSource;

    [SerializeField] private LayerMask capaPisos; // Asegúrate de asignar "Pisos" en el Inspector

    private void Awake()
    {
        jugador = GetComponent<Jugador>();
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && puedoSaltar)
        {
            puedoSaltar = false;

            if (miAudioSource != null && jugador.PerfilJugador.JumpSFX != null)
            {
                miAudioSource.PlayOneShot(jugador.PerfilJugador.JumpSFX);
            }
        }
    }

    private void FixedUpdate()
    {
        if (!puedoSaltar && !saltando)
        {
            miRigidbody2D.velocity = new Vector2(miRigidbody2D.velocity.x, 0); // Resetea velocidad vertical
            miRigidbody2D.AddForce(Vector2.up * jugador.PerfilJugador.FuerzaSalto, ForceMode2D.Impulse);
            saltando = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si colisiona con un objeto en la capa "Pisos"
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pisos"))
        {
            puedoSaltar = true;
            saltando = false;

            if (miAudioSource != null && jugador.PerfilJugador.CollisionSFX != null)
            {
                miAudioSource.PlayOneShot(jugador.PerfilJugador.CollisionSFX);
            }
        }
    }
}
