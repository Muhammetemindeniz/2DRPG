using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Slider slider;
    public Color low;
    public Color high;
    public Vector3 offset;

    public void SetHealth(float health, float maxhealth)
    {
        slider.gameObject.SetActive(health<maxhealth);
        slider.maxValue = maxhealth;
        slider.value = health;
        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low,high,slider.normalizedValue);
    }
    private void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position+offset);
    }
}
