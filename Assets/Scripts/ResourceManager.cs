using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResourceManager
{
    public static Action<int> ResourceChanged;

    public static int CurrentResource { get; private set; }

    public static bool SpendResource(int amount)
    {
        if (amount > CurrentResource)
            return false;

        CurrentResource -= amount;
        ResourceChanged?.Invoke(CurrentResource);
        return true;
    }

    public static void GainResource(int amount)
    {
        CurrentResource += amount;
        ResourceChanged?.Invoke(CurrentResource);
    }
}
