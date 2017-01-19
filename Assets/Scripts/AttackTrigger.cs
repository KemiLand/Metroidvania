using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour {

    public int damage = 3;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.isTrigger == false && collision.CompareTag("Enemy"))
        {
            collision.SendMessageUpwards("Damage", damage);
        }
    }
}
