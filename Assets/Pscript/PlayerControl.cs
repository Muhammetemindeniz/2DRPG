using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
namespace pcontrol
{
    public class PlayerControl : MonoBehaviour
    {
        public bool reststart;
        public Image Healthbar;
        public float maxHealth = 100;
        public float currentHealth;
        public Animator anim;
        float inx;
        private bool jumpAnimActive;
        [SerializeField] float hiz;
        Rigidbody2D fizik;
        [SerializeField] float zipla;
        [SerializeField] float Jump;
        
        public GameObject reststartButton;
        void Start()
        {
            
            currentHealth = maxHealth;
            anim = GetComponent<Animator>();
            fizik = GetComponent<Rigidbody2D>();
            jumpAnimActive = false;
        }
        public void pTakeDamage(float damage)
        {
            currentHealth -= damage;
            Healthbar.fillAmount = currentHealth / 100;

            if (currentHealth <= 0)
            {

                PlayerisDeath();
                reststartButton.SetActive(true);
            }

        }
       
        public void PlayerisDeath()
        {

            anim.SetTrigger("die");
            Destroy(gameObject, 2f);
            this.enabled = false;
            
           

        }
        void Update()
        {
           
            hareket();
            jump();
        }
        void hareket()
        {
            inx = Input.GetAxis("Horizontal");
            Vector3 hareketyonu = new Vector3(inx, 0f);
            transform.position += hareketyonu * hiz * Time.deltaTime;
            anim.SetFloat("speed", Mathf.Abs(inx));
            Rotation();

        }

        private void Rotation()
        {
            if (inx < 0)
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            else if (inx > 0)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);

            }
        }

        void jump()
        {
            if (!jumpAnimActive && Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(fizik.velocity.y) < .001f)
            {
                Vector2 zýpla = new Vector2(0, Jump);
                fizik.AddForce(zýpla, ForceMode2D.Impulse);
                anim.SetBool("isJump", true);
                Debug.Log("zipladý");


            }
            else
            {
                anim.SetBool("isJump", false);
            }
        }
    }
}
