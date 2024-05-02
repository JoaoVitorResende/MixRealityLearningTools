using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtividadeUI : MonoBehaviour
{
    private List<string> resposta = new List<string>();

    private ControlaSeguimentoDeAtividade controller;

    public List<string> primeiroGabarito = new List<string>();

    public List<string> segundoGabarito = new List<string>();

    private CanvasGroup acertoCanvas;

    public static AtividadeUI instancia;

    private CanvasGroup erroCanvas;

    private TutorialUI tutorial;

    private void Start()
    {
        controller = GameObject.Find("Controller").GetComponent<ControlaSeguimentoDeAtividade>();
        acertoCanvas = GameObject.Find("CanvasAcerto").GetComponent<CanvasGroup>();
        erroCanvas = GameObject.Find("CanvasErro").GetComponent<CanvasGroup>();

        if(gameObject.name.Equals("AtividadeFressadoura(Clone)") || gameObject.name.Equals("AtividadeFressadoura2(Clone)"))
        {
            tutorial = GameObject.Find("Fressadoura final(Clone)").GetComponent<TutorialUI>();
            controller.TipoDeAtividadeIndustrial(true);
        }
        else
        {
            tutorial = GameObject.Find("TornoMecanico(Clone)").GetComponent<TutorialUI>();
            controller.TipoDeAtividadeIndustrial(false);
        }

        instancia = this;
    } 
   
    private void FixedUpdate()
    {
        if(controller.respondido && controller.isFressadoura)
        {
            Debug.Log("teste");
            resposta.AddRange(controller.EnviarResposta());
            controller.respondido = false;
            RevisarAtividadeFressadoura();
        }

        if (controller.respondido && !controller.isFressadoura)
        {
            Debug.Log("teste");
            resposta.AddRange(controller.EnviarResposta());
            controller.respondido = false;
            RevisarAtividadeTorno();
        }
    }

    private void RevisarAtividadeFressadoura()
    {
        Debug.Log("quantidade no array resposta"+resposta.Count);

        int c = 0;

        Debug.Log("qual ativade está sendo corrigida " + TutorialUI.instancia.atividade);

       if(tutorial.atividade == 0)
       {
            Debug.Log("entrou na atividade 1");

            foreach(string r in resposta)
            {
                if (r.Equals(primeiroGabarito[c]))
                    c++;
            }

            Debug.Log(c);

            if (c == 5)
            {
                acertoCanvas.alpha = 1;
                acertoCanvas.interactable = true;
                acertoCanvas.blocksRaycasts = true;
            }
            else
            {
                erroCanvas.alpha = 1;
                erroCanvas.interactable = true;
                erroCanvas.blocksRaycasts = true;
            }
       }
       else
       {
            Debug.Log("entrou na atividade 2");

            foreach (string r in resposta)
            {
                if (r.Equals(segundoGabarito[c]))
                    c++;
            }

            if (c == 5)
            {
                acertoCanvas.alpha = 1;
                acertoCanvas.interactable = true;
                acertoCanvas.blocksRaycasts = true;
            }
            else
            {
                erroCanvas.alpha = 1;
                erroCanvas.interactable = true;
                erroCanvas.blocksRaycasts = true;
            }
       }
    }

    private void RevisarAtividadeTorno()
    {
        Debug.Log("quantidade no array resposta" + resposta.Count);

        int c = 0;

        Debug.Log("qual ativade está sendo corrigida " + TutorialUI.instancia.atividade);

        if (tutorial.atividade == 0)
        {
            Debug.Log("entrou na atividade 1");

            foreach (string r in resposta)
            {
                Debug.Log(r + " comparada com " + primeiroGabarito[c]);
                if (r.Equals(primeiroGabarito[c]))
                    c++;
            }

            Debug.Log(c);

            if (c == 4)
            {
                acertoCanvas.alpha = 1;
                acertoCanvas.interactable = true;
                acertoCanvas.blocksRaycasts = true;
            }
            else
            {
                erroCanvas.alpha = 1;
                erroCanvas.interactable = true;
                erroCanvas.blocksRaycasts = true;
            }
        }
        else
        {
            Debug.Log("entrou na atividade 2");

            foreach (string r in resposta)
            {
                Debug.Log(r + " comparada com " + segundoGabarito[c]);

                if (r.Equals(segundoGabarito[c]))
                    c++;
            }

            Debug.Log(c);

            if (c == 4)
            {
                acertoCanvas.alpha = 1;
                acertoCanvas.interactable = true;
                acertoCanvas.blocksRaycasts = true;
            }
            else
            {
                erroCanvas.alpha = 1;
                erroCanvas.interactable = true;
                erroCanvas.blocksRaycasts = true;
            }
        }
    }

    public void DesistirAtividade(){tutorial.DesativarAtividade(); controller.quantidade = 0; resposta.Clear(); controller.LimparLista(); Destroy(gameObject);}
}
