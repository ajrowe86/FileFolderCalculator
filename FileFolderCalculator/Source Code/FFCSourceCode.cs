using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

public class Program
{
    static long size;

    static string outFilePath = (Environment.CurrentDirectory + @"\Output Files\File Data.txt");
    static string outFolderPath = (Environment.CurrentDirectory + @"\Output Files\Folder Data.txt");
    static string outExceptionsPath = (Environment.CurrentDirectory + @"\Output Files\Exceptions Data.txt");

    static List<Tuple<string, long>> filesNameAndSize = new List<Tuple<string, long>>();
    static List<Tuple<string, long>> foldersNameAndSize = new List<Tuple<string, long>>();
    static List<string> exceptionsList = new List<string>();

    static void Main()
    {
        Directory.CreateDirectory(Environment.CurrentDirectory + @"\Output Files");

        System.IO.File.WriteAllText(outFilePath, string.Empty);
        System.IO.File.WriteAllText(outFolderPath, string.Empty);
        System.IO.File.WriteAllText(outExceptionsPath, string.Empty);

        RootCalculator();

        SortData();

        WriteData();

        Console.WriteLine("Press any key to exit.");
        Console.ReadLine();
    }

    static void RootCalculator()
    {
        string[] drives = System.Environment.GetLogicalDrives();

        foreach (string d in drives)
        {
            System.IO.DriveInfo di = new System.IO.DriveInfo(d);

            if (!di.IsReady)
            {
                Console.WriteLine("The drive {0} could not be read.", di.Name);
                exceptionsList.Add("The drive " + di.Name + " could not be read.");
                continue;
            }

            System.IO.DirectoryInfo rootDir = di.RootDirectory;

            size = DirectorySize(rootDir);

            FileCounter(rootDir);

            PrintData(size, rootDir.FullName);

            GoThroughDirectories(rootDir);
        }
    }

    static long DirectorySize(DirectoryInfo dInfo)
    {

        try
        {
            size = dInfo.EnumerateFiles().Sum(file => file.Length);

            size += dInfo.EnumerateDirectories().Sum(dir => DirectorySize(dir));

            return size;
        }

        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine(e.Message);
            exceptionsList.Add(e.Message);
            return size = 0;
        }
    }

    static void FileCounter(System.IO.DirectoryInfo dirInfo)
    {
        System.IO.FileInfo[] files = null;

        try
        {
            files = dirInfo.GetFiles("*.*");
        }
        catch(UnauthorizedAccessException e)
        {
            exceptionsList.Add(e.Message);
        }

        if (files != null)
        {
            foreach (System.IO.FileInfo fi in files)
            {
                Console.WriteLine(fi.FullName + "     " + fi.Length);
                filesNameAndSize.Add(new Tuple<string, long>(fi.FullName, fi.Length));
            }
        }
    }

    static void PrintData(long size, string path)
    {
        Console.WriteLine(path);

        Console.WriteLine("Directory size in Bytes : " + "{0:N0} Bytes", size);

        foldersNameAndSize.Add(new Tuple<string, long>(path, size));
    }

    static void GoThroughDirectories(DirectoryInfo dInfo)
    {
        try
        {
            System.IO.DirectoryInfo[] subdirs = dInfo.GetDirectories();
            foreach (System.IO.DirectoryInfo dir in subdirs)
            {
                size = DirectorySize(dir);

                FileCounter(dir);

                PrintData(size, dir.FullName);

                GoThroughDirectories(dir);
            }
        }
        catch(UnauthorizedAccessException e)
        {
            Console.WriteLine(e.Message);
            exceptionsList.Add(e.Message);
        }
    }

    static void SortData()
    {
        filesNameAndSize = filesNameAndSize.OrderByDescending(tup => tup.Item2).ToList();
        foldersNameAndSize = foldersNameAndSize.OrderByDescending(tup => tup.Item2).ToList();
    }

    static void WriteData()
    {
        using (StreamWriter fout = new StreamWriter(outFilePath, true))
        {
            fout.WriteLine("------------------------------     *****FILE DATA*****     ------------------------------\r\n\r\n\r\n");

            for (int i = 0; i < filesNameAndSize.Count; i++)
            {
                fout.WriteLine(filesNameAndSize[i].Item1 + "   ----------- Size (in bytes): " + filesNameAndSize[i].Item2);
            }
        }

        using (StreamWriter fout = new StreamWriter(outFolderPath, true))
        {
            fout.WriteLine("------------------------------     *****FOLDER DATA*****     ------------------------------\r\n\r\n\r\n");

            for (int i = 0; i < foldersNameAndSize.Count; i++)
            {
                fout.WriteLine(foldersNameAndSize[i].Item1 + "   ----------- Size (in bytes): " + foldersNameAndSize[i].Item2);
            }
        }

        using (StreamWriter fout = new StreamWriter(outExceptionsPath, true))
        {
            fout.WriteLine("------------------------------     *****EXCEPTION DATA*****     ------------------------------\r\n\r\n\r\n");
            
            for (int i = 0; i < exceptionsList.Count; i++)
            {
                fout.WriteLine(exceptionsList[i].ToString());
            }
        }
    }
}