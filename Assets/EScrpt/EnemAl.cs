using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using pcontrol;
public class EnemAl : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask playerLayers;
    public float radius = 0.5f;
    public float attackDamage = 10;
    public float pos1x, pos2x;

    //public Vector2 Pos1;
    // public Vector2 Pos2;
    private float oldPos;
    public float Speed;
    public GameObject Raycaststart;
    public float pMoveSpeed;
    public float Distance;
    public Transform Player;
    private float fallowSpeed;
    private float timeSincelastAttack;
    private float timeBetweenAttacks = 2f;
    public float attackDistance;

    Animator anim;
    void Start()
    {

        anim = GetComponent<Animator>();
    }
    void Update()
    {
        Ray();
        timeSincelastAttack += Time.deltaTime;


    }
    public void PlayerDamage()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, radius, playerLayers);
        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponent<PlayerControl>().pTakeDamage(attackDamage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, radius);
    }
    private void EnemMove()
    {
        Vector2 Pos1 = new Vector2(pos1x, transform.position.y);
        Vector2 pos2 = new Vector2(pos2x, transform.position.y);
        transform.position = Vector3.Lerp(Pos1, pos2, Mathf.PingPong(Time.time * Speed, 1.0f));
        anim.SetBool("walk", true);
        anim.ResetTrigger("attack");
        Flip("Patrol");


    }
    private void Ray()
    {

        RaycastHit2D hit = Physics2D.Raycast(Raycaststart.transform.position, transform.right, Distance);
        if (hit.collider != null)
        {


            if (hit.collider.tag == "player")
            {
                Flip("PLook");
                // Debug.Log("dolu");
                Debug.DrawLine(Raycaststart.transform.position, hit.point, Color.red);
                Debug.Log(hit.collider.name);
                if (Vector2.Distance(transform.position, Player.position) >= 1f || Vector2.Distance(transform.position, Player.position) <= 1f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, Player.position, pMoveSpeed * Time.deltaTime);
                    canAttack();
                }

            }
            else
            {
                EnemMove();
                Debug.Log(hit.collider.name);
                Debug.DrawLine(Raycaststart.transform.position, transform.position + transform.right * Distance, Color.black);
            }
        }
        else
        {
           
            EnemMove();
            Debug.DrawLine(Raycaststart.transform.position, transform.position + transform.right * Distance, Color.green);
        }



    }
    private void Attack()
    {
        if (timeSincelastAttack > timeBetweenAttacks)
        {
            anim.SetTrigger("attack");
            anim.SetBool("walk", false);
            timeSincelastAttack = 0f;
            Debug.Log(Vector2.Distance(transform.position, Player.transform.position) + "Animasyon tetiklendi");
        }
    }
    private void canAttack()
    {
        if (Vector2.Distance(transform.position, Player.transform.position) < attackDistance)
        {
            Attack();
            Debug.Log("attackyapldý");
        }
        else
        {
            anim.ResetTrigger("attack");
            anim.SetBool("walk", true);
        }


    }
    public void Flip(string tur)
    {
        switch (tur)
        {
            case "Patrol":
                if (transform.position.x > oldPos)
                {
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                }
                else
                {
                    transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
                }
                oldPos = transform.position.x;
                break;
            case "PLook":
                if (transform.position.x < Player.position.x)
                {
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                }
                else
                {
                    transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
                }
                break;

        }

    }
}
