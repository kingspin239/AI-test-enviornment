using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameEnviornment
{
    private static GameEnviornment instance;
    private List<GameObject> checkpoints = new List<GameObject>();
    public List<GameObject> _checkpoints { get { return checkpoints; } }
     public static GameEnviornment Singleton
    {
        get
        {
            if(instance == null)
            {
                instance = new GameEnviornment();
                instance._checkpoints.AddRange(GameObject.FindGameObjectsWithTag("Checkpoint"));
            }
            return instance;
        }
    }
}
