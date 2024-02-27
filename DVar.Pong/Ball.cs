using Raylib_cs;

namespace DVar.Pong;

public class Ball(int posX, int posY, int speedX, int speedY, float radius)
{
    public int PosX { get; set; } = posX;
    public int PosY { get; set; } = posY;
    public float Radius { get; set; } = radius;
    public int SpeedX { get; set; } = speedX;

    public void Draw(Color color)
    {
        Raylib.DrawCircle(PosX, PosY, Radius, color);
    }

    public void Draw()
    {
        Draw(Color.RayWhite);
    }
    
    public void Update()
    {
        PosX += SpeedX;
        PosY += speedY;

        if (PosY + Radius >= Raylib.GetScreenHeight() || PosY - Radius <= 0)
        {
            speedY *= -1;
        }

        if (PosX + Radius >= Raylib.GetScreenWidth())
        {
            //SpeedX *= -1;
            Score.Computer++;
            Reset();
        }

        if (PosX - Radius <= 0)
        {
            Score.Player++;
            Reset();
        }
    }

    public void Reset()
    {
        PosX = Raylib.GetScreenWidth() / 2;
        PosY = Raylib.GetScreenHeight() / 2;

        int[] speeds = [1, -1];
        var r = new Random();
        SpeedX *= speeds[r.Next(speeds.Length - 1)];
        speedY *= speeds[r.Next(speeds.Length - 1)];
    }
}