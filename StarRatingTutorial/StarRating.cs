using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Shapes;
using Avalonia.Media;

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
        private Path[] stars;

        public int Rating
        {
            get => rating;
            set => SetAndRaise(RatingProperty, ref rating, value);
        }

        protected override void OnTemplateApplied(TemplateAppliedEventArgs e)
        {
            base.OnTemplateApplied(e);

            stars = new[]
            {
                e.NameScope.Get<Path>("PART_One"),
                e.NameScope.Get<Path>("PART_Two"),
                e.NameScope.Get<Path>("PART_Three"),
                e.NameScope.Get<Path>("PART_Four"),
                e.NameScope.Get<Path>("PART_Five"),
            };

            UpdateStars();
        }

        protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs e)
        {
            if (e.Property == RatingProperty)
            {
                UpdateStars();
            }
        }

        private void UpdateStars()
        {
            if (stars != null)
            {
                for (var i = 0; i < stars.Length; ++i)
                {
                    stars[i].Fill = i < Rating ? Brushes.Orange : null;
                }
            }
        }
    }
}
