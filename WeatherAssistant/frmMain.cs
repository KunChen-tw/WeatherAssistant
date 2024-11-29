using System.Collections.Specialized;
using System.Reflection;
using System.Windows.Forms;
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
            SetWindowTitleWithVersion();
        }
        private void SetWindowTitleWithVersion()
        {
            // 獲取組件的版本資訊
            Version? version = Assembly.GetExecutingAssembly().GetName().Version;
            if (version != null)
            {
                string versionPrefix = $"{version.Major}.{version.Minor}.{version.Build}";
                // 設定視窗標題
                this.Text = $"{this.Text} - v{versionPrefix}";
            }


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
            IsEnableCutBySelect(false);
            selectedDay = -1;
        }

        private void ShowOutput(string str)
        {
            txtOutput.AppendText($"{str}\n");
            txtOutput.SelectionStart = txtOutput.Text.Length;
            txtOutput.ScrollToCaret();
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
        //private void IsEnableDayButton(bool value)
        //{
        //    foreach (Button button in btnDay)
        //    {
        //        button.Enabled = true;
        //        button.BackColor = Color.DarkGray;
        //    }
        //}
        //private void DisableDayButton()
        //{
        //    foreach (Button button in btnDay)
        //    {
        //        button.Enabled = false;
        //        button.BackColor = Color.DarkGray;
        //    }
        //}
        private void IsEnableCutButton(bool value)
        {
            grpCutData.Enabled = value;
            //btnCut0717.Enabled = value; // 啟用 btnCut0717 按鈕
            //btnCut0709.Enabled = value; // 啟用 btnCut0709 按鈕
            //btnCut0917.Enabled = value; // 啟用 btnCut0917 按鈕
        }
        private void IsEnableCutBySelect(bool value)
        {
            grpCutBySelect.Enabled = value;
            //cmbCutStart.Enabled = value;
            //cmbCutEnd.Enabled = value;
            //btnCutBySelectDay.Enabled = value;
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

            cmbSearchMonth.SelectedIndex = 0;
            cmbSearchDay.SelectedIndex = 0;

            cmbCutStart.SelectedIndex = 0;
            cmbCutEnd.SelectedIndex = 0;
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
                    if (weatherDataDay[i][j].GetHour() - 1 < 0)
                    {
                        ShowOutput($"資料超過範圍：{weatherDataDay[i][j].RawData}");
                        continue;
                    }
                    try
                    {
                        isHasHourMinute[weatherDataDay[i][j].GetHour() - 1][weatherDataDay[i][j].GetMinute() / 10] = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"例外錯誤: {ex.Message}, Data:{weatherDataDay[i][j].RawData}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

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
            IsEnableCutBySelect(true);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshTrainingData();
            ShowOutput("資料更新");
        }

        private void btnDay_Click(object sender, EventArgs e)
        {


            Button? clickedButton = sender as Button;

            if (clickedButton == null) { return; }

            selectedDay = int.Parse(clickedButton.Text);

            IsEnableCutButton(true);
            ShowOutput($"選擇 {cmbMonth.Text}月{selectedDay:D2}日");
        }

        private void SaveCSV(string fileName, int startHour, int endHour, bool isComplete)
        {
            List<string> result = GetWeatherDataHourMinute(startHour, endHour);

            if (result.Count == 0) { return; }

            if (isComplete && endHour <= 8)
            {
                string lastLine = result[^1];

                string firstEightChars = lastLine.Substring(0, 8);
                string firstThirteenChars = lastLine.Substring(12, 2);
                for (int i = 9; i < 17; i++)
                {
                    for (int j = 0; j < 60; j += 10)
                    {
                        string strNewLine = $"{firstEightChars}{i:d2}{j:d2}{firstThirteenChars},,,,,,";
                        result.Add(strNewLine);
                    }
                }
                //ShowOutput(firstLine);
            }
            File.WriteAllLines(fileName, result);

            ShowOutput($"{fileName} 存檔完成");
        }

        private void SaveCSVDialog(int startHour, int endHour, bool isShowDialog, bool isComplete)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                string deviceName = cmbDevice.Text.Split("_")[0];
                int deviceID = int.Parse(deviceName.Substring(1));
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
                saveFileDialog.FileName = $"L{deviceID:D2}_{cmbMonth.Text}{selectedDay:D2}_{startHour:D2}{endHour:D2}.csv"; // 預設檔名

                if (isShowDialog)
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        SaveCSV(saveFileDialog.FileName, startHour, endHour, isComplete);

                    }
                }
                else
                {
                    SaveCSV(saveFileDialog.FileName, startHour, endHour, isComplete);
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
            SaveCSVDialog(7, 16, true, false);
        }

        private void btnCut0708_Click(object sender, EventArgs e)
        {
            if (selectedDay < 0)
            {
                ShowOutput("沒選擇要切的日期");
                return;
            }

            SaveCSVDialog(7, 8, true, true);
        }

        private void btnCut0916_Click(object sender, EventArgs e)
        {
            if (selectedDay < 0)
            {
                ShowOutput("沒選擇要切的日期");
                return;
            }

            SaveCSVDialog(9, 16, true, false);
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

        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            if (mergeFullPath.Count == 0)
            {
                ShowOutput("沒有檔案可以合併");
                return;
            }
            int iProblemNumber = -1;
            using (frmInputDialog frmInput = new frmInputDialog())
            {
                if (frmInput.ShowDialog() == DialogResult.OK)
                {
                    iProblemNumber = frmInput.ProblemNumber;
                    // 在這裡處理使用者輸入的題號
                    ShowOutput($"您輸入的題號是: {iProblemNumber}");
                }
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
                saveFileDialog.Title = "儲存合併後的CSV檔案";
                int saveCount = 1;
                if (iProblemNumber > 0)
                {
                    saveCount = lstMergeData.Items.Count - 1;
                }

                if (iProblemNumber > 0)
                {
                    string strfile = lstMergeData.Items[^1].ToString().Substring(0, 9);
                    saveFileDialog.FileName = $"D{iProblemNumber:D3}_{strfile}{lstMergeData.Items.Count - 1:D2}.csv"; // 預設檔名
                }
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        writer.WriteLine("Serial,WindSpeed(m/s),Pressure(hpa),Temperature(°C),Humidity(%),Sunlight(Lux),Power(mW)");

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

                    //mergeFullPath.RemoveAt(0); // 移除第一筆資料

                    //lstMergeData.Items.RemoveAt(0); // 刪除第一筆資料
                }

                mergeFullPath.Clear();
                lstMergeData.Items.Clear();
            }
        }

        private void btnCutBySelectDay_Click(object sender, EventArgs e)
        {
            int startCut = int.Parse(cmbCutStart.Text) - 1;
            int endCut = int.Parse(cmbCutEnd.Text) - 1;

            if (startCut >= endCut)
            {
                MessageBox.Show("開始天不能大於等於結束天", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (btnDay[startCut].BackColor != Color.Orange)
            {
                MessageBox.Show("開始天必需是橙色", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //if (btnDay[endCut].BackColor != Color.Green)
            //{
            //    MessageBox.Show("結束天必需是綠色", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            for (int i = startCut; i <= endCut; i++)
            {
                btnDay[i].PerformClick();
                if (btnDay[i].BackColor == Color.Orange)
                {
                    SaveCSVDialog(7, 16, false, false);
                }
                else
                {
                    SaveCSVDialog(7, 8, false, true);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int iSearchMonth = int.Parse(cmbSearchMonth.Text);
            int iSearchDay = int.Parse(cmbSearchDay.Text);

            if (cmbDevice.Items.Count == 0)
            {
                MessageBox.Show("無裝置資料", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<string> lstDeviceMsg = new List<string>();
            List<string> lstDeviceName = new List<string>();

            for (int i = 0; i < cmbDevice.Items.Count; i++)
            {
                cmbDevice.SelectedIndex = i;

                bool isFindMonth = false;
                for (int j = 0; j < cmbMonth.Items.Count; j++)
                {
                    if (cmbMonth.Items[j] == null) { continue; }
                    if (iSearchMonth == int.Parse(cmbMonth.Items[j].ToString()))
                    {
                        cmbMonth.SelectedIndex = j;
                        isFindMonth = true;
                    }
                }

                if (!isFindMonth)
                    continue;

                if (btnDay[iSearchDay - 1].BackColor == Color.Orange)
                {
                    string strDeviceMsg = $"選擇 {cmbDevice.Text} 的 {iSearchMonth:D2}月{iSearchDay:D2}日";
                    ShowOutput(strDeviceMsg);

                    int iFirstDay = iSearchDay - 1;
                    int iLastDay = iSearchDay - 1;
                    //往前看連續完整天數
                    for (int j = iSearchDay - 2; j >= 0; j--)
                    {
                        if (btnDay[j].BackColor != Color.Orange)
                        {
                            iFirstDay = j + 1;
                            break;
                        }
                    }
                    //往前後連續完整天數
                    for (int j = iSearchDay; j < 31; j++)
                    {
                        if (btnDay[j].BackColor != Color.Orange)
                        {
                            iLastDay = j - 1;
                            break;
                        }
                    }
                    string strDeviceRange = $"選擇 {cmbDevice.Text} 的完整資料，範圍從 {iSearchMonth:D2}月{iFirstDay + 1:D2}日 到 {iSearchMonth:D2}月{iLastDay + 1:D2}日";
                    ShowOutput(strDeviceRange);
                    lstDeviceMsg.Add(strDeviceRange);
                    lstDeviceName.Add(cmbDevice.Text.Split("_")[0]);
                    //for (int j = iFirstDay; j <= iLastDay; j++)
                    //{

                    //    int startHour = 7;
                    //    int endHour = 16;
                    //    bool isComplete = false;
                    //    btnDay[j].PerformClick();
                    //    if (btnDay[j].BackColor == Color.Orange)
                    //    {
                    //        startHour = 7;
                    //        endHour = 16;
                    //    }
                    //    else
                    //    {
                    //        startHour = 7;
                    //        endHour = 8;
                    //        isComplete = true;
                    //    }
                    //    string deviceName = cmbDevice.Text.Split("_")[0];
                    //    int deviceID = int.Parse(deviceName.Substring(1));
                    //    string strFileName = $"L{deviceID:D2}_{cmbMonth.Text}{selectedDay:D2}_{startHour:D2}{endHour:D2}.csv"; // 預設檔名
                    //    SaveCSV(strFileName, startHour, endHour, isComplete);
                    //}
                }


            }
            foreach (var item in lstDeviceMsg)
            {
                ShowOutput(item);
            }
            lstDeviceName.Sort((x, y) =>
            {
                // 解析字串中的數字部分
                int numX = int.Parse(x.Substring(1)); // 移除 "L" 並轉成數字
                int numY = int.Parse(y.Substring(1));
                return numX.CompareTo(numY); // 比較數字大小
            });
            ShowOutput(string.Join(",", lstDeviceName));
            ShowOutput($"尋找 {iSearchMonth:D2}月{iSearchDay:D2}日 結束");
        }
    }
}
