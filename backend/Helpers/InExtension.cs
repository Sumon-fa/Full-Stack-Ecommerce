namespace backend.Helpers;

public static class InExtension
{
    public static bool IsOdd(this int num) => (num & 1) > 0;
    public static bool IsEven(this int num) => (num & 1) == 0;
}