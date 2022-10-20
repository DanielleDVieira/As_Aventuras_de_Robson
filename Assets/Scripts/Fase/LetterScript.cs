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
        //word = GameObject.FindGameObjectWithTag("Script").GetComponent<WordsScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Player")) {
            // Destruir letra
            Destroy(this.gameObject);
            word.indicator = 1;
            //word.RemoveCollectedLetter(1);    
            // TODO Gambiarra futura para poder verificar quem está colidindo com a 
            // letra e poder adicionar ao respectivo placar
            // Chamar função que irá acrescentar a letra destruida no placar do Robson
            // word.adicionarLetraPlacarRobson(posicao, letra);

        } else if(collision.gameObject.CompareTag("IA")) {
            // Destruir letra
            Debug.Log("Destrui :)");
            Destroy(this.gameObject);
            word.indicator = 0;
            //word.RemoveCollectedLetter(0);
            // Chamar função que irá acrescentar a letra destruida no placar da IA
            // word.adicionarLetraPlacarIA(posicao, letra);
        }
    }
}
