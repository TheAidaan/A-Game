using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    bool _selected;
    public Material hover,mouse;
    Material _still;
    Renderer rend;

    bool _isHovered;

    void Awake()
    {
        rend = GetComponent<Renderer>();
        _still = rend.sharedMaterial;
    }

    void Update()
    {
        if (_isHovered && _selected)
        {
            rend.sharedMaterial = hover;
        }

        if (_isHovered && !_selected)
        {
            rend.sharedMaterial = _still;
            _isHovered = false;
        }
    }
    public void isHovered()
    {
        _isHovered = true;
    }

    public void OnMouseOver()
    {
        _selected = true;
    }

    public void OnMouseExit()
    {
        _selected = false;
    }


}
