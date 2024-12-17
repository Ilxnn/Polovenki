using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using Utilities.Classes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static Utilities.Classes.RelativePath;

namespace Polovenki
{
    public partial class messengerForm : Form
    {
        // Поля формы
        private Panel LoadPanel;
        private findForm Findform;
        private profileForm ProfileForm;

        // Шрифты
        private PrivateFontCollection _fontCollection, _fontCollectionMain;
        private Font _montserratFont;
        private Font _montserratFontMain;
        private Font _montserratFontCalenadar;
        private Font _montserratFontAllowDate;

        // Константы для сообщений
        private const int MaxCharactersPerLine = 50;
        private const int marginMessage = 20;

        // Переменные для сообщений
        private int previousMessagePosition = 0;
        private int messageCount = 0;
        private bool messageSend = false;

        // Время последнего сообщения
        private DateTime lastMessageTime;

        // Текущая дата для календаря
        private DateTime currentDate;

        // Таймер для отправки сообщений бота
        private System.Timers.Timer timer = new System.Timers.Timer(1000);

        // Константы для календаря
        private const int CellWidth = 185;
        private const int HeaderHeight = 51;
        private const int RowHeight = 128;
        private const int TotalCells = 35;

        // Панель подтверждения даты
        private KryptonPanel confirmationPanel;

        // Переменная для хранения Y координаты предыдущего диалога
        int previuosDialogY;

        // Делегат события для отправки сообщения
        private delegate void SafeInvokeDelegate(string text, bool isUserMessage);
        // Конструктор формы
        public messengerForm(findForm findform, profileForm profileForm, Panel loadPanel)
        {
            InitializeComponent();

            // Включение DoubleBuffered для kryptonPanel4
            typeof(KryptonPanel).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)?.SetValue(kryptonPanel4, true);
            mainMessagePanel.BorderStyle = BorderStyle.None;

            this.DoubleBuffered = true;

            // Инициализация шрифтов
            _fontCollection = new PrivateFontCollection();
            _fontCollection.AddFontFile(GetFullPath(@"Source\Fonts\Montserrat-Medium.ttf"));
            _montserratFont = new Font(_fontCollection.Families[0], 12);
            _montserratFontCalenadar = new Font(_fontCollection.Families[0], 26);
            _montserratFontAllowDate = new Font(_fontCollection.Families[0], 12);

            _fontCollectionMain = new PrivateFontCollection();
            _fontCollectionMain.AddFontFile(GetFullPath(@"Source\Fonts\Montserrat-Bold.ttf"));
            _montserratFontMain = new Font(_fontCollectionMain.Families[0], 20);

            // Настройка таймера
            timer.Elapsed += Timer_Elapsed;

            // Инициализация полей формы
            LoadPanel = loadPanel;
            Findform = findform;
            ProfileForm = profileForm;

            previuosDialogY = 59;

            // Инициализация панели подтверждения
            InitializeConfirmationPanel();
        }


        // Обработчик события нажатия клавиши в поле ввода сообщения
        private void message_input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sendMessage(message_input.Text, true);
                message_input.Clear();
                timer.Start();  // Запускаем таймер после отправки сообщения пользователем
            }
        }

        // Обработчик события таймера для отправки сообщений бота
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Random sec = new Random();

            if (DateTime.Now - lastMessageTime >= TimeSpan.FromSeconds(sec.Next(3, 6)))
            {
                Invoke(new SafeInvokeDelegate(sendMessage), Utilities.Classes.messages.GetMessage(messageCount), false);
                messageSend = true;
                messageCount++;
            }

            // Перезапуск или остановка таймера в зависимости от отправки сообщения
            if (!messageSend)
            {
                timer.Start();
            }
            else
            {
                timer.Stop();
                messageSend = false;
            }
        }

        // Метод для отправки сообщения (пользователя или бота)
        public void sendMessage(string text, bool isUserMessage)
        {
            // Проверка на необходимость вызова в UI потоке
            if (InvokeRequired)
            {
                Invoke(new SafeInvokeDelegate(sendMessage), text, isUserMessage);
                return;
            }

            // Создание панели сообщения
            CustomPanel messagePanel = new CustomPanel();
            messagePanel.BackColor = Color.Transparent;
            messagePanel.BackgroundImage = isUserMessage ? new Bitmap(GetFullPath(@"Source\img\message_back_adresat.png")) : new Bitmap(GetFullPath(@"Source\img\message_back_adresant.png"));
            messagePanel.BackgroundImageLayout = ImageLayout.Stretch;
            messagePanel.BorderRadius = 0;
            messagePanel.BorderStyle = BorderStyle.None;
            messagePanel.BorderColor = Color.Transparent;
            messagePanel.BorderSize = 0;


            // Разделение текста на строки
            List<string> lines = new List<string>();
            int startIndex = 0;
            while (startIndex < text.Length)
            {
                int endIndex = Math.Min(startIndex + MaxCharactersPerLine, text.Length);
                lines.Add(text.Substring(startIndex, endIndex - startIndex));
                startIndex = endIndex;
            }

            // Создание label для каждой строки сообщения
            List<Label> messageLabels = lines.Select(line => new Label
            {
                Text = line,
                AutoSize = true,
                Font = _montserratFont,
                ForeColor = Color.White,
            }).ToList();

            // Расчет размеров панели сообщения
            int panelWidth = Math.Min(messageLabels.Max(label => label.PreferredWidth) + 8, 492);
            int panelHeight = messageLabels.Sum(label => label.PreferredHeight) + (messageLabels.Count - 1) * 6 + 6;

            messagePanel.Width = panelWidth;
            messagePanel.Height = panelHeight;

            // Размещение панели сообщения в зависимости от отправителя
            if (isUserMessage)
            {
                messagePanel.Location = new Point(mainMessagePanel.Width - 20 - messagePanel.Width, previousMessagePosition + marginMessage);
                lastMessageTime = DateTime.Now;
            }
            else
            {
                messagePanel.Location = new Point(20, previousMessagePosition + marginMessage);
            }

            // Добавление label на панель сообщения
            mainMessagePanel.Controls.Add(messagePanel);
            int currentY = 2;
            int currentX = 6;

            foreach (Label label in messageLabels)
            {
                label.Location = new Point(currentX, currentY);
                messagePanel.Controls.Add(label);
                currentY += label.PreferredHeight + 6;
            }

            previousMessagePosition = messagePanel.Top + messagePanel.Height;
        }

        // Обработчики событий для поля ввода сообщения
        private void message_input_Enter(object sender, EventArgs e)
        {
            message_input.Clear();
        }

        private void message_input_Leave(object sender, EventArgs e)
        {
            message_input.Text = "Ввод текстового сообщения...";
        }

        // Метод для центрирования текста в панели
        private Point ChangeLocation(Label text, KryptonPanel panel)
        {
            int pnlwidth = panel.Width;
            int txtwidth = text.Width;
            int resultPosition = ((pnlwidth - txtwidth) / 2);
            return new Point(resultPosition, 16);
        }


        // Метод для добавления диалогов
        private void addDialog()
        {
            SQLHelper.SetNameDB("girlsDataBase.db");
            string SQLQuery = "SELECT \"name\",\"age\" FROM \"girlsData\" WHERE \"Reaction\" = \"Like\";";
            List<Dictionary<string, object>> girls = SQLHelper.GetMultipleRecords(SQLQuery);

            foreach (Dictionary<string, object> girl in girls)
            {
                string name = girl["name"].ToString();
                int age = Convert.ToInt32(girl["age"]);


                // Создание панели диалога
                KryptonPanel dialog = new KryptonPanel();
                dialog.Location = new Point(0, previuosDialogY);
                dialog.Size = new Size(225, 59);
                dialog.StateCommon.Color1 = Color.FromArgb(89, 81, 204);
                dialog.StateCommon.Color2 = Color.FromArgb(89, 81, 204);
                kryptonPanel1.Controls.Add(dialog);

                // Создание label для имени и возраста в диалоге
                Label userDialog = new Label();
                userDialog.Text = name + ", " + age;
                userDialog.Font = kryptonLabel2.StateCommon.ShortText.Font;
                userDialog.ForeColor = Color.White;
                userDialog.BackColor = Color.Transparent;
                userDialog.AutoSize = true;
                
                dialog.Controls.Add(userDialog);


                // Обработчик клика по диалогу (изменение цвета и очистка сообщений)
                EventHandler clickHandler = (sender, e) =>
                {
                    foreach (Control control in kryptonPanel1.Controls)
                    {
                        if (control is KryptonPanel panel && panel != sender)
                        {
                            panel.StateCommon.Color1 = Color.FromArgb(89, 81, 204);
                            panel.Invalidate();
                            panel.Update();
                        }
                    }

                    KryptonPanel clickedPanel = (KryptonPanel)dialog;

                    clickedPanel.StateCommon.Color1 = Color.FromArgb(154, 64, 203);
                    clickedPanel.Invalidate();
                    clickedPanel.Update();


                    mainMessagePanel.Controls.Clear();
                    previousMessagePosition = 0;
                    messageCount = 0;
                    kryptonPanel3.Visible = true;
                };

                dialog.Click += clickHandler;
                userDialog.Click += clickHandler;
                userDialog.Location = ChangeLocation(userDialog, dialog);  // Центрирование label
                previuosDialogY += 59;
            }

            SQLHelper.CloseConnection();
            kryptonPanel1.Refresh();
        }

        // Обработчик события отображения формы
        private void messengerForm_Shown(object sender, EventArgs e)
        {
            addDialog();
        }

        // Обработчики событий кнопок
        private void btn_back_Click(object sender, EventArgs e)
        {
            LoadPanel.Controls.Clear();
            LoadPanel.Controls.Add(Findform);
            Findform.Show();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            kryptonPanel2.Visible = true;
        }

        private void btn_profile_Click(object sender, EventArgs e)
        {
            LoadPanel.Controls.Clear();
            LoadPanel.Controls.Add(ProfileForm);
            ProfileForm.Show();
        }



        private void kryptonLabel3_Click(object sender, EventArgs e)
        {
            currentDate = DateTime.Today;
            kryptonPanel3.Visible = false;
            kryptonPanel2.Visible = false;
            kryptonPanel4.Visible = true;
            kryptonPanel4.Dock = DockStyle.Fill;
            InitializeCalendarGrid();

        }


        // Метод для инициализации сетки календаря
        private void InitializeCalendarGrid()
        {
            // Создаем панель для календаря
            Panel calendarPanel = new Panel();
            calendarPanel.BackColor = Color.Transparent;
            calendarPanel.Size = new Size(1296, 696);
            calendarPanel.Location = new Point(0, 0);

            List<Control> controlsToAdd = new List<Control>();

            // Добавляем заголовки дней недели
            string[] dayNames = { "Пн", "Вт", "Ср", "Чт", "Пт", "Сб", "Вс" };
            for (int i = 0; i < 7; i++)
            {
                Label dayLabel = new ColoredBorderLabel();
                dayLabel.Font = _montserratFontCalenadar;
                dayLabel.ForeColor = Color.White;
                dayLabel.BackColor = Color.Transparent;
                dayLabel.Text = dayNames[i];
                dayLabel.TextAlign = ContentAlignment.MiddleCenter;
                dayLabel.Size = new Size(CellWidth, HeaderHeight);
                dayLabel.Location = new Point(i * CellWidth, 0);
                dayLabel.BorderStyle = BorderStyle.FixedSingle;
                controlsToAdd.Add(dayLabel);
            }


            // Добавляем даты месяца
            DateTime firstDayOfMonth = new DateTime(currentDate.Year, currentDate.Month, 1);
            int firstDayOfWeek = (int)firstDayOfMonth.DayOfWeek;
            if (firstDayOfWeek == 0) firstDayOfWeek = 7; // Корректировка для воскресенья
            firstDayOfWeek--;



            for (int i = 0; i < TotalCells; i++)
            {
                DateTime day = firstDayOfMonth.AddDays(i - firstDayOfWeek);
                Label dateLabel = new ColoredBorderLabel();
                dateLabel.Font = _montserratFontCalenadar;
                dateLabel.BackColor = Color.Transparent;
                dateLabel.Text = day.ToString("dd.MM");
                dateLabel.TextAlign = ContentAlignment.MiddleCenter;
                dateLabel.Size = new Size(CellWidth, RowHeight);
                dateLabel.Location = new Point((i % 7) * CellWidth, HeaderHeight + (i / 7) * RowHeight);
                dateLabel.BorderStyle = BorderStyle.FixedSingle;
                if (day.Date == DateTime.Today.Date)
                {
                    dateLabel.ForeColor = Color.Red;
                }
                else dateLabel.ForeColor = Color.White;
                dateLabel.Click += DateLabel_Click;
                controlsToAdd.Add(dateLabel);
            }
            calendarPanel.Controls.AddRange(controlsToAdd.ToArray());
            kryptonPanel4.Controls.Add(calendarPanel);
        }


        // Метод для инициализации панели подтверждения даты
        private void InitializeConfirmationPanel()
        {
            confirmationPanel = new KryptonPanel();
            confirmationPanel.Size = new Size(345, 100);
            confirmationPanel.StateCommon.Color1 = Color.Transparent;
            confirmationPanel.StateCommon.Color2 = Color.Transparent;
            confirmationPanel.StateCommon.Image = new Bitmap(GetFullPath(@"Source\img\calendarAllowDateBack.png"));
            confirmationPanel.StateCommon.ImageStyle = PaletteImageStyle.Stretch;
            confirmationPanel.Visible = false;

            // Label с вопросом
            Label questionLabel = new Label();
            questionLabel.Text = "Уверены, что хотите выбрать\nэту дату для свидания?";
            questionLabel.BackColor = Color.Transparent;
            questionLabel.AutoSize = true;
            questionLabel.Font = _montserratFontAllowDate;
            questionLabel.ForeColor = Color.White;
            questionLabel.TextAlign = ContentAlignment.MiddleCenter;
            questionLabel.Location = new Point(confirmationPanel.Width / 2 - questionLabel.Width - 25, 4); // Центрирование Label
            confirmationPanel.Controls.Add(questionLabel);

            // Кнопка "Да"
            Button yesButton = new Button();
            yesButton.Text = "Да";
            yesButton.Size = new Size(170, 40);
            yesButton.TextAlign = ContentAlignment.MiddleCenter;
            yesButton.Font = _montserratFontAllowDate;
            yesButton.ForeColor = Color.White;
            yesButton.BackColor = Color.Transparent;
            yesButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            yesButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            yesButton.FlatAppearance.BorderSize = 0;
            yesButton.FlatStyle = FlatStyle.Flat;
            yesButton.Location = new Point(4, 57);
            yesButton.Click += YesButton_Click;
            confirmationPanel.Controls.Add(yesButton);

            // Кнопка "Нет"
            Button noButton = new Button();
            noButton.Text = "Нет";
            noButton.Size = new Size(170, 40);
            noButton.TextAlign = ContentAlignment.MiddleCenter;
            noButton.BackColor = Color.Transparent;
            noButton.ForeColor = Color.White;
            noButton.FlatAppearance.BorderSize = 0;
            noButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            noButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            noButton.FlatStyle = FlatStyle.Flat;
            noButton.Font = _montserratFontAllowDate;
            noButton.Location = new Point(175, 57);
            noButton.Click += NoButton_Click;
            confirmationPanel.Controls.Add(noButton);

            kryptonPanel4.Controls.Add(confirmationPanel);
        }

        // Обработчик клика по дате в календаре
        private void DateLabel_Click(object sender, EventArgs e)
        {
            Label clickedLabel = (Label)sender;
            Point dateLabelLocation = clickedLabel.Location;

            // Расчет положения панели подтверждения
            int x = dateLabelLocation.X + clickedLabel.Width / 2 - confirmationPanel.Width / 2;
            int y = dateLabelLocation.Y - confirmationPanel.Height - 5;

            // Проверка на выход за границы экрана
            if (x < 0)
            {
                x = 0;
            }
            int rightEdge = this.ClientSize.Width - confirmationPanel.Width;
            if (x > rightEdge)
            {
                x = rightEdge;
            }

            confirmationPanel.Location = new Point(x, y);
            confirmationPanel.Visible = true;

            // Сохранение выбранной даты
            DateTime selectedDate = DateTime.ParseExact(clickedLabel.Text, "dd.MM", null);
            selectedDate = new DateTime(currentDate.Year, selectedDate.Month, selectedDate.Day);
            confirmationPanel.Tag = selectedDate;
        }


        // Обработчики событий кнопок подтверждения
        private void YesButton_Click(object sender, EventArgs e)
        {
            confirmationPanel.Visible = false;
            kryptonPanel4.Visible = false;
            kryptonPanel3.Visible = true;

            // Здесь можно добавить обработку выбранной даты (confirmationPanel.Tag)
        }


        private void NoButton_Click(object sender, EventArgs e)
        {
            confirmationPanel.Visible = false;
        }



    }
}