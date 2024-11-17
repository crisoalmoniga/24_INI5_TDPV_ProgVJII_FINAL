using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private int poolSize = 5;
    [SerializeField] private float tiempoDeVida = 3f; // Tiempo en segundos antes de desactivar automáticamente los objetos

    private List<GameObject> pooledObjects;

    void Start()
    {
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(objectPrefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        foreach (GameObject obj in pooledObjects)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true); // Activar el objeto
                StartCoroutine(DesactivarDespuesDeTiempo(obj, tiempoDeVida)); // Iniciar temporizador
                return obj;
            }
        }

        return null;
    }

    private IEnumerator DesactivarDespuesDeTiempo(GameObject obj, float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        obj.SetActive(false); // Desactivar el objeto después del tiempo de vida
    }
}
