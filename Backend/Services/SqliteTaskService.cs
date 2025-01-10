using TaskTracker.Models;
using Microsoft.Data.Sqlite;
using System.Globalization;

namespace TaskTracker.Services;

public class SqliteTaskService : ITaskService
{
    SqliteConnection sqliteConnection;
    public SqliteTaskService(string? databasefile)
    {
        if (databasefile == null)
        {
            sqliteConnection = new SqliteConnection("");
        }else{
            sqliteConnection = new SqliteConnection($"Data Source={databasefile}");
        }
        sqliteConnection.Open();

        var command = sqliteConnection.CreateCommand();
        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS
            tasks (
                id INTEGER PRIMARY KEY AUTOINCREMENT, 
                name              TEXT     NOT NULL,
                due_at_offset     INTEGER  NOT NULL,
                done_at_timestamp INTEGER
            );
        ";
        command.ExecuteNonQuery();
    }
    public List<DailyTask> GetAllTasks()
    {
        var tasks = new List<DailyTask>();
        var command = sqliteConnection.CreateCommand();
        command.CommandText = @"
            SELECT id, name, due_at_offset, done_at_timestamp FROM tasks;            
        ";
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                var id = reader.GetInt32(0);
                var name = reader.GetString(1);
                var due_at_offset = reader.GetInt32(2);
                var to_be_done_at = TimeSpan.FromSeconds(due_at_offset);
                DateTime? done_at_timestamp = null;
                if(!reader.IsDBNull(3))
                {
                    var offset = DateTimeOffset.FromUnixTimeSeconds(reader.GetInt64(3));
                    done_at_timestamp = offset.LocalDateTime;
                }
                tasks.Add(new DailyTask{Id=id, Name=name, To_be_done_at=to_be_done_at, Done_at=done_at_timestamp});
            }
        }
        return tasks;
    }

    long? convert_to_optional_timestamp(DailyTask task){
        if(task.Done_at is null)
        {
            return null;
        }else{
            var timestamp = new DateTimeOffset(task.Done_at.Value.ToUniversalTime()).ToUnixTimeSeconds();
            return timestamp;
        }

    }
    public void Add(DailyTask task)
    {
        var command = sqliteConnection.CreateCommand();
        command.CommandText = @"
            INSERT INTO tasks (name, due_at_offset )
            VALUES( $name, $due_at_offset );
        ";
        command.Parameters.AddWithValue("$name", task.Name);
        command.Parameters.AddWithValue("$due_at_offset", task.To_be_done_at.TotalSeconds);
        //command.Parameters.AddWithValue("$done_at_timestamp", convert_to_optional_timestamp(task));
        command.ExecuteNonQuery();
    }

    public DailyTask? Find(int id)
    {
        DailyTask? task = null;
        var command = sqliteConnection.CreateCommand();
        command.CommandText = @"
            SELECT id, name, due_at_offset, done_at_timestamp
            FROM tasks
            WHERE id = $id;
        ";
        command.Parameters.AddWithValue("$id", id);
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                var name = reader.GetString(1);
                var due_at_offset = reader.GetInt32(2);
                var to_be_done_at = TimeSpan.FromSeconds(due_at_offset);
                DateTime? done_at_timestamp = null;
                if(!reader.IsDBNull(3))
                {
                    var offset = DateTimeOffset.FromUnixTimeSeconds(reader.GetInt64(3));
                    done_at_timestamp = offset.LocalDateTime;
                }
                task = new DailyTask{Id=id, Name=name, To_be_done_at=to_be_done_at, Done_at=done_at_timestamp};
            }
        }
        return task;
    }

    public void Update(DailyTask task)
    {
        var command = sqliteConnection.CreateCommand();
        command.CommandText = @"
            UPDATE tasks 
            SET name = $name,
                due_at_offset = $due_at_offset,
                done_at_timestamp = $done_at_timestamp
            WHERE id = $id;
        ";
        command.Parameters.AddWithValue("$name", task.Name);
        command.Parameters.AddWithValue("$due_at_offset", task.To_be_done_at.TotalSeconds);
        var timestamp = convert_to_optional_timestamp(task);
        if(timestamp is not null)
        {
            command.Parameters.AddWithValue("$done_at_timestamp", timestamp);
        }else{
            command.Parameters.AddWithValue("$done_at_timestamp", DBNull.Value);
        }
        command.Parameters.AddWithValue("$id", task.Id);
        command.ExecuteNonQuery();
    }


    public void Delete(int id)
    {
        var command = sqliteConnection.CreateCommand();
        command.CommandText = @"
            DELETE FROM tasks 
            WHERE id = $id;
        ";
        command.Parameters.AddWithValue("$id", id);
        command.ExecuteNonQuery();
    }
}