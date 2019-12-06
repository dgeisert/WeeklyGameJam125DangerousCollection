using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : ElementObject
{
    public static List<Plant> plants = new List<Plant>();
    void Start()
    {
        List<Water> removeWater = new List<Water>();
        foreach (Water w in Water.waters)
        {
            if (Vector3.Distance(w.transform.position, transform.position) < 2)
            {
                transform.localScale += Vector3.one;
                removeWater.Add(w);
            }
        }
        foreach (Water w in removeWater)
        {
            Water.waters.Remove(w);
            Destroy(w.gameObject);
        }
        bool add = true;
        foreach (Fire f in Fire.fires)
        {
            if (Vector3.Distance(f.transform.position, transform.position) < 2)
            {
                f.transform.localScale += transform.localScale;
                add = false;
                Destroy(gameObject);
            }
        }
        if (add)
        {
            plants.Add(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x > 0.6f && Random.value < Time.deltaTime / 20 && Mathf.Abs(transform.position.x) < 14 && Mathf.Abs(transform.position.z) < 14)
        {
            Instantiate(gameObject,
                transform.position + new Vector3((Random.value - 0.5f), (Random.value - 0.5f), (Random.value - 0.5f)),
                Quaternion.Euler(transform.eulerAngles + Random.value * 360 * Vector3.up)
            ).transform.localScale = Vector3.one * 0.2f;
        }
        transform.localScale += Vector3.one * Time.deltaTime * 0.01f;
    }
}