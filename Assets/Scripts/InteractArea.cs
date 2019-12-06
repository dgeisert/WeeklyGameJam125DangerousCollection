using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractArea : MonoBehaviour
{
    Player player;

    void Start()
    {
        player = GetComponentInParent<Player>();
    }

    void OnTriggerStay(Collider col)
    {
        Tool t = col.GetComponent<Tool>();
        if (t != null)
        {
            if (player.heldTool != t && !player.nearbyTools.Contains(t))
            {
                player.nearbyTools.Add(t);
            }
        }
        ElementObject eo = col.GetComponent<ElementObject>();
        if (eo != null)
        {
            if (!player.nearbyObjects.Contains(eo))
            {
                player.nearbyObjects.Add(eo);
            }
        }
    }
    void OnTriggerLeave(Collider col)
    {
        Tool t = col.GetComponent<Tool>();
        if (t != null)
        {
            if (player.nearbyTools.Contains(t))
            {
                player.nearbyTools.Remove(t);
            }
        }
        ElementObject eo = col.GetComponent<ElementObject>();
        if (eo != null)
        {
            if (player.nearbyObjects.Contains(eo))
            {
                player.nearbyObjects.Remove(eo);
            }
        }
    }
}