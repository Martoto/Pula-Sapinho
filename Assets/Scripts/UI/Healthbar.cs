using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;

    private void Start() {
        slider = GetComponent<Slider>();
    }
   public void setHealth(int value) {
       slider.value = value;
   }

   public void setMaxHealth(int value) {
       slider.maxValue = value;
       slider.value = value;
   }
}
