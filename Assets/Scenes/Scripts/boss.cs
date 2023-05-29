using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{

    private int rutine;
    private float timer;
    private Quaternion angle;
    private float grade;
    public Animator ani;
    public int RunSpeed;
    public float AttackDistance;
    public float walkSpeed;

    public GameObject target;
    public float PlayerDistance;
    bool isAttacking;

    public float MaxLife;
    public float Life;
    public float AttackDamage;

    private float countDie;

    void Start()
    {
        ani = GetComponent<Animator>();
        Life = MaxLife;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyBehaviours();
        Die();
    }

    
    void EnemyBehaviours()
    {
        
        
        
        if (Vector3.Distance(transform.position, target.transform.position) > PlayerDistance)
        {
            //setear animacion de correr en falso
            ani.SetBool("run", false);
            timer += 1 * Time.deltaTime;
            if (timer >= 4)
            {
                rutine = Random.Range(0, 2);
                timer = 0;
            }
            switch (rutine)
            {
                case 0:
                    //setear aniamcion de caminar en falso
                    ani.SetBool("walk", false);

                    break;
                case 1:
                    grade = Random.Range(0, 360);
                    angle = Quaternion.Euler(0, grade, 0);
                    rutine++;
                    break;

                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, 0.5f);
                    transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
                    ani.SetBool("walk", true);
                    break;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, target.transform.position) > AttackDistance && !isAttacking)
            {
                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);

                //setear animacion de caminar en falso y al de correr en verdadaero
                ani.SetBool("walk", false);
                ani.SetBool("run", true);
                transform.Translate(Vector3.forward * RunSpeed * Time.deltaTime);

                //setear animacion attack en falso
                ani.SetBool("attack", false);
            }
            else
            {
                //seterar animacionde de correr, caminar en falso y ani de atacar en true
                ani.SetBool("walk", false);
                ani.SetBool("run", false);
                ani.SetBool("attack", true);
                isAttacking = true;
            }
        }


    }

    public void FinalAttackAnimation()
    {
        //setaer animacion de ayaque en falso
        ani.SetBool("attack", false);
        isAttacking = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Espada")
        {
            Life--;
            print("golpe");
        }

        if (other.gameObject.GetComponent<bullet>())
        {

            Life = Life - 2;
            Destroy(other.gameObject);

        }
    }
    private void Die()
    {
        if (Life <= 0)
        {
            print("murio el boss");
            
            ani.Play("die");
            //ani.SetBool("die", true);
            countDie = countDie + 1 * Time.deltaTime;

            if(countDie >= 3.5)
            ani.gameObject.GetComponent<Animator>().enabled = false;



        }
    }


}