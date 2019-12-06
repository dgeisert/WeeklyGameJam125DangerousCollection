using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public static Controls Instance;
    public static bool Forward
    {
        get
        {
            return Input.GetKey(KeyCode.W) ||
                Input.GetKey(KeyCode.UpArrow);
        }
    }
    public static bool Left
    {
        get
        {
            return Input.GetKey(KeyCode.A) ||
                Input.GetKey(KeyCode.LeftArrow);
        }
    }
    public static bool Right
    {
        get
        {
            return Input.GetKey(KeyCode.D) ||
                Input.GetKey(KeyCode.RightArrow);
        }
    }
    public static bool Back
    {
        get
        {
            return Input.GetKey(KeyCode.S) ||
                Input.GetKey(KeyCode.DownArrow);
        }
    }
    public static bool Interact
    {
        get
        {
            return Input.GetKeyDown(KeyCode.E) ||
                Input.GetKeyDown(KeyCode.Space) ||
                Input.GetMouseButtonDown(0);
        }
    }
    public static bool PickUpDrop
    {
        get
        {
            return Input.GetKeyDown(KeyCode.Q) ||
                Input.GetMouseButtonDown(1);
        }
    }
    public static bool Pause
    {
        get
        {
            return Input.GetKeyDown(KeyCode.P);
        }
    }
}