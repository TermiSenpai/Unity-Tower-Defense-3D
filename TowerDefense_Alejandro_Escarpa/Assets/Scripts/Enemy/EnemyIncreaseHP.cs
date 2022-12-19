using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIncreaseHP : MonoBehaviour
{
    public int HPIncreasedPerRound = 1;

    public void IncreaseHP()
    {
        HPIncreasedPerRound *= 2;
    }

    public int GetIncreasedHP()
    {
        return HPIncreasedPerRound;
    }
}
