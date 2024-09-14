namespace DiceRoller
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            SidesPicker.SelectedIndex = 0;
        }

        private void BtnSpin_Clicked(object sender, EventArgs e)
        {
            if (SidesPicker.SelectedItem == null || string.IsNullOrWhiteSpace(DiceCountEntry.Text))
            {
                ResultLabel.Text = "Selecione os lados e insira a quantidade de dados.";
                return;
            }

            if (!int.TryParse(SidesPicker.SelectedItem.ToString(), out int lados))
            {
                ResultLabel.Text = "Selecione um número válido de lados.";
                return;
            }

            if (!int.TryParse(DiceCountEntry.Text, out int quantidadeDados) || quantidadeDados <= 0)
            {
                ResultLabel.Text = "Insira uma quantidade válida de dados.";
                return;
            }

            int modificador = 0;
            if (ModifierPicker.SelectedItem != null)
            {
                modificador = Convert.ToInt32(ModifierPicker.SelectedItem.ToString().Replace("+", ""));
            }

            Random random = new Random();
            int somaResultados = 0;

            for (int i = 0; i < quantidadeDados; i++)
            {
                int valorSorteado = random.Next(1, lados + 1);
                somaResultados += valorSorteado + modificador;
            }

            ResultLabel.Text = $"Resultado Final: {somaResultados}";
        }

        private void OnAboutClicked(object sender, EventArgs e)
        {
            try
            {
                Launcher.Default.OpenAsync(new Uri("https://github.com/Matz-Turing"));
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", $"Não foi possível abrir o link: {ex.Message}", "OK");
            }
        }
    }
}
