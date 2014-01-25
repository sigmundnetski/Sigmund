using System;
using UnityEngine;

public class TournamentTest : MonoBehaviour
{
    private void Start()
    {
        GameStrings.LoadCategory(GameStringCategory.GLOBAL);
        GameStrings.LoadCategory(GameStringCategory.GLUE);
    }
}

