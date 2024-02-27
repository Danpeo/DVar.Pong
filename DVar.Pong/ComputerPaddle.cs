namespace DVar.Pong;

public class ComputerPaddle : Paddle
{
    public void Update(int ballPosY, int ballPosX)
    {
        if (ballPosX < PosX)
            return;
        
        if (PosY + Height / 2 > ballPosY)
        {
            PosY -= Speed;
        }

        if (PosY + Height / 2 <= ballPosY)
        {
            PosY += Speed;
        }
        
        KeepInBoundaries();
    }
}