using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private List<GameObject> canvasAtividades = new List<GameObject>();

    [SerializeField] private List<Button> pecas = new List<Button>();

    [HideInInspector] public int atividade;

    private Animator anim;

    private bool isInstanciado = false;

    public static TutorialUI instancia;

    private void Start()
    {
        instancia = this;

        foreach(Button bt in pecas)
            bt.interactable = false;

        anim = transform.gameObject.GetComponent<Animator>();
    }

    public void IniciarTutorial() => anim.Play("Tutorial");

    public void IniciarAtividade(int i)
    {
        if(!isInstanciado)
        {
            foreach (Button bt in pecas)
                bt.interactable = true;

            atividade = i;

            GameObject g = Instantiate(canvasAtividades[i], canvasAtividades[i].transform.position, canvasAtividades[i].transform.rotation);

            anim.SetBool("Finalizado", false);

            isInstanciado = true;
        }
    }

    public int SortearAtividade()
    {
        int c = Random.Range(0,2);

        atividade = c;

        return c;
    }

    public void DesativarAtividade()
    {
        foreach (Button bt in pecas)
        {
            bt.interactable = false;
        }

        anim.SetBool("Finalizado", true);

        isInstanciado = false;
    }

    public void AtivarAnimacaoPecaAtiva(int peca)
    {
        switch(peca)
        {
            case 1:
                anim.Play("ManivelaDireitaIda");
            break;

            case 2:
                anim.Play("ManivelaEsquerdaIda");
            break;

            case 3:
                anim.Play("AlavancaDeTipoDeSerragemPerfuração");
            break;

            case 4:
                anim.Play("AlavancaMotor");
            break;

            case 5:
                anim.Play("CliqueBotãoAgua");
            break;

            case 6:
                anim.Play("BrocaRotação");
            break;
        }
    }

    public void AtividadeFinalizada() => AtividadeUI.instancia.DesistirAtividade();

}
