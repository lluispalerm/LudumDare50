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
    public Transform fondo;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MostrarMuertos());
    }
    void Update()
    {
        fondo.localScale -= new Vector3(0.001f,0.001f,0.001f);
    }

    private IEnumerator MostrarMuertos()
    {
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
        
        yield return controlador.StartCoroutine("StartTransition");

        yield return new WaitForSeconds(5.0f);
        yield return controlador.StartCoroutine("EndTransition");
        SceneManager.LoadScene("Start");
    }
}
