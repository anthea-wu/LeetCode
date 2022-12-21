using System.Collections;

namespace LeetCode.Test;

[TestFixture]
public class MergeTwoSortedListsTests
{
    private MergeTwoSortedLists _mergeTwoSortedLists;

    [SetUp]
    public void Setup()
    {
        _mergeTwoSortedLists = new MergeTwoSortedLists();
    }

    [TestCaseSource(nameof(MergeTwoSortedListsFirstTimeTestCasesData))]
    public void do_first_time(List<int> ints1, List<int> ints2, List<int> expected)
    {
        var listNodes1 = CreateListNodes(ints1);
        var listNodes2 = CreateListNodes(ints2);

        var listNodes = _mergeTwoSortedLists.DoFirstTime(listNodes1, listNodes2);
        var result = GetAllNodes(listNodes);
        Assert.AreEqual(expected.Count, result.Count);
        for (int i = 0; i < result.Count; i++)
        {
            Assert.AreEqual(expected[i], result[i]);
        }
    }

    private List<int> GetAllNodes(ListNode listNodes)
    {
        var list = new List<int>();
        while (listNodes != null)
        {
            list.Add(listNodes.val);
            listNodes = listNodes.next;
        }
        return list;
    }

    private ListNode CreateListNodes(List<int> ints)
    {
        ListNode lastListNode = null;
        for (var i = ints.Count - 1; i > -1; i--)
        {
            lastListNode = new ListNode(ints[i], lastListNode);
        }

        return lastListNode;
    }

    public static IEnumerable MergeTwoSortedListsFirstTimeTestCasesData
    {
        get
        {
            yield return new TestCaseData(new List<int>(){ 1,2,4 }, new List<int>(){ 1,3,4 }, new List<int>(){ 1, 1, 2, 3, 4, 4 });
            yield return new TestCaseData(new List<int>(){}, new List<int>(){}, new List<int>(){});
            yield return new TestCaseData(new List<int>(){}, new List<int>(){ 0 }, new List<int>(){ 0 });
        }
    }
}