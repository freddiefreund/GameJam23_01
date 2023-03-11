using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Arms", menuName = "ScriptableObjects/CharacterPart/Arms", order = 2)]
public class CharacterArms : CharacterPart
{
    public Sprite sprite2;
    public float attackBonus;
    public float speedModifier;
}
