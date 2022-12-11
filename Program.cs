
using System.Collections.Generic;

static List<int> DividingList(List<int> originalList) // Recursion function - dividing the original list until 1 number each list (left and rigth)
{
    if (originalList.Count <= 1)  // Stopping conditions - when list becomes 1 element
        return originalList;

    List<int> left = new List<int>(); // Creation - left list
    List<int> right = new List<int>(); // Creation - right list

    int middle = originalList.Count / 2; // Finding - middle of list
    for (int i = 0; i < middle; i++)  // Dividing list - take the left side
        left.Add(originalList[i]);
    for (int i = middle; i < originalList.Count; i++) // Dividing list - take the right side
        right.Add(originalList[i]);

    left = DividingList(left); // (Recursion) Sending - smaller left list 
    right = DividingList(right); // (Recursion) Sending - smaller right list
    return Merge(left, right); // Sending to Merge - lists after dividing
}

static List<int> Merge(List<int> left, List<int> right) // Merge function - left list with rigth list, and add to result
{
    List<int> result = new List<int>(); //Creation - result list

    while (left.Count > 0 || right.Count > 0) // Stopping conditions - as long as there is an element in 1 of the lists
    {
        if (left.Count > 0 && right.Count > 0) // Case 1 - there is elemnts in the lists, we need compare
        {
            if (left.First() <= right.First())  // Compare - between 2 elemnts 
            {
                result.Add(left.First()); // Add the smaller to result
                left.Remove(left.First()); // Delete the smaller from left and the bigger now first
            }
            else
            {
                result.Add(right.First()); // Add the smaller to result
                right.Remove(right.First()); // Delete the smaller from rigth and the bigger now first
            }
        }
        else if (left.Count > 0) // Case 2 - in left there is one elment to compare (After all the comparisons)
        {
            result.Add(left.First()); // add the elemnt to result
            left.Remove(left.First()); // Delete the elemnt from left
        }
        else if (right.Count > 0) // Case 3 - in right there is one elment to compare (After all the comparisons)
        {
            result.Add(right.First()); // add the elemnt to result
            right.Remove(right.First()); // Delete the elemnt from rigth
        }
    }
    return result; // Return result
}

// Main

List<int> originalList = new List<int>(); // Creation - original list
List<int> sorted; // Creation - sort list

Random random = new Random(); // Creation - random

Console.WriteLine("Original array elements:");
for (int i = 0; i < 10; i++) // Addition and Writing - original list
{
    originalList.Add(random.Next(-100, 100)); // Addition - random numbers between -100 to 100
    Console.Write(originalList[i] + " "); // Write the original list
}
Console.WriteLine();

sorted = DividingList(originalList); // Sending - dividing the original list

Console.WriteLine("Sorted array elements: ");
foreach (int x in sorted) // Writing - sorted list
    Console.Write(x + " ");
Console.WriteLine();
