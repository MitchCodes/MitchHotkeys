using MitchHotkeys.Logic.Models;
using System;
using System.ComponentModel;
using System.Data.SQLite;
using System.IO;
using System.Linq;

namespace MitchHotkeys.Data
{
    public class DataService
    {

        SQLiteConnection m_dbConnection;

        public DataService()
        {
            if (!File.Exists("AppDatabase.sqlite"))
            {
                SQLiteConnection.CreateFile("AppDatabase.sqlite");
            }
            try
            {
                m_dbConnection = new SQLiteConnection("Data Source=AppDatabase.sqlite;Version=3;");
                m_dbConnection.Open();
                string sql = "create table if not exists hotkeys (groupId int, modifier int, key int, command int, extraData1 varchar(2500), extraData2 varchar(2500), extraData3 varchar(2500))";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.ToString());
            }
            finally
            {
                m_dbConnection.Close();
            }

            try {
                m_dbConnection = new SQLiteConnection("Data Source=AppDatabase.sqlite;Version=3;");
                m_dbConnection.Open();
                string sql = "create table if not exists hotkeyGroups (id int, name varchar(2500))";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
            }
            catch (Exception e) {
                //Console.WriteLine(e.ToString());
            }
            finally {
                m_dbConnection.Close();
            }

            try {
                m_dbConnection = new SQLiteConnection("Data Source=AppDatabase.sqlite;Version=3;");
                m_dbConnection.Open();
                string sql = "create table if not exists hotkeyAdditionalExtraData (groupId int, modifier int, key int, command int, keyName varchar(100), dataValue varchar(2500))";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
            }
            catch (Exception e) {
                //Console.WriteLine(e.ToString());
            }
            finally {
                m_dbConnection.Close();
            }
            
            
        }

        public void InsertHotkey(Hotkey hotkey, HotkeyGroup group)
        {
            m_dbConnection.Open();

            try
            {
                string sql = "insert into hotkeys (groupId, modifier,key,command,extraData1,extraData2,extraData3) values (" + group.Id + "," + hotkey.Modifier +"," + hotkey.Key +","+ hotkey.Command +",'" + hotkey.ExtraData1 +"','"+ hotkey.ExtraData2 +"','"+ hotkey.ExtraData3 + "')";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

                foreach (int key in hotkey.AdditionalExtraData.Keys)
                {
                    string value = hotkey.AdditionalExtraData[key];
                    sql = "insert into hotkeyAdditionalExtraData (groupId, modifier, key, command, keyName, dataValue) values (" + group.Id + "," + hotkey.Modifier + "," + hotkey.Key + "," + hotkey.Command + ",'" + key.ToString() + "','" + value + "')";
                    command = new SQLiteCommand(sql, m_dbConnection);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                m_dbConnection.Close();
            }
        }


        public void DeleteHotkey(Hotkey hotkey, HotkeyGroup group)
        {
            DeleteHotkey(hotkey.Modifier, hotkey.Key, group.Id);
        }

        public void DeleteHotkey(int modifier, int key, int groupId)
        {

            m_dbConnection.Open();

            try
            {
                string sql = "delete from hotkeys where modifier = " + modifier + " and key = " + key + " and groupId = " + groupId;
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

                sql = "delete from hotkeyAdditionalExtraData where modifier = " + modifier + " and key = " + key + " and groupId = " + groupId;
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                m_dbConnection.Close();
            }
            
        }


        public void DeleteAllHotkeys(HotkeyGroup group)
        {

            m_dbConnection.Open();

            try
            {
                string sql = "delete from hotkeys where groupId = " + group.Id;
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

                sql = "delete from hotkeyAdditionalExtraData where groupId = " + group.Id;
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                m_dbConnection.Close();
            }

        }

        public SQLiteDataReader GetHotkeys(HotkeyGroup group)
        {
            try
            {
                string sql = "select * from hotkeys where groupId = " + group.Id;
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                return reader;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            //finally
            //{
            //    m_dbConnection.Close();
            //}
            return null;
        }

        public SQLiteDataReader GetHotkeysAdditionalData(HotkeyGroup group) {
            try {
                string sql = "select * from hotkeyAdditionalExtraData where groupId = " + group.Id;
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                return reader;
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
            //finally {
            //    m_dbConnection.Close();
            //}
            return null;
        }



        public void InsertHotkeyGroup(HotkeyGroup hotkeyGroup)
        {
            m_dbConnection.Open();

            try
            {
                string sql = "insert into hotkeyGroups (id,name) values (" + hotkeyGroup.Id + ",'" + hotkeyGroup.Name + "')";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                m_dbConnection.Close();
            }
        }

        public void DeleteHotkeyGroup(HotkeyGroup hotkeyGroup)
        {
            DeleteHotkeyGroup((int) hotkeyGroup.Id);
        }

        public void DeleteHotkeyGroup(int id)
        {

            m_dbConnection.Open();

            try
            {
                string sql = "delete from hotkeyGroups where id = " + id;
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                m_dbConnection.Close();
            }

        }


        public void DeleteAllHotkeyGroups()
        {

            m_dbConnection.Open();

            try
            {
                string sql = "delete from hotkeyGroups";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                m_dbConnection.Close();
            }

        }

        public BindingList<HotkeyGroup> GetHotkeyGroups()
        {

            m_dbConnection.Open();

            BindingList<HotkeyGroup> returnHotkeyGroups = new BindingList<HotkeyGroup>();

            try
            {
                string sql = "select * from hotkeyGroups";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    HotkeyGroup group = new HotkeyGroup();
                    group.Id = int.Parse(reader["id"].ToString());
                    group.Name = reader["name"].ToString();

                    returnHotkeyGroups.Add(group);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            } finally {
                m_dbConnection.Close();
            }


            return returnHotkeyGroups;

        }

        public void OpenConnection() {
            m_dbConnection.Open();
        }

        public void CloseConnection()
        {
            m_dbConnection.Close();
        }
    }
}
