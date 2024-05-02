using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciaMaquinaIndustrialUI : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> maquinasIndustriais = new List<GameObject>();

    private int maquinaEscolhida;

    [SerializeField]
    private ScrollHoloUI scrolH;

    private void Start()
    {
        ControlaRetornoDaCenaUI.RecebeCanvas(gameObject);
    }

    public void Instanciar()
    {
        ControlaRetornoDaCenaUI.DesativarCanvas();

        maquinaEscolhida = scrolH.RetornarIndexDaMaquina();

        GameObject obj = Instantiate(maquinasIndustriais[maquinaEscolhida], maquinasIndustriais[maquinaEscolhida].transform.position, maquinasIndustriais[maquinaEscolhida].transform.rotation);

        obj.transform.position = new Vector3(0, -0.175f, 1);

        ControlaRetornoDaCenaUI.ReceberMaquinaEscolhida(obj);

        Focalizador.focalizador.PreencherListas();
    }
}
