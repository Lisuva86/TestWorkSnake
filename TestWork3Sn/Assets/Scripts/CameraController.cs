using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject mPlayer;
    private void Update()
    {
        if(mPlayer != null)
        transform.position = new Vector3(transform.position.x, transform.position.y, mPlayer.transform.position.z - 22.5f);
    }
}
