using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetIndicator : MonoBehaviour
{
    private WordsScript target;
    // Hide distance que deverá ser setada 
    public float HideDistance;


    void Start(){
        target = GameObject.FindGameObjectWithTag("Script").GetComponent<WordsScript>();
    }

    void Update(){
        // Acessando o script, para então, poder pegar a próxima letra que deverá ser apontada
        GameObject firstChild = target.getTarget();

        // Quando retornar null, significa que todas as letras já foram coletadas
        if(firstChild != null) {
            // Calculando a distância da letra para a posição do player
            Vector3 dir = firstChild.transform.position - transform.position;
            // Caso essa distância seja menor do que o hideDistance, desapareça com o indicador
            if(dir.magnitude < HideDistance) {
                SetChildrenActive(false);
            } else {
                SetChildrenActive(true);

                // Calculando a rotação do indicador para a próxima letra a ser coletada
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            }

        } else {
            // Caso não tenha mais letra para ser coletada, indicador some
            // (Pode ser substituído com um "destroy")
            SetChildrenActive(false);
        }

    }

    void SetChildrenActive(bool value){
        foreach( Transform child in transform ){
            child.gameObject.SetActive(value);
        }
    }
}