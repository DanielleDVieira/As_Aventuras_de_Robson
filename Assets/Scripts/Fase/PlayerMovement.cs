using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Relacionado ao controller do Player
    public CharacterController2D controller;
    // Relacionado ao controle de animação do Player
    public Animator animator;
    // Variável que receberá o "valor" do movimento horizontal
    // Lembrete: "Input.GetAxisRaw("Horizontal") retorna :
    //           -> -1 caso player andar para esquerda
    //           ->  0 caso player parado (idle)
    //           ->  1 caso player andar para direita
    float horizontalMove = 0f;

    // Resposável pela velocidade do movimento do usuário
    public float runSpeed = 40f;

    public GameObject DeathMenu;
    public GameObject LimiteInferior;
    public Joystick Joystick;

    // Responsável pelo controle de pulo
    bool jump = false;
    // Responsável pelo controle de agachar
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        // O personagem deve morrer se cair para fora dos limites do mapa
        if (controller.transform.position.y <= LimiteInferior.transform.position.y)
        {
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
}
