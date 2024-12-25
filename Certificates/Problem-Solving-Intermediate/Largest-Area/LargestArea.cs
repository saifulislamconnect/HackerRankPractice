namespace HackerRankPractice.Certificates.Problem_Solving_Intermediate.Largest_Area;

public class LargestArea
{    
     /*
      * Complete the 'getMaxArea' function below.
      *
      * The function is expected to return a LONG_INTEGER_ARRAY.
      * The function accepts following parameters:
      *  1. INTEGER w
      *  2. INTEGER h
      *  3. BOOLEAN_ARRAY isVertical
      *  4. INTEGER_ARRAY distance
      */
     public class SegmentNode
     {
         public SegmentNode Parent { get; private set; }
         public int LeftBoundary { get; private set; }
         public int RightBoundary { get; private set; }
         public SegmentNode LeftChild { get; private set; }
         public SegmentNode RightChild { get; private set; }
         public int MaxSegmentLength { get; private set; }
         private Func<int, int, int> CombineFunction;

         public SegmentNode(SegmentNode parent, int leftBoundary, int rightBoundary,
             Func<int, int, int> combineFunction = null)
         {
             Parent = parent;
             LeftBoundary = leftBoundary;
             RightBoundary = rightBoundary;
             CombineFunction = combineFunction ?? Math.Max;
             MaxSegmentLength = rightBoundary - leftBoundary;
         }

         public void Split(int position)
         {
             if (LeftBoundary <= position && position <= RightBoundary)
             {
                 if (position == LeftBoundary || position == RightBoundary)
                 {
                     // Position is on the boundary, no split needed.
                     return;
                 }

                 if (LeftChild != null)
                 {
                     if (position == LeftChild.RightBoundary)
                     {
                         // Position matches the split boundary.
                         return;
                     }

                     if (position < LeftChild.RightBoundary)
                     {
                         LeftChild.Split(position);
                     }
                     else
                     {
                         RightChild.Split(position);
                     }

                     MaxSegmentLength = CombineFunction(LeftChild.MaxSegmentLength, RightChild.MaxSegmentLength);
                 }
                 else
                 {
                     LeftChild = new SegmentNode(this, LeftBoundary, position, CombineFunction);
                     RightChild = new SegmentNode(this, position, RightBoundary, CombineFunction);
                     MaxSegmentLength = CombineFunction(position - LeftBoundary, RightBoundary - position);
                 }
             }
         }
     }

     public static List<long> getMaxArea(int w, int h, List<bool> isVertical, List<int> distance)
     {
         var horizontalSegments = new SegmentNode(null, 0, w);
         var verticalSegments = new SegmentNode(null, 0, h);
         var maxAreas = new List<long>();

         for (int i = 0; i < isVertical.Count; i++)
         {
             if (isVertical[i])
             {
                 horizontalSegments.Split(distance[i]);
             }
             else
             {
                 verticalSegments.Split(distance[i]);
             }

             maxAreas.Add((long)horizontalSegments.MaxSegmentLength * verticalSegments.MaxSegmentLength);
         }

         return maxAreas;
     }

     public static void EntryMethod()
    {
        // Here goes all the main method contents and test cases
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int w = Convert.ToInt32(Console.ReadLine().Trim());

        int h = Convert.ToInt32(Console.ReadLine().Trim());

        int isVerticalCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<bool> isVertical = new List<bool>();

        for (int i = 0; i < isVerticalCount; i++)
        {
            bool isVerticalItem = Convert.ToInt32(Console.ReadLine().Trim()) != 0;
            isVertical.Add(isVerticalItem);
        }

        int distanceCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> distance = new List<int>();

        for (int i = 0; i < distanceCount; i++)
        {
            int distanceItem = Convert.ToInt32(Console.ReadLine().Trim());
            distance.Add(distanceItem);
        }

        List<long> result = getMaxArea(w, h, isVertical, distance);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}