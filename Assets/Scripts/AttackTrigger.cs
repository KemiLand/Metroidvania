using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour {

    [SerializeField] int damage = 3;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.isTrigger == false && collision.CompareTag("Enemy"))
        {
            //If an enemy was hit, sends it the damage dealt
            collision.SendMessageUpwards("Damage", damage);
        }
    }
}
