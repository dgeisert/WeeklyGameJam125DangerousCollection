using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : ElementObject
{
    public static List<Rock> rocks = new List<Rock>();
    // Start is called before the first frame update
    void Start()
    {
        rocks.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
