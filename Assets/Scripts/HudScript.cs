using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HudScript : MonoBehaviour {

    public Sprite[] HeartSprites;

    public Image HeartUI;

    private PlayerCharacter player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacter>();
    }

    void Update()
    {
        HeartUI.sprite = HeartSprites[player.currentHealth];
    }

}
