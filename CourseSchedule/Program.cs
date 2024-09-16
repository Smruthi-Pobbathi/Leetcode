/* Leetcode(207) - Course Schedule:
 There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. 
 You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must take course bi first if you want to take course ai.
 For example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.
 Return true if you can finish all courses. Otherwise, return false.
*/
using System;
using System.Collections.Generic;
using System.Linq;

public class CourseSchedule
{
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        // Create adjacency list to represent the course dependencies
        List<List<int>> adjList = new List<List<int>>();
        for (int i = 0; i < numCourses; i++)
        {
            adjList.Add(new List<int>());
        }

        // Populate adjacency list with prerequisites
        foreach (int[] prerequisite in prerequisites)
        {
            int course = prerequisite[0];
            int prerequisiteCourse = prerequisite[1];
            adjList[prerequisiteCourse].Add(course);
        }

        // Create visited and recursion stack arrays
        bool[] visited = new bool[numCourses];
        bool[] recursionStack = new bool[numCourses];

        // Check for cycle in each course using DFS
        for (int course = 0; course < numCourses; course++)
        {
            if (HasCycle(course, adjList, visited, recursionStack))
            {
                return false; // Cycle found, cannot finish all courses
            }
        }

        return true; // No cycle found, can finish all courses
    }

    private bool HasCycle(int course, List<List<int>> adjList, bool[] visited, bool[] recursionStack)
    {
        // If the course is already in the recursion stack, a cycle is found
        if (recursionStack[course])
        {
            return true;
        }

        // If the course has been visited, no need to process it again
        if (visited[course])
        {
            return false;
        }

        // Mark the course as visited and add it to the recursion stack
        visited[course] = true;
        recursionStack[course] = true;

        // Traverse the prerequisites of the current course
        foreach (int nextCourse in adjList[course])
        {
            if (HasCycle(nextCourse, adjList, visited, recursionStack))
            {
                return true;
            }
        }

        // Remove the course from the recursion stack
        recursionStack[course] = false;

        return false;
    }
}

public class TestCourseSchedule
{
    public static void Main(string[] args)
    {
        CourseSchedule cs = new CourseSchedule();

        // Test cases
        Console.WriteLine("Test Case 1: Input = (2, [[1, 0]]), Expected Output = True, Actual Output = " + cs.CanFinish(2, new int[][] { new int[] { 1, 0 } }));
        Console.WriteLine("Test Case 2: Input = (2, [[1, 0], [0, 1]]), Expected Output = False, Actual Output = " + cs.CanFinish(2, new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 } }));
        Console.WriteLine("Test Case 3: Input = (4, [[1, 0], [2, 1], [3, 2]]), Expected Output = True, Actual Output = " + cs.CanFinish(4, new int[][] { new int[] { 1, 0 }, new int[] { 2, 1 }, new int[] { 3, 2 } }));
        Console.WriteLine("Test Case 4: Input = (3, [[0, 1], [1, 2], [2, 0]]), Expected Output = False, Actual Output = " + cs.CanFinish(3, new int[][] { new int[] { 0, 1 }, new int[] { 1, 2 }, new int[] { 2, 0 } }));
        Console.WriteLine("Test Case 5: Input = (5, [[0, 1], [1, 2], [2, 3], [3, 4]]), Expected Output = True, Actual Output = " + cs.CanFinish(5, new int[][] { new int[] { 0, 1 }, new int[] { 1, 2 }, new int[] { 2, 3 }, new int[] { 3, 4 } }));
    }
}
