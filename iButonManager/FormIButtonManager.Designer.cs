namespace Cluster.iButtonManager
{
    partial class FormIButtonManager
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormIButtonManager));
            this.dataGridViewDatabase = new System.Windows.Forms.DataGridView();
            this.buttonRead = new System.Windows.Forms.Button();
            this.dataGridViewKey = new System.Windows.Forms.DataGridView();
            this.buttonDeleteFromKey = new System.Windows.Forms.Button();
            this.buttonUpKey = new System.Windows.Forms.Button();
            this.buttonDownKey = new System.Windows.Forms.Button();
            this.buttonWrite = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAddToDevice = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.определитьПортToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.перезагрузитьУстройствоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCRC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTypeK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKeyK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCRCK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescriptionK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDatabase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKey)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewDatabase
            // 
            this.dataGridViewDatabase.AllowUserToAddRows = false;
            this.dataGridViewDatabase.AllowUserToDeleteRows = false;
            this.dataGridViewDatabase.AllowUserToResizeRows = false;
            this.dataGridViewDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewDatabase.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewDatabase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDatabase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNum,
            this.colType,
            this.colKey,
            this.colCRC,
            this.colDescription});
            this.dataGridViewDatabase.Location = new System.Drawing.Point(12, 40);
            this.dataGridViewDatabase.MultiSelect = false;
            this.dataGridViewDatabase.Name = "dataGridViewDatabase";
            this.dataGridViewDatabase.RowHeadersVisible = false;
            this.dataGridViewDatabase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDatabase.Size = new System.Drawing.Size(704, 247);
            this.dataGridViewDatabase.TabIndex = 0;
            this.dataGridViewDatabase.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDatabase_CellDoubleClick);
            this.dataGridViewDatabase.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDatabase_CellEndEdit);
            this.dataGridViewDatabase.Sorted += new System.EventHandler(this.dataGridViewDatabase_Sorted);
            // 
            // buttonRead
            // 
            this.buttonRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRead.Location = new System.Drawing.Point(12, 567);
            this.buttonRead.Name = "buttonRead";
            this.buttonRead.Size = new System.Drawing.Size(179, 23);
            this.buttonRead.TabIndex = 6;
            this.buttonRead.Text = "Прочитать ключи";
            this.buttonRead.UseVisualStyleBackColor = true;
            this.buttonRead.Click += new System.EventHandler(this.buttonRead_Click);
            // 
            // dataGridViewKey
            // 
            this.dataGridViewKey.AllowUserToAddRows = false;
            this.dataGridViewKey.AllowUserToDeleteRows = false;
            this.dataGridViewKey.AllowUserToResizeRows = false;
            this.dataGridViewKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewKey.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewKey.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKey.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNumK,
            this.colTypeK,
            this.colKeyK,
            this.colCRCK,
            this.colDescriptionK});
            this.dataGridViewKey.Location = new System.Drawing.Point(12, 351);
            this.dataGridViewKey.MultiSelect = false;
            this.dataGridViewKey.Name = "dataGridViewKey";
            this.dataGridViewKey.RowHeadersVisible = false;
            this.dataGridViewKey.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewKey.Size = new System.Drawing.Size(704, 198);
            this.dataGridViewKey.TabIndex = 5;
            this.dataGridViewKey.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewKey_CellEndEdit);
            this.dataGridViewKey.Sorted += new System.EventHandler(this.dataGridViewKey_Sorted);
            // 
            // buttonDeleteFromKey
            // 
            this.buttonDeleteFromKey.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonDeleteFromKey.Location = new System.Drawing.Point(408, 567);
            this.buttonDeleteFromKey.Name = "buttonDeleteFromKey";
            this.buttonDeleteFromKey.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteFromKey.TabIndex = 9;
            this.buttonDeleteFromKey.Text = "Удалить";
            this.buttonDeleteFromKey.UseVisualStyleBackColor = true;
            this.buttonDeleteFromKey.Click += new System.EventHandler(this.buttonDeleteFromKey_Click);
            // 
            // buttonUpKey
            // 
            this.buttonUpKey.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonUpKey.Location = new System.Drawing.Point(246, 567);
            this.buttonUpKey.Name = "buttonUpKey";
            this.buttonUpKey.Size = new System.Drawing.Size(75, 23);
            this.buttonUpKey.TabIndex = 7;
            this.buttonUpKey.Text = "Вверх";
            this.buttonUpKey.UseVisualStyleBackColor = true;
            this.buttonUpKey.Click += new System.EventHandler(this.buttonUpKey_Click);
            // 
            // buttonDownKey
            // 
            this.buttonDownKey.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonDownKey.Location = new System.Drawing.Point(327, 567);
            this.buttonDownKey.Name = "buttonDownKey";
            this.buttonDownKey.Size = new System.Drawing.Size(75, 23);
            this.buttonDownKey.TabIndex = 8;
            this.buttonDownKey.Text = "Вниз";
            this.buttonDownKey.UseVisualStyleBackColor = true;
            this.buttonDownKey.Click += new System.EventHandler(this.buttonDownKey_Click);
            // 
            // buttonWrite
            // 
            this.buttonWrite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonWrite.Location = new System.Drawing.Point(537, 567);
            this.buttonWrite.Name = "buttonWrite";
            this.buttonWrite.Size = new System.Drawing.Size(179, 23);
            this.buttonWrite.TabIndex = 10;
            this.buttonWrite.Text = "Записать ключи";
            this.buttonWrite.UseVisualStyleBackColor = true;
            this.buttonWrite.Click += new System.EventHandler(this.buttonWrite_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Ключи в базе:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 335);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Ключи в устройстве:";
            // 
            // buttonDown
            // 
            this.buttonDown.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonDown.Location = new System.Drawing.Point(327, 293);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(75, 23);
            this.buttonDown.TabIndex = 2;
            this.buttonDown.Text = "Вниз";
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonUp.Location = new System.Drawing.Point(246, 293);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(75, 23);
            this.buttonUp.TabIndex = 1;
            this.buttonUp.Text = "Вверх";
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonDelete.Location = new System.Drawing.Point(408, 293);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonAddToDevice
            // 
            this.buttonAddToDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddToDevice.Location = new System.Drawing.Point(537, 293);
            this.buttonAddToDevice.Name = "buttonAddToDevice";
            this.buttonAddToDevice.Size = new System.Drawing.Size(179, 23);
            this.buttonAddToDevice.TabIndex = 4;
            this.buttonAddToDevice.Text = "Добавить в устройство";
            this.buttonAddToDevice.UseVisualStyleBackColor = true;
            this.buttonAddToDevice.Click += new System.EventHandler(this.buttonAddToDevice_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(728, 24);
            this.menuStrip.TabIndex = 14;
            this.menuStrip.Text = "menuStrip";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.определитьПортToolStripMenuItem,
            this.перезагрузитьУстройствоToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // определитьПортToolStripMenuItem
            // 
            this.определитьПортToolStripMenuItem.Name = "определитьПортToolStripMenuItem";
            this.определитьПортToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.определитьПортToolStripMenuItem.Text = "Определить порт";
            this.определитьПортToolStripMenuItem.Click += new System.EventHandler(this.определитьПортToolStripMenuItem_Click);
            // 
            // перезагрузитьУстройствоToolStripMenuItem
            // 
            this.перезагрузитьУстройствоToolStripMenuItem.Name = "перезагрузитьУстройствоToolStripMenuItem";
            this.перезагрузитьУстройствоToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.перезагрузитьУстройствоToolStripMenuItem.Text = "Перезагрузить устройство";
            this.перезагрузитьУстройствоToolStripMenuItem.Click += new System.EventHandler(this.перезагрузитьУстройствоToolStripMenuItem_Click);
            // 
            // colNum
            // 
            this.colNum.HeaderText = "№";
            this.colNum.Name = "colNum";
            this.colNum.ReadOnly = true;
            this.colNum.Width = 30;
            // 
            // colType
            // 
            this.colType.HeaderText = "Тип";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Width = 70;
            // 
            // colKey
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.colKey.DefaultCellStyle = dataGridViewCellStyle1;
            this.colKey.HeaderText = "Серийник";
            this.colKey.Name = "colKey";
            this.colKey.ReadOnly = true;
            this.colKey.Width = 200;
            // 
            // colCRC
            // 
            this.colCRC.HeaderText = "CRC";
            this.colCRC.Name = "colCRC";
            this.colCRC.ReadOnly = true;
            this.colCRC.Width = 50;
            // 
            // colDescription
            // 
            this.colDescription.HeaderText = "Описание";
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 350;
            // 
            // colNumK
            // 
            this.colNumK.HeaderText = "№";
            this.colNumK.Name = "colNumK";
            this.colNumK.ReadOnly = true;
            this.colNumK.Width = 30;
            // 
            // colTypeK
            // 
            this.colTypeK.HeaderText = "Тип";
            this.colTypeK.Name = "colTypeK";
            this.colTypeK.ReadOnly = true;
            this.colTypeK.Width = 70;
            // 
            // colKeyK
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Courier New", 9F);
            this.colKeyK.DefaultCellStyle = dataGridViewCellStyle2;
            this.colKeyK.HeaderText = "Серийник";
            this.colKeyK.Name = "colKeyK";
            this.colKeyK.ReadOnly = true;
            this.colKeyK.Width = 200;
            // 
            // colCRCK
            // 
            this.colCRCK.HeaderText = "CRC";
            this.colCRCK.Name = "colCRCK";
            this.colCRCK.ReadOnly = true;
            this.colCRCK.Width = 50;
            // 
            // colDescriptionK
            // 
            this.colDescriptionK.HeaderText = "Описание";
            this.colDescriptionK.Name = "colDescriptionK";
            this.colDescriptionK.Width = 350;
            // 
            // FormIButtonManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 602);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.buttonUp);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAddToDevice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonWrite);
            this.Controls.Add(this.buttonDownKey);
            this.Controls.Add(this.buttonUpKey);
            this.Controls.Add(this.buttonDeleteFromKey);
            this.Controls.Add(this.dataGridViewKey);
            this.Controls.Add(this.buttonRead);
            this.Controls.Add(this.dataGridViewDatabase);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(684, 641);
            this.Name = "FormIButtonManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iButton Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormIButtonManager_FormClosing);
            this.Load += new System.EventHandler(this.FormIButtonManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDatabase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKey)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDatabase;
        private System.Windows.Forms.Button buttonRead;
        private System.Windows.Forms.DataGridView dataGridViewKey;
        private System.Windows.Forms.Button buttonDeleteFromKey;
        private System.Windows.Forms.Button buttonUpKey;
        private System.Windows.Forms.Button buttonDownKey;
        private System.Windows.Forms.Button buttonWrite;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAddToDevice;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem определитьПортToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem перезагрузитьУстройствоToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCRC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumK;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTypeK;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKeyK;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCRCK;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescriptionK;
    }
}

