using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEventNotifier : MonoBehaviour
{
    public delegate void PickupABonusEvent(enums.BonusType Bonus);

    public static event PickupABonusEvent PickupABonus;

    public static void OnPickupABonus(enums.BonusType bonus)
    {
        if(PickupABonus != null)
        {
            PickupABonus(bonus);
        }
    }
}
