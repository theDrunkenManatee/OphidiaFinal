using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject character;
    private float distance;
    public float attackRange;
    private Animator anim;
    public float speed;

    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player");
        anim = transform.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, character.transform.position);
        if (distance < attackRange)
        {
            transform.LookAt(character.transform);
            anim.Play("attack");
        }
        else
        {
            transform.LookAt(character.transform);
            Vector3 objPos = new Vector3(transform.position.x, 0f, transform.position.z);
            Vector3 charPos = new Vector3(character.transform.position.x, 0f, character.transform.position.z);
            transform.position = Vector3.MoveTowards(objPos, charPos, speed);
            anim.Play("walk");
        }
    }
}
