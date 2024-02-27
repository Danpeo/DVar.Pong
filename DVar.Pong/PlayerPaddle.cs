using Raylib_cs;

namespace DVar.Pong;

public class PlayerPaddle : Paddle
{
    public void Update()
    {
        if (Raylib.IsKeyDown(KeyboardKey.Up))
        {
            PosY -= Speed;
        }

        if (Raylib.IsKeyDown(KeyboardKey.Down))
        {
            PosY += Speed;
        }

        KeepInBoundaries();
    }


}