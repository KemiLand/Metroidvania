using UnityEngine;
using System.Collections;

public class SpikeScript : MonoBehaviour {

    private PlayerCharacter player;
    [SerializeField] int spikeDamage = 3;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacter>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            player.Damage(spikeDamage);
        }
    }
}
