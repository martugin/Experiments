using System;
using System.Collections.Generic;
using System.Data;
using BaseLibrary;
using System.Windows.Forms;
using Microsoft.Office.Interop.Access.Dao;

namespace VersionSynch
{
    public class DbVersion
    {
        private string _databasePath;
        private string _templatePath;
        private string _templateDate;
        private Version _templateVersion;
        private Version _dbVersion;
        private string _error = "";

        //Устанавливаем версию базы данных
        private void DetectDbVersion(string dbPath, DbMode dbMode)
        {
            _databasePath = dbPath;
            bool sqlMode = false;
            switch (dbMode)
            {
                case DbMode.Project:
                    _templatePath = Different.GetInfoTaskDir() + "General\\ProjectTemplate.accdb";
                    break;
                case DbMode.Archive:
                    _templatePath = Different.GetInfoTaskDir() + "Providers\\Archives\\CalcArchiveTemplate.accdb";
                    break;
                case DbMode.Test:
                    _templatePath = Different.GetInfoTaskDir() + "Providers\\Test\\TestProviderTemplate.accdb";
                    break;
                case DbMode.ControllerData:
                    _templatePath = Different.GetInfoTaskDir() + "Tmp\\ControllerDataTemplate.accdb";
                    break;
                case DbMode.ReporterData:
                    _templatePath = Different.GetInfoTaskDir() + "Tmp\\ReporterDataTemplate.accdb";
                    break;
                case DbMode.AnalyzerAppData:
                    _templatePath = Different.GetInfoTaskDir() + "Tmp\\AnalyzerAppDataTemplate.accdb";
                    break;
                case DbMode.ConstructorAppData:
                    _templatePath = Different.GetInfoTaskDir() + "Tmp\\ConstructorAppDataTemplate.accdb";
                    break;
                case DbMode.ArchiveSQL:
                    sqlMode = true;
                    break;
            }
            if (!sqlMode)
                using (var sys = new SysTabl(_templatePath))
                {
                    _templateVersion = new Version(sys.SubValue("AppOptions", "AppVersion"));
                    _templateDate = sys.SubValue("AppOptions", "AppVersionDate");
                }
            else
            {
                    _templateVersion = new Version("1.1.1");
                    _templateDate = "03.09.2013";
            }

            using (var sys = new SysTabl(_databasePath))
                _dbVersion = new Version(sys.SubValue("AppOptions", "AppVersion"));
        }

        //Сравниваем версии базы данных и ProjectTemplate
        public int ProjectVersionStatus(string dbPath)
        {
            DetectDbVersion(dbPath, DbMode.Project);
            //если версия не определилась, возвращаем ошибку
            var temp = new Version("1.0.0");
            if (_dbVersion < temp) return -1;

            // если версии совпадают или версия базы данных больше версии шаблона, возвращаем ноль
            if (_dbVersion >= _templateVersion) return 0;

            //var temp = new ProjectVersion("1.1.1");
            //if (_dbVersion < temp && temp <= _templateVersion) return 2;
            temp = new Version("1.0.4");
            if (_dbVersion < temp && temp <= _templateVersion) return 2;
            temp = new Version("1.0.2");
            if (_dbVersion < temp && temp <= _templateVersion) return 2;

            return 1;
        }
        public int ArchiveVersionStatus(string dbPath)
        {
            DetectDbVersion(dbPath, DbMode.Archive);
            //если версия не определилась, возвращаем ошибку
            var temp = new Version("1.0.0");
            if (_dbVersion < temp) return -1;

            // если версии совпадают или версия базы данных больше версии шаблона, возвращаем ноль
            if (_dbVersion >= _templateVersion) return 0;

            //var temp = new ProjectVersion("?.?.?");
            //if (_dbVersion < temp && temp <= _templateVersion) return 2;

            return 1;
        }
        public int TestProviderVersionStatus(string dbPath)
        {
            DetectDbVersion(dbPath, DbMode.Test);
            //если версия не определилась, возвращаем ошибку
            var temp = new Version("1.0.0");
            if (_dbVersion < temp) return -1;

            // если версии совпадают или версия базы данных больше версии шаблона, возвращаем ноль
            if (_dbVersion >= _templateVersion) return 0;

            //var temp = new ProjectVersion("?.?.?");
            //if (_dbVersion < temp && temp <= _templateVersion) return 2;

            return 1;
        }
        private int AnalizerAppDataVersionStatus(string dbPath)
        {
            DetectDbVersion(dbPath, DbMode.AnalyzerAppData);
            //если версия не определилась, возвращаем ошибку
            var temp = new Version("1.0.0");
            if (_dbVersion < temp) return -1;

            // если версии совпадают или версия базы данных больше версии шаблона, возвращаем ноль
            if (_dbVersion >= _templateVersion) return 0;

            //var temp = new ProjectVersion("?.?.?");
            //if (_dbVersion < temp && temp <= _templateVersion) return 2;

            return 1;
        }
        private int ConstructorAppDataVersionStatus(string dbPath)
        {
            DetectDbVersion(dbPath, DbMode.ConstructorAppData);
            //если версия не определилась, возвращаем ошибку
            var temp = new Version("1.0.0");
            if (_dbVersion < temp) return -1;

            // если версии совпадают или версия базы данных больше версии шаблона, возвращаем ноль
            if (_dbVersion >= _templateVersion) return 0;

            //var temp = new ProjectVersion("?.?.?");
            //if (_dbVersion < temp && temp <= _templateVersion) return 2;

            return 1;
        }
        private int ControllerDataVersionStatus(string dbPath)
        {
            DetectDbVersion(dbPath, DbMode.ControllerData);
            //если версия не определилась, возвращаем ошибку
            var temp = new Version("1.0.0");
            if (_dbVersion < temp) return -1;

            // если версии совпадают или версия базы данных больше версии шаблона, возвращаем ноль
            if (_dbVersion >= _templateVersion) return 0;

            //var temp = new ProjectVersion("?.?.?");
            //if (_dbVersion < temp && temp <= _templateVersion) return 2;

            return 1;
        }
        private int ReporterDataVersionStatus(string dbPath)
        {
            DetectDbVersion(dbPath, DbMode.ReporterData);
            //если версия не определилась, возвращаем ошибку
            var temp = new Version("1.0.0");
            if (_dbVersion < temp) return -1;

            // если версии совпадают или версия базы данных больше версии шаблона, возвращаем ноль
            if (_dbVersion >= _templateVersion) return 0;

            //var temp = new ProjectVersion("?.?.?");
            //if (_dbVersion < temp && temp <= _templateVersion) return 2;

            return 1;
        }

        //Обновляет архив до версии ArchiveTemplate
        public string UpdateArchiveVersion(string dbPath, bool silentMode)
        {
            string updatingDbVersion = "";
            try
            {
                _error = "";
                //DetectDbVersion(dbPath, DbMode.Archive);
                int versionStatus = ArchiveVersionStatus(dbPath);
                if (versionStatus == 0) return _error;
                if (versionStatus < 0)
                {
                    _error = "Файл архива не обновлен, т.к. не удалось установить его версию";
                    MessageBox.Show(_error, "Ошибка определения версии", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return _error;
                }
                if (versionStatus == 2 && !silentMode)
                {
                    bool toContinue =
                        MessageBox.Show(
                            "Архив " + _databasePath +
                            " имеет устаревшую версию. В случае обновления данный файл архива будет некорректно работать на более старых версиях системы InfoTask\nОбновить версию архива автоматически?",
                            "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1) == DialogResult.OK;
                    if (!toContinue) return _error;
                }
                updatingDbVersion = _dbVersion.ToString();
                //var temp = new Version("1.0.1");
                //if (_dbVersion == temp && temp < _templateVersion)
                //{
                //    UpdateArchive1_1_0();
                //}

                var updateList = new List<UpdateDelegate>
                                         {
                                             new UpdateDelegate("1.0.1", UpdateArchive1_1_0)
                                         };
                foreach (var updateDelegate in updateList)
                {
                    var temp = new Version(updateDelegate.UpgradeVersion);
                    if (_dbVersion == temp && temp < _templateVersion)
                    {
                        updateDelegate.UpgradeAction();
                    }
                }

                using (var sys = new SysTabl(_databasePath))
                {
                    sys.PutSubValue("AppOptions", "AppVersion", _dbVersion.ToString());
                    sys.PutSubValue("AppOptions", "AppVersionDate", _templateDate);
                }
            }
            catch (Exception ex)
            {
                _error += ex.Message;
            }
            if (_error == "") return _error;
            _error = "При обновлении файла архива версии " + updatingDbVersion + " до версии " + _templateVersion +
                     " система выдала следующие сообщения:\n" + _error;
            MessageBox.Show(_error, "Обновление версии", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return _error;
        }
        private void UpdateArchive1_1_0()
        {
            //try
            //{
            //    using (var db = new DaoDb(_databasePath))
            //    {
            //        db.Execute("ALTER TABLE BaseValues ADD COLUMN ProcessedTime DOUBLE");
            //    }
            //}
            //catch (Exception e1)
            //{
            //    _error += "1.1.0: " + e1.Message + "\n";
            //}
            //try
            //{
            //    using (var db = new DaoDb(_databasePath))
            //    {
            //        db.Execute("ALTER TABLE HourValues ADD COLUMN ProcessedTime DOUBLE");
            //    }
            //}
            //catch (Exception e1)
            //{
            //    _error += "1.1.0: " + e1.Message + "\n";
            //}
            //try
            //{
            //    using (var db = new DaoDb(_databasePath))
            //    {
            //        db.Execute("ALTER TABLE DayValues ADD COLUMN ProcessedTime DOUBLE");
            //    }
            //}
            //catch (Exception e1)
            //{
            //    _error += "1.1.0: " + e1.Message + "\n";
            //}
            //try
            //{
            //    using (var db = new DaoDb(_databasePath))
            //    {
            //        db.Execute("ALTER TABLE AbsoluteValues ADD COLUMN ProcessedTime DOUBLE");
            //    }
            //}
            //catch (Exception e1)
            //{
            //    _error += "1.1.0: " + e1.Message + "\n";
            //}
            //try
            //{
            //    using (var db = new DaoDb(_databasePath))
            //    {
            //        db.Execute("ALTER TABLE AbsoluteDayValues ADD COLUMN ProcessedTime DOUBLE");
            //    }
            //}
            //catch (Exception e1)
            //{
            //    _error += "1.1.0: " + e1.Message + "\n";
            //}
            _dbVersion = new Version("1.1.0");
        }

        //Обновляет архив до версии ArchiveSQL
        public string UpdateArchiveSQLVersion(string serverName, string dbName, bool windowsIdentification, string login, string password, bool silentMode)
        {
            string updatingDbVersion = "";
            try
            {
                _error = "";
                updatingDbVersion = _dbVersion.ToString();
                //int versionStatus = ArchiveVersionStatus(dbPath);
                //if (versionStatus == 0) return _error;
                //if (versionStatus == 2 && !silentMode)
                //{
                //    bool toContinue =
                //        MessageBox.Show(
                //            "Архив " + _databasePath +
                //            " имеет устаревшую версию. В случае обновления данный файл архива будет некорректно работать на более старых версиях системы InfoTask\nОбновить версию архива автоматически?",
                //            "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning,
                //            MessageBoxDefaultButton.Button1) == DialogResult.OK;
                //    if (!toContinue) return _error;
                //}
                //var temp = new Version("?.?.?");
                //if (_dbVersion == temp && temp < _templateVersion)
                //{
                //    Update();
                //    _dbVersion = new Version("?.?.?");
                //}
                //sys.PutSubValue("AppOptions", "AppVersionDate", _templateDate);
                //sys.PutSubValue("AppOptions", "AppVersion", _dbVersion.ToString());

                var updateList = new List<UpdateDelegate>
                                         {
                                         };
                foreach (var updateDelegate in updateList)
                {
                    var temp = new Version(updateDelegate.UpgradeVersion);
                    if (_dbVersion == temp && temp < _templateVersion)
                    {
                        updateDelegate.UpgradeAction();
                    }
                }

                return _error;
            }
            catch (Exception ex)
            {
                _error += ex.Message;
            }
            if (_error == "") return _error;
            return "При обновлении базы данных версии " + updatingDbVersion + " до версии " + _templateVersion +
                   " система выдала следующие сообщения:\n" + _error;
        }

        //Обновляет файл тестового источника до версии TestProviderTemplate
        public string UpdateTestVersion(string dbPath, bool silentMode)
        {
            string updatingDbVersion = "";
            try
            {
                _error = "";
                //DetectDbVersion(dbPath, DbMode.Test);
                int versionStatus = TestProviderVersionStatus(dbPath);
                if (versionStatus == 0) return _error;
                if (versionStatus < 0)
                {
                    _error = "Тестовый провайдер не обновлен, т.к. не удалось установить его версию";
                    MessageBox.Show(_error, "Ошибка определения версии", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return _error;
                }
                if (versionStatus == 2 && !silentMode)
                {
                    bool toContinue =
                        MessageBox.Show(
                            "Тестовый провайдер " + _databasePath +
                            " имеет устаревшую версию. В случае обновления данный файл будет некорректно работать на более старых версиях системы InfoTask\nОбновить версию тестового провайдера автоматически?",
                            "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1) == DialogResult.OK;
                    if (!toContinue) return _error;
                }
                updatingDbVersion = _dbVersion.ToString();
                //var temp = new Version("1.0.0");
                //if (_dbVersion == temp && temp < _templateVersion)
                //{
                //    UpdateTest_1_0_1();
                //    _dbVersion = new Version("1.0.1");
                //}
                //temp = new Version("1.0.1");
                //if (_dbVersion == temp && temp < _templateVersion)
                //{
                //    UpdateTest_1_0_2();
                //    _dbVersion = new Version("1.0.2");
                //}

                var updateList = new List<UpdateDelegate>
                                         {
                                             new UpdateDelegate("1.0.0", UpdateTest_1_0_1),
                                             new UpdateDelegate("1.0.1", UpdateTest_1_0_2)
                                         };
                foreach (var updateDelegate in updateList)
                {
                    var temp = new Version(updateDelegate.UpgradeVersion);
                    if (_dbVersion == temp && temp < _templateVersion)
                    {
                        updateDelegate.UpgradeAction();
                    }
                }

                using (var sys = new SysTabl(_databasePath))
                {
                    sys.PutSubValue("AppOptions", "AppVersion", _dbVersion.ToString());
                    sys.PutSubValue("AppOptions", "AppVersionDate", _templateDate);
                }
            }
            catch (Exception ex)
            {
                _error += ex.Message;
            }
            if (_error == "") return _error;
            _error = "При обновлении тестового провайдера версии " + updatingDbVersion + " до версии " + _templateVersion +
                     " система выдала следующие сообщения:\n" + _error;
            MessageBox.Show(_error, "Обновление версии", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return _error;
        }
        private void UpdateTest_1_0_1()
        {
            try
            {
                using (var db = new DaoDb(_databasePath))
                {
                    db.ExecuteAdo("ALTER TABLE Signals ADD COLUMN ReceiverName TEXT(50) WITH COMPRESSION");
                }
            }
            catch (Exception e1)
            {
                _error += "1.0.1: " + e1.Message + "\n";
            }
            _dbVersion = new Version("1.0.1");
        }
        private void UpdateTest_1_0_2()
        {
            try
            {
                using (var db = new DaoDb(_databasePath))
                {
                    db.ExecuteAdo("ALTER TABLE Signals ADD COLUMN NumSignals SET DEFAULT 0");
                }
            }
            catch (Exception e1)
            {
                _error += "1.0.2: " + e1.Message + "\n";
            }
            _dbVersion = new Version("1.0.2");
        }

        //Обновляет файл AppData до текущей версии
        public string UpdateAnalyzerAppDataVersion(string dbPath, bool silentMode)
        {
            string updatingDbVersion = "";
            try
            {
                _error = "";
                //DetectDbVersion(dbPath, DbMode.AnalyzerAppData);
                int versionStatus = AnalizerAppDataVersionStatus(dbPath);
                if (versionStatus == 0) return _error;
                if (versionStatus < 0)
                {
                    _error = "Файл данных не обновлен, т.к. не удалось установить его версию";
                    MessageBox.Show(_error, "Ошибка определения версии", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return _error;
                }
                updatingDbVersion = _dbVersion.ToString();
                //var temp = new Version("?.?.?");
                //if (_dbVersion == temp && temp < _templateVersion)
                //{
                //    Update();
                //    _dbVersion = new Version("?.?.?");
                //}
                //sys.PutSubValue("AppOptions", "AppVersionDate", _templateDate);
                //sys.PutSubValue("AppOptions", "AppVersion", _dbVersion.ToString());

                var updateList = new List<UpdateDelegate>
                                         {
                                         };
                foreach (var updateDelegate in updateList)
                {
                    var temp = new Version(updateDelegate.UpgradeVersion);
                    if (_dbVersion == temp && temp < _templateVersion)
                    {
                        updateDelegate.UpgradeAction();
                    }
                }
            }
            catch (Exception ex)
            {
                _error += ex.Message;
            }
            if (_error == "") return _error;
            return "При обновлении базы данных версии " + updatingDbVersion + " до версии " + _templateVersion +
                   " система выдала следующие сообщения:\n" + _error;
        }

        public string UpdateConstructorAppDataVersion(string dbPath, bool silentMode)
        {
            string updatingDbVersion = "";
            try
            {
                _error = "";
                //DetectDbVersion(dbPath, DbMode.ConstructorAppData);
                int versionStatus = ConstructorAppDataVersionStatus(dbPath);
                if (versionStatus == 0) return _error;
                if (versionStatus < 0)
                {
                    _error = "Файл данных не обновлен, т.к. не удалось установить его версию";
                    MessageBox.Show(_error, "Ошибка определения версии", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return _error;
                }
                updatingDbVersion = _dbVersion.ToString();
                //var temp = new Version("?.?.?");
                //if (_dbVersion == temp && temp < _templateVersion)
                //{
                //    Update();
                //    _dbVersion = new Version("?.?.?");
                //}
                //sys.PutSubValue("AppOptions", "AppVersionDate", _templateDate);
                //sys.PutSubValue("AppOptions", "AppVersion", _dbVersion.ToString());

                var updateList = new List<UpdateDelegate>
                                         {
                                         };
                foreach (var updateDelegate in updateList)
                {
                    var temp = new Version(updateDelegate.UpgradeVersion);
                    if (_dbVersion == temp && temp < _templateVersion)
                    {
                        updateDelegate.UpgradeAction();
                    }
                }
            }
            catch (Exception ex)
            {
                _error += ex.Message;
            }
            if (_error == "") return _error;
            return "При обновлении базы данных версии " + updatingDbVersion + " до версии " + _templateVersion +
                   " система выдала следующие сообщения:\n" + _error;
        }

        //Обновляет файл ControllerData до текущей версии
        public string UpdateControllerDataVersion(string dbPath, bool silentMode)
        {
            string updatingDbVersion = "";
            try
            {
                _error = "";
                //DetectDbVersion(dbPath, DbMode.ControllerData);
                int versionStatus = ControllerDataVersionStatus(dbPath);
                if (versionStatus == 0) return _error;
                if (versionStatus < 0)
                {
                    _error = "Файл данных не обновлен, т.к. не удалось установить его версию";
                    MessageBox.Show(_error, "Ошибка определения версии", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return _error;
                }
                updatingDbVersion = _dbVersion.ToString();
                //var temp = new Version("?.?.?");
                //if (_dbVersion == temp && temp < _templateVersion)
                //{
                //    Update();
                //    _dbVersion = new Version("?.?.?");
                //}
                //sys.PutSubValue("AppOptions", "AppVersionDate", _templateDate);
                //sys.PutSubValue("AppOptions", "AppVersion", _dbVersion.ToString());

                var updateList = new List<UpdateDelegate>
                                         {
                                         };
                foreach (var updateDelegate in updateList)
                {
                    var temp = new Version(updateDelegate.UpgradeVersion);
                    if (_dbVersion == temp && temp < _templateVersion)
                    {
                        updateDelegate.UpgradeAction();
                    }
                }
            }
            catch (Exception ex)
            {
                _error += ex.Message;
            }
            if (_error == "") return _error;
            return "При обновлении базы данных версии " + updatingDbVersion + " до версии " + _templateVersion +
                   " система выдала следующие сообщения:\n" + _error;
        }

        //Обновляет файл ReporterData до текущей версии
        public string UpdateReporterDataVersion(string dbPath, bool silentMode)
        {
            string updatingDbVersion = "";
            try
            {
                _error = "";
                //DetectDbVersion(dbPath, DbMode.ReporterData);
                int versionStatus = ReporterDataVersionStatus(dbPath);
                if (versionStatus == 0) return _error;
                if (versionStatus < 0)
                {
                    _error = "Файл данных не обновлен, т.к. не удалось установить его версию";
                    MessageBox.Show(_error, "Ошибка определения версии", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return _error;
                }
                updatingDbVersion = _dbVersion.ToString();
                //var temp = new Version("?.?.?");
                //if (_dbVersion == temp && temp < _templateVersion)
                //{
                //    Update();
                //    _dbVersion = new Version("?.?.?");
                //}
                //sys.PutSubValue("AppOptions", "AppVersionDate", _templateDate);
                //sys.PutSubValue("AppOptions", "AppVersion", _dbVersion.ToString());

                var updateList = new List<UpdateDelegate>
                                         {
                                         };
                foreach (var updateDelegate in updateList)
                {
                    var temp = new Version(updateDelegate.UpgradeVersion);
                    if (_dbVersion == temp && temp < _templateVersion)
                    {
                        updateDelegate.UpgradeAction();
                    }
                }
            }
            catch (Exception ex)
            {
                _error += ex.Message;
            }
            if (_error == "") return _error;
            return "При обновлении базы данных версии " + updatingDbVersion + " до версии " + _templateVersion +
                   " система выдала следующие сообщения:\n" + _error;
        }

        //Обновляет проект до версии ProjectTemplate
        public string UpdateProjectVersion(string dbPath, bool silentMode)
        {
            string updatingDbVersion = "";
            try
            {
                _error = "";
                //DetectDbVersion(dbPath, DbMode.Project);
                int versionStatus = ProjectVersionStatus(dbPath);
                if (versionStatus == 0) return _error;
                if (versionStatus < 0)
                {
                    _error = "Проект не обновлен, т.к. не удалось установить его версию";
                    MessageBox.Show(_error, "Ошибка определения версии", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return _error;
                }
                using (var sys = new SysTabl(_databasePath))
                {
                    if (versionStatus == 2 && !silentMode)
                    {
                        bool toContinue =
                            MessageBox.Show(
                                "Проект " + sys.SubValue("ProjectInfo", "Project") + "(" +
                                sys.SubValue("ProjectInfo", "ProjectName") +
                                "), файл: " + sys.SubValue("ProjectInfo", "ProjectFile") +
                                ", имеет устаревшую версию. В случае обновления данный файл проекта будет некорректно работать на более старых версиях системы InfoTask\nОбновить версию проекта автоматически?",
                                "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button1) == DialogResult.OK;
                        if (!toContinue) return _error;
                    }
                    updatingDbVersion = _dbVersion.ToString();

                    //var updateDictionary = new Dictionary<string, Action>
                    //                                             {
                    //                                                 {"1.0.0", Update_1_0_1},
                    //                                                 {"1.0.1", Update_1_0_2},
                    //                                                 {"1.0.2", Update_1_0_3},
                    //                                                 {"1.0.3", Update_1_0_4},
                    //                                                 {"1.0.4", Update_1_0_5},
                    //                                                 {"1.0.5", Update_1_0_6},
                    //                                                 {"1.0.6", Update_1_0_7},
                    //                                                 {"1.0.7", Update_1_0_8},
                    //                                                 {"1.0.8", Update_1_0_9},
                    //                                                 {"1.0.9", Update_1_0_10},
                    //                                                 {"1.0.10", Update_1_1_0},
                    //                                                 {"1.1.0", Update_1_1_1},
                    //                                                 {"1.1.1", Update_1_1_2},
                    //                                                 {"1.1.2", Update_1_1_3},
                    //                                                 {"1.1.3", Update_1_1_4},
                    //                                             };
                    //foreach (var action in updateDictionary)
                    //{
                    //    var temp = new Version(action.Key);
                    //    if (_dbVersion == temp && temp < _templateVersion)
                    //    {
                    //        action.Value();
                    //    }
                    //}
                    var updateList = new List<UpdateDelegate>
                                         {
                                             new UpdateDelegate("1.0.0", Update_1_0_1),
                                             new UpdateDelegate("1.0.1", Update_1_0_2),
                                             new UpdateDelegate("1.0.2", Update_1_0_3),
                                             new UpdateDelegate("1.0.3", Update_1_0_4),
                                             new UpdateDelegate("1.0.4", Update_1_0_5),
                                             new UpdateDelegate("1.0.5", Update_1_0_6),
                                             new UpdateDelegate("1.0.6", Update_1_0_7),
                                             new UpdateDelegate("1.0.7", Update_1_0_8),
                                             new UpdateDelegate("1.0.8", Update_1_0_9),
                                             new UpdateDelegate("1.0.9", Update_1_0_10),
                                             new UpdateDelegate("1.0.10", Update_1_1_0),
                                             new UpdateDelegate("1.1.0", Update_1_1_1),
                                             new UpdateDelegate("1.1.1", Update_1_1_2),
                                             new UpdateDelegate("1.1.2", Update_1_1_3),
                                             new UpdateDelegate("1.1.3", Update_1_1_4)
                                         };
                    foreach (var updateDelegate in updateList)
                    {
                        var temp = new Version(updateDelegate.UpgradeVersion);
                        if (_dbVersion == temp && temp < _templateVersion)
                        {
                            updateDelegate.UpgradeAction();
                        }
                    }
                    sys.PutSubValue("AppOptions", "AppVersionDate", _templateDate);
                    sys.PutSubValue("AppOptions", "AppVersion", _dbVersion.ToString());
                }
            }
            catch (Exception ex)
            {
                _error += ex.Message;
            }
            if (_error == "") return _error;
            _error = "При обновлении базы данных версии " + updatingDbVersion + " до версии " + _templateVersion +
                     " система выдала следующие сообщения:\n" + _error;
            MessageBox.Show(_error, "Обновление проекта", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return _error;
        }
        private void Update_1_0_1()
        {
            try
            {
                using (var db = new DaoDb(_databasePath))
                {

                }
            }
            catch (Exception e1)
            {
                _error += "1.0.1: " + e1.Message + "\n";
            }
            _dbVersion = new Version("1.0.1");
        }
        private void Update_1_0_2()
        {
            try
            {
                using (var db = new DaoDb(_databasePath))
                {

                }
            }
            catch (Exception e1)
            {
                _error += "1.0.2: " + e1.Message + "\n";
            }
            _dbVersion = new Version("1.0.2");
        }
        private void Update_1_0_3()
        {
            try
            {
                using (var db = new DaoDb(_databasePath))
                {

                }
            }
            catch (Exception e1)
            {
                _error += "1.0.3: " + e1.Message + "\n";
            }
            _dbVersion = new Version("1.0.3");
        }
        private void Update_1_0_4()
        {
            try
            {
                using (var db = new DaoDb(_databasePath))
                {

                }
            }
            catch (Exception e1)
            {
                _error += "1.0.4: " + e1.Message + "\n";
            }
            _dbVersion = new Version("1.0.4");
        }
        private void Update_1_0_5()
        {
            try
            {
                using (var db = new DaoDb(_databasePath))
                {

                }
            }
            catch (Exception e1)
            {
                _error += "1.0.5: " + e1.Message + "\n";
            }
            _dbVersion = new Version("1.0.5");
        }
        private void Update_1_0_6()
        {
            try
            {
                using (var db = new DaoDb(_databasePath))
                {

                }
            }
            catch (Exception e1)
            {
                _error += "1.0.6: " + e1.Message + "\n";
            }
            _dbVersion = new Version("1.0.6");
        }
        private void Update_1_0_7()
        {
            try
            {
                using (var db = new DaoDb(_databasePath))
                {

                }
            }
            catch (Exception e1)
            {
                _error += "1.0.7: " + e1.Message + "\n";
            }
            _dbVersion = new Version("1.0.7");
        }
        private void Update_1_0_8()
        {
            try
            {
                using (var db = new DaoDb(_databasePath))
                {
                    try
                    {
                        db.ExecuteAdo("SELECT * INTO PrevParams FROM [" + _templatePath + "].PrevParams");
                    }
                    catch (Exception e1)
                    {
                        _error += "1.0.8: " + e1.Message + "\n" + e1.StackTrace + "\n";
                    }
                    try
                    {
                        db.ExecuteAdo("CREATE INDEX ArchiveParamId ON PrevParams (ArchiveParamId)");
                    }
                    catch (Exception e1)
                    {
                        _error += "1.0.8: " + e1.Message + "\n" + e1.StackTrace + "\n";
                    }
                    try
                    {
                        db.ExecuteAdo("CREATE INDEX FullCode ON PrevParams (FullCode)");
                        посмотреть совпадение названий
                            уникальность добавить
                    }
                    catch (Exception e1)
                    {
                        _error += "1.0.8: " + e1.Message + "\n" + e1.StackTrace + "\n";
                    }
                }
            }
            catch (Exception e1)
            {
                _error += "1.0.8: " + e1.Message + "\n";
            }
            _dbVersion = new Version("1.0.8");
        }
        private void Update_1_0_9()
        {
            try
            {
                using (var db = new DaoDb(_databasePath))
                {
                    //Добавлено поле TaskTag типа МЕМО и со сжатием Unicode
                    db.ExecuteAdo("ALTER TABLE Tasks ADD COLUMN TaskTag MEMO WITH COMPRESSION");
                }
            }
            catch (Exception e1)
            {
                //MessageBox.Show(e1.Message);
                _error += "1.0.9: " + e1.Message + "\n";
            }
            _dbVersion = new Version("1.0.9");
        }
        private void Update_1_0_10()
        {
            try
            {
                using (var db = new DaoDb(_databasePath))
                {
                    //Удален индекс с полей SourceName, ReceiverName
                    try
                    {
                        db.ExecuteAdo("DROP INDEX ReceiverName ON SignalsInUse");
                    }
                    catch (Exception e1)
                    {
                        _error += "1.0.10: " + e1.Message + "\n";
                    }
                    try
                    {
                        db.ExecuteAdo("DROP INDEX ProviderName ON SignalsInUse");
                    }
                    catch (Exception e1)
                    {
                        _error += "1.0.10: " + e1.Message + "\n";
                    }
                    try
                    {
                        db.ExecuteAdo("DROP INDEX ProviderName ON Signals");
                    }
                    catch (Exception e1)
                    {
                        _error += "1.0.10: " + e1.Message + "\n";
                    }
                    try
                    {
                        db.ExecuteAdo("DROP INDEX ReceiverName ON Signals");
                    }
                    catch (Exception e1)
                    {
                        _error += "1.0.10: " + e1.Message + "\n";
                    }
                    //Добавлен индекс в поле ArchiveParamId
                    try
                    {
                        db.ExecuteAdo("CREATE INDEX ArchiveParamId ON PrevParams (ArchiveParamId)");
                    }
                    catch (Exception e1)
                    {
                        _error += "1.0.10: " + e1.Message + "\n";
                    }
                }
                _dbVersion = new Version("1.0.10");
            }
            catch (Exception e1)
            {
                _error += e1.Message + "\n";
            }
        }
        private void Update_1_1_0()
        {
            try
            {
                using (var db = new DaoDb(_databasePath))
                {
                    //Добавлены таблицы VedLinTemlpate и VedParamTemplate из ProjectTemplate
                    //При копировании таблиц индексы затираются, поэтому создаем их снова
                    try
                    {
                        db.Execute("SELECT * INTO VedLinTemlpate FROM [" + _templatePath + "].VedLinTemlpate");
                    }
                    catch (Exception e1)
                    {
                        _error += "1.1.0: " + e1.Message + "\n";
                    }
                    try
                    {
                        db.ExecuteAdo("CREATE INDEX BookMark ON VedLinTemlpate (BookMark)");
                    }
                    catch (Exception e1)
                    {
                        _error += "1.1.0: " + e1.Message + "\n";
                    }
                    try
                    {
                        db.ExecuteAdo("CREATE INDEX ParamId ON VedLinTemlpate (ParamId)");
                    }
                    catch (Exception e1)
                    {
                        _error += "1.1.0: " + e1.Message + "\n";
                    }
                    //Отдельно обрабатываем поле Time, т.к. индекс на это имя не навешивается из-за неуникальности имени
                    try
                    {
                        db.ConnectDao();
                        db.Execute("ALTER TABLE VedLinTemlpate ADD COLUMN TimeColumn DATETIME");
                        db.ExecuteAdo("CREATE INDEX TimeColumn ON VedLinTemlpate (TimeColumn)");
                        db.ExecuteAdo("UPDATE VedLinTemlpate SET TimeColumn = Time");
                        db.Database.TableDefs["VedLinTemlpate"].Fields.Delete("Time");
                        db.Database.TableDefs["VedLinTemlpate"].Fields["TimeColumn"].Name = "Time";
                    }
                    catch (Exception e1)
                    {
                        _error += "1.1.0: " + e1.Message + "\n" + e1.StackTrace + "\n";
                    }
                    try
                    {
                        db.ExecuteAdo("ALTER TABLE VedLinTemlpate ALTER COLUMN ParamId SET DEFAULT 0");
                    }
                    catch (Exception e1)
                    {
                        _error += "1.1.0: " + e1.Message + "\n" + e1.StackTrace + "\n";
                    }

                    try
                    {
                        db.ExecuteAdo("SELECT * INTO VedParamTemplate FROM [" + _templatePath + "].VedParamTemplate");
                    }
                    catch (Exception e1)
                    {
                        _error += "1.1.0: " + e1.Message + "\n" + e1.StackTrace + "\n";
                    }
                    try
                    {
                        db.ExecuteAdo("CREATE INDEX CalcParamId ON VedParamTemplate (CalcParamId)");
                    }
                    catch (Exception e1)
                    {
                        _error += "1.1.0: " + e1.Message + "\n" + e1.StackTrace + "\n";
                    }
                    try
                    {
                        db.ExecuteAdo("ALTER TABLE VedParamTemplate ALTER COLUMN ParamId SET DEFAULT 0");
                    }
                    catch (Exception e1)
                    {
                        _error += "1.1.0: " + e1.Message + "\n" + e1.StackTrace + "\n";
                    }
                }
                _dbVersion = new Version("1.1.0");
            }
            catch (Exception e1)
            {
                _error += "1.1.0: " + e1.Message + "\n";
            }
        }
        private void Update_1_1_1()
        {
            using (var db = new DaoDb(_databasePath))
            {
                //Удалены поля UsedCalcParams и UsedSignals
                try
                {
                    db.ExecuteAdo("ALTER TABLE CalcParams DROP COLUMN UsedCalcParams");
                }
                catch (Exception e1)
                {
                    _error += "1.1.1: " + e1.Message + "\n";
                }
                try
                {
                    db.ExecuteAdo("ALTER TABLE CalcParams DROP COLUMN UsedSignals");
                }
                catch (Exception e1)
                {
                    _error += "1.1.1: " + e1.Message + "\n";
                }
                try
                {
                    db.ExecuteAdo("ALTER TABLE CalcSubParams DROP COLUMN UsedCalcParams");
                }
                catch (Exception e1)
                {
                    _error += "1.1.1: " + e1.Message + "\n";
                }
                try
                {
                    db.ExecuteAdo("ALTER TABLE CalcSubParams DROP COLUMN UsedSignals");
                }
                catch (Exception e1)
                {
                    _error += "1.1.1: " + e1.Message + "\n";
                }
                //Добавлено UsedUnits
                try
                {
                    db.ExecuteAdo("ALTER TABLE CalcParams ADD COLUMN UsedUnits MEMO WITH COMPRESSION");
                }
                catch (Exception e1)
                {
                    _error += "1.1.1: " + e1.Message + "\n";
                }
                try
                {
                    db.ExecuteAdo("ALTER TABLE CalcSubParams ADD COLUMN UsedUnits MEMO WITH COMPRESSION");
                }
                catch (Exception e1)
                {
                    _error += "1.1.1: " + e1.Message + "\n";
                }
                _dbVersion = new Version("1.1.1");
            }
        }
        private void Update_1_1_2()
        {
            using (var db = new DaoDb(_databasePath))
            {
                //Добавлены Default, UsedUnits
                try
                {
                    db.ExecuteAdo("ALTER TABLE SignalsInUse ADD COLUMN UsedUnits MEMO WITH COMPRESSION");
                }
                catch (Exception e1)
                {
                    _error += "1.1.2: " + e1.Message + "\n";
                }
                //отдельно настраиваем отображение в виде чекбоксов
                try
                {
                    db.Execute("ALTER TABLE SignalsInUse ADD COLUMN [Default] YESNO");
                    db.ConnectDao();
                    db.Database.TableDefs["SignalsInUse"].Fields["Default"].Properties.Append(
                        db.Database.TableDefs["SignalsInUse"].Fields["Default"].CreateProperty("DisplayControl", 3, 106, false));
                }
                catch (Exception e1)
                {
                    _error += "1.1.2: " + e1.Message + "\n";
                }
                _dbVersion = new Version("1.1.2");
            }
        }
        private void Update_1_1_3()
        {
            try
            {
                using (var db = new DaoDb(_databasePath))
                {
                    //Добавлено поле UsedUnits
                    db.ExecuteAdo("ALTER TABLE GraficsList ADD COLUMN UsedUnits MEMO WITH COMPRESSION");
                }
            }
            catch (Exception e1)
            {
                _error += "1.1.3: " + e1.Message + "\n";
            }
            _dbVersion = new Version("1.1.3");
        }
        private void Update_1_1_4()
        {
            using (var db = new DaoDb(_databasePath))
            {
                //Добавлено поле Del в три таблицы
                //отдельно настраиваем отображение в виде чекбоксов
                try
                {
                    db.ConnectDao();
                    db.Execute("ALTER TABLE SignalsInUse ADD COLUMN [Del] YESNO");
                    db.Database.TableDefs["SignalsInUse"].Fields["Del"].Properties.Append(
                        db.Database.TableDefs["SignalsInUse"].Fields["Del"].CreateProperty("DisplayControl", 3, 106, false));

                    db.Execute("ALTER TABLE CalcParamsArchive ADD COLUMN [Del] YESNO");
                    db.Database.TableDefs["CalcParamsArchive"].Fields["Del"].Properties.Append(
                        db.Database.TableDefs["CalcParamsArchive"].Fields["Del"].CreateProperty("DisplayControl", 3, 106, false));

                    db.Execute("ALTER TABLE PrevParams ADD COLUMN [Del] YESNO ");
                    db.Database.TableDefs["PrevParams"].Fields["Del"].Properties.Append(
                        db.Database.TableDefs["PrevParams"].Fields["Del"].CreateProperty("DisplayControl", 3, 106, false));
                }
                catch (Exception e1)
                {
                    _error += "1.1.4: " + e1.Message + "\n";
                }
                _dbVersion = new Version("1.1.4");
            }
        }

        //Метод выдает список индексов данной таблицы или сообщает о том, есть ли в ней данный индекс
        private bool RunOverIndexList(string table, string index = "")
        {
            string indexesS = "";
            bool fieldFinded = false;
            using (var db = new DaoDb(_templatePath))
            {
                db.ConnectDao();
                foreach (Index ind in db.Database.TableDefs[table].Indexes)
                {
                    indexesS += ind.Name + "\n";
                    if (ind.Name == index)
                    {
                        fieldFinded = true;
                    }
                }
            }
            if (index == "") MessageBox.Show(indexesS);
            else return fieldFinded;
            return false;
        }

        public enum DbMode{Project, AnalyzerAppData, ConstructorAppData, Archive, Test, ControllerData, ReporterData, ArchiveSQL}
    }

    internal class Version
    {
        private readonly int _subVersion1;
        private readonly int _subVersion2;
        private readonly int _subVersion3;

        public Version(string versionString)
        {
            try
            {
                string ver = versionString;
                int dx = ver.IndexOf(".");

                if (dx == -1)
                {
                    _subVersion1 = 0;
                    _subVersion2 = 0;
                    _subVersion3 = 0;
                    return;
                }

                _subVersion1 = int.Parse(ver.Substring(0, dx));
                ver = ver.Substring(dx + 1, ver.Length - dx - 1);
                dx = ver.IndexOf(".");
                _subVersion2 = int.Parse(ver.Substring(0, dx));
                ver = ver.Substring(dx + 1, ver.Length - dx - 1);
                _subVersion3 = int.Parse(ver);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool Equals(Version other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other._subVersion1 == _subVersion1 && other._subVersion2 == _subVersion2 && other._subVersion3 == _subVersion3;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Version)) return false;
            return Equals((Version) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = _subVersion1;
                result = (result*397) ^ _subVersion2;
                result = (result*397) ^ _subVersion3;
                return result;
            }
        }

        public static bool operator ==(Version a, Version b)
        {
            if (a._subVersion1.Equals(b._subVersion1) && a._subVersion2.Equals(b._subVersion2) && a._subVersion3.Equals(b._subVersion3))
                return true;
            return false;
        }

        public static bool operator !=(Version a, Version b)
        {
            return !(a == b);
        }

        public static bool operator >(Version a, Version b)
        {
            if (a._subVersion1 > b._subVersion1) return true;
            if (a._subVersion1 < b._subVersion1) return false;
            if (a._subVersion2 > b._subVersion2) return true;
            if (a._subVersion2 < b._subVersion2) return false;
            if (a._subVersion3 > b._subVersion3) return true;
            if (a._subVersion3 < b._subVersion3) return false;
            return false;
        }

        public static bool operator <(Version a, Version b)
        {
            if (a._subVersion1 < b._subVersion1) return true;
            if (a._subVersion1 > b._subVersion1) return false;
            if (a._subVersion2 < b._subVersion2) return true;
            if (a._subVersion2 > b._subVersion2) return false;
            if (a._subVersion3 < b._subVersion3) return true;
            if (a._subVersion3 > b._subVersion3) return false;
            return false;
        }

        public static bool operator >=(Version a, Version b)
        {
            return !(a < b);
        }

        public static bool operator <=(Version a, Version b)
        {
            return !(a > b);
        }

        public override string ToString()
        {
            return _subVersion1 + "." + _subVersion2 + "." + _subVersion3;
        }
    }

    internal class UpdateDelegate
    {
        public UpdateDelegate (string uVersion, Action uAction)
        {
            UpgradeVersion = uVersion;
            UpgradeAction = uAction;
        }

        public string UpgradeVersion;
        public Action UpgradeAction;
    }
}
