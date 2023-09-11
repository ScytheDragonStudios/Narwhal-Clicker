using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class BonusParticle : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private TextMeshPro bonusText;

    public void Configure(int narwhalMultiplier)
    {
        bonusText.text = "+" + narwhalMultiplier;
    }

}
