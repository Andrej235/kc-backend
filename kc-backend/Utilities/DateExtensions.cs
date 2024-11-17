namespace kc_backend.Utilities
{
    public static class DateExtensions
    {
        public static DateTime GetStartOfWeek(this DateTime date)
        {
            int diff = (7 + (date.DayOfWeek - DayOfWeek.Monday)) % 7;
            return date.AddDays(-diff).Date;
        }
    }
}
