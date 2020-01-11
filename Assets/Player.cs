using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public bool power = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (power)
        {
            Color tmp = GetComponent<SpriteRenderer>().color;
            tmp.a = 0.5f;
            GetComponent<SpriteRenderer>().color = tmp;
            Physics2D.IgnoreLayerCollision(9,8,true);
        }
        else
        {
            Color tmp = GetComponent<SpriteRenderer>().color;
            tmp.a = 1f;
            GetComponent<SpriteRenderer>().color = tmp;
            Physics2D.IgnoreLayerCollision(9, 8, false);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Obstacle" && !power)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void isTouching(bool isActive)
    {
        power = isActive;
    }
}
