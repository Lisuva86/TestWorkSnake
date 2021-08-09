using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    

    private const int PINKCOLORLINE = 13;
    private const int GREENCOLORLINE = 14;
    private const int BLUECOLORLINE = 15;
    private const int REDCOLORLINE = 20;
    private const int BLACKCOLORLINE = 21;
    private const int BROWNCOLORLINE = 22;
    private const int YELLOWCOLORLINE = 23;

    private const int FINISH = 19;
    public static bool WinGame = false;

    

    [SerializeField] private Material pink;
    [SerializeField] private Material blue;
    [SerializeField] private Material green;
    [SerializeField] private Material black;
    [SerializeField] private Material red;
    [SerializeField] private Material brown;
    [SerializeField] private Material yellow;

    private enum Direction { Forward,Left,Right}
    private Direction direction = Direction.Forward;

    private MeshRenderer mr;
    public static Rigidbody rb;
    private float speed = 15f;

    public static string ColorPlayer = "Blue";

    public static int count = 0;
    public static float[] pointZ = new float[100];
    public static int[] pointDirection = new int[100];

    [SerializeField] private Piece tail1;
    [SerializeField] private Piece tail2;
    [SerializeField] private Piece tail3;
    [SerializeField] private Piece tail4;
    [SerializeField] private Piece tail5;
    [SerializeField] private Piece tail6;

    
    
    private float WIDTHSCREEN;
    public static bool deathPlayer = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        mr = GetComponent<MeshRenderer>();
        
       
    }
    private void Start()
    {
        
        WIDTHSCREEN = Screen.width;
        rb.velocity = Vector3.forward * speed;
        mr.material = blue;
    }
    private void Update()
    {
        if (deathPlayer)
        {
            DestroyPlayer();
        }
        if (GameMeneger.Aegis)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 45f);
        }
        else rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 15f);
    }
    private void FixedUpdate()
    {
        if (!GameMeneger.Aegis)
        {

            if (Input.GetButton("Fire1"))
            {
                Vector3 mousePos = Input.mousePosition;

                if (((transform.position.x - 3.9f) / 0.081f > (mousePos.x) / (WIDTHSCREEN / 100f)) && Mathf.Abs((((transform.position.x - 3.9f) / 0.081f) - (mousePos.x) / (WIDTHSCREEN / 100f))) > 2.7f)
                {
                    if (direction != Direction.Left)
                    {
                        pointZ[count] = transform.position.z;
                        pointDirection[count] = -1;
                        count++;
                        ChangeTailsPosition();
                    }
                    direction = Direction.Left;
                }
                else if (((transform.position.x - 3.9f) / 0.081f < (mousePos.x) / (WIDTHSCREEN / 100f)) && Mathf.Abs((((transform.position.x - 3.9f) / 0.081f) - (mousePos.x) / (WIDTHSCREEN / 100f))) > 2.7f)
                {
                    if (direction != Direction.Right)
                    {
                        pointZ[count] = transform.position.z;
                        pointDirection[count] = 1;
                        count++;
                        ChangeTailsPosition();
                    }
                    direction = Direction.Right;
                }
                else
                {
                    if (direction != Direction.Forward)
                    {
                        pointZ[count] = transform.position.z;
                        pointDirection[count] = 0;
                        count++;
                        ChangeTailsPosition();
                    }
                    direction = Direction.Forward;
                }

                DirectionPlayer();


            }
            else
            {
                if (direction != Direction.Forward)
                {
                    pointZ[count] = transform.position.z;
                    pointDirection[count] = 0;
                    count++;
                    ChangeTailsPosition();
                }
                direction = Direction.Forward;
                rb.velocity = new Vector3(0f, rb.velocity.y, rb.velocity.z);
            }
        }
        else
        {
            if(transform.position.x < 7.5f)
            {
                if (direction != Direction.Right)
                {
                    pointZ[count] = transform.position.z;
                    pointDirection[count] = 1;
                    count++;
                    ChangeTailsPosition();
                }
                direction = Direction.Right;
            }
            else if(transform.position.x > 8.5f)
            {
                if (direction != Direction.Left)
                {
                    pointZ[count] = transform.position.z;
                    pointDirection[count] = -1;
                    count++;
                    ChangeTailsPosition();
                }
                direction = Direction.Left;
            }
            else
            {
                if (direction != Direction.Forward)
                {
                    pointZ[count] = transform.position.z;
                    pointDirection[count] = 0;
                    count++;
                    ChangeTailsPosition();
                }
                direction = Direction.Forward;
                
            }

            DirectionPlayer();
        }

    }


    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.layer == PINKCOLORLINE)
        {
            ColorPlayer = "Pink";
            mr.material = pink;
        }
        if (collision.gameObject.layer == GREENCOLORLINE)
        {
            ColorPlayer = "Green";
            mr.material = green;
        }
        if (collision.gameObject.layer == BLUECOLORLINE)
        {
            ColorPlayer = "Blue";
            mr.material = blue;
        }
        if (collision.gameObject.layer == REDCOLORLINE)
        {
            ColorPlayer = "Red";
            mr.material = red;
        }
        if (collision.gameObject.layer == BLACKCOLORLINE)
        {
            ColorPlayer = "Black";
            mr.material = black;
        }
        if (collision.gameObject.layer == BROWNCOLORLINE)
        {
            ColorPlayer = "Brown";
            mr.material = brown;
        }
        if (collision.gameObject.layer == YELLOWCOLORLINE)
        {
            ColorPlayer = "Yellow";
            mr.material = yellow;
        }
        if (collision.gameObject.layer == FINISH)
        {
            WinGame = true;
        }

    }
  
    private void DestroyPlayer()
    {
        Destroy(gameObject);
    }
    private void ChangeTailsPosition()
    {
        tail1.ChangePosTail(pointZ[count - 1]);
        tail2.ChangePosTail(pointZ[count - 1]);
        tail3.ChangePosTail(pointZ[count - 1]);
        tail4.ChangePosTail(pointZ[count - 1]);
        tail5.ChangePosTail(pointZ[count - 1]);
        tail6.ChangePosTail(pointZ[count - 1]);
    }

    private void DirectionPlayer()
    {
        if (direction == Direction.Right) rb.velocity = new Vector3(20f, rb.velocity.y, rb.velocity.z);
        else if (direction == Direction.Left) rb.velocity = new Vector3(-20f, rb.velocity.y, rb.velocity.z);
        else rb.velocity = new Vector3(0f, rb.velocity.y, rb.velocity.z);
    }
}
