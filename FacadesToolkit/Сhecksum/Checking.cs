using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;

namespace FacadesToolkit
{
    public class Checking
    {
        public bool ValidateChecksums()
        {
            string BinName = "Facades Toolkit.bin";
            string TxtName = "Facades Toolkit.txt";
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Syberian Facades");
            string checksumBinPath = Path.Combine(folderPath, BinName);
            string assemblyPath = Assembly.GetExecutingAssembly().Location;
            string directoryPath = Path.GetDirectoryName(assemblyPath);

            string checksumTxtPath = Path.Combine(folderPath, TxtName);
            string assemblyTxtPath = Assembly.GetExecutingAssembly().Location;
            string directoryTxtPath = Path.GetDirectoryName(assemblyTxtPath);

            bool BinCheck = CheckBin(directoryPath, checksumBinPath);
            bool TxtCheck = CheckTxt(directoryTxtPath, checksumTxtPath);

            if (BinCheck && TxtCheck)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Проверяет имеется ли бинарный файл чексумм
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="checksumBinPath"></param>
        /// <returns></returns>
        private bool CheckBin(string directoryPath, string checksumBinPath)
        {
            List<FileChecksum> fileChecksums = ReadChecksumsFromBin(checksumBinPath);

            if (fileChecksums == null)
            {
                TaskDialog.Show("Ошибка", "Отсутствует компонент");
                return false;
            }
            else
            {
                foreach (FileChecksum fileChecksum in fileChecksums)
                {
                    string filePath = Path.Combine(directoryPath, fileChecksum.FileName);

                    if (File.Exists(filePath))
                    {
                        string md5Checksum = CalculateMD5Checksum(filePath);
                        string sha256Checksum = CalculateSHA256Checksum(filePath);
                        string sha1Checksum = CalculateSHA1Checksum(filePath);

                        if (md5Checksum != fileChecksum.MD5 || sha256Checksum != fileChecksum.SHA256 || sha1Checksum != fileChecksum.SHA1)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        TaskDialog.Show("Отказ в доступе", "Отсутствует компонент");
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Провряет имеется ли текстовый файл чексумм
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="checksumTxtPath"></param>
        /// <returns></returns>
        private bool CheckTxt(string directoryPath, string checksumTxtPath)
        {
            List<FileChecksum> fileChecksums = ReadChecksumsFromFile(checksumTxtPath);

            if (fileChecksums == null)
            {
                TaskDialog.Show("Ошибка", "Отсутствует компонент");
                return false;
            }
            else
            {
                foreach (FileChecksum fileChecksum in fileChecksums)
                {
                    string filePath = Path.Combine(directoryPath, fileChecksum.FileName);

                    if (File.Exists(filePath))
                    {
                        string md5Checksum = CalculateMD5Checksum(filePath);
                        string sha256Checksum = CalculateSHA256Checksum(filePath);
                        string sha1Checksum = CalculateSHA1Checksum(filePath);

                        if (md5Checksum != fileChecksum.MD5 || sha256Checksum != fileChecksum.SHA256 || sha1Checksum != fileChecksum.SHA1)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        TaskDialog.Show("Отказ в доступе", "Отсутствует компонент");
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Считывает значения из бинарного файла чексумм
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private List<FileChecksum> ReadChecksumsFromBin(string filePath)
        {
            try
            {
                List<FileChecksum> fileChecksums = new List<FileChecksum>();

                using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
                {
                    while (reader.BaseStream.Position != reader.BaseStream.Length)
                    {
                        FileChecksum currentChecksum = new FileChecksum();

                        currentChecksum.FileName = reader.ReadString();
                        currentChecksum.MD5 = reader.ReadString();
                        currentChecksum.SHA1 = reader.ReadString();
                        currentChecksum.SHA256 = reader.ReadString();

                        fileChecksums.Add(currentChecksum);
                    }
                }

                return fileChecksums;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Считывает значения из текстового файла чексумм
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private List<FileChecksum> ReadChecksumsFromFile(string filePath)
        {
            try
            {
                List<FileChecksum> fileChecksums = new List<FileChecksum>();

                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    FileChecksum currentChecksum = null;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.StartsWith("File:"))
                        {
                            currentChecksum = new FileChecksum();
                            currentChecksum.FileName = line.Substring(6).Trim();
                        }
                        else if (line.StartsWith("MD5:"))
                        {
                            currentChecksum.MD5 = line.Substring(4).Trim();
                        }
                        else if (line.StartsWith("SHA1:"))
                        {
                            currentChecksum.SHA1 = line.Substring(5).Trim();
                        }
                        else if (line.StartsWith("SHA256:"))
                        {
                            currentChecksum.SHA256 = line.Substring(8).Trim();
                            fileChecksums.Add(currentChecksum);
                            currentChecksum = null;
                        }
                    }
                }

                return fileChecksums;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Алгоритм определения контрольной суммы (хэша)
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private string CalculateMD5Checksum(string filePath)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    byte[] hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLower();
                }
            }
        }

        /// <summary>
        /// Алгоритм определения контрольной суммы (хэша)
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private string CalculateSHA256Checksum(string filePath)
        {
            using (var sha256 = SHA256.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    byte[] hash = sha256.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLower();
                }
            }
        }

        /// <summary>
        /// Алгоритм определения контрольной суммы (хэша)
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private string CalculateSHA1Checksum(string filePath)
        {
            using (var sha256 = SHA1.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    byte[] hash = sha256.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLower();
                }
            }
        }
    }

    public class FileChecksum
    {
        public string FileName { get; set; }
        public string MD5 { get; set; }
        public string SHA256 { get; set; }
        public string SHA1 { get; set; }
    }
}