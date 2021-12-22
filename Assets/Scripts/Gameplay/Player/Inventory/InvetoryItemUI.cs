using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InvetoryItemUI : MonoBehaviour, IDropHandler
{
    public int id;
    private ResourceData _item;
    public ResourceData Item => _item;
    public bool HasItem => _item != null;

    [SerializeField] private Image itemImage;
    [SerializeField] private Image topImage;
    public UIItem uiItem { get; private set; }
    public InventoryUI inventoryUI;

    private void Start()
    {
        uiItem = itemImage.GetComponent<UIItem>();
        // uiItem.cell = this;
    }
    public void SetItem(ResourceData item)
    {
        _item = item;
        if (item is Item temp)
        {
            itemImage.sprite = temp.bottomSprite;
            itemImage.enabled = true;
            topImage.sprite = temp.topSprite;
            topImage.enabled = true;
            return;
        }
        itemImage.enabled = true;
        itemImage.sprite = item.sprite;
    }

    public void ClearItem()
    {
        _item = null;
        topImage.enabled = false;
        itemImage.enabled = false;
    }

    public void OnDrop(PointerEventData eventData)
    {
        inventoryUI.HandleDropToCell(this);
    }
}
