using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    private const int PLAYER = 16;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.layer == PLAYER)
        {
            GameMeneger.Bonus++;
            GameMeneger.ChangeText();
            if (!GameMeneger.Aegis)
            {
                GameMeneger.feverCount++;
            }
            Destroy(gameObject);

        }
    }
}
