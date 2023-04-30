using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyC : MonoBehaviour
{
    public Image Healthbar;
    public float maxHealth = 100;
    public float currentHealth;
    public Animator anim;
    EnemAl enemAi;
    void Start()
    {
        currentHealth = maxHealth;
        enemAi = GetComponent<EnemAl>();
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Healthbar.fillAmount = currentHealth / 100;
        if (currentHealth <= 0)
        {

            isDeath();
        }

    }
    public void isDeath()
    {

        anim.SetTrigger("die");
        anim.SetBool("walk", false);
        this.enabled = false;
     
        enemAi.enabled = false;
        Destroy(gameObject, 2f);
    }
}
