using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendsListPopulate : MonoBehaviour
{
    // The number of items to create
    [SerializeField] int itemCount = 5;
    // Each list item will be of this type
    [SerializeField] ListItem itemPrefab;
    // Object that items should be inserted into
    [SerializeField] RectTransform itemContainer;
    [SerializeField] RectTransform FriendsList;
    private void Awake()
    {
        FriendsList.GetComponent<CanvasGroup>().alpha = 0;
    }
    void Start()
    {
        // Create as many items as needed to
        for (int i = 0; i < itemCount; i++)
        {
            var label = string.Format("Friend {0}", i);
            // Create each new item
            CreateNewListItem(label);
        }
    }

    public void CreateNewListItem(string label)
    {
        var newItem = Instantiate(itemPrefab);

        // Place in container; tell it to not keep the current position/scale

        newItem.transform.SetParent(
            itemContainer,
            worldPositionStays: false);
        // Give it a label
        newItem.Label = label;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
