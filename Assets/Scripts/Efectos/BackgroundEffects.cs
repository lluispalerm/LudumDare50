using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundEffects : MonoBehaviour
{
    public AudioSource source;
    public List<AudioClip> clips = new List<AudioClip>();
    public float mediaSegundosEntreEfectos = 10.0f;
    public float variante = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LanzarSonido(Tiempo()));
    }

    private IEnumerator LanzarSonido(float tiempo)
    {
        Debug.Log("Siguiente sonido será lanzado en " + tiempo);
        if (tiempo is 50.0f)
        {
            yield return new WaitForSeconds(5.0f);
        }
        else
        {
            yield return new WaitForSeconds(tiempo);
            if (source != null)
            {
                source.clip = clips[Random.Range(0, clips.Count)];
                source.Play();
                yield return new WaitForSeconds(source.clip.length);
            }
        }
        StartCoroutine(LanzarSonido(Tiempo()));

    }

    private float Tiempo()
    {
        int azar = Random.Range(0, 3);
        float tiempo = 0.0f;
        switch (azar)
        {
            case 0:
                tiempo = mediaSegundosEntreEfectos + Random.Range(0, variante + 1);
                break;
            case 1:
                tiempo = mediaSegundosEntreEfectos - Random.Range(0, variante + 1);
                break;
            case 2:
                tiempo = 50.0f;
                break;
        }
        return tiempo;
    }
    private void OnEnable()
    {
        Start();    
    }
}
