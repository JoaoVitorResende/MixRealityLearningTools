using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity;

public class ManualUI : MonoBehaviour
{
    [SerializeField] GameObject canvasManualDasMaquina;

    [SerializeField] private List<GameObject> paginas = new List<GameObject>();

    [SerializeField] private Billboard bill;

    private int atual = 0;

    private bool isInstanciado = false;
    
    public void ChangePageRight() => StartCoroutine(AplyLerpRight());

    public void ChangePageLeft() => StartCoroutine(AplyLerpLeft());

    public void RemoverManual()
    {
        MaquinaIndustrial.instancia.ManualRemovido();
        isInstanciado = false;
    }

    IEnumerator AplyLerpLeft()
    {

        bill.enabled = false;

        if (atual != paginas.Count-1)
        {
            float x = paginas[atual].transform.position.x;

            float y = paginas[atual].transform.position.y;

            float z = paginas[atual].transform.position.z;

            float t = 0;

            Vector3 posicao_atual = paginas[atual].transform.position;

            Quaternion rotacaoAtual = paginas[atual].transform.rotation;

            Debug.Log("posicao atual " + posicao_atual);

            Vector3 posicao_destino = new Vector3(x - 2, paginas[atual].transform.position.y, paginas[atual].transform.position.z);

            while (t < 2)
            {
                t += Time.deltaTime;

                paginas[atual].transform.position = Vector3.Lerp(posicao_atual, posicao_destino, Mathf.SmoothStep(0f, 1f, t / 1));

                yield return null;
            }

            atual += 1;

            GameObject objeto = paginas[atual];

            t = 0;

            posicao_atual = objeto.transform.position;

            posicao_destino = new Vector3(x,y,z);

            objeto.transform.rotation = rotacaoAtual;

            while (t < 2)
            {
                t += Time.deltaTime;
                objeto.transform.position = Vector3.Lerp(posicao_atual, posicao_destino, Mathf.SmoothStep(0f, 1f, t / 1));
                yield return null;
            }

            x = objeto.transform.position.x;
            y = objeto.transform.position.y;
            z = objeto.transform.position.z;

            bill.enabled = true;
        }
        else
        {
            bill.enabled = true;
            Debug.Log("está caindo no else");
        }
    }

    IEnumerator AplyLerpRight()
    {
        bill.enabled = false;

        if (atual != 0)
        {
            float x = paginas[atual].transform.position.x;

            float y = paginas[atual].transform.position.y;

            float z = paginas[atual].transform.position.z;

            float t = 0;

            Vector3 posicao_atual = paginas[atual].transform.position;

            Quaternion rotacaoAtual = paginas[atual].transform.rotation;

            Debug.Log("posicao atual " + posicao_atual);

            Vector3 posicao_destino = new Vector3(x + 2, paginas[atual].transform.position.y, paginas[atual].transform.position.z);

            while (t < 2)
            {
                t += Time.deltaTime;

                paginas[atual].transform.position = Vector3.Lerp(posicao_atual, posicao_destino, Mathf.SmoothStep(0f, 1f, t / 1));

                yield return null;
            }

            atual -= 1;

            GameObject objeto = paginas[atual];

            t = 0;

            posicao_atual = objeto.transform.position;

            posicao_destino = new Vector3(x,y,z);

            objeto.transform.rotation = rotacaoAtual;

            while (t < 2)
            {
                t += Time.deltaTime;
                objeto.transform.position = Vector3.Lerp(posicao_atual, posicao_destino, Mathf.SmoothStep(0f, 1f, t / 1));
                yield return null;
            }

            x = objeto.transform.position.x;
            y = objeto.transform.position.y;
            z = objeto.transform.position.z;

            bill.enabled = true;
        }
        else
        {
            bill.enabled = true;
            Debug.Log("está caindo no else");
        }
    }
}
