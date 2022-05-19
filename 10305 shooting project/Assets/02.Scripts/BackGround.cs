using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public Material bgMatefial;
    public float scrollSpeed = 0.1f;



    void Update()
    {
        Vector2 direction = Vector2.up;
        bgMatefial.mainTextureOffset += direction * scrollSpeed * Time.deltaTime;
    }
}
