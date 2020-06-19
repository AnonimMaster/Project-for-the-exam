using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : CollectionsItems
{
    public override void Collection()
    {
        Data.Score+=15;
        Destroy(this.gameObject);
    }
}
