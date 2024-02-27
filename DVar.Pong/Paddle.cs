using Raylib_cs;

namespace DVar.Pong;

public abstract class Paddle
{
    public int PosX { get; set; }
    public int PosY { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int Speed { get; set; }

    public void Draw(Color color)
    {
        Raylib.DrawRectangle(PosX, PosY, Width, Height, color);
    }

    protected void KeepInBoundaries()
    {
        if (PosY <= 0)
        {
            PosY = 0;
        }

        if (PosY + Height >= Raylib.GetScreenHeight())
        {
            PosY = Raylib.GetScreenHeight() - Height;
        }
    }
}