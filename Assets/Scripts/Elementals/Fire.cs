using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : ElementObject
{
    public static List<Fire> fires = new List<Fire>();
    // Start is called before the first frame update
    void Start()
    {
        fires.Add(this);
        List<Plant> removePlants = new List<Plant>();
        foreach (Plant p in Plant.plants)
        {
            if (Vector3.Distance(p.transform.position, transform.position) < 2)
            {
                transform.localScale += p.transform.localScale;
                removePlants.Add(p);
            }
        }
        foreach (Plant p in removePlants)
        {
            Plant.plants.Remove(p);
            Destroy(p.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.value < Time.deltaTime / 10 && Mathf.Abs(transform.position.x) < 14 && Mathf.Abs(transform.position.z) < 14)
        {
            Instantiate(gameObject, transform.position + new Vector3((Random.value - 0.5f), (Random.value - 0.5f), (Random.value - 0.5f)), Quaternion.Euler(transform.eulerAngles + Random.value * 360 * Vector3.up));
        }
        transform.localScale -= Vector3.one * Time.deltaTime * 0.01f;
        if (transform.localScale.x < 0.1f)
        {
            fires.Remove(this);
            Destroy(gameObject);
        }
    }
}