using UnityEngine;

public class ScreenSize
{
    public static FrameCoordinates GetCornerCoordinates()
    {
        Camera camera = Camera.main;

        float width = camera.pixelWidth;
        float height = camera.pixelHeight;

        Vector2 bottomLeft = camera.ScreenToWorldPoint(new Vector2(0, 0));
        Vector2 topRight = camera.ScreenToWorldPoint(new Vector2(width, height));

        return new FrameCoordinates
        {
            PointBL = bottomLeft,
            PointUR = topRight
        };
    }
}

public class FrameCoordinates
{
    public Vector2 PointBL;
    public Vector2 PointUR;
}