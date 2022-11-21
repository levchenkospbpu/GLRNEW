using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AccessManager
{
    public static void GenerateAccesToken()
    {
        PlayerPrefs.SetString(PlayerPrefsKeys.AccesToken, Random.Range(0,100).ToString());
    }
}
