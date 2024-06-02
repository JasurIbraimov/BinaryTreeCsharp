using BinaryTree;

Tree<int> tree1 = new Tree<int>();
int[] values1 = { 11, 19, 17, 6, 4, 8, 43, 31, 10, 5, 49 };
foreach (int value in values1)
{
    tree1.Insert(value);
}

Tree<int> tree2 = new Tree<int>();
int[] values2 = { 8, 11, 17, 19, 31, 43, 6, 5, 4, 10, 49 };
foreach (int value in values2)
{
    tree2.Insert(value);
}

Console.WriteLine("Tree1 Height: " + tree1.Height());

Console.WriteLine("Tree1 contains 8: " + tree1.Contains(8));
Console.WriteLine("Tree1 contains 100: " + tree1.Contains(100));

Console.WriteLine("Tree1 Min Value: " + tree1.Min());
Console.WriteLine("Tree1 Max Value: " + tree1.Max());

Console.WriteLine("Tree1 Sum of Values: " + tree1.Sum());

// Transform tree1 to descending order and display the new root values
tree1.TransformToDescendingOrder();
Console.WriteLine("Tree1 Root after Descending Order Transform: " + tree1.Root?.Data);
Console.WriteLine("Tree1 Root Left after Descending Order Transform: " + tree1.Root?.Left?.Data);
Console.WriteLine("Tree1 Root Right after Descending Order Transform: " + tree1.Root?.Right?.Data);

// Find the path to a number in tree1
string? pathTo8 = tree1.PathToNumber(8);
if (pathTo8 != null)
{
    Console.WriteLine("Path to 8 in Tree1: " + pathTo8);
}
else
{
    Console.WriteLine("Value 8 not found in Tree1.");
}

// Find the number for a given path in tree1
try
{
    Console.WriteLine("Number for Path /L/L/L/L/L/L/L/8 in Tree1: " + tree1.NumberForPath("/L/L/L/L/L/L/L/8"));
}
catch (InvalidPathException ex)
{
    Console.WriteLine("Caught an InvalidPathException: " + ex.Message);
}

try
{
    Console.WriteLine("Number for Invalid Path /L/R/R in Tree1: " + tree1.NumberForPath("/L/R/R"));
}
catch (InvalidPathException ex)
{
    Console.WriteLine("Caught an InvalidPathException: " + ex.Message);
}
