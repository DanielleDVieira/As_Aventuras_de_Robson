using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordsScript : MonoBehaviour
{
    // Generator para pegar posições aleatórias para colocar as letras no cenário
    System.Random Generator;
    // Título (Receberá a palavra em inglês para ser traduzida)
    public TextMeshProUGUI textMesh;
    // Letras coletadas pelo robson
    public TextMeshProUGUI letrasRobson;
    // Lista de Palavras possíveis
    public WordList Words;
    // Prefab que será fabricado (Pefrab da letra)
    public GameObject prefab;
    // Lista de todos Prefabs criados
    private List<GameObject> prefabs;
    // Instanciando objeto grid
    private Grid grid;

    // Para saber qual é a Word "sorteada"
    Word atual;
    int posLetraAtual = 0;
    // Tamanho antigo do Objeto que contém todos os prefabs
    int tamanhoAntigo;

    // Start is called before the first frame update
    void Start()
    {
        Generator = new System.Random();
        // "Geração" de possíveis Palavras 
        Words = new WordList();
        Words.Load();
        prefabs = new List<GameObject>();
        // Criar grid
        grid = new Grid(38, 20, 1f, new Vector3(-19, -10));

        // Será uma palavra aleatória <
        atual = Words.Next();

        // Atualizando título com a palavra em inglês sorteada
        textMesh.text = atual.Ingles;

        // Iniciar o jogo com as letras coletadas pelo robson sem nada
        letrasRobson.text = "";

        // Criar lista com as posições do grid que possuem valor 1
        List<Vector3> worldPos = getAxis();
        Vector3 posAleatoria;

        // Lista com as posições das letras no mundo da palavra em portugues
        List<Vector3> posicaoAleatoriaLetras = new List<Vector3>();

        // Iterando por todas as letras da tradução da palavra
        // E instanciando um prefab para cada letra
        for (int i = 0; i < atual.Portugues.Length; i++)
        {
            // Pegar posição aleatória da lista worldPos para setar as posições onde ficará as letras da palavra em português
            posAleatoria = verificaPosicaoAleatoria(worldPos, posicaoAleatoriaLetras, Generator);
            posicaoAleatoriaLetras.Add(posAleatoria);
            // Setar as letras na posição aleatória
            GameObject prefab_gameObject = Instantiate(
                prefab,
                (new Vector3(posAleatoria[0], posAleatoria[1], posAleatoria[2]) + new Vector3(1f, 1f) * .5f),
                Quaternion.identity,
                transform
            );
            // Nome do prefab
            prefab_gameObject.name = "Letra";
            // Gambiarra do Guilherme das braba
            var letterScript = prefab_gameObject.GetComponent<LetterScript>();
            letterScript.word = this;
            letterScript.posicao = i;
            TextMeshProUGUI txt = prefab_gameObject.GetComponentInChildren<TextMeshProUGUI>();
            txt.text = atual.Portugues[i].ToString().ToUpper();
            letterScript.letra = txt.text;
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

    /*
        Função que garante que será gerado posições diferentes para colocar as letras no mundo
    */
    Vector3 verificaPosicaoAleatoria(List<Vector3> worldPos, List<Vector3> posicaoAleatoriaLetras, System.Random Generator) {
        Vector3 posAleatoria = worldPos[Generator.Next(worldPos.Count)];
        bool test = true;

        while (test) {
            if (isVector3(posAleatoria, posicaoAleatoriaLetras)) {
                posAleatoria = worldPos[Generator.Next(worldPos.Count)];
            } else {
                test = false;
            }
        }
        return posAleatoria;
    }

    /*
        Função que verifica se já existe a posição no vetor de posições aleatórias das letras no mundo
    */
    bool isVector3(Vector3 posicion, List<Vector3> posicaoAleatoriaLetras) {
        int quantPos = posicaoAleatoriaLetras.Count;

        for(int i = 0; i < quantPos; i++) {
            if (posicaoAleatoriaLetras[i] == posicion) {
                return true;
            }
        }
        return false;
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
        // Atualizando as letras coletadas pelo robson
        letrasRobson.text += atual.Portugues[posLetraAtual];
        posLetraAtual++;
        ColliderSizeUpdate();
    }
    
    /*
        Método para adicionar letra no placar do Robson
        Os parâmetros posicao e letraAtual vem da classe LetterScript
    */
    public void adicionarLetraPlacarRobson (int posicao, string letraAtual) {
        Debug.Log("letraAtual: " + letraAtual);
        // Atualizando as letras coletadas pelo robson
        letrasRobson.text += letraAtual;
        // TODO deixar um espaço em branco no placar da IA
    }

    /*
        Método para adicionar letra no placar da IA
        Os parâmetros posicao e letraAtual vem da classe LetterScript
    */
    public void adicionarLetraPlacarIA (int posicao, string letraAtual) {
        // TODO atualizar quando a IA encostar na letra acrescentar a letra no placar dela 
        // e deixar um espaço em branco no placar do robson
    }

    /*
        Função que retorna uma lista Vector3 que tem todas as posições da grid com valor 1
    */
    private List<Vector3> getAxis(){
        // Cria lista pos que guardará as posições que contem o valor 1 na grid
        List<Vector3> pos = new List<Vector3>();
        // Percorre a matriz grid
        for(int i = 0; i < 38; i++){
            for(int j = 0; j < 20; j++){
                // Verifica se o valor daquela posição na grid é igual a 1 e se não é no eixo y igual a 6 e 2
                // O eixo y 6 é onde nasce a IA, e o eixo y 2 é onde nasce o robson, assim não terá letras nestas plataformas
                if(grid.GetValue(i,j) == 1 && j != 6 && j != 2){
                    pos.Add(grid.GetWorldPosition(i,j));
                }
            }
        }
        return pos;
    }
}
