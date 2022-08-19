
using GameInterface.Game;
using GameInterface.Game.Characters;
using LordOfTheRings.Characters;
using LordOfTheRings.Locations;

namespace GameInterface
{
    public partial class GameI : Form
    {
        public GameI()
        {
            InitializeComponent();
        }
        public void PrintLine(string text)
        {
            textBox1.AppendText(text + '\r' + '\n');
        }

        public void PrintAction(string text)
        {
            listBox1.Items.Add(text);
        }

        public void ClearAction()
        {
            listBox1.Items.Clear();
        }
        public void ClearHystory()
        {
            textBox1.Clear();
        }

        public void Print(string text)
        {
            textBox1.AppendText(text);
        }

        public async Task<string> Read()
        {
            return await GetPlayChoiceAsync();
        }

        public static Task<Control> OnClickAnyAsync(params Control[] controls)
        {
            var tcs = new TaskCompletionSource<Control>();
            foreach (var control in controls) control.Click += OnClick;
            return tcs.Task;

            void OnClick(object sender, EventArgs e)
            {
                foreach (var control in controls) control.Click -= OnClick;
                tcs.SetResult((Control)sender);
            }
        }
        private async Task<string> GetPlayChoiceAsync()
        {
            string result = "";
            var clickedButton = await OnClickAnyAsync(button1);
            if (clickedButton == button1)
            {
                result = textBox2.Text;
                textBox2.Clear();
                textBox2.Select();
            }
            return result;
            //throw new NotImplementedException();
        }

        public async void Start()
        {
            Cnsl.WriteLine("Создание персонажа ");
            IRace hero = await CreatePerson();
            Cnsl.WriteLine($"Создан персонаж: {hero.Name} . Раса: {hero.RaceName}");
            hero.CharacterState();
            Tract tract = new Tract();
            tract.GoToTract(hero);
        }

        public async Task<IRace> CreatePerson()
        {
            string comand = string.Empty;
            do
            {
                Cnsl.WriteLine("Выберите расу ");
                Cnsl.WriteAction("1 - Человек");
                Cnsl.WriteAction("2 - Орк");
                Cnsl.WriteAction("3 - Эльф");
                Cnsl.WriteAction("4 - Хафлинг");

                comand = await Cnsl.ReadLine();
            }
            while (comand != "1" && comand != "2" && comand != "3" && comand != "4");
            Cnsl.WriteLine("Введите имя персонажа");
            string Name = await Cnsl.ReadLine();
            IRace hero = null;

            switch (comand)
            {
                case "1":
                    {
                        hero = new Human(Name);
                    }
                    break;
                case "2":
                    {
                        hero = new Orc(Name);

                    }
                    break;
                case "3":
                    {
                        hero = new Elf(Name);
                    }
                    break;
                case "4":
                    {
                        hero = new Hafling(Name);
                    }
                    break;

            }
            return hero;
        }

        private void GameI_Shown(object sender, EventArgs e)
        {
            Cnsl.init(this);
            Start();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = GetActionNum();
        }

        private string GetActionNum()
        {
            var str = listBox1.Items[listBox1.SelectedIndex].ToString();
            return str.Substring(0, str.IndexOf(' '));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearAction();
            ClearHystory();
        }
    }
}