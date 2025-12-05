namespace AutoEBookBuilder
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.messageLabel = new System.Windows.Forms.Label();
            this.eBookTextBox = new System.Windows.Forms.RichTextBox();
            this.rawFilesListBox = new System.Windows.Forms.ListBox();
            this.addRawFileButton = new System.Windows.Forms.Button();
            this.removeRawFileButton = new System.Windows.Forms.Button();
            this.newFilePathTextBox = new System.Windows.Forms.TextBox();
            this.liftFileButton = new System.Windows.Forms.Button();
            this.lowerFileButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.buildButton = new System.Windows.Forms.Button();
            this.explorerButton = new System.Windows.Forms.Button();
            this.explorerDialog = new System.Windows.Forms.OpenFileDialog();
            this.buildCounterLabel = new System.Windows.Forms.Label();
            this.l = new System.Windows.Forms.Label();
            this.totalCounterLabel = new System.Windows.Forms.Label();
            this.saveExplorerDialog = new System.Windows.Forms.SaveFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.apiListComboBox = new System.Windows.Forms.ComboBox();
            this.addApiButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // messageLabel
            // 
            this.messageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(525, 423);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.messageLabel.Size = new System.Drawing.Size(96, 20);
            this.messageLabel.TabIndex = 0;
            this.messageLabel.Text = "Сообщение";
            this.messageLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.messageLabel.Click += new System.EventHandler(this.messageLabel_Click);
            // 
            // eBookTextBox
            // 
            this.eBookTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eBookTextBox.Location = new System.Drawing.Point(12, 12);
            this.eBookTextBox.Name = "eBookTextBox";
            this.eBookTextBox.Size = new System.Drawing.Size(400, 393);
            this.eBookTextBox.TabIndex = 2;
            this.eBookTextBox.Text = "";
            // 
            // rawFilesListBox
            // 
            this.rawFilesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rawFilesListBox.FormattingEnabled = true;
            this.rawFilesListBox.ItemHeight = 20;
            this.rawFilesListBox.Location = new System.Drawing.Point(418, 81);
            this.rawFilesListBox.Name = "rawFilesListBox";
            this.rawFilesListBox.Size = new System.Drawing.Size(370, 324);
            this.rawFilesListBox.TabIndex = 3;
            // 
            // addRawFileButton
            // 
            this.addRawFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addRawFileButton.Location = new System.Drawing.Point(418, 12);
            this.addRawFileButton.Name = "addRawFileButton";
            this.addRawFileButton.Size = new System.Drawing.Size(100, 31);
            this.addRawFileButton.TabIndex = 4;
            this.addRawFileButton.Text = "Добавить";
            this.addRawFileButton.UseVisualStyleBackColor = true;
            this.addRawFileButton.Click += new System.EventHandler(this.addRawFileButton_Click);
            // 
            // removeRawFileButton
            // 
            this.removeRawFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeRawFileButton.Location = new System.Drawing.Point(524, 12);
            this.removeRawFileButton.Name = "removeRawFileButton";
            this.removeRawFileButton.Size = new System.Drawing.Size(100, 31);
            this.removeRawFileButton.TabIndex = 5;
            this.removeRawFileButton.Text = "Удалить";
            this.removeRawFileButton.UseVisualStyleBackColor = true;
            this.removeRawFileButton.Click += new System.EventHandler(this.removeRawFileButton_Click);
            // 
            // newFilePathTextBox
            // 
            this.newFilePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newFilePathTextBox.Location = new System.Drawing.Point(418, 49);
            this.newFilePathTextBox.Name = "newFilePathTextBox";
            this.newFilePathTextBox.Size = new System.Drawing.Size(324, 26);
            this.newFilePathTextBox.TabIndex = 6;
            // 
            // liftFileButton
            // 
            this.liftFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.liftFileButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.liftFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.liftFileButton.Location = new System.Drawing.Point(630, 12);
            this.liftFileButton.Margin = new System.Windows.Forms.Padding(0);
            this.liftFileButton.Name = "liftFileButton";
            this.liftFileButton.Size = new System.Drawing.Size(40, 31);
            this.liftFileButton.TabIndex = 7;
            this.liftFileButton.Text = "☝️";
            this.liftFileButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.liftFileButton.UseVisualStyleBackColor = false;
            this.liftFileButton.Click += new System.EventHandler(this.liftFileButton_Click);
            // 
            // lowerFileButton
            // 
            this.lowerFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lowerFileButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lowerFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lowerFileButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lowerFileButton.Location = new System.Drawing.Point(676, 12);
            this.lowerFileButton.Margin = new System.Windows.Forms.Padding(0);
            this.lowerFileButton.Name = "lowerFileButton";
            this.lowerFileButton.Size = new System.Drawing.Size(40, 31);
            this.lowerFileButton.TabIndex = 8;
            this.lowerFileButton.Text = "👇";
            this.lowerFileButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lowerFileButton.UseVisualStyleBackColor = false;
            this.lowerFileButton.Click += new System.EventHandler(this.lowerFileButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(296, 417);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(116, 31);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // buildButton
            // 
            this.buildButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buildButton.Location = new System.Drawing.Point(418, 417);
            this.buildButton.Name = "buildButton";
            this.buildButton.Size = new System.Drawing.Size(100, 31);
            this.buildButton.TabIndex = 10;
            this.buildButton.Text = "Собрать";
            this.buildButton.UseVisualStyleBackColor = true;
            this.buildButton.Click += new System.EventHandler(this.buildButton_Click);
            // 
            // explorerButton
            // 
            this.explorerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.explorerButton.Location = new System.Drawing.Point(748, 44);
            this.explorerButton.Name = "explorerButton";
            this.explorerButton.Size = new System.Drawing.Size(40, 31);
            this.explorerButton.TabIndex = 11;
            this.explorerButton.Text = "🔎";
            this.explorerButton.UseVisualStyleBackColor = true;
            this.explorerButton.Click += new System.EventHandler(this.explorerButton_Click);
            // 
            // explorerDialog
            // 
            this.explorerDialog.Multiselect = true;
            // 
            // buildCounterLabel
            // 
            this.buildCounterLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buildCounterLabel.AutoSize = true;
            this.buildCounterLabel.Location = new System.Drawing.Point(12, 423);
            this.buildCounterLabel.Name = "buildCounterLabel";
            this.buildCounterLabel.Size = new System.Drawing.Size(18, 20);
            this.buildCounterLabel.TabIndex = 12;
            this.buildCounterLabel.Text = "0";
            // 
            // l
            // 
            this.l.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.l.AutoSize = true;
            this.l.Location = new System.Drawing.Point(36, 423);
            this.l.Name = "l";
            this.l.Size = new System.Drawing.Size(14, 20);
            this.l.TabIndex = 13;
            this.l.Text = "|";
            // 
            // totalCounterLabel
            // 
            this.totalCounterLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.totalCounterLabel.AutoSize = true;
            this.totalCounterLabel.Location = new System.Drawing.Point(56, 423);
            this.totalCounterLabel.Name = "totalCounterLabel";
            this.totalCounterLabel.Size = new System.Drawing.Size(18, 20);
            this.totalCounterLabel.TabIndex = 14;
            this.totalCounterLabel.Text = "0";
            // 
            // apiListComboBox
            // 
            this.apiListComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.apiListComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.apiListComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.apiListComboBox.FormattingEnabled = true;
            this.apiListComboBox.Location = new System.Drawing.Point(169, 417);
            this.apiListComboBox.Name = "apiListComboBox";
            this.apiListComboBox.Size = new System.Drawing.Size(121, 28);
            this.apiListComboBox.TabIndex = 15;
            // 
            // addApiButton
            // 
            this.addApiButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addApiButton.Location = new System.Drawing.Point(723, 12);
            this.addApiButton.Name = "addApiButton";
            this.addApiButton.Size = new System.Drawing.Size(65, 30);
            this.addApiButton.TabIndex = 16;
            this.addApiButton.Text = "АПИ";
            this.addApiButton.UseVisualStyleBackColor = true;
            this.addApiButton.Click += new System.EventHandler(this.addApiButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clearButton.Location = new System.Drawing.Point(688, 418);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(100, 31);
            this.clearButton.TabIndex = 17;
            this.clearButton.Text = "Очистить";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(627, 420);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(55, 27);
            this.button1.TabIndex = 18;
            this.button1.Text = "Срт";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(737, 269);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(8, 8);
            this.button2.TabIndex = 19;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 455);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.addApiButton);
            this.Controls.Add(this.apiListComboBox);
            this.Controls.Add(this.totalCounterLabel);
            this.Controls.Add(this.l);
            this.Controls.Add(this.buildCounterLabel);
            this.Controls.Add(this.explorerButton);
            this.Controls.Add(this.buildButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.lowerFileButton);
            this.Controls.Add(this.liftFileButton);
            this.Controls.Add(this.newFilePathTextBox);
            this.Controls.Add(this.removeRawFileButton);
            this.Controls.Add(this.addRawFileButton);
            this.Controls.Add(this.rawFilesListBox);
            this.Controls.Add(this.eBookTextBox);
            this.Controls.Add(this.messageLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Сборщик электронных книг";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.RichTextBox eBookTextBox;
        private System.Windows.Forms.ListBox rawFilesListBox;
        private System.Windows.Forms.Button addRawFileButton;
        private System.Windows.Forms.Button removeRawFileButton;
        private System.Windows.Forms.TextBox newFilePathTextBox;
        private System.Windows.Forms.Button liftFileButton;
        private System.Windows.Forms.Button lowerFileButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button buildButton;
        private System.Windows.Forms.Button explorerButton;
        private System.Windows.Forms.OpenFileDialog explorerDialog;
        private System.Windows.Forms.Label buildCounterLabel;
        private System.Windows.Forms.Label l;
        private System.Windows.Forms.Label totalCounterLabel;
        private System.Windows.Forms.SaveFileDialog saveExplorerDialog;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox apiListComboBox;
        private System.Windows.Forms.Button addApiButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

