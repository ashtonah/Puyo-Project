

using Microsoft.Xna.Framework;

public enum PuyoColor
{
    Yellow,
    Blue,
    Red,
    Green,
    Purple
}

public struct Puyo
{
    
    public readonly PuyoColor pcolor;
    public const int WIDTH = 8;
    public const int HEIGHT = 8;

    public Puyo(PuyoColor pcolor = PuyoColor.Yellow)
    {
        this.pcolor = pcolor;
    }
    
    

    public Rectangle PuyoSprite(Puyo p)
    {
        int y0 = 0;

        switch (pcolor)
        {
            case PuyoColor.Yellow:
            y0 = 0;
            break;

            case PuyoColor.Blue:
            y0 = HEIGHT;
            break;

            case PuyoColor.Red:
            y0 = 2 * HEIGHT;
            break;

            case PuyoColor.Green:
            y0 = 3 * HEIGHT;
            break;

            case PuyoColor.Purple:
            y0 = 4 * HEIGHT;
            break;

        }
        
        return new Rectangle(0, y0, WIDTH, HEIGHT);
    }
}