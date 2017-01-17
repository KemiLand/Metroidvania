using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HudScript : MonoBehaviour {

    [SerializeField] Sprite[] HeartSprites;
    [SerializeField] Image HeartUI;
    private PlayerCharacter player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacter>();
    }

    void Update()
    {
        if(player.currentHealth < 0)
        {
            player.currentHealth = 0;
        }
        if(player.currentHealth > 5)
        {
            player.currentHealth = 5;
        }

        HeartUI.sprite = HeartSprites[player.currentHealth]; // Changes the hearts sprite according to the player's health
    }

}
