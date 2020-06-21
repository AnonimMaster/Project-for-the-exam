using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : CollectionsItems
{
    public override void Collection()
    {
        Data.Score += 5;
        Destroy(this.gameObject);
    }
}
