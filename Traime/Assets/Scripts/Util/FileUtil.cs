using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Traime
{
    public static class FileUtil
    {
        private static string persistentDataPath = Application.persistentDataPath;

        private const string FileCreateError = "Couldn't create file {0}\n{1}";
        private const string FileReadError = "Couldn't read file {0}\n{1}";
        private const string FileWriteError = "Coulnd't write file {0}\n{1}";
        private const string FileWriteSuccess = "Wrote file {0}";

        public static bool FileExists(string path)
        {
            return File.Exists(persistentDataPath + path);
        }

        public static FileStream CreateFile(string path)
        {
            try
            {
                return File.Create(persistentDataPath + path);
            }
            catch (Exception e)
            {
                Debug.LogError(string.Format(FileCreateError, persistentDataPath + path, e.Message));
                return null;
            }
        }

        public static string ReadFileText(string path)
        {
            try
            {
                return File.ReadAllText(persistentDataPath + path);
            }
            catch (Exception e)
            {
                Debug.LogError(string.Format(FileReadError, persistentDataPath + path, e.Message));
                return null;
            }
        }

        public static byte[] ReadFileBytes(string path)
        {
            try
            {
                return File.ReadAllBytes(persistentDataPath + path);
            }
            catch (Exception e)
            {
                Debug.LogError(string.Format(FileReadError, persistentDataPath + path, e.Message));
                return null;
            }
        }
        
        public static FileStream ReadFileStream(string path)
        {
            try
            {
                return File.Open(persistentDataPath + path, FileMode.Open);
            }
            catch (Exception e)
            {
                Debug.LogError(string.Format(FileReadError, persistentDataPath + path, e.Message));
                return null;
            }
        }

        public static bool WriteFileText(string path, string text)
        {
            try
            {
                File.WriteAllText(persistentDataPath + path, text);
                Debug.Log(string.Format(FileWriteSuccess, persistentDataPath + path));
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError(string.Format(FileWriteError, persistentDataPath + path, e.Message));
                return false;
            }
        }

        public static bool WriteFileBytes(string path, byte[] bytes)
        {
            try
            {
                File.WriteAllBytes(persistentDataPath + path, bytes);
                Debug.Log(string.Format(FileWriteSuccess, persistentDataPath + path));
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError(string.Format(FileWriteError, persistentDataPath + path, e.Message));
                return false;
            }
        }
    }
}

