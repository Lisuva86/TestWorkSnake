using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    [SerializeField] GameObject player;
    public Rigidbody Rb;
    private const int PINKCOLORLINE = 13;
    private const int GREENCOLORLINE = 14;
    private const int BLUECOLORLINE = 15;
    private const int REDCOLORLINE = 20;
    private const int BLACKCOLORLINE = 21;
    private const int BROWNCOLORLINE = 22;
    private const int YELLOWCOLORLINE = 23;

    [SerializeField] private Material pink;
    [SerializeField] private Material blue;
    [SerializeField] private Material green;
    [SerializeField] private Material black;
    [SerializeField] private Material red;
    [SerializeField] private Material brown;
    [SerializeField] private Material yellow;

    private MeshRenderer mr;
    private float tailPointZ = 100000000;
    private int tailDirection = 0;
    [SerializeField] private bool LastTail;
    private void Awake()
    {
        Rb = GetComponent<Rigidbody>();
        mr = GetComponent<MeshRenderer>();
    }
    private void Start()
    {
        Rb.velocity = Vector3.forward * 15f;
        mr.material = blue;
    }
    private void Update()
    {
        if (GameMeneger.Aegis)
        {
            Rb.velocity = new Vector3(Rb.velocity.x, Rb.velocity.y, 45f);
        }
        else Rb.velocity = new Vector3(Rb.velocity.x, Rb.velocity.y, 15f);

        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, - 1);
    }
    private void FixedUpdate()
    {
        


        if(transform.position.z >= tailPointZ)
        {
            
            int index = 0;
            for(int i = 0; i < Player.count; i++)
            {
                if(Player.pointZ[i] == tailPointZ)
                {
                    index = i;
                    
                }
            }

            tailDirection = Player.pointDirection[index];
            if (index + 1 != Player.count)
            {
                tailPointZ = Player.pointZ[index + 1];
            }
            else
            {
                tailPointZ = 100000000;
                if (tailDirection == 0)
                {
                    transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
                }
            }


            if (LastTail)
            {
                for (int i = 0; i < Player.count; i++)
                {
                    Player.pointZ[i] = Player.pointZ[i + 1];
                    Player.pointDirection[i] = Player.pointDirection[i + 1];
                }

                Player.count--;
            }
        }



        if (tailDirection == 0)
        {
            Rb.velocity = new Vector3(0f, Rb.velocity.y, Rb.velocity.z);
        }
        else if(tailDirection == -1)
        {
            Rb.velocity = new Vector3(-20f, Rb.velocity.y, Rb.velocity.z);
        }
        else Rb.velocity = new Vector3(20f, Rb.velocity.y, Rb.velocity.z);
    }

    public void ChangePosTail(float point)
    {
        if(tailPointZ == 100000000)
        {
            tailPointZ = point;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.layer == PINKCOLORLINE)
        {
            mr.material = pink;
        }
        if (collision.gameObject.layer == GREENCOLORLINE)
        {
            mr.material = green;
        }
        if (collision.gameObject.layer == BLUECOLORLINE)
        {
            mr.material = blue;
        }
        if (collision.gameObject.layer == REDCOLORLINE)
        {
            mr.material = red;
        }
        if (collision.gameObject.layer == BLACKCOLORLINE)
        {
            mr.material = black;
        }
        if (collision.gameObject.layer == BROWNCOLORLINE)
        {
            mr.material = brown;
        }
        if (collision.gameObject.layer == YELLOWCOLORLINE)
        {
            mr.material = yellow;
        }


    }
}
