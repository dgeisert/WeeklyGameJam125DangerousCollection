using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : ElementObject
{
    public static List<Water> waters = new List<Water>();
    // Start is called before the first frame update
    void Start()
    {
        bool add = true;
        foreach (Plant p in Plant.plants)
        {
            if (Vector3.Distance(p.transform.position, transform.position) < 2)
            {
                p.transform.localScale += Vector3.one;
                add = false;
                Destroy(gameObject);
            }
        }
        if (add)
        {
            waters.Add(this);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}