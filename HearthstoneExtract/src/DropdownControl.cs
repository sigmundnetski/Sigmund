using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DropdownControl : PegUIElement
{
    [CompilerGenerated]
    private static itemChosenCallback <>f__am$cache8;
    [CompilerGenerated]
    private static menuShownCallback <>f__am$cache9;
    [CompilerGenerated]
    private static itemChosenCallback <>f__am$cacheA;
    public DropdownButton m_button;
    public DropdownCancelCatcher m_cancelCatcher;
    private itemChosenCallback m_itemChosenCallback;
    private List<DropdownMenuItem> m_items;
    private itemTextCallback m_itemTextCallback;
    public DropdownMenu m_menu;
    private menuShownCallback m_menuShownCallback;
    public DropdownMenuItem m_selectedItem;

    public DropdownControl()
    {
        if (<>f__am$cache8 == null)
        {
            <>f__am$cache8 = new itemChosenCallback(DropdownControl.<m_itemChosenCallback>m__3C);
        }
        this.m_itemChosenCallback = <>f__am$cache8;
        this.m_itemTextCallback = new itemTextCallback(DropdownControl.defaultItemTextCallback);
        if (<>f__am$cache9 == null)
        {
            <>f__am$cache9 = new menuShownCallback(DropdownControl.<m_menuShownCallback>m__3D);
        }
        this.m_menuShownCallback = <>f__am$cache9;
        this.m_items = new List<DropdownMenuItem>();
    }

    [CompilerGenerated]
    private static void <m_itemChosenCallback>m__3C(object, object)
    {
    }

    [CompilerGenerated]
    private static void <m_menuShownCallback>m__3D(bool)
    {
    }

    public void addItem(object value)
    {
        DropdownMenuItem item = (DropdownMenuItem) UnityEngine.Object.Instantiate(this.m_menu.m_itemTemplate);
        this.m_items.Add(item);
        item.transform.parent = this.m_menu.m_itemTemplate.transform.parent;
        this.layoutMenu();
        item.SetValue(value, this.m_itemTextCallback(value));
        item.click += new DropdownMenuItem.handleClick(this.onUserItemClicked);
        item.gameObject.SetActive(true);
    }

    public void clearItems()
    {
        foreach (DropdownMenuItem item in this.m_items)
        {
            UnityEngine.Object.Destroy(item.gameObject);
        }
        this.layoutMenu();
    }

    public static string defaultItemTextCallback(object val)
    {
        return ((val != null) ? val.ToString() : string.Empty);
    }

    private DropdownMenuItem findItem(object value)
    {
        for (int i = 0; i < this.m_items.Count; i++)
        {
            DropdownMenuItem item = this.m_items[i];
            if (item.GetValue() == value)
            {
                return item;
            }
        }
        return null;
    }

    private int findItemIndex(object value)
    {
        for (int i = 0; i < this.m_items.Count; i++)
        {
            DropdownMenuItem item = this.m_items[i];
            if (item.GetValue() == value)
            {
                return i;
            }
        }
        return -1;
    }

    public itemChosenCallback getItemChosenCallback()
    {
        return this.m_itemChosenCallback;
    }

    public itemTextCallback getItemTextCallback()
    {
        return this.m_itemTextCallback;
    }

    public menuShownCallback getMenuShownCallback()
    {
        return this.m_menuShownCallback;
    }

    public object getSelection()
    {
        return this.m_selectedItem.GetValue();
    }

    private void hideMenu()
    {
        this.m_cancelCatcher.gameObject.SetActive(false);
        this.m_menu.gameObject.SetActive(false);
        this.m_menuShownCallback(false);
    }

    public bool isMenuShown()
    {
        return this.m_menu.gameObject.activeInHierarchy;
    }

    private void layoutMenu()
    {
        this.m_menu.gameObject.SetActive(true);
        this.m_menu.m_itemTemplate.gameObject.SetActive(true);
        float z = this.m_menu.m_itemTemplate.GetComponent<BoxCollider>().size.y * this.m_menu.m_itemTemplate.transform.localScale.y;
        this.m_menu.m_itemTemplate.gameObject.SetActive(false);
        if (this.m_items.Count > 1)
        {
            Transform transform = this.m_menu.m_bottom.transform;
            transform.localPosition += new Vector3(0f, 0f, z);
            Transform transform2 = this.m_menu.m_middle.transform;
            transform2.localScale += new Vector3(0f, 0f, z * 0.35f);
        }
        this.m_menu.gameObject.SetActive(false);
        for (int i = 0; i < this.m_items.Count; i++)
        {
            DropdownMenuItem item = this.m_items[i];
            Vector3 vector = new Vector3(0f, 0f, i * z);
            item.transform.localPosition = this.m_menu.m_itemTemplate.transform.localPosition + vector;
            item.transform.localScale = this.m_menu.m_itemTemplate.transform.localScale;
            item.transform.localEulerAngles = this.m_menu.m_itemTemplate.transform.localEulerAngles;
        }
    }

    public void onUserCancelled()
    {
        this.hideMenu();
    }

    public void onUserItemClicked(DropdownMenuItem item)
    {
        this.hideMenu();
        object prevSelection = this.getSelection();
        object val = item.GetValue();
        this.setSelection(val);
        this.m_itemChosenCallback(val, prevSelection);
    }

    public void onUserPressedButton()
    {
        this.showMenu();
    }

    public void onUserPressedSelection(DropdownMenuItem item)
    {
        this.showMenu();
    }

    public bool removeItem(object value)
    {
        int index = this.findItemIndex(value);
        if (index < 0)
        {
            return false;
        }
        DropdownMenuItem item = this.m_items[index];
        this.m_items.RemoveAt(index);
        UnityEngine.Object.Destroy(item.gameObject);
        this.layoutMenu();
        return true;
    }

    public void setItemChosenCallback(itemChosenCallback callback)
    {
        // This item is obfuscated and can not be translated.
        if (callback != null)
        {
            goto Label_0026;
        }
        if (<>f__am$cacheA == null)
        {
            <>f__am$cacheA = delegate {
            };
        }
        this.m_itemChosenCallback = <>f__am$cacheA;
    }

    public void setItemTextCallback(itemTextCallback callback)
    {
        // This item is obfuscated and can not be translated.
        if (callback != null)
        {
            goto Label_0015;
        }
        this.m_itemTextCallback = new itemTextCallback(DropdownControl.defaultItemTextCallback);
    }

    public void setMenuShownCallback(menuShownCallback callback)
    {
        this.m_menuShownCallback = callback;
    }

    public void setSelection(object val)
    {
        this.m_selectedItem.SetValue(null, string.Empty);
        for (int i = 0; i < this.m_items.Count; i++)
        {
            DropdownMenuItem item = this.m_items[i];
            object obj2 = item.GetValue();
            if (((obj2 == null) && (val == null)) || obj2.Equals(val))
            {
                item.SetSelected(true);
                this.m_selectedItem.SetValue(obj2, this.m_itemTextCallback(obj2));
            }
            else
            {
                item.SetSelected(false);
            }
        }
    }

    private void showMenu()
    {
        this.m_cancelCatcher.gameObject.SetActive(true);
        this.m_menu.gameObject.SetActive(true);
        this.m_menuShownCallback(true);
    }

    public void Start()
    {
        this.m_button.click += new DropdownButton.HandleClick(this.onUserPressedButton);
        this.m_selectedItem.click += new DropdownMenuItem.handleClick(this.onUserPressedSelection);
        this.m_cancelCatcher.click += new DropdownCancelCatcher.HandleClick(this.onUserCancelled);
        this.hideMenu();
    }

    public delegate void itemChosenCallback(object selection, object prevSelection);

    public delegate string itemTextCallback(object val);

    public delegate void menuShownCallback(bool shown);
}

