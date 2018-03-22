using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{

    public LayerMask unit;
    public LayerMask tile;
    public Map map;
    GameObject selectedUnit;
    Color color;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (selectedUnit != null)
            {
                Debug.Log(selectedUnit.name);
            }            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow, 5);
            if (Physics.Raycast(ray, out raycastHit, Mathf.Infinity, tile))
            {
                //Debug.Log("tile");
                if (selectedUnit != null)
                {
                    Debug.Log("Not Null");
                    if (selectedUnit.name == "Visual")
                    {
                        MoveUnit(raycastHit.transform.gameObject);
                    }
                    
                }
            }           
            else if (Physics.Raycast(ray, out raycastHit, Mathf.Infinity, unit))
            {
                Deselect();
                Debug.Log(raycastHit.transform.parent.gameObject);
                SelectUnit(raycastHit.transform.parent.gameObject);
            }
            else
            {
                Deselect();
            }

        }
    }
    void MoveUnit(GameObject selectedTile)
    {
        if (selectedUnit != null)
        {
            Debug.Log("object is not null");
            Debug.Log(selectedTile);
            //Debug.Log(selectedTile.);
            Debug.Log(selectedTile.GetComponentInParent<Cell>());
            Cell cell = selectedTile.GetComponentInParent<Cell>();
            Debug.Log(cell.X + " " + cell.Y);
            selectedUnit.transform.SetParent(cell.transform, false);
        }
    }

    void Deselect()
    {
        if (selectedUnit == null)
        {
            Debug.Log("unit = null");
            return;
        }
        else
        {
            selectedUnit.GetComponent<MeshRenderer>().material.color = color;
            selectedUnit = null;
        }
    }
    void SelectUnit(GameObject selected)
    {
        selectedUnit = selected;
        color = selectedUnit.GetComponent<MeshRenderer>().material.color;
        selectedUnit.GetComponent<MeshRenderer>().material.color = Color.black;
    }
}
