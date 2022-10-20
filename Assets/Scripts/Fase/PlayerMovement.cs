using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Text;

public class PlayerMovement : MonoBehaviour
{
    // Relacionado ao controller do Player
    public CharacterController2D controller;
    // Relacionado ao controle de animação do Player
    public Animator animator;

    // Variavel para guardar se botão de ataque está pressionado
    public GameObject _button;
    ButtonAtack _press;

    // Variavel que contem as letras coletadas do Robson e IA
    WordsScript wordScript;

    // Variável que receberá o "valor" do movimento horizontal
    // Lembrete: "Input.GetAxisRaw("Horizontal") retorna :
    //           -> -1 caso player andar para esquerda
    //           ->  0 caso player parado (idle)
    //           ->  1 caso player andar para direita
    float horizontalMove = 0f;

    // Resposável pela velocidade do movimento do usuário
    public float runSpeed = 40f;

    public GameObject DeathMenu;
    int somDerrota = 0;

    public GameObject LimiteInferior;
    public Joystick Joystick;

    // Responsável pelo controle de pulo
    bool jump = false;
    // Responsável pelo controle de agachar
    bool crouch = false;

    void Start() {
        _press = _button.GetComponent<ButtonAtack>();
        wordScript = GameObject.FindGameObjectWithTag("Script").GetComponent<WordsScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // O personagem deve morrer se cair para fora dos limites do mapa
        if (controller.transform.position.y <= LimiteInferior.transform.position.y)
        {
            // Gambiarra para tocar o efeito sonoro da derrota apenas uma vez (so no 1o Update() pos morte)
            somDerrota++;
            if(somDerrota == 1){
                SoundManagerScript.audioSrc.Stop();
                SoundManagerScript.PlaySound("defeat");
            }

            DeathMenu.SetActive(true);
            Time.timeScale = 0;
        }

        // Recebendo valor do input das teclas horizontais 
        // Pré-setado na unity: Horizontal = A e D

        if (Joystick.Horizontal == 0)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        }
        else
        {
            horizontalMove = Joystick.Horizontal * runSpeed;
        }

        // Setando na variável da animação de corrida o valor absoluto do movimento horizontal
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        // Recebendo valor do input da tecla jump
        // Pré-setado na unity: Jump = Espaço
        if (Input.GetButtonDown("Jump") || Joystick.Vertical >= 0.5)
        {
            SoundManagerScript.PlaySound("jump");
            jump = true;
            // Setando na variável da animação de pulo o valor positivo quando clicarmos para pular    
            animator.SetBool("IsJumping", true);
        }

        // Recebendo valor do input da tecla crouch
        // Essa não é pré-setada na unity, mas basta copiar o preset do jump, e alterar a tecla
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    // Função necessária para a animação
    public void OnLanding()
    {
        jump = false;
        animator.SetBool("IsJumping", false);
    }

    // Função necessária para a animação
    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    // Função que será executada em um tempo fixo (Fixed)
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
    }

    /*
        Quando o Robson colidir com a IA
    */
    private void OnCollisionEnter2D(Collision2D collision){
        // Se colidido com a IA
        if(collision.gameObject.CompareTag("IA")) {

            // Verificar se botão de ataque está pressionado
            if(_press.pressButtonAtack) {
                int posAux = 0;
                int pos = -1;

                StringBuilder auxRobson = new StringBuilder(wordScript.letrasRobson.text);
                StringBuilder auxIA = new StringBuilder(wordScript.letrasIA.text);

                // Percorrer a palavra do Robson procurando uma posição com _
                while(posAux < wordScript.letrasRobson.text.Length) {
                    // Se encontrar uma posição com _ guardar esta posicao
                    if(auxRobson[posAux] == '_') {
                        pos = posAux;
                        posAux = wordScript.letrasRobson.text.Length;
                    }
                    posAux++;
                }   

                // Se encontrar alguma posição válida para mudar, alterar letrasRobson e letrasIA
                if (pos != -1) {
                    auxRobson[pos] = auxIA[pos];
                    auxIA[pos] = '_';
                    wordScript.letrasRobson.text = auxRobson.ToString();
                    wordScript.letrasIA.text = auxIA.ToString();
                }
            } 
        }
    }
}
