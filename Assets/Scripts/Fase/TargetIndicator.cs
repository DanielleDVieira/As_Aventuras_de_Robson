/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetIndicator : MonoBehaviour
{
    /*
    int tamanhoAntigo;
    WordsScript target;
    public float HideDistance;

    void Start(){
        target = GameObject.FindGameObjectWithTag("Script").GetComponent<WordsScript>();
        tamanhoAntigo = target.getPrefabsSize();
    }

    void Update(){
        int tamanhoAtual = target.getPrefabsSize();

        GameObject firstChild = target.getTarget();

        if(firstChild != null) {
            Vector3 dir = firstChild.transform.position - transform.position;
            if(dir.magnitude < HideDistance) {
                SetChildrenActive(false);
            } else {
                SetChildrenActive(true);
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            }


           
        }

    }

    void SetChildrenActive(bool value){
        foreach( Transform child in transform ){
            child.gameObject.SetActive(value);
        }
    }


    private List<GameObject> Components(){
        GameObject firstChild = target.transform.GetChild(0).gameObject;
        return null;
    }

    */

}
*/