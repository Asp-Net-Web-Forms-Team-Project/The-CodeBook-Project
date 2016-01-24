namespace TheCodeBookProject.Web.App.UserControls
{
    using System;
    using System.Web.UI;

    public partial class RatingVisualizer : UserControl
    {
        public int RatingSum { get; set; }

        public int VotesCount { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}