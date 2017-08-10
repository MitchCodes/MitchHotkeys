using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MitchHotkeys.MiddleTier.Factories;
using System.IO;
using MitchHotkeys.Logic.Models;

namespace MitchHotkeys.DataTier
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

        public BindingList<Hotkey> GetHotkeys(HotkeyGroup group)
        {

            m_dbConnection.Open();

            BindingList<Hotkey> returnHotkeys = new BindingList<Hotkey>();

            try
            {
                string sql = "select * from hotkeys where groupId = " + group.Id;
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int hotkeyCommand = int.Parse(reader["command"].ToString());
                    Hotkey newHotkey = HotkeyTypeFactory.GetHotkeyType(hotkeyCommand);
                    newHotkey.Modifier = int.Parse(reader["modifier"].ToString());
                    newHotkey.Key = int.Parse(reader["key"].ToString());
                    newHotkey.Command = hotkeyCommand;
                    newHotkey.ExtraData1 = reader["extraData1"].ToString();
                    newHotkey.ExtraData2 = reader["extraData2"].ToString();
                    newHotkey.ExtraData3 = reader["extraData3"].ToString();

                    returnHotkeys.Add(newHotkey);
                }

                sql = "select * from hotkeyAdditionalExtraData where groupId = " + group.Id;
                command = new SQLiteCommand(sql, m_dbConnection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int currentModifier = int.Parse(reader["modifier"].ToString());
                    int currentKey = int.Parse(reader["key"].ToString());
                    int currentCommand = int.Parse(reader["command"].ToString());

                    Hotkey addedHotkey = returnHotkeys.FirstOrDefault(hk => hk.Modifier == currentModifier && hk.Key == currentKey && hk.Command == currentCommand);
                    if (addedHotkey != null)
                    {
                        string currentDataKey = reader["keyName"].ToString();
                        string currentDataValue = reader["dataValue"].ToString();
                        addedHotkey.AdditionalExtraData.Add(int.Parse(currentDataKey), currentDataValue);
                    }
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
            

            return returnHotkeys;

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
            DeleteHotkeyGroup(hotkeyGroup.Id);
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
            }
            finally
            {
                m_dbConnection.Close();
            }


            return returnHotkeyGroups;

        }


        public void CloseConnection()
        {
            m_dbConnection.Close();
        }
    }
}
