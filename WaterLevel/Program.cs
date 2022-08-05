// See https://aka.ms/new-console-template for more information
int[] height = { 0,1,0,2,1,0,1,3,2,1,2,1 };
Console.WriteLine(CalcWater(height));

static int CalcWater(int[] height)
{
    int highestHeight = height.Max();
    int secondHighestHeight = height.Where(h => h != highestHeight).Max();
    int water = 0;
    bool isPostSecondHighest = false;

    for (int i = 0; i < height.Length - 1; i++)
    {
        if(height[i] == secondHighestHeight) isPostSecondHighest = true;
        if (isPostSecondHighest)
        {
            if(height[i] != secondHighestHeight && height[i] != highestHeight)
            {
                if(isObstruction(i, height))  water += secondHighestHeight - height[i];
            }
        }
        else
        {
            if(height[i] > height[i+1]) water+= height[i]-height[i+1]; 
        }
    }

    return water;

}

static bool isObstruction(int index, int[] height)
{
    for(int i = index+1; i< height.Length; i++) if(height[index+1] == height[i]) return true;
    return false;
}