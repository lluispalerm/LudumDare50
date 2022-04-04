using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FamiliaMuerta : MonoBehaviour
{
    public Controlador controlador;
    public GameObject pareja;
    public GameObject abuelo;
    public GameObject ninia;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MostrarMuertos());
    }
    void Update()
    {
        Camera.main.orthographicSize -= 0.0005f;
    }

    private IEnumerator MostrarMuertos()
    {
        yield return controlador.StartCoroutine("StartTransition");
        if (PlayerPrefs.GetInt("familia_1", 1) is 0)
        {
            pareja.SetActive(false);
        }
        if (PlayerPrefs.GetInt("familia_2", 1) is 0)
        {
            abuelo.SetActive(false);
        }
        if (PlayerPrefs.GetInt("familia_3", 1) is 0)
        {
            ninia.SetActive(false);
        }
        yield return new WaitForSeconds(5.0f);
        yield return controlador.StartCoroutine("EndTransition");
        SceneManager.LoadScene("Start");
    }
}
