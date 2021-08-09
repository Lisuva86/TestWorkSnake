using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstruction : MonoBehaviour
{
    private const int PLAYER = 16;
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.layer == PLAYER)
        {
            if (GameMeneger.Aegis)
            {
                GameMeneger.Score++;
                GameMeneger.feverCount = 0;
                GameMeneger.ChangeText();
                Destroy(gameObject);
            }
            else Player.deathPlayer = true;
        }
    }
}
