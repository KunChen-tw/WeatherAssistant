using System.Collections.Specialized;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WeatherAssistant
{
    public partial class FrmMain : Form
    {
        private WeatherDataCollection[] weatherDataMonth = new WeatherDataCollection[12];
        private WeatherDataCollection[] weatherDataDay = new WeatherDataCollection[31];
        // 創建一個二維布林陣列，用於標記每小時的每十分鐘是否有資料
        private WeatherDataCollection[][] weatherDataHourMinute = new WeatherDataCollection[24][];

        private StringCollection mergeFullPath = new StringCollection();

        private int selectedDay = -1;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void RefreshTrainingData()
        {
            string trainingDataPath = "TrainingData";
            if (!Directory.Exists(trainingDataPath))
            {
                MessageBox.Show("氣象數據 資料夾 不存在", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            ClearWeatherDataDevice();
            string[] csvFiles = Directory.GetFiles(trainingDataPath, "*.csv");
            if (csvFiles.Length == 0)
            {
                MessageBox.Show("氣象數據 資料夾 不存在", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                cmbDevice.Items.AddRange(csvFiles.Select(file => Path.GetFileName(file)).ToArray());
            }
            IsEnableCutButton(false);
            selectedDay = -1;
        }

        private void ShowOutput(string str)
        {
            txtOutput.AppendText($"{str}\n");
        }

        private void ClearWeatherDataMonth()
        {
            cmbMonth.Items.Clear(); // 清空 cmbDevice 的項目
            for (int i = 0; i < weatherDataMonth.Length; i++)
            {
                this.weatherDataMonth[i].Clear();
            }
            for (int i = 0; i < weatherDataDay.Length; i++)
            {
                this.weatherDataDay[i].Clear();
            }
            for (int hour = 0; hour < weatherDataHourMinute.Length; hour++)
            {
                for (int minute = 0; minute < weatherDataHourMinute[hour].Length; minute++)
                {
                    weatherDataHourMinute[hour][minute].Clear();
                }
            }

        }

        private void ClearWeatherDataDevice()
        {
            cmbDevice.Items.Clear(); // 清空 cmbDevice 的項目
        }

        private void ClearWeatherDataDay()
        {
            for (int i = 0; i < weatherDataDay.Length; i++)
            {
                this.weatherDataDay[i].Clear();
            }
        }

        private void ClearWeatherDataHourMinute()
        {
            for (int hour = 0; hour < weatherDataHourMinute.Length; hour++)
            {
                for (int minute = 0; minute < weatherDataHourMinute[hour].Length; minute++)
                {
                    weatherDataHourMinute[hour][minute].Clear();
                }
            }
        }
        private void EnableDayButton()
        {
            foreach (Button button in btnDay)
            {
                button.Enabled = true;
                button.BackColor = Color.DarkGray;
            }
        }
        private void DisableDayButton()
        {
            foreach (Button button in btnDay)
            {
                button.Enabled = false;
                button.BackColor = Color.DarkGray;
            }
        }
        private void IsEnableCutButton(bool value)
        {
            btnCut0717.Enabled = value; // 啟用 btnCut0717 按鈕
            btnCut0709.Enabled = value; // 啟用 btnCut0709 按鈕
            btnCut0917.Enabled = value; // 啟用 btnCut0917 按鈕
        }


        private List<string> GetWeatherDataHourMinute(int startHour, int endHour)
        {
            ClearWeatherDataHourMinute();

            for (int i = 0; i < weatherDataDay[selectedDay - 1].Count; i++)
            {
                WeatherData data = weatherDataDay[selectedDay - 1][i];

                weatherDataHourMinute[data.GetHour() - 1][data.GetMinute() / 10].Add(data);
            }

            List<string> result = new List<string>();

            for (int hour = startHour; hour <= endHour; hour++)
            {
                for (int minute = 0; minute < weatherDataHourMinute[hour - 1].Length; minute++)
                {
                    WeatherDataCollection data = weatherDataHourMinute[hour - 1][minute];
                    if (data.Count > 0)
                    {
                        result.Add(data.GetAverageCSV());
                    }
                }
            }

            return result;
        }


        #region 控制項事件

        private void frmMain_Load(object sender, EventArgs e)
        {
            RefreshTrainingData();

            for (int i = 0; i < weatherDataMonth.Length; i++)
            {
                this.weatherDataMonth[i] = new WeatherDataCollection();
            }
            for (int i = 0; i < weatherDataDay.Length; i++)
            {
                this.weatherDataDay[i] = new WeatherDataCollection();
            }

            for (int hour = 0; hour < weatherDataHourMinute.Length; hour++)
            {
                weatherDataHourMinute[hour] = new WeatherDataCollection[6];
                for (int minute = 0; minute < 6; minute++)
                {
                    weatherDataHourMinute[hour][minute] = new WeatherDataCollection();
                }
            }

            int buttonsPerRow = 10; // 每行顯示10個按鈕
            int buttonSize = 35; // 按鈕的寬度和高度都為35
            int horizontalSpacing = 5; // 按鈕間水平間距
            int verticalSpacing = 5; // 按鈕間垂直間距

            // 第一個按鈕的起始位置
            int startX = 12;
            int startY = 76;

            for (int i = 0; i < 31; i++)
            {
                btnDay[i] = new Button();

                // 計算按鈕的 X 和 Y 位置
                int x = startX + (i % buttonsPerRow) * (buttonSize + horizontalSpacing);
                int y = startY + (i / buttonsPerRow) * (buttonSize + verticalSpacing);

                btnDay[i].BackColor = Color.DarkGray;
                btnDay[i].Location = new System.Drawing.Point(x, y);
                btnDay[i].Name = $"button{i + 1}";
                btnDay[i].Size = new System.Drawing.Size(buttonSize, buttonSize); // 按鈕大小為35x35
                btnDay[i].Text = (i + 1).ToString(); // 文字為天數 1, 2, 3, ..., 31
                btnDay[i].UseVisualStyleBackColor = false;
                btnDay[i].Click += btnDay_Click; // 綁定點擊事件
                this.Controls.Add(btnDay[i]);
            }
        }

        private void cmbDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFileName = cmbDevice.Text;
            string filePath = Path.Combine("TrainingData", selectedFileName);

            if (File.Exists(filePath))
            {
                ClearWeatherDataMonth();


                string[] lines = File.ReadAllLines(filePath);
                for (int i = 1; i < lines.Length; i++) // 從第二行開始，跳過標題
                {
                    WeatherData weatherData = new WeatherData(lines[i]);
                    int month = weatherData.GetMonth();
                    this.weatherDataMonth[month - 1].Add(weatherData);
                }

                cmbMonth.Items.Clear(); // 清空 cmbMonth 的項目
                for (int i = 0; i < weatherDataMonth.Length; i++)
                {
                    if (weatherDataMonth[i].Count > 0)
                    {
                        cmbMonth.Items.Add((i + 1).ToString("D2")); // 格式化為 01, 02, ... 並直接加入 cmbMonth
                    }
                }
            }
            else
            {
                MessageBox.Show("選擇的檔案不存在", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedMonth = int.Parse(cmbMonth.Text);
            WeatherDataCollection selectedMonthData = weatherDataMonth[selectedMonth - 1];

            ClearWeatherDataDay(); // 清空每一天的資料
            // 將選擇月份的資料添加到 weatherDataDay 中
            foreach (var data in selectedMonthData)
            {
                int day = data.GetDay();
                this.weatherDataDay[day - 1].Add(data); // 直接添加資料，不檢查是否已有資料
            }

            // 檢查每一天的資料是否完整
            for (int i = 0; i < weatherDataDay.Length; i++)
            {
                // 創建一個二維布林陣列，用於標記每小時的每十分鐘是否有資料
                bool[][] isHasHourMinute = new bool[24][];
                // 初始化每小時的布林陣列，長度為6，表示每小時的六個十分鐘
                for (int hour = 0; hour < 24; hour++)
                {
                    isHasHourMinute[hour] = new bool[6];
                }
                // 遍歷當天的所有資料，標記每小時的每十分鐘是否有資料
                for (int j = 0; j < weatherDataDay[i].Count; j++)
                {
                    isHasHourMinute[weatherDataDay[i][j].GetHour() - 1][weatherDataDay[i][j].GetMinute() / 10] = true;
                }

                // 檢查7點到16點的資料是否完整
                int startHour = 7;
                int endHour = 16;
                bool isHasFullData = true;
                // 檢查當天的資料是否完整，並根據完整性設置背景顏色
                for (int hour = startHour; hour < endHour; hour++)
                {
                    bool hasFullMinute = true;
                    for (int minute = 0; minute < 6; minute++)
                    {
                        if (!isHasHourMinute[hour][minute])
                        {
                            hasFullMinute = false;
                            break;
                        }
                    }
                    if (!hasFullMinute)
                    {
                        isHasFullData = false;
                        break;
                    }
                }

                // 根據資料完整性設置 btnDay[i] 的背景顏色
                if (weatherDataDay[i].Count == 0)
                {
                    btnDay[i].BackColor = Color.DarkGray; // 整天都沒資料
                }
                else if (isHasFullData)
                {
                    btnDay[i].BackColor = Color.Orange; // 資料完整
                }
                else
                {
                    btnDay[i].BackColor = Color.Green; // 資料不完整
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshTrainingData();
        }

        private void btnDay_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            selectedDay = int.Parse(clickedButton.Text);

            IsEnableCutButton(true);
        }

        private void SaveCSV(int startHour, int endHour)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                string deviceName = cmbDevice.Text.Split("_")[0];
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
                saveFileDialog.FileName = $"{deviceName}_{cmbMonth.Text}{selectedDay:D2}_{startHour:D2}{endHour:D2}.csv"; // 預設檔名
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    List<string> result = GetWeatherDataHourMinute(startHour, endHour);
                    File.WriteAllLines(saveFileDialog.FileName, result);

                    ShowOutput($"{saveFileDialog.FileName} 存檔完成");
                }
            }
        }


        private void btnCut0716_Click(object sender, EventArgs e)
        {
            if (selectedDay < 0)
            {
                ShowOutput("沒選擇要切的日期");
                return;
            }
            SaveCSV(7, 16);
        }

        private void btnCut0708_Click(object sender, EventArgs e)
        {
            if (selectedDay < 0)
            {
                ShowOutput("沒選擇要切的日期");
                return;
            }

            SaveCSV(7, 8);
        }

        private void btnCut0916_Click(object sender, EventArgs e)
        {
            if (selectedDay < 0)
            {
                ShowOutput("沒選擇要切的日期");
                return;
            }

            SaveCSV(9, 16);
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSV files (*.csv)|*.csv";
                openFileDialog.Title = "選擇要合併的CSV檔案";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string filePath in openFileDialog.FileNames)
                    {
                        //lstMergeData. (filePath);
                        lstMergeData.Items.Add(Path.GetFileName(filePath));
                        mergeFullPath.Add(filePath); // 將完整路徑存成變數
                        ShowOutput($"加入 {filePath} 成功");
                    }

                }
            }
        }
        #endregion



        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstMergeData.SelectedItems.Count == 0)
            {
                ShowOutput("請選擇要刪除的項目");
                return;
            }
            foreach (var selectedItem in lstMergeData.SelectedItems.Cast<string>().ToList())
            {
                mergeFullPath.RemoveAt(lstMergeData.Items.IndexOf(selectedItem));
                lstMergeData.Items.Remove(selectedItem);
            }
            ShowOutput("已刪除選擇的項目");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lstMergeData.Items.Clear();
            mergeFullPath.Clear();
            ShowOutput("已清空所有檔案和檔案路徑");
        }

        private void btn_Click(object sender, EventArgs e)
        {
        if (mergeFullPath.Count == 0)
        {
            ShowOutput("沒有檔案可以合併");
            return;
        }

        using (SaveFileDialog saveFileDialog = new SaveFileDialog())
        {
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            saveFileDialog.Title = "儲存合併後的CSV檔案";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    foreach (var filePath in mergeFullPath)
                    {
                        var lines = File.ReadAllLines(filePath);
                        foreach (var line in lines)
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
                ShowOutput($"檔案已成功合併並儲存至 {saveFileDialog.FileName}");
            }
        }

        }
    }
}
