namespace EnderOverhaul.EnderDynamics.Utils;


[Flags]
public enum CompassDirection
{
    None  = 0 ,
    North = 1 ,
    South = 2 ,
    East  = 4 ,
    West  = 8 ,
    NorthWest = North | West ,
    NorthEast = North | East ,
    SouthWest = South | West ,
    SouthEast = South | East ,
}


public static class DirectionExtension
{
    public static bool IsNorth(this CompassDirection compassDirection) => (compassDirection & CompassDirection.North) > 0;
    public static bool IsSouth(this CompassDirection compassDirection) => (compassDirection & CompassDirection.South) > 0;
    public static bool IsEast(this CompassDirection compassDirection) => (compassDirection & CompassDirection.East) > 0;
    public static bool IsWest(this CompassDirection compassDirection) => (compassDirection & CompassDirection.West) > 0;

    public static CompassDirection Invert(this CompassDirection compassDirection)
    {
        int result = 0;

        if (((int)compassDirection & 0b0011) > 0)
            result = ~(int)compassDirection & 0b0011;
        if (((int)compassDirection & 0b1100) > 0)
            result |= ~(int)compassDirection & 0b1100;

        return (CompassDirection)result;
    }
}


public static class DirectionUtils
{
    public static CompassDirection FormName(string name) => Enum.TryParse<CompassDirection>(name , out var value) ? value : CompassDirection.None;

    public static bool TryParse(string s , out CompassDirection result)
    {
        switch (s)
        {
            case "N":
            case "North":
                result = CompassDirection.North;
                return true;

            case "S":
            case "South":
                result = CompassDirection.South;
                return true;

            case "E":
            case "East":
                result = CompassDirection.East;
                return true;

            case "W":
            case "West":
                result = CompassDirection.West;
                return true;

            case "NW":
            case "NorthWest":
            case "North West":
                result = CompassDirection.NorthWest;
                return true;

            case "NE":
            case "NorthEast":
            case "North East":
                result = CompassDirection.NorthEast;
                return true;

            case "SW":
            case "SouthWest":
            case "South West":
                result = CompassDirection.SouthWest;
                return true;

            case "SE":
            case "SouthEast":
            case "South East":
                result = CompassDirection.SouthEast;
                return true;


            default:
                result = CompassDirection.None;
                return false;
        }
    }

    public static CompassDirection GetDirection(double angle)
    {
        CompassDirection compassDirection = CompassDirection.None;

        switch (angle)
        {
            case > -135 and <= -45:
                compassDirection = CompassDirection.East;
                break;

            case > -45 and <= 45:
                compassDirection = CompassDirection.South;
                break;

            case > 45 and <= 135:
                compassDirection = CompassDirection.West;
                break;

            case > +135 and <= +180:
            case > -180 and <= -135:
                compassDirection = CompassDirection.North;
                break;
        }
        return compassDirection;
    }
}
