using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.Events; 
using UnityEngine.EventSystems;

 public class TextColor : MonoBehaviour, ISelectHandler, IDeselectHandler {
 
     void ISelectHandler.OnSelect(BaseEventData eventData)
     {
         gameObject.GetComponentInChildren<Text>().color = new Color(150, 150, 150, 255);
 
     }
 
     public void OnDeselect(BaseEventData eventData)
     {
         gameObject.GetComponentInChildren<Text>().color = new Color(0, 0, 0, 255);
 
     }
 }