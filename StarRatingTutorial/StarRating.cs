using Avalonia;
using Avalonia.Controls.Primitives;

namespace StarRatingTutorial
{
    public class StarRating : TemplatedControl
    {
        public static readonly DirectProperty<StarRating, int> RatingProperty =
            AvaloniaProperty.RegisterDirect<StarRating, int>(
                nameof(Rating),
                o => o.Rating,
                (o, v) => o.Rating = v);

        private int rating;

        public int Rating
        {
            get => rating;
            set => SetAndRaise(RatingProperty, ref rating, value);
        }
    }
}
