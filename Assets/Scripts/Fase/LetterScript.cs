using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterScript : MonoBehaviour
{
    public WordsScript word;
    public int posicao;
    public string letra;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Player")) {
            // Destruir letra
            Destroy(this.gameObject);
            
            // TODO Gambiarra futura para poder verificar quem está colidindo com a 
            // letra e poder adicionar ao respectivo placar
            // Chamar função que irá acrescentar a letra destruida no placar do Robson
            // word.adicionarLetraPlacarRobson(posicao, letra);

        } else if(collision.gameObject.CompareTag("IA")) {
            // Destruir letra
            Destroy(this.gameObject);

            // Chamar função que irá acrescentar a letra destruida no placar da IA
            // word.adicionarLetraPlacarIA(posicao, letra);
        }
    }
}
