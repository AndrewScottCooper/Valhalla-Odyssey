using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingClick : MonoBehaviour
{
    public Canvas canvas;
    public BuildingType building;

    private void OnMouseDown()
    {
        if (building == BuildingType.Meadhall) {
            canvas.GetComponent<PlayerUI>().MeadHallDisplay();
        }
        else if (building == BuildingType.Shipyard)
        {
            canvas.GetComponent<PlayerUI>().ShipyardDisplay();
        }
        else if (building == BuildingType.Bowyer)
        {
            canvas.GetComponent<PlayerUI>().BowyerDisplay();
        }
        else if (building == BuildingType.Blacksmith)
        {
            canvas.GetComponent<PlayerUI>().BlacksmithDisplay();
        }
    }

    public enum BuildingType
    {
        Meadhall,
        Shipyard,
        Bowyer,
        Blacksmith
    }
}

