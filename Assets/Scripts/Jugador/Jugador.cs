using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Jugador : MonoBehaviour
{
    [SerializeField]
    private PerfilJugador perfilJugador;
    public PerfilJugador PerfilJugador { get => perfilJugador; }

    [SerializeField]
    private int vidasIniciales = 5; // Este valor se puede ajustar en el Inspector para definir las vidas iniciales del jugador

    //---------- Eventos del Jugador ----------//

    [SerializeField]
    private UnityEvent<int> OnLivesChanged;

    [SerializeField]
    private UnityEvent<string> OnTextChanged;

    private void Start()
    {
        //perfilJugador.Vida = vidasIniciales; // Inicializamos la vida del jugador con el valor de vidasIniciales
        OnLivesChanged.Invoke(perfilJugador.Vida);
        OnTextChanged.Invoke(GameManager.Instance.GetScore().ToString());
    }

    public void ModificarVida(int puntos)
    {
        perfilJugador.Vida += puntos;

        // Aseguramos que la vida no baje de 0 ni supere el valor de vidasIniciales
        //perfilJugador.Vida = Mathf.Clamp(perfilJugador.Vida, 0, vidasIniciales);
        GameManager.Instance.AddScore(puntos * 100);
        OnTextChanged.Invoke(GameManager.Instance.GetScore().ToString());
        OnLivesChanged.Invoke(perfilJugador.Vida);
        Debug.Log(EstasVivo());
    }

    private bool EstasVivo()
    {
        return perfilJugador.Vida > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Meta")) { return; }

        Debug.Log("GANASTE");
    }
}
