namespace LeetCode;

public class MergeTwoSortedLists
{
    public ListNode DoFirstTime(ListNode list1, ListNode list2)
    {
        if (list1 == null && list2 == null) return null;
        
        var min = GetMinNode(ref list1, ref list2);
        var head = new ListNode(min);
        var current = head;
        while (list1 != null || list2 != null)
        {
            var nextMin = GetMinNode(ref list1, ref list2);
            current.next = new ListNode(nextMin);
            current = current.next;
        }
        
        return head;
    }

    private static int GetMinNode(ref ListNode list1, ref ListNode list2)
    {
        int min;
        if (list1 == null)
        {
            min = list2.val;
            list2 = list2.next;
        }
        else if (list2 == null)
        {
            min = list1.val;
            list1 = list1.next;
        }
        else if (list1.val < list2.val)
        {
            min = list1.val;
            list1 = list1.next;
        }
        else
        {
            min = list2.val;
            list2 = list2.next;
        }

        return min;
    }
}

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}