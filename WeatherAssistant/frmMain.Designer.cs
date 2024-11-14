
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
            btn = new Button();
            btnClear = new Button();
            btnDelete = new Button();
            btnAdd = new Button();
            lstMergeData = new ListBox();
            txtOutput = new RichTextBox();
            grpDevice.SuspendLayout();
            gbMonth.SuspendLayout();
            grpCutData.SuspendLayout();
            grpMergeData.SuspendLayout();
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
            grpCutData.Location = new Point(12, 241);
            grpCutData.Name = "grpCutData";
            grpCutData.Size = new Size(203, 56);
            grpCutData.TabIndex = 5;
            grpCutData.TabStop = false;
            grpCutData.Text = "切割資料";
            // 
            // btnCut0917
            // 
            btnCut0917.Enabled = false;
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
            btnCut0709.Enabled = false;
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
            btnCut0717.Enabled = false;
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
            grpMergeData.Controls.Add(btn);
            grpMergeData.Controls.Add(btnClear);
            grpMergeData.Controls.Add(btnDelete);
            grpMergeData.Controls.Add(btnAdd);
            grpMergeData.Controls.Add(lstMergeData);
            grpMergeData.Location = new Point(427, 12);
            grpMergeData.Name = "grpMergeData";
            grpMergeData.Size = new Size(255, 282);
            grpMergeData.TabIndex = 7;
            grpMergeData.TabStop = false;
            grpMergeData.Text = "合併資料";
            // 
            // btn
            // 
            btn.Location = new Point(171, 253);
            btn.Name = "btn";
            btn.Size = new Size(78, 23);
            btn.TabIndex = 4;
            btn.Text = "合併匯出";
            btn.UseVisualStyleBackColor = true;
            btn.Click += btn_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(119, 253);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(46, 23);
            btnClear.TabIndex = 3;
            btnClear.Text = "清除";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(67, 253);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(46, 23);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "刪除";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(6, 253);
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
            lstMergeData.Size = new Size(243, 229);
            lstMergeData.TabIndex = 0;
            // 
            // txtOutput
            // 
            txtOutput.Location = new Point(12, 303);
            txtOutput.Name = "txtOutput";
            txtOutput.Size = new Size(670, 96);
            txtOutput.TabIndex = 8;
            txtOutput.Text = "";
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(694, 409);
            Controls.Add(txtOutput);
            Controls.Add(grpMergeData);
            Controls.Add(btnRefresh);
            Controls.Add(grpCutData);
            Controls.Add(gbMonth);
            Controls.Add(grpDevice);
            FormBorderStyle = FormBorderStyle.FixedDialog;
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
        private Button btn;
        private Button btnClear;
        private RichTextBox txtOutput;
    }
}
