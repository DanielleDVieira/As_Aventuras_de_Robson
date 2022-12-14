using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordsScript : MonoBehaviour
{
    // Título (Receberá a palavra em inglês para ser traduzida)
    public TextMeshProUGUI textMesh;
    // Lista de Palavras possíveis
    public WordList Words;
    // Prefab que será fabricado (Pefrab da letra)
    public GameObject prefab;
    // Lista de todos Prefabs criados
    private List<GameObject> prefabs;

    // Para saber qual é a Word "sorteada"
    Word atual;
    int posLetraAtual = 0;
    // Tamanho antigo do Objeto que contém todos os prefabs
    int tamanhoAntigo;

    // Start is called before the first frame update
    void Start()
    {
        // "Geração" de possíveis Palavras 
        Words = new WordList();
        Words.Load();
        prefabs = new List<GameObject>();

        // Será uma palavra aleatória <
        atual = Words.Next();

        // Atualizando título com a palavra em inglês sorteada
        textMesh.text = atual.Ingles;

        // Iterando por todas as letras da tradução da palavra
        // E instanciando um prefab para cada letra
        for (int i = 0; i < atual.Portugues.Length; i++)
        {
            GameObject prefab_gameObject = Instantiate(
                prefab,
                //TODO lembrar de arrumar a posição baseado na posição do vértice aleatório escolhido
                new Vector2(i, 0),
                Quaternion.identity,
                transform
            );
            // Nome do prefab
            prefab_gameObject.name = "Letra";
            TextMeshProUGUI txt = prefab_gameObject.GetComponentInChildren<TextMeshProUGUI>();
            txt.text = atual.Portugues[i].ToString().ToUpper();
            // Colocando prefeb la lista de prefabs
            prefabs.Add(prefab_gameObject);
        }
        tamanhoAntigo = atual.Portugues.Length;
        ColliderSizeUpdate();

    }

    // Update is called once per frame
    void Update()
    {
        // Pegando a quantidade total de prefabs existentes (Baseando-se na quantidade de elementos com a tag "Letra")
        GameObject[] gObjects = GameObject.FindGameObjectsWithTag("Letra");
        int tamanhoAtual = gObjects.Length;
        // Caso o tamanho antigo da quantidade de elemento seja diferente da atual, significa que uma letra foi "coletada"
        if (tamanhoAntigo != tamanhoAtual)
        {
            tamanhoAntigo = tamanhoAtual;
            RemoveCollectedLetter();
        }
    }

    // Macete para garantir que só será coletado as letras na ordem desejada
    // A ideia é zerar o tamanho do Collider das letras (com exceção da que queremos)
    // Assim, não existirá contato entre o Collider do player e o Collider das letras
    // Logo, as letras indesejadas não serão deletadas
    void ColliderSizeUpdate()
    {
        foreach (GameObject item in prefabs)
        {
            // Obtendo o Collider do componente filho
            BoxCollider2D collider = item.transform.gameObject.GetComponent<BoxCollider2D>();
            // Obtendo o componente filho
            TextMeshProUGUI conteudo = item.GetComponentInChildren<TextMeshProUGUI>();
            // Obtendo o conteúdo existente no componente filho
            string sConteudo = conteudo.text.ToLower();
            // Se não for a letra desejada, zere o collider, caso contrário, aumente-o
            if (!sConteudo.Equals(atual.Portugues[posLetraAtual].ToString().ToLower()))
            {
                collider.size = new Vector2(0, 0);
            }
            else
            {
                collider.size = new Vector2(0.5F, 0.5F);
            }
        }
    }

    // Função que irá remover de Prefabs a letra que acabou de ser coletada
    // Em "LetterScript", quando há contato entre o player e a letra ela será deletada
    // Portanto, basta procurar pelo item que está nulo
    private void RemoveCollectedLetter()
    {
        GameObject objetoRemovido = new GameObject();
        foreach (GameObject item in prefabs)
        {
            if (item == null) objetoRemovido = item;
        }
        prefabs.Remove(objetoRemovido);
        posLetraAtual++;
        ColliderSizeUpdate();
    }


}
