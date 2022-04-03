using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controlador : MonoBehaviour
{
    [Header("Timer")]
    public Timer timer;
    [Header("Transitions")]
    public Image transitionImage;
    public float transitionVelocity = 0.05f;
    public BackgroundEffects backgroundEffects;
    public LuzEffects luzEffects;
    public AudioSource sourceCalle;
    public AudioSource sourceInteraccion;
    public AudioClip audioFinalDia;

    public FamilyBehaviour[] family;

    public bool interactin = false;
    public GameObject canvasDay; 
    public GameObject[] canvasBar;

    //Gestion days
    private bool dayEnded;
    private int day;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        if(timer)
            timer.Reset();
        if(canvasDay)
            canvasDay.SetActive(false);
        StartCoroutine(StartTransition());
        day = 1;
    }
    
    
    private IEnumerator StartTransition()
    {
        if(timer)
            timer.isTransitioning = true;
        float alpha = 1.0f;
        while (transitionImage.color.a > 0.0f)
        {
            alpha -= transitionVelocity *Time.deltaTime;
            Color color = new Color(transitionImage.color.r, transitionImage.color.g, transitionImage.color.b, alpha);
            transitionImage.color = color;
            yield return null;
        }
        if(timer)
            timer.isTransitioning = false;
        yield return null;
    }

    private IEnumerator EndTransition()
    {
        if(timer)
            timer.isTransitioning = true;
        float alpha = 0.0f;
        while (transitionImage.color.a < 1.0f)
        {
            alpha += transitionVelocity *Time.deltaTime;
            Color color = new Color(transitionImage.color.r, transitionImage.color.g, transitionImage.color.b, alpha);
            transitionImage.color = color;
            yield return null;
        }
        if(timer)
            timer.isTransitioning = false;
        yield return null;
    }

    public IEnumerator DoAction(IntecteableObject obj)
    {
        interactin = true;
        yield return StartCoroutine(EndTransition());
        if(timer)
            timer.isTransitioning = true;
        timer.ApplyTimeLoss(obj.hoursToDo, obj.minutesToDo);
        if(obj.family)
            obj.familyMember.AddWill(obj.hoursToDo, obj.minutesToDo);
        if(obj.sound != null){
            sourceInteraccion.clip = obj.sound;
            sourceInteraccion.Play();
            yield return new WaitForSeconds(obj.sound.length);
        }
        
        yield return StartCoroutine(StartTransition());
        interactin = false;

        if(timer.hours < 0f){
            StartNewDay();
        }
    }
    
    public bool HasTime(IntecteableObject obj){
        if(timer.hours == obj.hoursToDo){
            if(timer.minutes < obj.minutesToDo){
                return false;
            }
        }
        else if(timer.hours < obj.hoursToDo){
            return false;
        }

        return true;
    }

    public void StartNewDay(){
        interactin = true;
        timer.isTransitioning = true;
        StartCoroutine(transiotionToNextDay());

    }

    private IEnumerator transiotionToNextDay()
    {
        timer.isTransitioning = true;
        if (canvasDay)
            canvasDay.SetActive(true);
        yield return null;
        backgroundEffects.enabled = false;
        luzEffects.enabled = false;
        sourceInteraccion.clip = null;
        sourceInteraccion.Stop();
        sourceCalle.clip = null;
        sourceCalle.Stop();
        sourceInteraccion.clip = audioFinalDia;
        sourceCalle.Play();
        for(int i = 0; i < 4; i++)
        {
            BarraBehaviour bh = canvasBar[i].GetComponent<BarraBehaviour>();
            float value = 0.0f;
            if(i != 0){
                Image imgPerfil = canvasBar[i].GetComponent<Image>();
                imgPerfil.sprite = family[i - 1].sprite;
                value =  family[i - 1].willToLive -  Mathf.Log(day) * 0.1f;
                family[i - 1].willToLive  = value;
            }
            else
            {

            }

            bh.UpdateBarraStatus();
        }
        yield return new WaitForSeconds(audioFinalDia.length);
        day++;
        interactin = false;
        timer.isTransitioning = false;
        if (canvasDay)
            canvasDay.SetActive(false);
        timer.Reset();
        luzEffects.enabled = true;
        backgroundEffects.enabled = true;
    }

}
