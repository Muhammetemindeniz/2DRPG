using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class wins : MonoBehaviour
{
    public GameObject winText;
    public GameObject Reststart;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            winText.SetActive(true);
            Reststart.SetActive(true);
        }
    }
}
