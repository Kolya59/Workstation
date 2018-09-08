namespace Workstation
{
    // TODO: Протестировать
    // TODO: Не изменяется информация о зданиях
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Windows.Forms;

    /// <inheritdoc />
    /// <summary>TODO The form main.</summary>
    public partial class FormMain : Form
    {
        private readonly Users currentUser;
        private readonly List<string> collectionOfMorgues = new List<string>();
        private readonly List<string> collectionOfBuildings = new List<string>();
        private readonly List<string> collectionOfStuff = new List<string>();

        public FormMain(Users currentUser)
        {
            this.currentUser = currentUser;
            InitializeComponent();
            Autorization();
            IntializeTabs();
        }

        #region Авторизация

        private void Autorization()
        {
            Text = @"Текущий пользователь: " + currentUser.login + @". Текущая роль: " + currentUser.role;

            #region Выдача прав на Изменение/Добавление/Удаление содержиомго dgv

            var permissionOnUpdateInsertDelete = currentUser.role != @"Гость";
            dgvMorgues.AllowUserToAddRows = permissionOnUpdateInsertDelete;
            dgvMorgues.AllowUserToDeleteRows = permissionOnUpdateInsertDelete;
            dgvBuildings.AllowUserToAddRows = permissionOnUpdateInsertDelete;
            dgvBuildings.AllowUserToDeleteRows = permissionOnUpdateInsertDelete;
            dgvPositions.AllowUserToAddRows = permissionOnUpdateInsertDelete;
            dgvPositions.AllowUserToDeleteRows = permissionOnUpdateInsertDelete;
            dgvStuff.AllowUserToAddRows = permissionOnUpdateInsertDelete;
            dgvStuff.AllowUserToDeleteRows = permissionOnUpdateInsertDelete;

            dgvUsers.Visible = currentUser.role == "Администратор";

            #endregion
        }

        #endregion

        #region Инициализация Tab Control

        private void IntializeTabs()
        {
            #region Инициализация dgv

            IntializeDgvMorgues();
            IntializeDgvBuildings();
            IntializeDgvPositions();
            IntializeDgvStuff();
            if (currentUser.role == "Администратор")
            {
                IntializeDgvUsers();
            }

            tcMain.Selecting += TcMainSelecting;

            #endregion
        }

        private void IntializeDgvMorgues()
        {
            dgvMorgues.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = @"idMorgue",
                Name = "idMorgue",
                Visible = false
            });
            dgvMorgues.Columns.Add(new DataGridViewComboBoxColumn()
            {
                DataSource = collectionOfBuildings,
                HeaderText = @"Адрес",
                Name = "address"
            });
            dgvMorgues.Columns.Add(new DataGridViewComboBoxColumn
            {
                HeaderText = @"Тип морга",
                Name = "typeOfMorgue",
                DataSource = new[] { "Патолого-анатомический", "Судебно-медицинский" }
            });
            dgvMorgues.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = @"Официальное название",
                Name = "officialName",
            });
            dgvMorgues.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = @"Количество работников",
                Name = "workersAmount",
                ValueType = typeof(int)
            });
            dgvMorgues.Columns.Add(new DataGridViewComboBoxColumn
            {
                HeaderText = @"Тип финансирования",
                Name = "typeOfFinancing",
                DataSource = new[] { "Государственное", "Частное" }
                                       });
            FillDgvMorgues();
        }

        private void IntializeDgvBuildings()
        {
            dgvBuildings.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = @"Адрес",
                Name = "address"
            });
            dgvBuildings.Columns.Add(new DataGridViewComboBoxColumn
            {
                HeaderText = @"Тип здания",
                                             Name = "type",
                                             DataSource = new[] { "Жилое", "Нежилое" }
                                         });
            dgvBuildings.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = @"Количество этажей",
                Name = "floorCount",
                ValueType = typeof(int)
            });
            FillDgvBuildings();
        }

        private void IntializeDgvPositions()
        {
            dgvPositions.Columns.Add(new DataGridViewComboBoxColumn()
            {
                HeaderText = @"id морга",
                Name = "idMorgue",
                DataSource = collectionOfMorgues
            });
            dgvPositions.Columns.Add(new DataGridViewComboBoxColumn()
            {
                HeaderText = @"id работника",
                Name = "idPerson",
                DataSource = collectionOfStuff
            });
            dgvPositions.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = @"Должность",
                Name = "nameOfPosition",
            });
            dgvPositions.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = @"Зарплата(руб.)",
                Name = "salary",
                ValueType = typeof(int)
            });
            dgvPositions.Columns.Add(new DataGridViewCheckBoxColumn
            {
                HeaderText = @"Разрешение оперировать",
                Name = "permissonToOperate",
            });
            FillDgvPositions();
        }

        private void IntializeDgvStuff()
        {
            dgvStuff.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "id",
                Visible = false
            });
            dgvStuff.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = @"Имя",
                Name = "firstName",
            });
            dgvStuff.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = @"Фамилия",
                Name = "secondName",
            });
            dgvStuff.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = @"Возраст",
                Name = "age",
                ValueType = typeof(int)
            });
            dgvStuff.Columns.Add(new DataGridViewCheckBoxColumn
            {
                HeaderText = @"Является ли пенсионером?",
                Name = "pensioner",
            });
            FillDgvStuff();
        }

        private void IntializeDgvUsers()
        {
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = @"id",
                Name = "id",
                ValueType = typeof(int),
                Visible = false
            });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = @"Логин",
                Name = "Login",
            });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = @"Пароль",
                Name = "Password",
                ReadOnly = true
            });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = @"Соль",
                Name = "Salt",
                ReadOnly = true
            });
            dgvUsers.Columns.Add(new DataGridViewComboBoxColumn
                                     {
                                         DataSource = new[] { "Администратор", "Оператор", "Гость" },
                                         HeaderText = @"Роль",
                                         Name = "Role"
            });
            dgvUsers.Columns.Add(new CalendarColumn
            {
                HeaderText = @"Дата регистрации",
                Name = @"dateOfReg"
            });
            FillDgvUsers();
        }

        #endregion

        #region Заполнение dgv данными

        private void FillDgvMorgues()
        {
            using (var readContext = new MorgueEntities())
            {
                foreach (var morgue in readContext.Morgues)
                {
                    var id = morgue.idMorgue;
                    var address = morgue.address;
                    var typeOfMorgue = morgue.typeOfMorgue;
                    var officialName = morgue.officialName;
                    var workersAmount = morgue.workersAmount;
                    var typeOfFinancing = morgue.typeOfFinancing;
                    var row = dgvMorgues.Rows.Add(
                        id,
                        address,
                        typeOfMorgue,
                        officialName,
                        workersAmount,
                        typeOfFinancing);
                    dgvMorgues.Rows[row].Tag = morgue;
                    collectionOfMorgues.Add(morgue.idMorgue + "(" + morgue.officialName + ")");
                    collectionOfMorgues.Sort();
                }
            }

            dgvMorgues.AutoResizeColumns();
        }

        private void FillDgvBuildings()
        {
            using (var readContext = new MorgueEntities())
            {
                foreach (var building in readContext.Buildings)
                {
                    var adress = building.address;
                    var type = building.type;
                    var floorCount = building.floorCount;
                    var row = dgvBuildings.Rows.Add(adress, type, floorCount);
                    dgvBuildings.Rows[row].Tag = building;
                    collectionOfBuildings.Add(building.address);
                    collectionOfBuildings.Sort();
                }

                dgvBuildings.AutoResizeColumns();
            }
        }

        private void FillDgvPositions()
        {
            using (var readContext = new MorgueEntities())
            {
                foreach (var position in readContext.Positions)
                {
                    var idMorgue = position.idMorgue;
                    var idPerson = position.idPerson;
                    var nameOfPosition = position.nameOfPosition;
                    var salary = position.salary;
                    var row = dgvPositions.Rows.Add(idMorgue, idPerson, nameOfPosition, salary);
                    dgvPositions.Rows[row].Tag = position;
                }

                dgvPositions.AutoResizeColumns();
            }
        }

        private void FillDgvStuff()
        {
            using (var readContext = new MorgueEntities())
            {               
                foreach (var person in readContext.Stuff)
                {
                    var id = person.id;
                    var firstName = person.firstName;
                    var secondName = person.secondName;
                    var age = person.age;
                    var pensioner = person.pensioner;
                    var row = dgvStuff.Rows.Add(id, firstName, secondName, age, pensioner);
                    dgvStuff.Rows[row].Tag = person;
                    collectionOfStuff.Add(id + "(" + firstName + string.Empty + secondName + ")");
                    collectionOfStuff.Sort();
                }

                dgvStuff.AutoResizeColumns();
            }
        }

        private void FillDgvUsers()
        {
            tcMain.TabPages["tpUsers"].Visible = true;
            using (var readContext = new MorgueEntities())
            {
                foreach (var user in readContext.Users)
                {
                    var id = user.id;
                    var login = user.login;
                    var password = user.password;
                    var salt = user.salt;
                    var role = user.role;
                    var dateOfReg = user.dateOfReg;
                    var row = dgvUsers.Rows.Add(id, login, password, salt, role, dateOfReg);
                    dgvUsers.Rows[row].Tag = user;
                }

                dgvUsers.AutoResizeColumns();
            }
        }

        #endregion

        #region Добавление/Изменение данных в dgv

        private void DgvMorguesRowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!dgvMorgues.IsCurrentRowDirty)
            {
                return;
            }

            #region Выделение данных из dgv и проверка данных на корректность

            var row = dgvMorgues.Rows[e.RowIndex];

            var newIdMorgue = (int?)dgvMorgues.Rows[e.RowIndex].Cells["idMorgue"].Value;

            var newAddress = (string)row.Cells["address"].Value;
            if (newAddress == null)
            {
                dgvMorgues.Rows[e.RowIndex].Cells["address"].ErrorText = "Это поле не может быть пустым";
                dgvMorgues.Rows[e.RowIndex].ErrorText = "Есть незаполненные ячейки";
                return;
            }

            var newTypeOfMorgue = (string)row.Cells["typeOfMorgue"].Value;
            if (newTypeOfMorgue == null)
            {
                dgvMorgues.Rows[e.RowIndex].Cells[0].ErrorText = "Это поле не может быть пустым";
                dgvMorgues.Rows[e.RowIndex].ErrorText = "Есть незаполненные ячейки";
                return;
            }

            var newOfficialName = (string)row.Cells["officialName"].Value;
            if (newOfficialName == null)
            {
                dgvMorgues.Rows[e.RowIndex].Cells["officialName"].ErrorText = "Это поле не может быть пустым";
                dgvMorgues.Rows[e.RowIndex].ErrorText = "Есть незаполненные ячейки";
                return;
            }

            var newWorkersAmount = (int?)row.Cells["workersAmount"].Value;
            if (newWorkersAmount == null)
            {
                dgvMorgues.Rows[e.RowIndex].Cells["workersAmount"].ErrorText = "Это поле не может быть пустым";
                dgvMorgues.Rows[e.RowIndex].ErrorText = "Есть незаполненные ячейки";
                return;
            }

            if (newWorkersAmount <= 0)
            {
                dgvMorgues.Rows[e.RowIndex].Cells["workersAmount"].ErrorText = "Количество работников должно быть положительным и целым";
                return;
            }

            var newTypeOfFinancing = (string)row.Cells["typeOfFinancing"].Value;
            if (newTypeOfFinancing == null)
            {
                dgvMorgues.Rows[e.RowIndex].Cells["typeOfFinancing"].ErrorText = "Это поле не может быть пустым";
                dgvMorgues.Rows[e.RowIndex].ErrorText = "Есть незаполненные ячейки";
                return;
            }

            #endregion

            using (var readWriteContext = new MorgueEntities())
            {
                #region Проверка уникальности объекта

                if (readWriteContext.Morgues.FirstOrDefault(t =>
                        t.address == newAddress && 
                        t.typeOfMorgue == newTypeOfMorgue &&
                        t.officialName == newOfficialName &&
                        t.workersAmount == newWorkersAmount &&
                        t.typeOfFinancing == newTypeOfFinancing &&
                        t.idMorgue != newIdMorgue) != null)
                {
                    row.ErrorText = "Такой морг уже существует";
                    return;
                }

                #endregion

                // Проверка наличия объекта в бд
                if (row.Tag == null)
                {
                    #region Добавление объекта

                    // Создание нового объекта
                    var newMorgue = new Morgues
                    {
                        address = newAddress,
                        typeOfMorgue = newTypeOfMorgue,
                        officialName = newOfficialName,
                        workersAmount = (int)newWorkersAmount,
                        typeOfFinancing = newTypeOfFinancing,
                    };

                    // Добавление нового объекта в БД
                    readWriteContext.Morgues.Add(newMorgue);

                    // Добавление тэга
                    row.Tag = newMorgue;

                    #endregion
                }
                else
                {
                    #region Обновление полей существующего объекта

                    // Поиск обновляемого объекта в БД 
                    var updatedMorgue = readWriteContext.Morgues.Single(t =>
                        t.idMorgue == newIdMorgue);

                    // Обновление полей
                    updatedMorgue.address = newAddress;
                    updatedMorgue.typeOfMorgue = newTypeOfMorgue;
                    updatedMorgue.officialName = newOfficialName;
                    updatedMorgue.workersAmount = (int)newWorkersAmount;
                    updatedMorgue.typeOfFinancing = newTypeOfFinancing;

                    #endregion
                }

                // Сохранение данных
                readWriteContext.SaveChanges();
            }

            // Обновление коллекции
            collectionOfMorgues.Add(newIdMorgue + "(" + newOfficialName + ")");
            collectionOfMorgues.Sort();

            // Удаление ошибок
            foreach (DataGridViewCell cell in row.Cells)
            {
                cell.ErrorText = string.Empty;
            }
        }

        private void DgvBuildingsRowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!dgvBuildings.IsCurrentRowDirty)
            {
                return;
            }

            #region Выделение данных из dgv и проверка данных на корректность

            var row = dgvBuildings.Rows[e.RowIndex];

            var newAddress = (string)row.Cells["address"].Value;
            if (newAddress == null)
            {
                dgvBuildings.Rows[e.RowIndex].Cells["address"].ErrorText = "Это поле не может быть пустым";
                return;
            }

            var newType = (string)row.Cells["type"].Value;
            if (newType == null)
            {
                dgvBuildings.Rows[e.RowIndex].Cells["type"].ErrorText = "Это поле не может быть пустым";
                return;
            }

            var newFloorCount = (int?)dgvBuildings.Rows[e.RowIndex].Cells["floorCount"].Value;
            if (newFloorCount == null)
            {
                dgvBuildings.Rows[e.RowIndex].Cells["floorCount"].ErrorText = "Это поле не может быть пустым";
                return;
            }

            if (newFloorCount <= 0)
            {
                dgvBuildings.Rows[e.RowIndex].Cells["floorCount"].ErrorText = "Количество этажей должно быть положительным и целым";
                return;
            }

            #endregion

            using (var readWriteContext = new MorgueEntities())
            {
                #region Проверка уникальности объекта

                if (readWriteContext.Buildings.FirstOrDefault(t => t.address == newAddress) != null)
                {
                    row.ErrorText = "Такое здание уже существует";
                    return;
                }

                #endregion

                // Проверка наличия объекта в бд
                if (row.Tag == null)
                {
                    #region Добавление объекта

                    // Создание нового объекта
                    var newBuilding = new Buildings()
                    {
                        address = newAddress,
                        type = newType,
                        floorCount = (int)newFloorCount
                    };

                    // Добавление нового объекта в БД
                    readWriteContext.Buildings.Add(newBuilding);

                    // Добавление тэга
                    row.Tag = newBuilding;

                    #endregion
                }
                else
                {
                    #region Обновление полей существующего объекта

                    // Поиск обновляемого объекта в БД 
                    var updatedMorgue = readWriteContext.Buildings.Single(t =>
                        t.address == newAddress);

                    // Обновление полей
                    updatedMorgue.type = newType;
                    updatedMorgue.floorCount = (int)newFloorCount;

                    #endregion
                }

                // Сохранение данных
                readWriteContext.SaveChanges();
            }

            // Обновление коллекций
            collectionOfBuildings.Add(newAddress);
            collectionOfBuildings.Sort();

            // Удаление ошибок
            foreach (DataGridViewCell cell in row.Cells)
            {
                cell.ErrorText = string.Empty;
            }
        }

        private void DgvPositionsRowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!dgvPositions.IsCurrentRowDirty)
            {
                return;
            }

            #region Выделение данных из dgv и проверка данных на корректность

            var row = dgvPositions.Rows[e.RowIndex];

            var newStringIdMorgue = row.Cells["idMorgue"].Value.ToString().Split('(')[0];
            if (string.IsNullOrEmpty(newStringIdMorgue))
            {
                dgvPositions.Rows[e.RowIndex].Cells["idMorgue"].ErrorText = "Это поле не может быть пустым";
                return;
            }

            var newIdMorgue = int.Parse(newStringIdMorgue);

            var newStringIdPerson = row.Cells["idPerson"].Value.ToString().Split('(')[0];
            if (string.IsNullOrEmpty(newStringIdPerson))
            {
                dgvPositions.Rows[e.RowIndex].Cells["idPesron"].ErrorText = "Это поле не может быть пустым";
                return;
            }

            var newIdPerson = int.Parse(newStringIdPerson);
                
            var newNameOfPosition = (string)row.Cells["nameOfPosition"].Value;
            if (newNameOfPosition == null)
            {
                dgvPositions.Rows[e.RowIndex].Cells["nameOfPosition"].ErrorText = "Это поле не может быть пустым";
                return;
            }

            var newSalary = (int?)row.Cells["salary"].Value;
            if (newSalary == null)
            {
                dgvMorgues.Rows[e.RowIndex].Cells["salary"].ErrorText = "Это поле не может быть пустым";
                return;
            }

            if (newSalary < 0)
            {
                dgvMorgues.Rows[e.RowIndex].Cells["salary"].ErrorText = "Зарплата не должна быть меньше 0";
                return;
            }

            var newPermissonToOperate = (bool)row.Cells["permissonToOperate"].Value;

            #endregion

            using (var readWriteContext = new MorgueEntities())
            {
                // Проверка наличия объекта в бд
                if (row.Tag == null)
                {
                    #region Добавление объекта

                    #region Проверка уникальности объекта

                    if (readWriteContext.Positions.FirstOrDefault(t =>
                            t.idMorgue == newIdMorgue &&
                            t.idPerson == newIdPerson &&
                            t.nameOfPosition == newNameOfPosition) != null)
                    {
                        row.ErrorText = "Такая запись уже существует";
                        return;
                    }

                    #endregion

                    // Создание нового объекта
                    var newPosition = new Positions
                    {
                        idMorgue = newIdMorgue,
                        idPerson = newIdPerson,
                        nameOfPosition = newNameOfPosition,
                        salary = (int)newSalary,
                        permissionToOperate = newPermissonToOperate
                    };

                    // Добавление нового объекта в БД
                    readWriteContext.Positions.Add(newPosition);

                    // Добавление тэга
                    row.Tag = newPosition;

                    #endregion
                }
                else
                {
                    #region Обновление полей существующего объекта

                    // Поиск обновляемого объекта в БД 
                    var updatedMorgue = readWriteContext.Positions.Single(t =>
                        t.idMorgue == Convert.ToInt32(newIdMorgue) &&
                        t.idPerson == Convert.ToInt32(newIdPerson) &&
                        t.nameOfPosition == newNameOfPosition);

                    // Обновление полей
                    updatedMorgue.salary = (int)newSalary;
                    updatedMorgue.permissionToOperate = newPermissonToOperate;

                    #endregion
                }

                // Сохранение данных
                readWriteContext.SaveChanges();
            }

            // Удаление ошибок
            foreach (DataGridViewCell cell in row.Cells)
            {
                cell.ErrorText = string.Empty;
            }
        }

        private void DgvStuffRowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!dgvStuff.IsCurrentRowDirty)
            {
                return;
            }

            #region Выделение данных из dgv и проверка данных на корректность

            var row = dgvStuff.Rows[e.RowIndex];

            var newId = (int?)dgvStuff.Rows[e.RowIndex].Cells["id"].Value;

            var newFirstName = (string)row.Cells["firstName"].Value;
            if (newFirstName == null)
            {
                dgvStuff.Rows[e.RowIndex].Cells["firstName"].ErrorText = "Это поле не может быть пустым";
                return;
            }

            var newSecondName = (string)row.Cells["secondName"].Value;
            if (newSecondName == null)
            {
                dgvStuff.Rows[e.RowIndex].Cells["secondName"].ErrorText = "Это поле не может быть пустым";
                return;
            }

            var newAge = (int?)row.Cells["age"].Value;
            if (newAge == null)
            {
                dgvStuff.Rows[e.RowIndex].Cells["age"].ErrorText = "Это поле не может быть пустым";
                return;
            }

            if (newAge <= 0)
            {
                dgvStuff.Rows[e.RowIndex].Cells["age"].ErrorText = "Возраст должен быть положительным и целым";
                return;
            }

            var newPensioner = (bool)dgvStuff.Rows[e.RowIndex].Cells["pensioner"].Value;

            #endregion

            using (var readWriteContext = new MorgueEntities())
            {
                // Проверка наличия объекта в бд
                if (row.Tag == null)
                {
                    #region Добавление объекта

                    // Создание нового объекта
                    var newPerson = new Stuff
                    {
                        firstName = newFirstName,
                        secondName = newSecondName,
                        age = (int)newAge,
                        pensioner = newPensioner
                    };

                    // Добавление нового объекта в БД
                    readWriteContext.Stuff.Add(newPerson);

                    // Добавление тэга
                    row.Tag = newPerson;

                    #endregion
                }
                else
                {
                    #region Обновление полей существующего объекта

                    // Поиск обновляемого объекта в БД 
                    var updatedPerson = readWriteContext.Stuff.Single(t =>
                        t.id == newId);

                    // Обновление полей
                    updatedPerson.firstName = newFirstName;
                    updatedPerson.secondName = newSecondName;
                    updatedPerson.age = (int)newAge;
                    updatedPerson.pensioner = newPensioner;

                    #endregion
                }

                // Сохранение данных
                readWriteContext.SaveChanges();
            }

            // Обновление коллекций
            collectionOfStuff.Add(newId + "(" + newFirstName + " " + newSecondName + ")");
            collectionOfStuff.Sort();

            // Удаление ошибок
            foreach (DataGridViewCell cell in row.Cells)
            {
                cell.ErrorText = string.Empty;
            }
        }

        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1408:ConditionalExpressionsMustDeclarePrecedence", Justification = "Reviewed. Suppression is OK here.")]
        private void DgvUsersRowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!dgvUsers.IsCurrentRowDirty)
            {
                return;
            }

            #region Выделение данных из dgv

            var row = dgvUsers.Rows[e.RowIndex];

            var id = (int)dgvUsers.Rows[e.RowIndex].Cells["id"].Value;
            var newLogin = (string)dgvUsers.Rows[e.RowIndex].Cells["login"].Value;
            var newPassword = (string)row.Cells["password"].Value;
            var newRole = (string)row.Cells["role"].Value;
            var newDateOfReg = (DateTime)row.Cells["dateOfReg"].Value;
            var errorMessage = string.Empty;
            #endregion

            using (var readWriteContext = new MorgueEntities())
            {
                // Проверка наличия объекта в бд
                if (row.Tag == null)
                {
                    if (!AuthorizationMethods.Registration(newLogin, newPassword, newRole, ref errorMessage))
                    {
                        foreach (var error in errorMessage.Split('\n'))
                        {
                            if (error.Contains("Логин") || error.Contains("логином"))
                            {
                                row.Cells["login"].ErrorText += error;
                                continue;
                            }

                            if (error.Contains("Пароль") || error.Contains("пароль"))
                            {
                                row.Cells["password"].ErrorText += error;
                                continue;
                            }

                            if (error.Contains("Роль"))
                            {
                                row.Cells["role"].ErrorText += error;
                            }
                        }

                        row.Tag = readWriteContext.Users.FirstOrDefault(t => t.login == newLogin);
                        return;
                    }
                }
                else
                {
                    #region Обновление полей существующего объекта

                    // Поиск обновляемого объекта в БД 
                    var updatedUser = readWriteContext.Users.Single(t => t.id == id);

                    // Обновление полей
                    #region Проверка логина

                    var errorFlag = false;
                    if (newLogin == string.Empty)
                    {
                        row.Cells["login"].ErrorText += "Логин не может быть меньше 8 символов\n";
                        errorFlag = true;
                    }

                    var containOnlyAllowedToLoginCharacters = true;
                    foreach (var character in newLogin)
                    {
                        containOnlyAllowedToLoginCharacters &=
                            AuthorizationMethods.AllowedToLoginСharacters.Contains(character) ||
                                                               character >= 'a' && character <= 'z' ||
                                                               character >= 'A' && character <= 'Z' ||
                                                               character >= '0' && character <= '9';
                    }

                    if (!containOnlyAllowedToLoginCharacters)
                    {
                        row.Cells["login"].ErrorText += "Логин может содержать только цифры, буквы латинского алфавита и символы: - . ' _\n";
                        errorFlag = true;
                    }

                    #endregion

                    if (errorFlag)
                    {
                        return;
                    }
             
                    updatedUser.login = newLogin;
                    updatedUser.role = newRole;
                    updatedUser.dateOfReg = newDateOfReg;

                    #endregion

                    // Сохранение данных
                    readWriteContext.SaveChanges();
                }
            }

            // Удаление ошибок
            foreach (DataGridViewCell cell in row.Cells)
            {
                cell.ErrorText = string.Empty;
            }
        }

        #endregion

        #region Удаление данных из dgv

        private void DgvMorguesUserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            using (var deleteContext = new MorgueEntities())
            {
                // Удаление несохраненного в БД объекта из dgv
                if (e.Row.Tag == null)
                {
                    return;
                }

                var deletedMorgue = (Morgues)e.Row.Tag;

                // Добавление удаляемого объекта к контексту
                deleteContext.Morgues.Attach(deletedMorgue);

                if (deleteContext.Positions.FirstOrDefault(t => t.idMorgue == deletedMorgue.idMorgue) != null)
                {
                    e.Row.ErrorText = "Невозможно удалить морг, так как существуют люди, работающие в нем";
                    return;
                }

                // Удаление найденного объекта
                deleteContext.Morgues.Remove(deletedMorgue);

                // Сохранение изменений
                deleteContext.SaveChanges();
            }
        }

        private void DgvBuildingsUserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            using (var deleteContext = new MorgueEntities())
            {
                // Удаление несохраненного в БД объекта из dgv
                if (e.Row.Tag == null)
                {
                    return;
                }

                var deletedBuilding = (Buildings)e.Row.Tag;

                // Добавление удаляемого объекта к контексту
                deleteContext.Buildings.Attach(deletedBuilding);

                if (deleteContext.Morgues.FirstOrDefault(t => t.address == deletedBuilding.address) != null)
                {
                    e.Row.ErrorText = "Невозможно удалить информацию о здании, так как есть морги, существующие в нем";
                    return;
                }

                // Удаление найденного объекта
                deleteContext.Buildings.Remove(deletedBuilding);

                // Сохранение изменений
                deleteContext.SaveChanges();
            }
        }

        private void DgvPositionsUserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            using (var deleteContext = new MorgueEntities())
            {
                // Удаление несохраненного в БД объекта из dgv
                if (e.Row.Tag == null)
                {
                    return;
                }

                var deletedPosition = (Positions)e.Row.Tag;

                // Добавление удаляемого объекта к контексту
                deleteContext.Positions.Attach(deletedPosition);
                if (deletedPosition.permissionToOperate && deleteContext.Operations.FirstOrDefault(t => 
                        t.idMorgue == deletedPosition.idMorgue &&
                        t.idOperator == deletedPosition.idPerson) != null)
                {
                    e.Row.ErrorText =
                        "Невозможно удалить информацию о должности сотрудника, так как существуют операции, проведенные им";
                    return;
                }

                // Удаление найденного объекта
                deleteContext.Positions.Remove(deletedPosition);

                // Сохранение изменений
                deleteContext.SaveChanges();
            }
        }

        private void DgvStuffUserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            using (var deleteContext = new MorgueEntities())
            {
                // Удаление несохраненного в БД объекта из dgv
                if (e.Row.Tag == null)
                {
                    return;
                }

                var deletedPerson = (Stuff)e.Row.Tag;

                // Добавление удаляемого объекта к контексту
                deleteContext.Stuff.Attach(deletedPerson);
                if (deleteContext.Positions.FirstOrDefault(t =>
                        t.idPerson == deletedPerson.id) != null)
                {
                    e.Row.ErrorText =
                        "Невозможно удалить информацию о должности сотрудника, так как существуют операции, проведенные им";
                    return;
                }

                // Удаление найденного объекта
                deleteContext.Stuff.Remove(deletedPerson);

                // Сохранение изменений
                deleteContext.SaveChanges();
            }
        }

        private void DgvUsersUserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            using (var deleteContext = new MorgueEntities())
            {
                // Удаление несохраненного в БД объекта из dgv
                if (e.Row.Tag == null)
                {
                    return;
                }

                var deletedUser = (Users)e.Row.Tag;

                // Добавление удаляемого объекта к контексту
                deleteContext.Users.Attach(deletedUser);
                if (deletedUser.login == currentUser.login)
                {
                    e.Row.ErrorText = "Невозможно удалить информацию о себе самом";
                    return;
                }

                // Удаление найденного объекта
                deleteContext.Users.Remove(deletedUser);

                // Сохранение изменений
                deleteContext.SaveChanges();
            }
        }

        #endregion

        #region Обработка несохраненных данных в dgv

        private void DgvMorguesCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!dgvMorgues.Rows[e.RowIndex].IsNewRow)
            {
                dgvMorgues[e.ColumnIndex, e.RowIndex].ErrorText = "Значение изменено и не сохранено.";
            }
        }

        private void DgvBuildingsCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!dgvBuildings.Rows[e.RowIndex].IsNewRow)
            {
                dgvBuildings[e.ColumnIndex, e.RowIndex].ErrorText = "Значение изменено и не сохранено.";
            }
        }

        private void DgvPositionsCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!dgvPositions.Rows[e.RowIndex].IsNewRow)
            {
                dgvPositions[e.ColumnIndex, e.RowIndex].ErrorText = "Значение изменено и не сохранено.";
            }
        }

        private void DgvStuffCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!dgvStuff.Rows[e.RowIndex].IsNewRow)
            {
                dgvStuff[e.ColumnIndex, e.RowIndex].ErrorText = "Значение изменено и не сохранено.";
            }
        }

        private void DgvUsersCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!dgvUsers.Rows[e.RowIndex].IsNewRow)
            {
                dgvUsers[e.ColumnIndex, e.RowIndex].ErrorText = "Значение изменено и не сохранено.";
            }
        }

        #endregion

        #region Переключение вкладок

        private void TcMainSelecting(object sender, TabControlCancelEventArgs e)
        {
            switch (e.TabPageIndex)
            {
                case 4:
                    {
                        if (currentUser.role != "Администратор")
                        {
                            MessageBox.Show(@"У вас нет доступа к этой вкладке!");
                            e.Cancel = true;
                        }

                        break;
                    }

                case 5:
                    {
                        var selected = cbMorgue.SelectedIndex;
                        collectionOfMorgues.Clear();
                        using (var readContext = new MorgueEntities())
                        {
                            foreach (var morgue in readContext.Morgues)
                            {
                                collectionOfMorgues.Add(morgue.idMorgue + "(" + morgue.officialName + ")");
                            }

                            collectionOfMorgues.Sort();
                        }
                       
                        cbMorgue.DataSource = collectionOfMorgues;
                        cbMorgue.SelectedIndex = selected;
                        break;
                    }

                case 6:
                    {
                        cbPensioner.SelectedIndex = cbPensioner.Text == string.Empty ? 1 : cbPensioner.SelectedIndex;
                        break;
                    }

                case 7:
                    {
                        Close();
                        new FormAutorization().ShowDialog();
                        break;
                    }
            }
        }

        #endregion

        #region Обработка ошибок данных

        private void DgvMorguesDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void DgvBuildingsDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void DgvPositionsDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void DgvStuffDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void DgvUsersDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        #endregion

        #region Запросы

        private void BtSearchStuffClick(object sender, EventArgs e)
        {
            // TODO: Не удаляет полностью список людей
            lvStuffByName.Items.Clear();
            var firstName = tbFirstName.Text;
            var secondName = tbSecondName.Text;
            int.TryParse(tbAge.Text, out var age);
            var pensioner = cbPensioner.Text == @"Да";

            using (var readContext = new MorgueEntities())
            {
                var persons = readContext.Stuff.Where(
                    t => (firstName == string.Empty || t.firstName == firstName)
                         && (secondName == string.Empty || t.secondName == secondName) 
                         && (tbAge.Text == string.Empty || t.age == age)
                         && (cbPensioner.Text == @"Не указано" || t.pensioner == pensioner));
                foreach (var person in persons)
                {
                    lvStuffByName.Items.Add(
                        new ListViewItem
                            {
                                Text = person.firstName,
                                SubItems =
                                    {                                     
                                        person.secondName,
                                        person.age.ToString(),
                                        person.pensioner ? "Да" : "Нет"
                                    }
                            });
                }     
            }
        }

        private void CbMorgueSelectedIndexChanged(object sender, EventArgs e)
        {
            lvStuffByMorgue.Items.Clear();
            using (var readContext = new MorgueEntities())
            {
                if (cbMorgue.SelectedItem == null)
                {
                    return;
                }

                var selectedMorgue = int.Parse(cbMorgue.SelectedItem.ToString().Split('(')[0]);

                var persons = readContext.Stuff.Join(
                    readContext.Positions, 
                    s => s.id, 
                    p => p.idPerson,
                    (s, p) => new
                        {
                            FirstName = s.firstName,
                            SecondName = s.secondName,
                            Age = s.age,
                            Pensioner = s.pensioner,
                            Morgue = p.idMorgue
                        }).Where(t => t.Morgue == selectedMorgue);
                foreach (var person in persons)
                {
                    lvStuffByMorgue.Items.Add(new ListViewItem
                                                  {
                                                      Text = person.FirstName,
                                                      SubItems =
                                                          {
                                                              person.SecondName,
                                                              person.Age.ToString(),
                                                              person.Pensioner ? @"Да" : @"Нет"
                                                          }
                                                  });
                }
            }
        }

        #endregion
    }
}