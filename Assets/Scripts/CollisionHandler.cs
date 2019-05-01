using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollisionHandler : MonoBehaviour
{
    public string lastHit = "";
    public TailScript playerTail;
    public int cansCollected = 0;
    public int colorsCollected = 0;
    private float timer;
    public Text counterText;
    public Text canText;
    public Text colorsText;
    [SerializeField] private float mainTimer;

    
    // Start is called before the first frame update
    void Start()
    {
        timer = mainTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 0.0f)
        {
            timer -= Time.deltaTime;
            counterText.text = timer.ToString("F");
        }
        else if (timer <= 0.0f)
        {
            counterText.text = "0.00";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }

    public void HandleHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.name != lastHit)
        {
            Debug.Log("CollisionHandler detected new hit between " + hit.controller.name  + " and " + hit.gameObject.tag);
            if (hit.gameObject.tag == "Collectable")
            {
                if (hit.controller.tag == "Player")
                {
                    playerTail.incrementTailBy(1);
                    if (hit.gameObject.name == "Can_1(Clone)" || hit.gameObject.name == "Can_2(Clone)" || hit.gameObject.name == "Can_3(Clone)")
                    {
                        cansCollected++;
                        timer = 18.0f;
                        canText.text = "Cans: " + cansCollected;
                    } else if (hit.gameObject.name == "RedSphere(Clone)" || hit.gameObject.name == "BlueSphere(Clone)" || hit.gameObject.name == "GreenSphere(Clone)" || hit.gameObject.name == "ChartreuseSphere(Clone)") {
                        colorsCollected++;
                        timer = 18.0f;
                        colorsText.text = "Colors: " + colorsCollected;

                    }
                    Destroy(hit.gameObject);
                }
            } else if (hit.gameObject.tag == "Enemy")
            {
                if (hit.controller.tag == "Player")
                {
                 
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
            else if(hit.gameObject.tag == "Tail")
            {
                if(hit.controller.tag == "Player")
                {
                    
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }

            }
        }

        lastHit = hit.gameObject.name;

    }
    public void unlockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
