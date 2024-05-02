using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using cakeslice;


public class Focalizador : MonoBehaviour
{
    [SerializeField] private List<cakeslice.Outline> scriptsLocaisFressadoura = new List<cakeslice.Outline>();

    private List<GameObject> toolTips = new List<GameObject>();

    private bool iniciar = false;

    private GameObject [] objetosDaFressadoura;

    private GameObject[] objetosToolTip;

    private GameObject atual;

    private GameObject toolTipAtual;

    private TMP_Text textoDaToolTip;   

    public static Focalizador focalizador;

    private void Start() => focalizador = this;
    
    public void IniciarFocalizacao() => iniciar = !iniciar;

    public void PreencherListas()
    {
        objetosDaFressadoura = GameObject.FindGameObjectsWithTag("outline");

        objetosToolTip = GameObject.FindGameObjectsWithTag("tooltip");

        toolTips.AddRange(objetosToolTip);

        foreach (GameObject g in objetosDaFressadoura)
        {
            scriptsLocaisFressadoura.Add(g.GetComponent<cakeslice.Outline>());
        }

        foreach(cakeslice.Outline o in scriptsLocaisFressadoura)
        {
            if (o != null)
            {
                o.enabled = false;
            }
        }

        foreach(GameObject g in toolTips)
        {
            g.SetActive(false);
        }
    }

    public void Update()
    {
        if (iniciar)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                if(hit.transform.gameObject != atual && atual != null)
                {
                    atual.GetComponent<cakeslice.Outline>().enabled = false;
                    atual = null;
                    toolTipAtual.SetActive(false);
                    toolTipAtual = null;
                }

                if (hit.transform.gameObject.GetComponent<cakeslice.Outline>())
                {
                    atual = hit.transform.gameObject;
                    atual.GetComponent<cakeslice.Outline>().enabled = true;
                }

                if (toolTipAtual == null && atual != null)
                {
                    GameObject toolTip = null;

                    foreach(GameObject g in toolTips)
                    {
                        if(g.name.Equals(hit.transform.gameObject.name))
                        {
                            Debug.Log("lista " + g.name + " objeto apontado " + hit.transform.gameObject.name);
                            toolTip = g;
                            toolTipAtual = toolTip;
                        }
                    }

                    toolTip.SetActive(true);
                }

                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            }
            else
            {
                if(atual != null)
                {
                    atual.GetComponent<cakeslice.Outline>().enabled = false;
                    atual = null;
                    toolTipAtual.SetActive(false);
                    toolTipAtual = null;
                }
            }
        }
    }

    public void LimparListas()
    {
        scriptsLocaisFressadoura.Clear();
        toolTips.Clear();
    }
}
