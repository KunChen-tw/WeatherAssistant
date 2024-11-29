
namespace WeatherAssistant
{
    partial class FrmMain
    {
        private Button[] btnDay = new Button[31];

        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            grpDevice = new GroupBox();
            cmbDevice = new ComboBox();
            gbMonth = new GroupBox();
            cmbMonth = new ComboBox();
            grpCutData = new GroupBox();
            btnCut0917 = new Button();
            btnCut0709 = new Button();
            btnCut0717 = new Button();
            btnRefresh = new Button();
            grpMergeData = new GroupBox();
            btnExportCSV = new Button();
            btnClear = new Button();
            btnDelete = new Button();
            btnAdd = new Button();
            lstMergeData = new ListBox();
            txtOutput = new RichTextBox();
            grpCutBySelect = new GroupBox();
            btnCutBySelectDay = new Button();
            cmbCutEnd = new ComboBox();
            cmbCutStart = new ComboBox();
            grpSearchOtherDevice = new GroupBox();
            btnSearch = new Button();
            cmbSearchDay = new ComboBox();
            cmbSearchMonth = new ComboBox();
            grpDevice.SuspendLayout();
            gbMonth.SuspendLayout();
            grpCutData.SuspendLayout();
            grpMergeData.SuspendLayout();
            grpCutBySelect.SuspendLayout();
            grpSearchOtherDevice.SuspendLayout();
            SuspendLayout();
            // 
            // grpDevice
            // 
            grpDevice.Controls.Add(cmbDevice);
            grpDevice.Location = new Point(12, 12);
            grpDevice.Name = "grpDevice";
            grpDevice.Size = new Size(187, 58);
            grpDevice.TabIndex = 3;
            grpDevice.TabStop = false;
            grpDevice.Text = "選擇裝置";
            // 
            // cmbDevice
            // 
            cmbDevice.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDevice.FormattingEnabled = true;
            cmbDevice.Location = new Point(6, 22);
            cmbDevice.Name = "cmbDevice";
            cmbDevice.Size = new Size(171, 23);
            cmbDevice.TabIndex = 2;
            cmbDevice.SelectedIndexChanged += cmbDevice_SelectedIndexChanged;
            // 
            // gbMonth
            // 
            gbMonth.Controls.Add(cmbMonth);
            gbMonth.Location = new Point(205, 12);
            gbMonth.Name = "gbMonth";
            gbMonth.Size = new Size(141, 58);
            gbMonth.TabIndex = 4;
            gbMonth.TabStop = false;
            gbMonth.Text = "選擇月份";
            // 
            // cmbMonth
            // 
            cmbMonth.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMonth.FormattingEnabled = true;
            cmbMonth.Location = new Point(6, 22);
            cmbMonth.Name = "cmbMonth";
            cmbMonth.Size = new Size(124, 23);
            cmbMonth.TabIndex = 3;
            cmbMonth.SelectedIndexChanged += cmbMonth_SelectedIndexChanged;
            // 
            // grpCutData
            // 
            grpCutData.Controls.Add(btnCut0917);
            grpCutData.Controls.Add(btnCut0709);
            grpCutData.Controls.Add(btnCut0717);
            grpCutData.Location = new Point(12, 267);
            grpCutData.Name = "grpCutData";
            grpCutData.Size = new Size(203, 56);
            grpCutData.TabIndex = 5;
            grpCutData.TabStop = false;
            grpCutData.Text = "切割資料";
            // 
            // btnCut0917
            // 
            btnCut0917.Location = new Point(136, 22);
            btnCut0917.Name = "btnCut0917";
            btnCut0917.Size = new Size(59, 23);
            btnCut0917.TabIndex = 2;
            btnCut0917.Text = "09-16";
            btnCut0917.UseVisualStyleBackColor = true;
            btnCut0917.Click += btnCut0916_Click;
            // 
            // btnCut0709
            // 
            btnCut0709.Location = new Point(71, 22);
            btnCut0709.Name = "btnCut0709";
            btnCut0709.Size = new Size(59, 23);
            btnCut0709.TabIndex = 1;
            btnCut0709.Text = "07-08";
            btnCut0709.UseVisualStyleBackColor = true;
            btnCut0709.Click += btnCut0708_Click;
            // 
            // btnCut0717
            // 
            btnCut0717.Location = new Point(6, 22);
            btnCut0717.Name = "btnCut0717";
            btnCut0717.Size = new Size(59, 23);
            btnCut0717.TabIndex = 0;
            btnCut0717.Text = "07-16";
            btnCut0717.UseVisualStyleBackColor = true;
            btnCut0717.Click += btnCut0716_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(352, 33);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(69, 23);
            btnRefresh.TabIndex = 6;
            btnRefresh.Text = "重新整理";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // grpMergeData
            // 
            grpMergeData.Controls.Add(btnExportCSV);
            grpMergeData.Controls.Add(btnClear);
            grpMergeData.Controls.Add(btnDelete);
            grpMergeData.Controls.Add(btnAdd);
            grpMergeData.Controls.Add(lstMergeData);
            grpMergeData.Location = new Point(427, 12);
            grpMergeData.Name = "grpMergeData";
            grpMergeData.Size = new Size(255, 311);
            grpMergeData.TabIndex = 7;
            grpMergeData.TabStop = false;
            grpMergeData.Text = "合併資料";
            // 
            // btnExportCSV
            // 
            btnExportCSV.Location = new Point(171, 277);
            btnExportCSV.Name = "btnExportCSV";
            btnExportCSV.Size = new Size(78, 23);
            btnExportCSV.TabIndex = 4;
            btnExportCSV.Text = "合併匯出";
            btnExportCSV.UseVisualStyleBackColor = true;
            btnExportCSV.Click += btnExportCSV_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(119, 277);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(46, 23);
            btnClear.TabIndex = 3;
            btnClear.Text = "清除";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(67, 277);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(46, 23);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "刪除";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(6, 277);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(55, 23);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "加入";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // lstMergeData
            // 
            lstMergeData.FormattingEnabled = true;
            lstMergeData.ItemHeight = 15;
            lstMergeData.Location = new Point(6, 21);
            lstMergeData.Name = "lstMergeData";
            lstMergeData.SelectionMode = SelectionMode.MultiSimple;
            lstMergeData.Size = new Size(243, 244);
            lstMergeData.TabIndex = 0;
            // 
            // txtOutput
            // 
            txtOutput.Location = new Point(12, 329);
            txtOutput.Name = "txtOutput";
            txtOutput.Size = new Size(670, 120);
            txtOutput.TabIndex = 8;
            txtOutput.Text = "";
            // 
            // grpCutBySelect
            // 
            grpCutBySelect.Controls.Add(btnCutBySelectDay);
            grpCutBySelect.Controls.Add(cmbCutEnd);
            grpCutBySelect.Controls.Add(cmbCutStart);
            grpCutBySelect.Enabled = false;
            grpCutBySelect.Location = new Point(213, 267);
            grpCutBySelect.Name = "grpCutBySelect";
            grpCutBySelect.Size = new Size(208, 56);
            grpCutBySelect.TabIndex = 9;
            grpCutBySelect.TabStop = false;
            grpCutBySelect.Text = "指定日期";
            // 
            // btnCutBySelectDay
            // 
            btnCutBySelectDay.Location = new Point(140, 24);
            btnCutBySelectDay.Name = "btnCutBySelectDay";
            btnCutBySelectDay.Size = new Size(62, 23);
            btnCutBySelectDay.TabIndex = 2;
            btnCutBySelectDay.Text = "切割";
            btnCutBySelectDay.UseVisualStyleBackColor = true;
            btnCutBySelectDay.Click += btnCutBySelectDay_Click;
            // 
            // cmbCutEnd
            // 
            cmbCutEnd.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCutEnd.FormattingEnabled = true;
            cmbCutEnd.Items.AddRange(new object[] { "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31" });
            cmbCutEnd.Location = new Point(73, 25);
            cmbCutEnd.Name = "cmbCutEnd";
            cmbCutEnd.Size = new Size(61, 23);
            cmbCutEnd.TabIndex = 1;
            // 
            // cmbCutStart
            // 
            cmbCutStart.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCutStart.FormattingEnabled = true;
            cmbCutStart.Items.AddRange(new object[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30" });
            cmbCutStart.Location = new Point(6, 25);
            cmbCutStart.Name = "cmbCutStart";
            cmbCutStart.Size = new Size(61, 23);
            cmbCutStart.TabIndex = 0;
            // 
            // grpSearchOtherDevice
            // 
            grpSearchOtherDevice.Controls.Add(btnSearch);
            grpSearchOtherDevice.Controls.Add(cmbSearchDay);
            grpSearchOtherDevice.Controls.Add(cmbSearchMonth);
            grpSearchOtherDevice.Location = new Point(213, 206);
            grpSearchOtherDevice.Name = "grpSearchOtherDevice";
            grpSearchOtherDevice.Size = new Size(208, 56);
            grpSearchOtherDevice.TabIndex = 11;
            grpSearchOtherDevice.TabStop = false;
            grpSearchOtherDevice.Text = "尋找日期";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(140, 24);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(62, 23);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "尋找";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // cmbSearchDay
            // 
            cmbSearchDay.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSearchDay.FormattingEnabled = true;
            cmbSearchDay.Items.AddRange(new object[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31" });
            cmbSearchDay.Location = new Point(73, 25);
            cmbSearchDay.Name = "cmbSearchDay";
            cmbSearchDay.Size = new Size(61, 23);
            cmbSearchDay.TabIndex = 1;
            // 
            // cmbSearchMonth
            // 
            cmbSearchMonth.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSearchMonth.FormattingEnabled = true;
            cmbSearchMonth.Items.AddRange(new object[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" });
            cmbSearchMonth.Location = new Point(6, 25);
            cmbSearchMonth.Name = "cmbSearchMonth";
            cmbSearchMonth.Size = new Size(61, 23);
            cmbSearchMonth.TabIndex = 0;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(694, 461);
            Controls.Add(grpSearchOtherDevice);
            Controls.Add(grpCutBySelect);
            Controls.Add(txtOutput);
            Controls.Add(grpMergeData);
            Controls.Add(btnRefresh);
            Controls.Add(grpCutData);
            Controls.Add(gbMonth);
            Controls.Add(grpDevice);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "氣候資料處理工具";
            Load += frmMain_Load;
            grpDevice.ResumeLayout(false);
            gbMonth.ResumeLayout(false);
            grpCutData.ResumeLayout(false);
            grpMergeData.ResumeLayout(false);
            grpCutBySelect.ResumeLayout(false);
            grpSearchOtherDevice.ResumeLayout(false);
            ResumeLayout(false);
        }



        #endregion

        private GroupBox grpDevice;
        private ComboBox cmbDevice;
        private GroupBox gbMonth;
        private ComboBox cmbMonth;
        private GroupBox grpCutData;
        private Button btnRefresh;
        private Button btnCut0917;
        private Button btnCut0709;
        private Button btnCut0717;
        private GroupBox grpMergeData;
        private ListBox lstMergeData;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnExportCSV;
        private Button btnClear;
        private RichTextBox txtOutput;
        private GroupBox grpCutBySelect;
        private Button btnCutBySelectDay;
        private ComboBox cmbCutEnd;
        private ComboBox cmbCutStart;
        private GroupBox grpSearchOtherDevice;
        private Button btnSearch;
        private ComboBox cmbSearchDay;
        private ComboBox cmbSearchMonth;
    }
}
