using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DataBaseOP.Database.Entities;

namespace DataBaseOP.Database
{
    public class DataBaseOPContext
    {
        // Реализовн паттерн Singleton. Экземпляр класса DataBaseOPContext можно создать только один.
        private static readonly DataBaseOPContext context = new DataBaseOPContext();
        public static DataBaseOPContext GetContext => context;
        private string ConnectionString { get; }

        private DataBaseOPContext()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        }

        // POSITION COMMANDS

        /// <summary>
        /// Добавляет новую должность в таблицу "Position".
        /// </summary>
        /// <param name="position">Новая сущность "Должности"</param>
        public void AddPosition(Position position)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                Position newPosition = position;
                string name = newPosition.Name;

                SqlCommand command = new SqlCommand("sp_InsertPosition", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", name);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        /// <summary>
        /// Изменяет информацию о должности в таблице "Position".
        /// </summary>
        /// <param name="position">Сущность "Должность" с обновленными данными.</param>
        public void EditPosition(Position position)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                Position updatedPosition = position;
                int id = updatedPosition.ID;
                string name = updatedPosition.Name;

                SqlCommand command = new SqlCommand("sp_UpdatePosition", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@Name", name);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        /// <summary>
        /// Извлекает все данные из таблицы "Position".
        /// </summary>
        /// <returns>Таблица с названиями имеющихся должностей в БД.</returns>
        public DataTable GetAllPositions()
        {
            DataTable dataTable;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("sp_GetAllPositions", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                dataTable = new DataTable();

                dataTable.Load(reader);

                connection.Close();
            }

            return dataTable;
        }


        // CATEGORY COMMANDS

        /// <summary>
        /// Добавляет новую категорию в таблицу "Category".
        /// </summary>
        /// <param name="category">Новая сущность "Категория".</param>
        public void AddCategory(Category category)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                Category newCategory = (Category)category;
                string name = newCategory.Name;

                SqlCommand command = new SqlCommand("sp_InsertCategory", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", name);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        /// <summary>
        /// Изменяет информацию о категории в таблице "Category".
        /// </summary>
        /// <param name="category">Сущность "Категория" с обновленными данными.</param>
        public void EditCategory(Category category)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                Category updatedCategory = (Category)category;
                int id = updatedCategory.ID;
                string name = updatedCategory.Name;

                SqlCommand command = new SqlCommand("sp_UpdateCategory", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@Name", name);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        /// <summary>
        /// Универсальный метод для удаления записей из таблиц.
        /// </summary>
        /// <param name="recordId">Идентификатор записи, по которому будет искаться запись в БД для удаления.</param>
        /// <param name="procedureName">Наименование хранимой процедуры для удаления записи.</param>
        public void Delete(int recordId, string procedureName)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                int id = recordId;

                SqlCommand command = new SqlCommand(procedureName, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", id);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        /// <summary>
        /// Извлекает все данные из таблицы "Category".
        /// </summary>
        /// <returns>Таблица с названиями имеющихся категорий товаров в БД.</returns>
        public DataTable GetAllCategories()
        {
            DataTable dataTable;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("sp_GetAllCategories", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                dataTable = new DataTable();

                dataTable.Load(reader);
                dataTable.Columns[2].ReadOnly = false;

                connection.Close();
            }

            return dataTable;
        }

        /// <summary>
        /// Возвращает идентификатор категории по наименованию категории. Название категории - уникальный столбец в таблице "Category".
        /// </summary>
        /// <param name="categoryName">Наименование категории.</param>
        /// <returns>Идентификатор найденной категории.</returns>
        public int GetCategoryIdByName(string categoryName)
        {
            int categoryId = 0;
            string name = categoryName;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("sp_GetCategoryIdByName", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("Name", name);

                categoryId = Convert.ToInt32(command.ExecuteScalar());

                connection.Close();
            }

            return categoryId;
        }


        // SUPPLIER COMMANDS


        /// <summary>
        /// Добавляет нового поставщика в таблицу "Supplier".
        /// </summary>
        /// <param name="supplier">Новая сущность "Поставщик".</param>
        public void AddSupplier(Supplier supplier)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                Supplier newSupplier = supplier;
                string fio = newSupplier.FIO;
                string address = newSupplier.Address;
                string phone = newSupplier.Phone;

                SqlCommand command = new SqlCommand("sp_InsertSupplier", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FIO", fio);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@Phone", phone);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        /// <summary>
        /// Изменяет информацию о поставщике в таблице "Supplier".
        /// </summary>
        /// <param name="supplier">Сущность "Поставщик" с обновленными данными.</param>
        public void EditSupplier(Supplier supplier)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                Supplier updatedSupplier = supplier;
                int id = updatedSupplier.ID;
                string fio = updatedSupplier.FIO;
                string address = updatedSupplier.Address;
                string phone = updatedSupplier.Phone;

                SqlCommand command = new SqlCommand("sp_UpdateSupplier", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@FIO", fio);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@Phone", phone);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        /// <summary>
        /// Извлекает все данные из таблицы "Supplier".
        /// </summary>
        /// <returns>Таблица с информацией о существующих поставщиках в БД.</returns>
        public DataTable GetAllSuppliers()
        {
            DataTable dataTable;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("sp_GetAllSuppliers", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                dataTable = new DataTable();

                dataTable.Load(reader);
                for (int i = 2; i < dataTable.Columns.Count; i++)
                    dataTable.Columns[i].ReadOnly = false;

                connection.Close();
            }

            return dataTable;
        }

        /// <summary>
        /// Возвращает идентификатор поставщика по телефону поставщика. Телефон - уникальный столбец в таблице "Supplier".
        /// </summary>
        /// <param name="supplierPhone">Номер телефона поставщика.</param>
        /// <returns>Идентификатор найденного поставщика.</returns>
        public int GetSupplierIdByPhone(string supplierPhone)
        {
            int supplierId = 0;
            string phone = supplierPhone;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("sp_GetSupplierIdByPhone", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("Phone", phone);

                supplierId = Convert.ToInt32(command.ExecuteScalar());

                connection.Close();
            }

            return supplierId;
        }

        /// <summary>
        /// Возвращает информацию о поставщике, найденного по телефону поставщика.
        /// </summary>
        /// <param name="supplierPhone">Номер телефона поставщика.</param>
        /// <returns>Таблица с данными о найденном поставщике.</returns>
        public DataTable GetSupplierInfoByPhone(string supplierPhone)
        {
            DataTable dataTable;
            string phone = supplierPhone;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("sp_GetSupplierInfoByPhone", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("Phone", phone);
                SqlDataReader reader = command.ExecuteReader();
                dataTable = new DataTable();

                dataTable.Load(reader);

                connection.Close();
            }

            return dataTable;
        }



        // TRADEMARK COMMANDS

        /// <summary>
        /// Добавляет новый бренд в таблицу "Trademark".
        /// </summary>
        /// <param name="trademark">Новая сущность "Бренд".</param>
        public void AddTrademark(Trademark trademark)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                Trademark newTrademark = trademark;
                string name = newTrademark.Name;
                string address = newTrademark.Address;
                string phone = newTrademark.Phone;

                SqlCommand command = new SqlCommand("sp_InsertTrademark", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@Phone", phone);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        /// <summary>
        /// Изменяет информацию о бренде в таблице "Trademark".
        /// </summary>
        /// <param name="trademark">Сущность "Бренд" с обновленными данными.</param>
        public void EditTrademark(Trademark trademark)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                Trademark updatedTrademark = trademark;
                int id = updatedTrademark.ID;
                string name = updatedTrademark.Name;
                string address = updatedTrademark.Address;
                string phone = updatedTrademark.Phone;

                SqlCommand command = new SqlCommand("sp_UpdateTrademark", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@Phone", phone);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        /// <summary>
        /// Извлекает все данные из таблицы "Trademark".
        /// </summary>
        /// <returns>Таблица с информацией о существующих брендах в БД.</returns>
        public DataTable GetAllTrademarks()
        {
            DataTable dataTable;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("sp_GetAllTrademarks", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                dataTable = new DataTable();

                dataTable.Load(reader);
                for (int i = 2; i < dataTable.Columns.Count; i++)
                    dataTable.Columns[i].ReadOnly = false;

                connection.Close();
            }

            return dataTable;
        }

        /// <summary>
        /// Возвращает идентификатор бренда, найденного по наименованию бренда. Имя бренда - уникальный столбец в таблице "Trademark".
        /// </summary>
        /// <param name="trademarkName">Наименование бренда.</param>
        /// <returns>Идентификатор найденного бренда.</returns>
        public int GetTrademarkIdByName(string trademarkName)
        {
            int trademarkId = 0;
            string name = trademarkName;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("sp_GetTrademarkIdByName", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("Name", name);

                trademarkId = Convert.ToInt32(command.ExecuteScalar());

                connection.Close();
            }

            return trademarkId;
        }



        // TRADEMARK COMMANDS

        /// <summary>
        /// Добавляет нового клиента в таблицу "Client".
        /// </summary>
        /// <param name="client">Новая сущность "Клиент".</param>
        public void AddClient(Client client)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                Client updatedClient = client;
                string fio = updatedClient.FIO;
                string phone = updatedClient.Phone;
                string address = updatedClient.Address;

                SqlCommand command = new SqlCommand("sp_InsertClient", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FIO", fio);
                command.Parameters.AddWithValue("@Phone", phone);
                command.Parameters.AddWithValue("@Address", address);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        /// <summary>
        /// Изменяет информацию о клиенте в таблице "Client".
        /// </summary>
        /// <param name="client">Сущность "Клиент" с обновленными данными.</param>
        public void EditClient(Client client)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                Client updatedClient = client;
                int id = updatedClient.ID;
                string fio = updatedClient.FIO;
                string phone = updatedClient.Phone;
                string address = updatedClient.Address;

                SqlCommand command = new SqlCommand("sp_UpdateClient", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@FIO", fio);
                command.Parameters.AddWithValue("@Phone", phone);
                command.Parameters.AddWithValue("@Address", address);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        /// <summary>
        /// Извлекает все данные из таблицы "Client".
        /// </summary>
        /// <returns>Таблица с информацией о существующих клиентах в БД.</returns>
        public DataTable GetAllClients()
        {
            DataTable dataTable;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("sp_GetAllClients", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                dataTable = new DataTable();

                dataTable.Load(reader);
                for (int i = 2; i < dataTable.Columns.Count; i++)
                    dataTable.Columns[i].ReadOnly = false;

                connection.Close();
            }

            return dataTable;
        }

        /// <summary>
        /// Возвращает идентификатор клиента, найденного по номеру телефона клиента. Номер телефона - уникальный столбец в таблице "Client".
        /// </summary>
        /// <param name="clientPhone">Номер телефона клиента.</param>
        /// <returns>Идентификатор найденного клиента.</returns>
        public int GetClientIdByPhone(string clientPhone)
        {
            int clientId = 0;
            string phone = clientPhone;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("sp_GetClientIdByPhone", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("Phone", phone);

                clientId = Convert.ToInt32(command.ExecuteScalar());

                connection.Close();
            }

            return clientId;
        }

        /// <summary>
        /// Возвращает информацию о клиенте, найденного по номеру телефона клиента.
        /// </summary>
        /// <param name="clientPhone">Номер телефона клиента.</param>
        /// <returns>Таблица с данными о найденном клиенте.</returns>
        public DataTable GetClientInfoByPhone(string clientPhone)
        {
            DataTable dataTable;
            string phone = clientPhone;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("sp_GetClientInfoByPhone", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("Phone", phone);
                SqlDataReader reader = command.ExecuteReader();
                dataTable = new DataTable();

                dataTable.Load(reader);

                connection.Close();
            }

            return dataTable;
        }



        // REALIZATION COMMANDS

        /// <summary>
        /// Добавляет новую реализацию в таблицу "Realization".
        /// </summary>
        /// <param name="realization">Новая сущность "Реализация".</param>
        public void AddRealization(Realization realization)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                Realization newRealization = realization;
                string number = newRealization.Number;
                DateTime realizeDate = newRealization.RealizeDate;
                decimal cost = newRealization.Cost;
                int discount = newRealization.Discount;
                decimal amountDue = newRealization.AmountDue;
                decimal paidOf = newRealization.PaidOf;
                decimal change = newRealization.Change;
                int amountProducts = newRealization.AmountProducts;
                bool realized = newRealization.Realized;
                int clientId = newRealization.ClientID;
                int supplierId = newRealization.SupplierID;
                int seniorId = newRealization.SeniorID;
                int productId = newRealization.ProductID;


                SqlCommand command = new SqlCommand("sp_InsertRealization", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ProductID", productId);
                command.Parameters.AddWithValue("@Number", number);
                command.Parameters.AddWithValue("@RealizeDate", realizeDate);
                command.Parameters.AddWithValue("@Cost", cost);
                command.Parameters.AddWithValue("@Discount", discount);
                command.Parameters.AddWithValue("@AmountDue", amountDue);
                command.Parameters.AddWithValue("@PaidOf", paidOf);
                command.Parameters.AddWithValue("@Change", change);
                command.Parameters.AddWithValue("@AmountProducts", amountProducts);
                command.Parameters.AddWithValue("@Realized", realized);
                command.Parameters.AddWithValue("@ClientID", clientId);
                command.Parameters.AddWithValue("@SupplierID", supplierId);
                command.Parameters.AddWithValue("@SeniorID", seniorId);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        /// <summary>
        /// Изменяет информацию о реализации в таблице "Realization".
        /// </summary>
        /// <param name="realization">Сущность "Реализация" с обновленными данными.</param>
        public void EditRealization(Realization realization)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                Realization updatedRealization = realization;
                int id = updatedRealization.ID;
                string number = updatedRealization.Number;
                DateTime realizeDate = updatedRealization.RealizeDate;
                decimal cost = updatedRealization.Cost;
                int discount = updatedRealization.Discount;
                decimal amountDue = updatedRealization.AmountDue;
                decimal paidOf = updatedRealization.PaidOf;
                decimal change = updatedRealization.Change;
                int amountProducts = updatedRealization.AmountProducts;
                bool realized = updatedRealization.Realized;
                int clientId = updatedRealization.ClientID;
                int supplierId = updatedRealization.SupplierID;
                int seniorId = updatedRealization.SeniorID;
                int productId = updatedRealization.ProductID;

                SqlCommand command = new SqlCommand("sp_UpdateRealization", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@ProductID", productId);
                command.Parameters.AddWithValue("@Number", number);
                command.Parameters.AddWithValue("@RealizeDate", realizeDate);
                command.Parameters.AddWithValue("@Cost", cost);
                command.Parameters.AddWithValue("@Discount", discount);
                command.Parameters.AddWithValue("@AmountDue", amountDue);
                command.Parameters.AddWithValue("@PaidOf", paidOf);
                command.Parameters.AddWithValue("@Change", change);
                command.Parameters.AddWithValue("@AmountProducts", amountProducts);
                command.Parameters.AddWithValue("@Realized", realized);
                command.Parameters.AddWithValue("@ClientID", clientId);
                command.Parameters.AddWithValue("@SupplierID", supplierId);
                command.Parameters.AddWithValue("@SeniorID", seniorId);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        /// <summary>
        /// Извлекает все данные из таблицы "Realization".
        /// </summary>
        /// <returns>Таблица с информацией о существующих реализациях в БД.</returns>
        public DataTable GetAllRealizations()
        {
            DataTable dataTable;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("sp_GetAllRealizations", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                dataTable = new DataTable();

                dataTable.Load(reader);
                for (int i = 2; i < dataTable.Columns.Count; i++)
                    dataTable.Columns[i].ReadOnly = false;

                connection.Close();
            }

            return dataTable;
        }

        /// <summary>
        /// Возвращает идентификатор реализации, найденной по номеру реализации. Номер реализации - уникальный столбец в таблице "Realization".
        /// </summary>
        /// <param name="realizationNumber">Номер реализации.</param>
        /// <returns>Идентификатор найденной реализации.</returns>
        public int GetRealizationIdByNumber(string realizationNumber)
        {
            int realizationId = 0;
            string number = realizationNumber;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("sp_GetRealizationIdByNumber", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("Number", number);

                realizationId = Convert.ToInt32(command.ExecuteScalar());

                connection.Close();
            }

            return realizationId;
        }


        // PRODUCT COMMANDS

        /// <summary>
        /// Добавляет новый продукт в таблицу "Product".
        /// </summary>
        /// <param name="product">Новая сущность "Продукт".</param>
        public void AddProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                Product newProduct = product;
                string name = newProduct.Name;
                int amount = newProduct.Amount;
                string unit = newProduct.Unit;
                decimal cost = newProduct.Cost;
                string description = newProduct.Description;
                int categoryId = newProduct.CategoryID;
                int trademarkId = newProduct.TrademarkID;

                SqlCommand command = new SqlCommand("sp_InsertProduct", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Amount", amount);
                command.Parameters.AddWithValue("@Unit", unit);
                command.Parameters.AddWithValue("@Cost", cost);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@CategoryID", categoryId);
                command.Parameters.AddWithValue("@TrademarkID", trademarkId);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        /// <summary>
        /// Изменяет информацию о продукте в таблице "Product".
        /// </summary>
        /// <param name="product">Сущность "Продукт" с обновленными данными.</param>
        public void EditProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                Product updatedProduct = product;
                int id = updatedProduct.ID;
                string name = updatedProduct.Name;
                int amount = updatedProduct.Amount;
                string unit = updatedProduct.Unit;
                decimal cost = updatedProduct.Cost;
                string description = updatedProduct.Description;
                int categoryId = updatedProduct.CategoryID;
                int trademarkId = updatedProduct.TrademarkID;

                SqlCommand command = new SqlCommand("sp_UpdateProduct", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Amount", amount);
                command.Parameters.AddWithValue("@Unit", unit);
                command.Parameters.AddWithValue("@Cost", cost);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@CategoryID", categoryId);
                command.Parameters.AddWithValue("@TrademarkID", trademarkId);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        /// <summary>
        /// Извлекает все данные из таблицы "Product".
        /// </summary>
        /// <returns>Таблица с информацией о существующих продукциях в БД.</returns>
        public DataTable GetAllProducts()
        {
            DataTable dataTable;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("sp_GetAllProducts", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                dataTable = new DataTable();

                dataTable.Load(reader);
                for (int i = 2; i < dataTable.Columns.Count; i++)
                    dataTable.Columns[i].ReadOnly = false;

                connection.Close();
            }

            return dataTable;
        }

        /// <summary>
        /// Возвращает идентификатор продукта, найденного по наименованию продукции. Наименование продукции - уникальный столбец в таблице "Product".
        /// </summary>
        /// <param name="productName">Наименование продукта.</param>
        /// <returns>Идентификатор найденного продукта.</returns>
        public int GetProductIdByName(string productName)
        {
            int productId = 0;
            string name = productName;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("sp_GetProductIdByName", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("Name", name);

                productId = Convert.ToInt32(command.ExecuteScalar());

                connection.Close();
            }

            return productId;
        }


        // WORKER COMMANDS

        /// <summary>
        /// Добавляет нового сотрудника в таблицу "Worker".
        /// </summary>
        /// <param name="worker">Новая сущность "Сотрудник".</param>
        public void AddWorker(Worker worker)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                Worker newWorker = worker;
                string fio = newWorker.FIO;
                string phone = newWorker.Phone;
                string positionName = newWorker.Position.Name;
                int positionId = 0;

                SqlCommand command = new SqlCommand("sp_InsertWorker", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FIO", fio);
                command.Parameters.AddWithValue("@Phone", phone);
                command.Parameters.AddWithValue("@PositionID", positionId);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        /// <summary>
        /// Изменяет информацию о сотруднике в таблице "Worker".
        /// </summary>
        /// <param name="worker">Сущность "Сотрудник" с обновленными данными.</param>
        public void EditWorker(Worker worker)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                Worker updatedWorker = worker;
                int id = updatedWorker.ID;
                string phone = updatedWorker.Phone;

                SqlCommand command = new SqlCommand("sp_UpdateWorker", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@Phone", phone);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        /// <summary>
        /// Извлекает все данные из таблицы "Workers".
        /// </summary>
        /// <returns>Таблица с информацией о существующих сотрудниках в БД.</returns>
        public DataTable GetAllWorkers()
        {
            DataTable dataTable;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("sp_GetAllWorkers", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                dataTable = new DataTable();

                dataTable.Load(reader);
                dataTable.Columns[2].ReadOnly = false;

                connection.Close();
            }

            return dataTable;
        }

        /// <summary>
        /// Возвращает идентификатор сотрудника, найденного по номеру телефона сотрудника. Номер телефона - уникальный столбец в таблице "Worker".
        /// </summary>
        /// <param name="workerPhone">Номер телефона сотрудника.</param>
        /// <returns>Идентификатор найденного сотрудника.</returns>
        public int GetWorkerIdByPhone(string workerPhone)
        {
            int workerId = 0;
            string phone = workerPhone;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("sp_GetWorkerIdByPhone", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("Phone", phone);

                workerId = Convert.ToInt32(command.ExecuteScalar());

                connection.Close();
            }

            return workerId;
        }

        /// <summary>
        /// Возвращает информацию о сотруднике, найденного по номеру телефона сотрудника.
        /// </summary>
        /// <param name="workerPhone">Номер телефона сотрудника.</param>
        /// <returns>Таблица с данными о найденном сотруднике.</returns>
        public DataTable GetWorkerInfoByPhone(string workerPhone)
        {
            DataTable dataTable;
            string phone = workerPhone;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("sp_GetWorkerInfoByPhone", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("Phone", phone);
                SqlDataReader reader = command.ExecuteReader();
                dataTable = new DataTable();

                dataTable.Load(reader);

                connection.Close();
            }

            return dataTable;
        }



        // REPORTS

        /// <summary>
        /// Возвращает информацию о выручке и обороте средств за выбранный период времени.
        /// </summary>
        /// <param name="beginDate">Дата начала периода.</param>
        /// <param name="endDate">Дата конца периода.</param>
        /// <returns>Таблица с информацией о выручке о обороте средств.</returns>
        public DataTable GetRealizationsResult(DateTime beginDate, DateTime endDate)
        {
            DataTable dataTable;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("sp_GetRealizationsResult", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@BeginDate", SqlDbType.Date).Value = beginDate;
                command.Parameters.Add("@EndDate", SqlDbType.Date).Value = endDate;
                SqlDataReader reader = command.ExecuteReader();
                dataTable = new DataTable();

                dataTable.Load(reader);

                connection.Close();
            }

            return dataTable;
        }
    }
}
