using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    private const int MAINPLAYER = 16;
    private const int MAGN = 24;
    [SerializeField] private string color;
    private bool inside = false;
    private Rigidbody rb;
    private Vector3 dir;
    private GameObject trSnake;

    private bool test = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == MAINPLAYER)
        {
            if (Player.ColorPlayer == color || GameMeneger.Aegis)
            {
                if (test)
                {
                    test = false;
                    GameMeneger.Score++;
                    GameMeneger.feverCount = 0;
                    GameMeneger.ChangeText();
                    Destroy(gameObject);
                }
            }
            else
            {
                Player.deathPlayer = true;
                Destroy(gameObject);
            }
        }
        if(collision.gameObject.layer == MAGN)
        {
            inside = true;
            trSnake = collision.gameObject;
        }
    }

    private void FixedUpdate()
    {
        if (inside)
        {
            dir = (trSnake.transform.position - transform.position);
            rb.velocity = dir * 15f;
        }
        if(trSnake != null)
        {
            if(trSnake.transform.position.z > transform.position.z)
            {
                if (Player.ColorPlayer == color || GameMeneger.Aegis )
                {
                    if (test)
                    {
                        test = false;
                        GameMeneger.Score++;
                        GameMeneger.feverCount = 0;
                        GameMeneger.ChangeText();
                        Destroy(gameObject);
                    }
                }
                else
                {
                    Player.deathPlayer = true;
                    Destroy(gameObject);
                }
            }
        }
    }
}
