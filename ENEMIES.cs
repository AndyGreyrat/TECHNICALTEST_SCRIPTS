using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMIES : MonoBehaviour
{
    public Animator EnemyAnimations;
    public int MonsterRutine;
    public float timer;
    public Quaternion MonsterRotation;
    public float Angle;
    public GameObject target;
    public bool MonsterAttack;
    // Start is called before the first frame update
    void Start()
    {
        EnemyAnimations = GetComponent<Animator>();
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        MonsterBehavior();
    }
    public void MonsterBehavior()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 20)
        {
            EnemyAnimations.SetBool("Run", false);
            timer += 1 * Time.deltaTime;
            if (timer >= 4)
            {
                MonsterRutine = Random.Range(0, 2);
                timer = 0;
            }
            switch (MonsterRutine)
            {
                case 0:
                    EnemyAnimations.SetBool("Walk", false);
                    break;
                case 1:
                    Angle = Random.Range(0, 360);
                    MonsterRotation = Quaternion.Euler(0, Angle, 0);
                    MonsterRutine++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, MonsterRotation, 0.5f);
                    transform.Translate(Vector3.forward * 4 * Time.deltaTime);
                    EnemyAnimations.SetBool("Walk", true);

                    break;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, target.transform.position) > 1 && !MonsterAttack)
            {
                var LookPosition = target.transform.position - transform.position;
                LookPosition.y = 0;
                var Rotation = Quaternion.LookRotation(LookPosition);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Rotation, 5);
                EnemyAnimations.SetBool("Walk", false);
                EnemyAnimations.SetBool("Run", true);
                transform.Translate(Vector3.forward * 13 * Time.deltaTime);
                EnemyAnimations.SetBool("MonsterAttack", false);
            }
            else
            {
                EnemyAnimations.SetBool("Walk", false);
                EnemyAnimations.SetBool("Run", false);
                EnemyAnimations.SetBool("MonsterAttack", true);
                MonsterAttack = true;
            }
        }
    }
    public void EndAnimations()
    {
        EnemyAnimations.SetBool("MonsterAttack", false);
        MonsterAttack = false;
    }
}
