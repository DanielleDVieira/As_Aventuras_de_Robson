using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAtack : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Variavel que guarda se botão está pressionado
    public bool pressButtonAtack;
    
    /*
        Se pressionado alterar para true
    */
    public void OnPointerDown(PointerEventData eventData) {
        pressButtonAtack = true;
    }

    /*
        Se não pressionado alterar para false
    */
    public void OnPointerUp(PointerEventData eventData) {
        pressButtonAtack = false;
    }
}
