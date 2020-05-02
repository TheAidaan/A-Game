using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAbility : MonoBehaviour
{

    public LayerMask layermask;
    
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, 25, layermask))
        {
            hit.collider.gameObject.GetComponent<Cube>().isHovered();
        }
    }
}
