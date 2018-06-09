using Android.Content;
using FormsRatingBar;
using FormsRatingBar.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using ARatingBar = Android.Widget.RatingBar;

[assembly: ExportRenderer(typeof(RatingBar), typeof(RatingBarRenderer))]
namespace FormsRatingBar.Droid
{
    class RatingBarRenderer : ViewRenderer<RatingBar, ARatingBar>
    {
        private ARatingBar aRatingBar;
        private Context context;

        public RatingBarRenderer(Context context) : base(context)
        {
            this.context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<RatingBar> e)
        {
            base.OnElementChanged(e);
            
            aRatingBar = new ARatingBar(context);

            if (Element.IsEditable)
                aRatingBar.IsIndicator = false;
            else
                aRatingBar.IsIndicator = true;

            aRatingBar.NumStars = Element.CountOfStar;
            aRatingBar.Rating = Element.Rating;
            aRatingBar.StepSize = Element.StepSize;

            aRatingBar.RatingBarChange += ARatingBar_RatingBarChange;

            SetNativeControl(aRatingBar);
        }

        private void ARatingBar_RatingBarChange(object sender, ARatingBar.RatingBarChangeEventArgs e)
        {
            Element.Rating = e.Rating;
        }
    }
}