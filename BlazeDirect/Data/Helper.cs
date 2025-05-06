namespace BlazeDirect.Data
{
    public static class Helper
    {
        public static int AgeCalculator(this DateTime? sender)
        {
            if (sender.HasValue)
            {
                var today = DateTime.Today;
                var age = today.Year - sender.Value.Year;
                if (sender.Value.Date > today.AddYears(-age)) age--;
                return age;
            }
            else
            {
                return 0;
            }
        }
    }
}
