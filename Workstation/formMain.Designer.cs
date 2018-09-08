using System.Windows.Forms;

namespace Workstation
{
    partial class FormMain
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
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpMorgues = new System.Windows.Forms.TabPage();
            this.dgvMorgues = new System.Windows.Forms.DataGridView();
            this.tpBuildings = new System.Windows.Forms.TabPage();
            this.dgvBuildings = new System.Windows.Forms.DataGridView();
            this.tpPositions = new System.Windows.Forms.TabPage();
            this.dgvPositions = new System.Windows.Forms.DataGridView();
            this.tpStuff = new System.Windows.Forms.TabPage();
            this.dgvStuff = new System.Windows.Forms.DataGridView();
            this.tpUsers = new System.Windows.Forms.TabPage();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.tpSearchStuff = new System.Windows.Forms.TabPage();
            this.cbMorgue = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lvStuffByMorgue = new System.Windows.Forms.ListView();
            this.tpSearchStuffByName = new System.Windows.Forms.TabPage();
            this.cbPensioner = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btSearchStuff = new System.Windows.Forms.Button();
            this.tbSecondName = new System.Windows.Forms.TextBox();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.tbAge = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lvStuffByName = new System.Windows.Forms.ListView();
            this.colFirstName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSecondName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAge = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPensionerStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tpChangeUser = new System.Windows.Forms.TabPage();
            this.colFirstNameForMorgue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSecondNameForMorgue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAgeForMorgue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPensionerForMorgue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tcMain.SuspendLayout();
            this.tpMorgues.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMorgues)).BeginInit();
            this.tpBuildings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuildings)).BeginInit();
            this.tpPositions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPositions)).BeginInit();
            this.tpStuff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStuff)).BeginInit();
            this.tpUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.tpSearchStuff.SuspendLayout();
            this.tpSearchStuffByName.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tpMorgues);
            this.tcMain.Controls.Add(this.tpBuildings);
            this.tcMain.Controls.Add(this.tpPositions);
            this.tcMain.Controls.Add(this.tpStuff);
            this.tcMain.Controls.Add(this.tpUsers);
            this.tcMain.Controls.Add(this.tpSearchStuff);
            this.tcMain.Controls.Add(this.tpSearchStuffByName);
            this.tcMain.Controls.Add(this.tpChangeUser);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Multiline = true;
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(800, 450);
            this.tcMain.TabIndex = 0;
            // 
            // tpMorgues
            // 
            this.tpMorgues.Controls.Add(this.dgvMorgues);
            this.tpMorgues.Cursor = System.Windows.Forms.Cursors.Default;
            this.tpMorgues.Location = new System.Drawing.Point(4, 22);
            this.tpMorgues.Name = "tpMorgues";
            this.tpMorgues.Padding = new System.Windows.Forms.Padding(3);
            this.tpMorgues.Size = new System.Drawing.Size(792, 424);
            this.tpMorgues.TabIndex = 0;
            this.tpMorgues.Text = "Морги";
            this.tpMorgues.UseVisualStyleBackColor = true;
            // 
            // dgvMorgues
            // 
            this.dgvMorgues.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMorgues.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvMorgues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMorgues.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvMorgues.Location = new System.Drawing.Point(3, 3);
            this.dgvMorgues.Name = "dgvMorgues";
            this.dgvMorgues.Size = new System.Drawing.Size(786, 421);
            this.dgvMorgues.TabIndex = 0;
            this.dgvMorgues.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvMorguesCellValueChanged);
            this.dgvMorgues.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DgvMorguesDataError);
            this.dgvMorgues.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DgvMorguesRowValidating);
            this.dgvMorgues.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DgvMorguesUserDeletingRow);
            // 
            // tpBuildings
            // 
            this.tpBuildings.Controls.Add(this.dgvBuildings);
            this.tpBuildings.Location = new System.Drawing.Point(4, 22);
            this.tpBuildings.Name = "tpBuildings";
            this.tpBuildings.Padding = new System.Windows.Forms.Padding(3);
            this.tpBuildings.Size = new System.Drawing.Size(792, 424);
            this.tpBuildings.TabIndex = 1;
            this.tpBuildings.Text = "Здания";
            this.tpBuildings.UseVisualStyleBackColor = true;
            // 
            // dgvBuildings
            // 
            this.dgvBuildings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBuildings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBuildings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBuildings.Location = new System.Drawing.Point(3, 3);
            this.dgvBuildings.Name = "dgvBuildings";
            this.dgvBuildings.Size = new System.Drawing.Size(786, 418);
            this.dgvBuildings.TabIndex = 0;
            this.dgvBuildings.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvBuildingsCellValueChanged);
            this.dgvBuildings.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DgvBuildingsDataError);
            this.dgvBuildings.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DgvBuildingsRowValidating);
            this.dgvBuildings.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DgvBuildingsUserDeletingRow);
            // 
            // tpPositions
            // 
            this.tpPositions.Controls.Add(this.dgvPositions);
            this.tpPositions.Location = new System.Drawing.Point(4, 22);
            this.tpPositions.Name = "tpPositions";
            this.tpPositions.Size = new System.Drawing.Size(792, 424);
            this.tpPositions.TabIndex = 2;
            this.tpPositions.Text = "Список должностей";
            this.tpPositions.UseVisualStyleBackColor = true;
            // 
            // dgvPositions
            // 
            this.dgvPositions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPositions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPositions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPositions.Location = new System.Drawing.Point(0, 0);
            this.dgvPositions.Name = "dgvPositions";
            this.dgvPositions.Size = new System.Drawing.Size(792, 424);
            this.dgvPositions.TabIndex = 0;
            this.dgvPositions.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPositionsCellValueChanged);
            this.dgvPositions.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DgvPositionsDataError);
            this.dgvPositions.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DgvPositionsRowValidating);
            this.dgvPositions.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DgvPositionsUserDeletingRow);
            // 
            // tpStuff
            // 
            this.tpStuff.Controls.Add(this.dgvStuff);
            this.tpStuff.Location = new System.Drawing.Point(4, 22);
            this.tpStuff.Name = "tpStuff";
            this.tpStuff.Size = new System.Drawing.Size(792, 424);
            this.tpStuff.TabIndex = 3;
            this.tpStuff.Text = "Сотрудники";
            this.tpStuff.UseVisualStyleBackColor = true;
            // 
            // dgvStuff
            // 
            this.dgvStuff.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStuff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStuff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStuff.Location = new System.Drawing.Point(0, 0);
            this.dgvStuff.Name = "dgvStuff";
            this.dgvStuff.Size = new System.Drawing.Size(792, 424);
            this.dgvStuff.TabIndex = 0;
            this.dgvStuff.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvStuffCellValueChanged);
            this.dgvStuff.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DgvStuffDataError);
            this.dgvStuff.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DgvStuffRowValidating);
            this.dgvStuff.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DgvStuffUserDeletingRow);
            // 
            // tpUsers
            // 
            this.tpUsers.Controls.Add(this.dgvUsers);
            this.tpUsers.Location = new System.Drawing.Point(4, 22);
            this.tpUsers.Name = "tpUsers";
            this.tpUsers.Size = new System.Drawing.Size(792, 424);
            this.tpUsers.TabIndex = 4;
            this.tpUsers.Text = "Пользователи";
            this.tpUsers.UseVisualStyleBackColor = true;
            // 
            // dgvUsers
            // 
            this.dgvUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Location = new System.Drawing.Point(0, 0);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.Size = new System.Drawing.Size(792, 424);
            this.dgvUsers.TabIndex = 0;
            this.dgvUsers.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvUsersCellValueChanged);
            this.dgvUsers.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DgvUsersDataError);
            this.dgvUsers.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DgvUsersRowValidating);
            this.dgvUsers.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DgvUsersUserDeletingRow);
            // 
            // tpSearchStuff
            // 
            this.tpSearchStuff.Controls.Add(this.cbMorgue);
            this.tpSearchStuff.Controls.Add(this.label1);
            this.tpSearchStuff.Controls.Add(this.lvStuffByMorgue);
            this.tpSearchStuff.Location = new System.Drawing.Point(4, 22);
            this.tpSearchStuff.Name = "tpSearchStuff";
            this.tpSearchStuff.Size = new System.Drawing.Size(792, 424);
            this.tpSearchStuff.TabIndex = 6;
            this.tpSearchStuff.Text = "Список работников морга";
            this.tpSearchStuff.UseVisualStyleBackColor = true;
            // 
            // cbMorgue
            // 
            this.cbMorgue.FormattingEnabled = true;
            this.cbMorgue.Location = new System.Drawing.Point(308, 13);
            this.cbMorgue.Name = "cbMorgue";
            this.cbMorgue.Size = new System.Drawing.Size(194, 21);
            this.cbMorgue.TabIndex = 2;
            this.cbMorgue.SelectedIndexChanged += new System.EventHandler(this.CbMorgueSelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(260, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Морг";
            // 
            // lvStuffByMorgue
            // 
            this.lvStuffByMorgue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFirstNameForMorgue,
            this.colSecondNameForMorgue,
            this.colAgeForMorgue,
            this.colPensionerForMorgue});
            this.lvStuffByMorgue.Location = new System.Drawing.Point(8, 39);
            this.lvStuffByMorgue.Name = "lvStuffByMorgue";
            this.lvStuffByMorgue.Size = new System.Drawing.Size(776, 359);
            this.lvStuffByMorgue.TabIndex = 0;
            this.lvStuffByMorgue.UseCompatibleStateImageBehavior = false;
            this.lvStuffByMorgue.View = System.Windows.Forms.View.Details;
            // 
            // tpSearchStuffByName
            // 
            this.tpSearchStuffByName.Controls.Add(this.cbPensioner);
            this.tpSearchStuffByName.Controls.Add(this.label5);
            this.tpSearchStuffByName.Controls.Add(this.btSearchStuff);
            this.tpSearchStuffByName.Controls.Add(this.tbSecondName);
            this.tpSearchStuffByName.Controls.Add(this.tbFirstName);
            this.tpSearchStuffByName.Controls.Add(this.tbAge);
            this.tpSearchStuffByName.Controls.Add(this.label4);
            this.tpSearchStuffByName.Controls.Add(this.label3);
            this.tpSearchStuffByName.Controls.Add(this.label2);
            this.tpSearchStuffByName.Controls.Add(this.lvStuffByName);
            this.tpSearchStuffByName.Location = new System.Drawing.Point(4, 22);
            this.tpSearchStuffByName.Name = "tpSearchStuffByName";
            this.tpSearchStuffByName.Size = new System.Drawing.Size(792, 424);
            this.tpSearchStuffByName.TabIndex = 7;
            this.tpSearchStuffByName.Text = "Поиск работников";
            this.tpSearchStuffByName.UseVisualStyleBackColor = true;
            // 
            // cbPensioner
            // 
            this.cbPensioner.FormattingEnabled = true;
            this.cbPensioner.Items.AddRange(new object[] {
            "Не указано",
            "Да",
            "Нет"});
            this.cbPensioner.Location = new System.Drawing.Point(688, 11);
            this.cbPensioner.Name = "cbPensioner";
            this.cbPensioner.Size = new System.Drawing.Size(96, 21);
            this.cbPensioner.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(534, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Является ли пенсионером?";
            // 
            // btSearchStuff
            // 
            this.btSearchStuff.Location = new System.Drawing.Point(323, 393);
            this.btSearchStuff.Name = "btSearchStuff";
            this.btSearchStuff.Size = new System.Drawing.Size(75, 23);
            this.btSearchStuff.TabIndex = 14;
            this.btSearchStuff.Text = "Поиск";
            this.btSearchStuff.UseVisualStyleBackColor = true;
            this.btSearchStuff.Click += new System.EventHandler(this.BtSearchStuffClick);
            // 
            // tbSecondName
            // 
            this.tbSecondName.Location = new System.Drawing.Point(242, 12);
            this.tbSecondName.Name = "tbSecondName";
            this.tbSecondName.Size = new System.Drawing.Size(142, 20);
            this.tbSecondName.TabIndex = 13;
            // 
            // tbFirstName
            // 
            this.tbFirstName.Location = new System.Drawing.Point(43, 11);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(131, 20);
            this.tbFirstName.TabIndex = 12;
            // 
            // tbAge
            // 
            this.tbAge.Location = new System.Drawing.Point(445, 11);
            this.tbAge.Name = "tbAge";
            this.tbAge.Size = new System.Drawing.Size(83, 20);
            this.tbAge.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(390, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Возраст";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(180, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Фамилия";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Имя";
            // 
            // lvStuffByName
            // 
            this.lvStuffByName.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFirstName,
            this.colSecondName,
            this.colAge,
            this.colPensionerStatus});
            this.lvStuffByName.Location = new System.Drawing.Point(8, 37);
            this.lvStuffByName.Name = "lvStuffByName";
            this.lvStuffByName.Size = new System.Drawing.Size(776, 350);
            this.lvStuffByName.TabIndex = 3;
            this.lvStuffByName.UseCompatibleStateImageBehavior = false;
            this.lvStuffByName.View = System.Windows.Forms.View.Details;
            // 
            // colFirstName
            // 
            this.colFirstName.Text = "Имя";
            this.colFirstName.Width = 206;
            // 
            // colSecondName
            // 
            this.colSecondName.Text = "Фамилия";
            this.colSecondName.Width = 221;
            // 
            // colAge
            // 
            this.colAge.Text = "Возраст";
            this.colAge.Width = 193;
            // 
            // colPensionerStatus
            // 
            this.colPensionerStatus.Text = "Является ли пенсионером";
            this.colPensionerStatus.Width = 149;
            // 
            // tpChangeUser
            // 
            this.tpChangeUser.Location = new System.Drawing.Point(4, 22);
            this.tpChangeUser.Name = "tpChangeUser";
            this.tpChangeUser.Size = new System.Drawing.Size(792, 424);
            this.tpChangeUser.TabIndex = 5;
            this.tpChangeUser.Text = "Смена пользователя";
            this.tpChangeUser.UseVisualStyleBackColor = true;
            // 
            // colFirstNameForMorgue
            // 
            this.colFirstNameForMorgue.Text = "Имя";
            this.colFirstNameForMorgue.Width = 239;
            // 
            // colSecondNameForMorgue
            // 
            this.colSecondNameForMorgue.Text = "Фамилия";
            this.colSecondNameForMorgue.Width = 311;
            // 
            // colAgeForMorgue
            // 
            this.colAgeForMorgue.Text = "Возраст";
            this.colAgeForMorgue.Width = 72;
            // 
            // colPensionerForMorgue
            // 
            this.colPensionerForMorgue.Text = "Является ли пенсионером";
            this.colPensionerForMorgue.Width = 150;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tcMain);
            this.Name = "FormMain";
            this.Text = "АРМ";
            this.tcMain.ResumeLayout(false);
            this.tpMorgues.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMorgues)).EndInit();
            this.tpBuildings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuildings)).EndInit();
            this.tpPositions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPositions)).EndInit();
            this.tpStuff.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStuff)).EndInit();
            this.tpUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.tpSearchStuff.ResumeLayout(false);
            this.tpSearchStuff.PerformLayout();
            this.tpSearchStuffByName.ResumeLayout(false);
            this.tpSearchStuffByName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpMorgues;
        private System.Windows.Forms.TabPage tpBuildings;
        private System.Windows.Forms.TabPage tpPositions;
        private System.Windows.Forms.TabPage tpStuff;
        private System.Windows.Forms.TabPage tpUsers;
        private System.Windows.Forms.DataGridView dgvMorgues;
        private System.Windows.Forms.DataGridView dgvBuildings;
        private System.Windows.Forms.DataGridView dgvPositions;
        private System.Windows.Forms.DataGridView dgvStuff;
        private System.Windows.Forms.DataGridView dgvUsers;
        private TabPage tpChangeUser;
        private TabPage tpSearchStuff;
        private ComboBox cbMorgue;
        private Label label1;
        private ListView lvStuffByMorgue;
        private TabPage tpSearchStuffByName;
        private TextBox tbAge;
        private Label label4;
        private Label label3;
        private Label label2;
        private ListView lvStuffByName;
        private TextBox tbSecondName;
        private TextBox tbFirstName;
        private Button btSearchStuff;
        private ComboBox cbPensioner;
        private Label label5;
        private ColumnHeader colFirstName;
        private ColumnHeader colSecondName;
        private ColumnHeader colAge;
        private ColumnHeader colPensionerStatus;
        private ColumnHeader colFirstNameForMorgue;
        private ColumnHeader colSecondNameForMorgue;
        private ColumnHeader colAgeForMorgue;
        private ColumnHeader colPensionerForMorgue;
    }
}

