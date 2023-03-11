using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/CharacterPart/Weapon", order = 4)]
public class CharacterWeapon : CharacterPart
{
    public AudioClip audioClip;
    public float attackValueHead;
    public float attackValueBody;
    public float speedModifier;
}
