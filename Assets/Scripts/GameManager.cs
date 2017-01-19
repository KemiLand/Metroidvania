using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    float timeToEnd = 2;

	// Update is called once per frame
	void Update ()
    {
        var enemies = GameObject.FindWithTag("Enemy");

        if(enemies == null)
        {
            if(timeToEnd > 0) // If all enemies are dead, show the win screen after 2 seconds
            {
                timeToEnd -= Time.deltaTime;
            }
            else
            {
                SceneManager.LoadScene("VictoryScreen");
            }
        }
	}
}
