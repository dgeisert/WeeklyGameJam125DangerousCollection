using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elemental : MonoBehaviour
{
    public Transform area;
    public Vector3 target;
    public float speed = 4;
    public GameObject elementObject;
    public float dropRate = 1;
    bool moving = false;
    public void Start()
    {
        SetTarget();
    }
    public void Update()
    {
        if (Random.value < 0.004 * dropRate)
        {
            DropElement();
        }
        if (Vector3.Distance(target, transform.position) < 0.5f && moving)
        {
            moving = false;
            StartCoroutine(Wait());
        }
        else
        {
            Move();
        }
    }
    public void Move()
    {
        if (moving)
        {
            transform.LookAt(target);
            transform.eulerAngles = new Vector3(-90, transform.eulerAngles.y + 90, 0);
            transform.position += (target - transform.position).normalized * Time.deltaTime * speed;
        }
    }
    public void SetTarget()
    {
        moving = true;
        target = area.position + new Vector3(area.localScale.x * (Random.value - 0.5f), 0, area.localScale.z * (Random.value - 0.5f));
    }
    public void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Wall")
        {
            moving = false;
            SetTarget();
        }
        if (col.tag == "Rock")
        {
            SetTarget();
        }
    }
    public virtual void DropElement()
    {
        Instantiate(elementObject, transform.position, transform.rotation).transform.localScale = transform.localScale;;
    }
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(Random.value * 2f);
        SetTarget();
    }
}