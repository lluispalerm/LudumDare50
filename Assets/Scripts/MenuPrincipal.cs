using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuPrincipal : MonoBehaviour
{
    public Controlador controlador;
    public List<GameObject> botones = new List<GameObject>();
    public GameObject flechaDer;
    public GameObject flechaIzq;
    private int botonActivo = 0;
    // Start is called before the first frame update
    void Start()
    {
        controlador.StartCoroutine("StartTransition");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StartCoroutine(FlashObject(flechaIzq));
            botonActivo--;
            if (botonActivo < 0)
                botonActivo = botones.Count - 1;
            SwitchCurrentOption();
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            StartCoroutine(FlashObject(flechaDer));
            botonActivo++;
            if (botonActivo > botones.Count - 1)
                botonActivo = 0;
            SwitchCurrentOption();
        }
        else if (Input.GetKeyDown("space"))
        {
            StartCoroutine(Interact());
        }
    }

    private IEnumerator Interact()
    {
        yield return controlador.StartCoroutine("EndTransition");
        switch (botonActivo)
        {
            case 0:
                SceneManager.LoadScene("House");
                break;
            case 1:
                SceneManager.LoadScene("Credits");
                break;
            case 2:
                break;
        }
    }

    private void SwitchCurrentOption()
    {
        int i = -1;
        foreach(GameObject t in botones)
        {
            i++;
            if (i == botonActivo)
                t.SetActive(true);
            else
                t.SetActive(false);
        }
    }

    private IEnumerator FlashObject(GameObject t)
    {
        t.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        t.SetActive(true);
    }
}
