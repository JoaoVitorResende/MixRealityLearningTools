using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaRetornoDaCenaUI : MonoBehaviour
{
    public static GameObject canvasMenuDeEscolha;

    public static GameObject maquinaEscolhida;

    public static void RecebeCanvas(GameObject canvas)
    {
        canvasMenuDeEscolha = canvas;
    }

    public static void AtivarCanvas()
    {
        Destroy(maquinaEscolhida);
        canvasMenuDeEscolha.SetActive(true);
    }

    public static void DesativarCanvas()
    {
        canvasMenuDeEscolha.SetActive(false);
    }

    public static void ReceberMaquinaEscolhida(GameObject maquina)
    {
        maquinaEscolhida = maquina;
    }
}