using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollHoloUI : MonoBehaviour
{
    [Header("Objeto")]
    private GameObject canvasSelector,objeto,btLeft,btRight;

    [Header("Objetos para instanciar")]
    public List<GameObject> objetosUI = new List<GameObject>();

    [Header("Botões do menu")]
    public Button buttonLeft, buttonRight;

    [Header("Quantidade de objetos")]
    public int quantidadeDeObjetos = 0, atual = 0;

    private bool incremento = false, inicio = true;

    public static ScrollHoloUI scrollHoloUi;

    [SerializeField]
    private Vector3 centro;
       
    public Image right, left;

    public void Awake()
    {
        canvasSelector = gameObject;
        buttonRight.interactable = false;
    }
   
    public void Start()
    {
        objeto = objetosUI[atual];
        scrollHoloUi = this;
    }
    
    public void LeftButton() => StartCoroutine(AplyLerpLeft());

    public void RightButton() => StartCoroutine(AplyLerpRight());
    
    IEnumerator AplyLerpLeft()
    {
        if (atual != objetosUI.Count-1)
        {
            float x = objeto.transform.position.x;

            float t = 0;

            if(inicio)
            {
                centro = objeto.transform.position;
                inicio = false;
            }
              
            Vector3 posicao_atual = objeto.transform.position;
       
            Vector3 posicao_destino = new Vector3(x-1f,objeto.transform.position.y, objeto.transform.position.z);

            while (t < 1)
            {
                t += Time.deltaTime;
                objeto.transform.position = Vector3.Lerp(posicao_atual, posicao_destino, Mathf.SmoothStep(0f, 1f, t / 1));
                yield return null;
            }
     
            atual += 1;
            objeto = objetosUI[atual];

            x = objeto.transform.position.x;

            t = 0;

            posicao_atual = objeto.transform.position;

            posicao_destino = new Vector3(x - 1f, objeto.transform.position.y, objeto.transform.position.z);

            if(atual > 0) buttonRight.interactable = true;

            while (t < 1)
            {
                t += Time.deltaTime;
                objeto.transform.position = Vector3.Lerp(posicao_atual, centro, Mathf.SmoothStep(0f, 1f, t / 1));
                yield return null;
            }
        }
        else
        {
            buttonLeft.interactable = false;
        }           
    }
    
    IEnumerator AplyLerpRight()
    {
        if (atual != 0)
        {
            float x = objeto.transform.position.x;

            float t = 0;

            Vector3 posicao_atual = objeto.transform.position;

            Vector3 posicao_destino = new Vector3(x + 1f, objeto.transform.position.y, objeto.transform.position.z);

            while (t < 1)
            {
                t += Time.deltaTime;
                objeto.transform.position = Vector3.Lerp(posicao_atual, posicao_destino, Mathf.SmoothStep(0f, 1f, t / 1));
                yield return null;
            }
       
            atual -= 1;

            objeto = objetosUI[atual];

            x = objeto.transform.position.x;

            t = 0;

            posicao_atual = objeto.transform.position;

            posicao_destino = new Vector3(x - 1f, objeto.transform.position.y, objeto.transform.position.z);

            if(atual == 0) buttonLeft.interactable = true; buttonRight.interactable = false;

            while (t < 1)
            {
                t += Time.deltaTime;
                objeto.transform.position = Vector3.Lerp(posicao_atual, centro, Mathf.SmoothStep(0f, 1f, t / 1));
                yield return null;
            }
        }
        else
        {
            buttonRight.interactable = false;
        }
    }
   
    public int RetornarIndexDaMaquina()
    {
        return atual;
    }
}
