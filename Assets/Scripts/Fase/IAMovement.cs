using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAMovement : MonoBehaviour
{
    private WordsScript wordsScript;

    // Relacionado ao controle de animação da IA
    public Animator animator;

    // Variável que receberá o "valor" do movimento horizontal
    //float horizontalMove = 0f;

    // Resposável pela velocidade do movimento do usuário
    public float runSpeed = 40f;

    // Responsável pelo controle de voo
    bool fly = false;

    public bool right = true;

    // Start is called before the first frame update
    void Start()
    {
        wordsScript = GameObject.FindGameObjectWithTag("Script").GetComponent<WordsScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // Setando na variável da animação de corrida o valor absoluto do movimento horizontal
        animator.SetFloat("Speed", Mathf.Abs(1.0f));

        if (wordsScript.getGrid().GetValue(transform.position) == 2)
        {
            fly = true;
            animator.SetBool("IsJumping", true);
        } else {
            animator.SetBool("IsJumping", false);
        }
    }

    // Função necessária para a animação
    public void OnLanding()
    {
        fly = false;
        animator.SetBool("IsJumping", false);
    }
    
    public void Flip() {
        right = !right;
        Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
    }
};
