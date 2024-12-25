using System;

class CountingSort
{
    
    public static void PerformCountingSort(int[] array)
    {
        
        int max = FindMax(array);

        
        int[] count = new int[max + 1];

        for (int i = 0; i < array.Length; i++)
        {
            count[array[i]]++;
        }

       
        for (int i = 1; i < count.Length; i++)
        {
            count[i] += count[i - 1];
        }

        int[] output = new int[array.Length];

       
        for (int i = array.Length - 1; i >= 0; i--)
        {
            output[count[array[i]] - 1] = array[i];
            count[array[i]]--;
        }

        
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = output[i];
        }
    }


    private static int FindMax(int[] array)
    {
        int max = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
            }
        }
        return max;
    }

   
    static void Main(string[] args)
    {
        int[] array = { 4, 2, 2, 8, 3, 3, 1 };

        Console.WriteLine("Original Array:");
        Console.WriteLine(string.Join(" ", array));

        PerformCountingSort(array);

        Console.WriteLine("\nSorted Array:");
        Console.WriteLine(string.Join(" ", array));
    }

}


class PrimsAlgorithm
{
    
    public static void PrimMST(int[,] graph, int verticesCount)
    {
        
        int[] parent = new int[verticesCount];
        
        int[] key = new int[verticesCount];
        
        bool[] mstSet = new bool[verticesCount];

        
        for (int i = 0; i < verticesCount; i++)
        {
            key[i] = int.MaxValue;
            mstSet[i] = false;
        }

       
        key[0] = 0; 
        parent[0] = -1; 

        
        for (int count = 0; count < verticesCount - 1; count++)
        {
            
            int u = MinKey(key, mstSet, verticesCount);

            
            mstSet[u] = true;

            
            for (int v = 0; v < verticesCount; v++)
            {
                
                if (graph[u, v] != 0 && !mstSet[v] && graph[u, v] < key[v])
                {
                    parent[v] = u;
                    key[v] = graph[u, v];
                }
            }
        }

        
        PrintMST(parent, graph, verticesCount);
    }

    
    private static int MinKey(int[] key, bool[] mstSet, int verticesCount)
    {
        int min = int.MaxValue, minIndex = -1;

        for (int v = 0; v < verticesCount; v++)
        {
            if (!mstSet[v] && key[v] < min)
            {
                min = key[v];
                minIndex = v;
            }
        }

        return minIndex;
    }

    
    private static void PrintMST(int[] parent, int[,] graph, int verticesCount)
    {
        Console.WriteLine("Edge \tWeight");
        for (int i = 1; i < verticesCount; i++)
        {
            Console.WriteLine($"{parent[i]} - {i} \t{graph[i, parent[i]]}");
        }
    }

    static void Main(string[] args)
    {
        
        int[,] graph = new int[,]
        {
            { 0, 2, 0, 6, 0 },
            { 2, 0, 3, 8, 5 },
            { 0, 3, 0, 0, 7 },
            { 6, 8, 0, 0, 9 },
            { 0, 5, 7, 9, 0 }
        };

        int verticesCount = graph.GetLength(0);
        PrimMST(graph, verticesCount);
    }
}