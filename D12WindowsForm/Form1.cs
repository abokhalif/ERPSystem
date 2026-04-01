namespace D12WindowsForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //2 - the usually way
            //this.Load += (sender, e) => this.BackColor = Color.Yellow;
            this.ResizeBegin += (sen, e) => this.Opacity = 0.5;
            this.ResizeEnd += (sen, e) =>
            {
                this.Text = "Helloooo";
                this.BackColor = Color.Gold;
                this.Opacity = 1;
                this.MinimumSize =new(400,400);

            };
        }






        // 1- the special way when the subescriber(Form1) is child of the publisher class (Form -base) by
        // Base Event =>Base.OnEventName Method
        // this will executed during the loading event (before execution the constructor)
        //protected override void OnLoad(EventArgs e)
        //{
        //    this.BackColor = Color.YellowGreen;
        //    base.OnLoad(e);
        //}
        // 3- Double clicking => but is noisy because when remove it u will must remove its code from the .Designer.cs
        //private void Form1_Load(object sender, EventArgs e)// Name of the subescriber_tje name of the event
        //{
        //    this.Text = "HelloWorld";
        //}
        // 4- i can subescribe by my own function// when remove it u will must remove its code from the .Designer.cs
        private void UpdateTextForm(object sender, EventArgs e)
        {
            this.Text = $"{this.Width},{this.Height}";
        }

    }
}