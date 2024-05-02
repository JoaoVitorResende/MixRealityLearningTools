using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelecaoDePeca : MonoBehaviour
{
    private ControlaSeguimentoDeAtividade controller;

    private void Start() => controller = GameObject.Find("Controller").GetComponent<ControlaSeguimentoDeAtividade>();

    public void PecaSelecionada(string nomeDaPeca)
    { 
        controller.RecebeSeguimento(nomeDaPeca);
        gameObject.GetComponent<Button>().interactable = false;
    }

    public void NumeroDapeca(int numero) => TutorialUI.instancia.AtivarAnimacaoPecaAtiva(numero);
   
}
