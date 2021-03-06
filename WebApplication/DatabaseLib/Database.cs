using InterfacesLib;
using Microsoft.Data.SqlClient;

namespace DatabaseLib
{
    public class Database : InterfacesLib.IDatabase
    {
        string connectionString; 
        public Database(string ConnectionString = "")
        {
            connectionString = ConnectionString;
        }

        public void Clear()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Не удалось подключиться к базе данных", ex);
                }

                try
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "DELETE FROM dbo.MainModels";
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Не удалось выполнить скрипт очистики таблицы", ex);
                }
            }
        }

        public void Insert(IEnumerable<IMainModel> data)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Не удалось подключиться к базе данных", ex);
                }

                try
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "INSERT INTO dbo.MainModels (code, value) VALUES (@code, @value)";
                        foreach (var item in data.OrderBy(x => x.Code))
                        {
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("code", item.Code);
                            command.Parameters.AddWithValue("value", item.Value);
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Не удалось выполнить скрипт очистики таблицы", ex);
                }
            }
        }

        public IEnumerable<IDatabaseMainModel> Select(ref int totalcount, int? offset = 0, int? count = 0, int? code = null, string? value = null)
        {
            if (offset < 0)
                throw new Exception("Смещение не может быть отрицательным");
            if (count < 0)
                throw new Exception("Количество выводимых строк не может быть отрицательным");

            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Не удалось подключиться к базе данных", ex);
                }

                using (var command = connection.CreateCommand())
                {
                    bool flagFetch = (count > 0);

                    var selectData = "SELECT [id],[code],[value] FROM[testdb].[dbo].[MainModels] ";
                    var selectCount = "SELECT count([id]) FROM[testdb].[dbo].[MainModels] ";
                    string whereFilter = "";
                    // настройка SQL для фильтрации
                    if ((count != null) || (value != null))
                    {                        
                        bool flagAnd = false;
                        if (value != null)
                        {
                            whereFilter += $"[value] like @value ";
                            flagAnd = true;
                        }
                        if (code != null)
                        {
                            if (flagAnd)
                                whereFilter += " and ";
                            whereFilter += $"[code] = @code ";
                        }
                        if (whereFilter != "")
                            whereFilter = $"where {whereFilter}";
                    }

                    selectCount += whereFilter;
                    selectData += whereFilter + " order by [code] OFFSET @offset ROWS ";
                    if (flagFetch)
                        selectData += " fetch next @count rows only";
                    
                    command.Connection = connection;

                    command.CommandText = selectCount;
                    if (value != null)
                        command.Parameters.AddWithValue("value", $"%{value}%");
                    if (code != null)
                        command.Parameters.AddWithValue("code", code);

                    totalcount = Convert.ToInt32(command.ExecuteScalar());

                    command.CommandText = selectData;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("offset", offset * count);
                    if (flagFetch)
                        command.Parameters.AddWithValue("count", count);
                    if (value != null)
                        command.Parameters.AddWithValue("value", $"%{value}%");
                    if (code != null)
                        command.Parameters.AddWithValue ("code", code);

                    using (var reader = command.ExecuteReader())
                    {
                        List<IDatabaseMainModel> result = new List<IDatabaseMainModel>();
                        while (reader.Read())
                        {
                            var _id = reader.GetInt64(0);
                            var _code = reader.GetInt32(1);
                            var _value = reader.GetString(2);
                            result.Add(new ModelsLib.DatabaseMainModel(_id, _code, _value));
                        }
                        return result;
                    }
                }
            }
            return null;
        }
    }
}
