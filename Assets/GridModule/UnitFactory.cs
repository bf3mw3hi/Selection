using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitFactory : MonoBehaviour
{
    public Unit Prototype;
    public Map Map;
    public TurnManager turnManager;

    public List<ResourceCost> Costs;

    // Temporary until we figure out a better way to decide where to spawn.
    public Text inputX;
    public Text inputY;
    public void SpawnUnit()
    {

        bool canAfford = true;
        for (int i = 0; i < Costs.Count; i++)
        {
            if (!Costs[i].CanAfford())
            {
                canAfford = false;
            }
        }


        if (canAfford)
        {
            for (int i = 0; i < Costs.Count; i++)
            {
                Costs[i].Pay();
            }

            Unit newUnit = Instantiate(Prototype);
            //transform.root.gameObject.activeSelf
            Debug.Log(this.gameObject.activeSelf.ToString());
            if (turnManager.GetPlayerTurn() == 0)
            {
                newUnit.GetComponentInChildren<Renderer>().material.color = Color.blue;
            }
            Cell cell = Map.GetCell(Convert.ToInt32(inputX.text), Convert.ToInt32(inputY.text));
            newUnit.transform.SetParent(cell.transform, false);
        }
        else
        {
            Debug.Log("Not enough resources!");
        }

    }

    [System.Serializable]
    public class ResourceCost
    {
        public Resource Resource;
        public int Cost;

        public bool CanAfford()
        {
            return Resource.CanAfford(Cost);
        }

        public void Pay()
        {
            Resource.RemoveAmount(Cost);
        }

    }
}