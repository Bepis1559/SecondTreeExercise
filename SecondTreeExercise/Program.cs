// See https://aka.ms/new-console-template for more information
using SecondTreeExercise;
using System;
BinarySearchTree tree = new();
List<int> treeNums = [7, 6, 2, 3, 8, 10, 9, 11];
treeNums.ForEach(tree.Insert);
tree.InorderTraversal();
//tree.DeleteNode(10);
Console.WriteLine("\nA node was deleted");
tree.InorderTraversal();

//Console.WriteLine(tree.GetParentNode(8)?.Data);