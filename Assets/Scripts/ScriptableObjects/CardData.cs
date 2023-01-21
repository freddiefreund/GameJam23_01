using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "CardData", menuName = "ScriptableObjects/CardData", order = 1)]
    public class CardData : ScriptableObject
    {
        public string cardName;
        public Sprite backgroundImage;
        public string descriptionText;
    }
}
