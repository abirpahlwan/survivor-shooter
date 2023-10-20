using UnityEngine;

public class Utils
{
    public static float GetAngleFromDirection(Vector2 direction)
    {
        float dirx = direction.x;
        float diry = direction.y;
        
        if (dirx > 0 && diry == 0) //right
        {
            return 0f;
        }
        if (dirx > 0 && diry > 0) //right up
        {
            return 45f;
        }
        if (dirx == 0 && diry > 0) //up
        {
            return 90f;
        }
        if (dirx < 0 && diry > 0) //left up
        {
            return 135f;
        }
        if (dirx < 0 && diry == 0) //left
        {
            return 180f;
        }
        if (dirx < 0 && diry < 0) //left down
        {
            return -135f;
        }
        if (dirx == 0 && diry < 0) //down
        {
            return -90f;
        }
        if (dirx > 0 && diry < 0) //right down
        {
            return -45f;
        }
        
        return 0;
    }
}
