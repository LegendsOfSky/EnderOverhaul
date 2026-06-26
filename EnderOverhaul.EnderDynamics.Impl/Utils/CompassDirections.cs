namespace EnderOverhaul.EnderDynamics.Impl.Utils;


[Flags]
public enum CompassDirections
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
    public static bool IsNorth(this CompassDirections compassDirections) => (compassDirections & CompassDirections.North) > 0;
    public static bool IsSouth(this CompassDirections compassDirections) => (compassDirections & CompassDirections.South) > 0;
    public static bool IsEast(this CompassDirections compassDirections) => (compassDirections & CompassDirections.East) > 0;
    public static bool IsWest(this CompassDirections compassDirections) => (compassDirections & CompassDirections.West) > 0;

    public static CompassDirections Invert(this CompassDirections compassDirections)
    {
        int result = 0;

        if (((int)compassDirections & 0b0011) > 0)
            result = ~(int)compassDirections & 0b0011;
        if (((int)compassDirections & 0b1100) > 0)
            result |= ~(int)compassDirections & 0b1100;

        return (CompassDirections)result;
    }
}


public static class DirectionUtils
{
    public static CompassDirections FormName(string name) => Enum.TryParse<CompassDirections>(name , out var value) ? value : CompassDirections.None;

    public static bool TryParse(string s , out CompassDirections result)
    {
        switch (s)
        {
            case "N":
            case "North":
                result = CompassDirections.North;
                return true;

            case "S":
            case "South":
                result = CompassDirections.South;
                return true;

            case "E":
            case "East":
                result = CompassDirections.East;
                return true;

            case "W":
            case "West":
                result = CompassDirections.West;
                return true;

            case "NW":
            case "NorthWest":
            case "North West":
                result = CompassDirections.NorthWest;
                return true;

            case "NE":
            case "NorthEast":
            case "North East":
                result = CompassDirections.NorthEast;
                return true;

            case "SW":
            case "SouthWest":
            case "South West":
                result = CompassDirections.SouthWest;
                return true;

            case "SE":
            case "SouthEast":
            case "South East":
                result = CompassDirections.SouthEast;
                return true;


            default:
                result = CompassDirections.None;
                return false;
        }
    }

    public static CompassDirections GetDirection(double angle)
    {
        CompassDirections compassDirections = CompassDirections.None;

        switch (angle)
        {
            case > -135 and <= -45:
                compassDirections = CompassDirections.East;
                break;

            case > -45 and <= 45:
                compassDirections = CompassDirections.South;
                break;

            case > 45 and <= 135:
                compassDirections = CompassDirections.West;
                break;

            case > +135 and <= +180:
            case > -180 and <= -135:
                compassDirections = CompassDirections.North;
                break;
        }
        return compassDirections;
    }
}
