using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaSeguimentoDeAtividade : MonoBehaviour
{
    private List<string> resposta = new List<string>();

    [HideInInspector] public int quantidade;

    public bool respondido;

    public bool isFressadoura = false;

    public void RecebeSeguimento(string click)
    {
        Debug.Log(click);

        if(isFressadoura)
        {
            if (quantidade <= 5)
            {
                resposta.Add(click);
                quantidade++;
            }
        }
        else
        {
            if (quantidade <= 4)
            {
                resposta.Add(click);
                quantidade++;
            }
        }
    }

    public void TipoDeAtividadeIndustrial(bool vl) => isFressadoura = vl;

    private void FixedUpdate()
    {
        if(isFressadoura)
        {
            if (quantidade == 5)
            {
                respondido = true;

                quantidade = 0;

                TutorialUI.instancia.DesativarAtividade();
            }
        }
        else
        {
            if (quantidade == 4)
            {
                respondido = true;

                quantidade = 0;

                TutorialUI.instancia.DesativarAtividade();
            }
        }
    }

    public List<string> EnviarResposta(){return resposta;}

    public void LimparLista() => resposta.Clear();

}
