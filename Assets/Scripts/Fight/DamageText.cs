using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textObj;

    // Start is called before the first frame update
    void Start()
    {
        transform.DOMoveY(transform.position.y + 100.0f, 3.0f).SetEase(Ease.Linear).OnComplete(() => Destroy(gameObject));
    }

    public void SetText(string text)
    {
        textObj.text = text;
    }
}
