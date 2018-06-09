using System;
using Xamarin.Forms;

namespace FormsRatingBar
{
    public class RatingBar : View
    {
        public static BindableProperty IsEditableProperty 
            = BindableProperty.Create
                (nameof(IsEditable),
                typeof(bool),
                typeof(RatingBar),
                true);

        public bool IsEditable
        {
            get => (bool)GetValue(IsEditableProperty);
            set => SetValue(IsEditableProperty, value);
        }

        public static BindableProperty CountOfStarProperty
            = BindableProperty.Create
                (nameof(CountOfStar),
                typeof(int),
                typeof(RatingBar),
                5);

        public int CountOfStar
        {
            get => (int)GetValue(CountOfStarProperty);
            set => SetValue(CountOfStarProperty, value);
        }

        public static BindableProperty RatingProperty
            = BindableProperty.Create
                    (nameof(Rating),
                    typeof(float),
                    typeof(RatingBar),
                    0f,
                    propertyChanged: (s, o, n) =>
                    {
                        (s as RatingBar).OnRatingUpdated((float)n);
                    });

        public float Rating
        {
            get => (float)GetValue(RatingProperty);
            set => SetValue(RatingProperty, value);
        }

        public static BindableProperty StepSizeProperty
            = BindableProperty.Create
                    (nameof(StepSize),
                    typeof(float),
                    typeof(RatingBar),
                    1f);

        public float StepSize
        {
            get => (float)GetValue(StepSizeProperty);
            set => SetValue(StepSizeProperty, value);
        }

        public event EventHandler<float> RatingUpdated;

        protected virtual void OnRatingUpdated(float rating)
        {
            RatingUpdated?.Invoke(this, rating);
        }
    }
}
