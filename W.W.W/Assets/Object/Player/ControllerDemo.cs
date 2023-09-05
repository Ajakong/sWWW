using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerDemo : MonoBehaviour
{
   void Update()
    {
        if (Input.GetKeyDown("joystick button 0"))
        {
            Debug.Log("button0"); // A
        }
        if (Input.GetKeyDown("joystick button 1"))
        {
            Debug.Log("button1"); // B
        }
        if (Input.GetKeyDown("joystick button 2"))
        {
            Debug.Log("button2"); // X
        }
        if (Input.GetKeyDown("joystick button 3"))
        {
            Debug.Log("button3"); // Y
        }
        if (Input.GetKeyDown("joystick button 4"))
        {
            Debug.Log("button4"); // L
        }
        if (Input.GetKeyDown("joystick button 5"))
        {
            Debug.Log("button5"); // R
        }
        if (Input.GetKeyDown("joystick button 6"))
        {
            Debug.Log("button6"); // View (�l�p�`��̂��)
        }
        if (Input.GetKeyDown("joystick button 7"))
        {
            Debug.Log("button7"); // Menu(��)
        }
        if (Input.GetKeyDown("joystick button 8"))
        {
            Debug.Log("button8"); // L�X�e�B�b�N
        }
        if (Input.GetKeyDown("joystick button 9"))
        {
            Debug.Log("button9"); // R�X�e�B�b�N
        }
        float hori = Input.GetAxis("Horizontal");  // L�X�e�B�b�N�����@�i��-1�`�E1�j
        float vert = Input.GetAxis("Vertical");    // L�X�e�B�b�N�c���@�i��-1�`��1�j
        if ((hori != 0) || (vert != 0))
        {
            Debug.Log("stick:" + hori + "," + vert);
        }
    }
}
