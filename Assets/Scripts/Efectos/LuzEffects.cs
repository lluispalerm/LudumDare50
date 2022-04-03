using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzEffects : MonoBehaviour
{
    [Header("GameObject")]
    public GameObject encendido;
    public GameObject apagado;
    [Header("Tiempos generales")]
    public float mediaSegundosEntreEfectos = 10.0f;
    public float variante = 2.5f;
    [Header("Tiempos para parpadeo")]
    public int parpadeosMaximos = 10;
    public int parpadeosAHacer = 0;
    public float mediaEntreParpadeos = 0.3f;
    public float varianteParpadeos = 0.2f;
    private int parpadeosActuales = 0;
    private bool estamosParpadeando = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LanzarLuz(Tiempo()));
    }

    private IEnumerator LanzarLuz(float tiempo)
    {
        Debug.Log("Siguiente parpadeo será lanzado en " + tiempo);
        if (tiempo is 50.0f)
        {
            yield return new WaitForSeconds(5.0f);
        }
        else
        {
            yield return new WaitForSeconds(tiempo);
            if (encendido.activeSelf)
            {
                encendido.SetActive(false);
                apagado.SetActive(true);
            }
            else
            {
                encendido.SetActive(true);
                apagado.SetActive(false);
            }
            if (!estamosParpadeando)
            {
                parpadeosAHacer = Random.Range(3, parpadeosMaximos+1);
                estamosParpadeando = true;
                parpadeosActuales = 0;

            }
            else
            {

                if (parpadeosActuales > parpadeosAHacer)
                    estamosParpadeando = false;
                else parpadeosActuales++;
            }
        }
        StartCoroutine(LanzarLuz(Tiempo()));

    }

    private float Tiempo()
    {
        int azar = 0;
        if (!estamosParpadeando)
            Random.Range(0, 3);
        else
            Random.Range(0, 2);
        float tiempo = 0.0f;
        switch (azar)
        {
            case 0:
                if (!estamosParpadeando)
                    tiempo = mediaSegundosEntreEfectos + Random.Range(0, variante + 1);
                else
                    tiempo = mediaEntreParpadeos + Random.Range(0, varianteParpadeos);
                break;
            case 1:
                if (!estamosParpadeando)
                    tiempo = mediaSegundosEntreEfectos - Random.Range(0, variante + 1);
                else
                    tiempo = mediaEntreParpadeos - Random.Range(0, varianteParpadeos);
                break;
            case 2:
                tiempo = 50.0f;
                break;
        }
        return tiempo;
    }
}
