using TMPro;
using UnityEngine;

public class ShoptTitle : MonoBehaviour
{
    [SerializeField] private int startResources;
    private TextMeshProUGUI _titleText;

    private void OnEnable()
    {
        ResourceManager.ResourceChanged += ChangeResourceAmount;
    }

    private void OnDisable()
    {
        ResourceManager.ResourceChanged -= ChangeResourceAmount;
    }

    private void Start()
    {
        _titleText = GetComponent<TextMeshProUGUI>();
        ResourceManager.GainResource(startResources);
        SetTextToCurrentResourceAmount();
    }

    private void SetTextToCurrentResourceAmount()
    {
        ChangeResourceAmount(ResourceManager.CurrentResource);
    }

    private void ChangeResourceAmount(int newAmount)
    {
        _titleText.text = $"Shop {newAmount}c";
    }
}
