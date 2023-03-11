using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Body", menuName = "ScriptableObjects/CharacterPart/Body", order = 1)]
public class CharacterBody : CharacterPart
{
    public float hp;
    public float bodyDefense;
}
