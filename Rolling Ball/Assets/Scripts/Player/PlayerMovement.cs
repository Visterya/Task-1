using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    private float moveInputX;
    private float moveInputZ;


    void Update()
    {
        moveInputX = UnityEngine.Input.GetAxisRaw("Horizontal");
        moveInputZ = UnityEngine.Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(moveInputX, 0f, moveInputZ).normalized * moveSpeed * Time.deltaTime;

    }
}
