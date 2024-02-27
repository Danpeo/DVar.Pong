using System.Numerics;
using DVar.Pong;
using Raylib_cs;

Raylib.InitWindow(Param.ScreenWidth, Param.ScreenHeight, "PONG");
Raylib.SetTargetFPS(Param.TargetFPS);

var ball = new Ball
(
    posX: Param.ScreenWidth / 2,
    posY: Param.ScreenHeight / 2,
    speedX: 7,
    speedY: 7,
    radius: 20.0f
);

var playerPaddle = new PlayerPaddle
{
    Width = 25,
    Height = 120
};
playerPaddle.PosX = Param.ScreenWidth - playerPaddle.Width - 30;
playerPaddle.PosY = Param.ScreenHeight / 2 - playerPaddle.Height / 2;
playerPaddle.Speed = 12;

var compPaddle = new ComputerPaddle
{
    Height = 120,
    Width = 25
};
compPaddle.PosY = Param.ScreenHeight / 2 - compPaddle.Height / 2;
compPaddle.PosX = 30;
compPaddle.Speed = 6;

while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();

    ball.Update();
    playerPaddle.Update();
    compPaddle.Update(ball.PosY, ball.PosX);

    var ballVector = new Vector2(ball.PosX, ball.PosY);

    if (Raylib.CheckCollisionCircleRec(ballVector, ball.Radius,
            new Rectangle(playerPaddle.PosX, playerPaddle.PosY, playerPaddle.Width, playerPaddle.Height)))
    {
        ball.SpeedX *= -1;
    }

    if (Raylib.CheckCollisionCircleRec(ballVector, ball.Radius,
            new Rectangle(compPaddle.PosX, compPaddle.PosY, compPaddle.Width, compPaddle.Height)))
    {
        ball.SpeedX *= -1;
    }

    Raylib.ClearBackground(Color.Black);
    Raylib.DrawLine(Param.ScreenWidth / 2, 0, Param.ScreenWidth / 2,
        Param.ScreenHeight, Color.RayWhite);
    ball.Draw(Colors.Pink);
    playerPaddle.Draw(Colors.Green);
    compPaddle.Draw(Colors.Green);

    Raylib.DrawText(Score.Computer.ToString(), Param.ScreenWidth / 4 - 20, 20, 50, Colors.Green);
    Raylib.DrawText(Score.Player.ToString(), 3 * Param.ScreenWidth / 4 - 20, 20, 50, Colors.Green);
    Raylib.EndDrawing();
}

Raylib.CloseWindow();