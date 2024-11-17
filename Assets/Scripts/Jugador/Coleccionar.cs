using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coleccionar : MonoBehaviour
{
    [SerializeField] private List<GameObject> coleccionables;
    [SerializeField] private GameObject bolsa;

    private bool presionado = false;

    private void Awake()
    {
        coleccionables = new List<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Coleccionable")) { return; }
                
        GameObject nuevoColeccionable = collision.gameObject;
        nuevoColeccionable.SetActive(false);

        coleccionables.Add(nuevoColeccionable);
        nuevoColeccionable.transform.SetParent(bolsa.transform);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (coleccionables.Count == 0) return;

            presionado = !presionado;
            coleccionables[0].SetActive(presionado);
        }
    }
}
