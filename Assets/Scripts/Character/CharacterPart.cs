using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Element
{
    Normal = 0,
    Plant,
    Fire,
    Water
}
public class CharacterPart : ScriptableObject
{
    public Sprite sprite;
    public Element element;
}
