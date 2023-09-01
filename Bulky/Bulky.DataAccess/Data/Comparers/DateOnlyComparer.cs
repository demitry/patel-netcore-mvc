using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BulkyBook.DataAccess.Data.Comparers
{
    public class DateOnlyComparer : ValueComparer<DateOnly>
    {
        public DateOnlyComparer() : base(
            (x, y) => x.DayNumber == y.DayNumber,
            dateOnly => dateOnly.GetHashCode())
        { }
    }
}
