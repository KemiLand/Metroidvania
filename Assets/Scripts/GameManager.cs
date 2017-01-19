using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    float timeToEnd = 2;

    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        var enemies = GameObject.FindWithTag("Enemy");

        if(enemies == null)
        {
            if(timeToEnd > 0)
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
