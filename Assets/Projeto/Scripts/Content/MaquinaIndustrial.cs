using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity.UX;

public class MaquinaIndustrial : MonoBehaviour
{
    [SerializeField] private BoundingBoxRig bbr;

    [SerializeField] private GameObject manual;

    private GameObject referenciaManual;

    private bool movimentar = false;

    private GameObject boundingbox;

    private bool isInstanciado = false;

    public static MaquinaIndustrial instancia;

    private void Start()
    {
        bbr.enabled = false;
        bbr.GetComponent<BoundingBoxRig>().Start();
        boundingbox = GameObject.Find("BoundingBoxBasic(Clone)");
        instancia = this;
    }

    public void Movimentar()
    {
        movimentar = !movimentar;
        GetComponent<HandDraggable>().enabled = movimentar;
    }
   
    public void Rotacionar()
    {
        if (bbr.enabled == false)
        {
            bbr.enabled = true;
            bbr.GetComponent<BoundingBoxRig>().Activate();
            boundingbox.SetActive(true);
        }
        else
        {
            bbr.enabled = false;
            bbr.GetComponent<BoundingBoxRig>().Deactivate();
            boundingbox.SetActive(false);
        }
    }
    
    public void Tutorial(){GetComponent<TutorialUI>().IniciarTutorial();}
    
    public void Atividade(){GetComponent<TutorialUI>().IniciarAtividade(GetComponent<TutorialUI>().SortearAtividade());}
    
    public void Manual()
    {
        if (!isInstanciado)
        {
            referenciaManual = Instantiate(manual, manual.transform.position, manual.transform.rotation);

            isInstanciado = true;
        }
    }
    
    public void Focalizar(){Camera.main.GetComponent<Focalizador>().IniciarFocalizacao();}

    public void Retornar()
    {
        ControlaRetornoDaCenaUI.AtivarCanvas();
        Focalizador.focalizador.LimparListas();
        Destroy(boundingbox);
    }

    public void ManualRemovido()
    {
        isInstanciado = false;
        Destroy(referenciaManual);
    }

}
