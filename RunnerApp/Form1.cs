using AbstractFactoryLibrar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AbstractFactoryLibrar;

namespace RunnerApp
{
    public partial class Form1 : Form
    {
        private IDistanceFactory _factory;
        public Form1()
        {
            InitializeComponent();

            // Заполнение ComboBox
            comboBoxFactory.Items.AddRange(new[] { "Street", "Stadium", "Gym" });
            comboBoxObject.Items.AddRange(new[] { "Runner", "Opponent", "Treadmill" });
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            switch (comboBoxFactory.SelectedItem?.ToString())
            {
                case "Street":
                    _factory = new StreetFactory();
                    break;
                case "Stadium":
                    _factory = new StadiumFactory();
                    break;
                case "Gym":
                    _factory = new GymFactory();
                    break;
                default:
                    MessageBox.Show("Выберите фабрику.");
                    return;
            }

            // Создание объекта
            string result = "";
            switch (comboBoxObject.SelectedItem?.ToString())
            {
                case "Runner":
                    var runner = _factory.CreateRunner();
                    result = $"Runner: {runner.Name}, Speed: {runner.Speed}, Photo: {runner.Photo}";
                    runner.Run();
                    break;
                case "Opponent":
                    var opponent = _factory.CreateOpponent();
                    result = $"Opponent: {opponent.Name}, Speed: {opponent.Speed}, Photo: {opponent.Photo}";
                    opponent.Challenge();
                    break;
                case "Treadmill":
                    var treadmill = _factory.CreateTreadmill();
                    result = $"Treadmill: {treadmill.Length}, Coating: {treadmill.Coating}, Photo: {treadmill.Photo}";
                    treadmill.Show();
                    break;
                default:
                    MessageBox.Show("Выберите объект.");
                    return;
            }

            textBoxResult.Text = result;
        }
    }
}

