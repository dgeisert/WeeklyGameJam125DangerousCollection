using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public List<Tool> nearbyTools = new List<Tool>();
    public List<ElementObject> nearbyObjects = new List<ElementObject>();
    public Tool heldTool;
    public Transform toolPos;
    int layerMask = 1 << 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Controls.Forward && !Controls.Back)
        {
            transform.position += Vector3.forward * Time.deltaTime * speed;
        }
        else if (Controls.Back && !Controls.Forward)
        {
            transform.position -= Vector3.forward * Time.deltaTime * speed;
        }
        if (Controls.Right && !Controls.Left)
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
        }
        else if (Controls.Left && !Controls.Right)
        {
            transform.position -= Vector3.right * Time.deltaTime * speed;
        }

        if (Controls.PickUpDrop)
        {
            PickUpDrop();
        }
        if (Controls.Interact)
        {
            Interact();
        }

        Look();
    }

    public void PickUpDrop()
    {
        if (heldTool == null)
        {
            if (nearbyTools != null && nearbyTools.Count > 0)
            {
                Tool near = nearbyTools[0];
                foreach (Tool t in nearbyTools)
                {
                    if (Vector3.Distance(transform.position, t.transform.position) < Vector3.Distance(transform.position, near.transform.position))
                    {
                        near = t;
                    }
                }
                heldTool = near;
                heldTool.GetComponent<Collider>().enabled = false;
                near.transform.SetParent(toolPos);
                near.transform.localPosition = Vector3.zero;
                near.transform.localRotation = Quaternion.identity;
            }
        }
        else
        {
            heldTool.transform.SetParent(null);
            heldTool.GetComponent<Collider>().enabled = true;
            heldTool = null;
        }
    }
    public void Interact()
    {
        if (heldTool != null)
        {
            if (nearbyObjects != null && nearbyObjects.Count > 0)
            {
                foreach (ElementObject eo in nearbyObjects)
                {
                    if (heldTool.type == eo.type)
                    {
                        RemoveObject(eo);
                    }
                }
            }
        }
    }

    public void Look()
    {
        RaycastHit hit = GetMousePoint();
        transform.LookAt(hit.point);
    }

    public RaycastHit GetMousePoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 50f, layerMask))
        {
            Transform objectHit = hit.transform;
        }
        return hit;
    }

    public void RemoveObject(ElementObject elementObject)
    {
        if (heldTool == null || heldTool.type != elementObject.type)
        {
            return;
        }
        switch (elementObject.type)
        {
            case 0:
                Fire.fires.Remove(elementObject.GetComponent<Fire>());
                break;
            case 1:
                Plant.plants.Remove(elementObject.GetComponent<Plant>());
                break;
            case 2:
                Rock.rocks.Remove(elementObject.GetComponent<Rock>());
                break;
            case 3:
                Water.waters.Remove(elementObject.GetComponent<Water>());
                break;
            default:
                break;
        }
        nearbyObjects.Remove(elementObject);
        Destroy(elementObject.gameObject);
    }
}