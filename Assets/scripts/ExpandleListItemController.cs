using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandleListItemController : MonoBehaviour
{
    [SerializeField] private Transform itemContent;

    public void AddListItem(Transform listItem)
    {
        listItem.parent = itemContent;
    }
}
