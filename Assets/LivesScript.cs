using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LivesScript : MonoBehaviour
{
    public Text lifeText;
    [SerializeField] public float lives;
    // Start is called before the first frame update
    void Start()
    {
        lives = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if(lives == 2)
        {
            lifeText.text = "Lives:" + lives;
        }
        else if(lives == 1)
        {
            lifeText.text = "Lives:" + lives;
        }
        else
        {
            Restart(); 
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void subtractLife()
    {
        lives--;
    }
}


