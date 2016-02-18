﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace SEGAN_POS.Common
{

  // Fuente: http://www.codeproject.com/Articles/32908/C-Single-Instance-App-With-the-Ability-To-Restore

  /// <summary>
  /// This is where the magic happens.
  /// Start() tries to create a mutex.
  /// If it detects that another instance is already using the mutex, then it returns FALSE.
  /// Otherwise it returns TRUE.
  /// (Notice that a GUID is used for the mutex name, which is a little better than using the application name.)
  /// 
  /// If another instance is detected, then you can use ShowFirstInstance() to show it
  /// (which will work as long as you override WndProc as shown above).
  /// 
  /// ShowFirstInstance() broadcasts a message to all windows.
  /// The message is WM_SHOWFIRSTINSTANCE.
  /// (Notice that a GUID is used for WM_SHOWFIRSTINSTANCE.
  /// That allows you to reuse this code in multiple applications without getting
  /// strange results when you run them all at the same time.)
  /// </summary>
  public static class SingleInstance
  {
    public static readonly int WM_SHOWFIRSTINSTANCE = WinApi.RegisterWindowMessage("WM_SHOWFIRSTINSTANCE|{0}", ProgramInfo.AssemblyGuid);
    static Mutex mutex;

    public static bool Start()
    {
      bool onlyInstance = false;
      string mutexName = String.Format("Local\\{0}", ProgramInfo.AssemblyGuid);

      // if you want your app to be limited to a single instance
      // across ALL SESSIONS (multiple users & terminal services), then use the following line instead:
      // string mutexName = String.Format("Global\\{0}", ProgramInfo.AssemblyGuid);

      mutex = new Mutex(true, mutexName, out onlyInstance);
      return onlyInstance;
    }

    public static void ShowFirstInstance()
    {
      WinApi.PostMessage((IntPtr)WinApi.HWND_BROADCAST, WM_SHOWFIRSTINSTANCE, IntPtr.Zero, IntPtr.Zero);
    }

    public static void Stop()
    {
      mutex.ReleaseMutex();
    }

  }

  /// <summary>
  /// This class is just a wrapper for your various WinApi functions.
  /// In this sample only the bare essentials are included.
  /// In my own WinApi class, I have all the WinApi functions that any of
  /// my applications would ever need.
  /// </summary>
  static public class WinApi
  {
    [DllImport("user32")]
    public static extern int RegisterWindowMessage(string message);

    public static int RegisterWindowMessage(string format, params object[] args)
    {
      string message = String.Format(format, args);
      return RegisterWindowMessage(message);
    }

    public const int HWND_BROADCAST = 0xffff;
    public const int SW_SHOWNORMAL = 1;

    [DllImport("user32")]
    public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);

    [DllImportAttribute("user32.dll")]
    public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    [DllImportAttribute("user32.dll")]
    public static extern bool SetForegroundWindow(IntPtr hWnd);

    public static void ShowToFront(IntPtr window)
    {
      ShowWindow(window, SW_SHOWNORMAL);
      SetForegroundWindow(window);
    }

  }

  /// <summary>
  /// This class is just for getting information about the application.
  /// Each assembly has a GUID, and that GUID is useful to us in this application,
  /// so the most important thing in this class is the AssemblyGuid property.
  /// 
  /// GetEntryAssembly() is used instead of GetExecutingAssembly(), so that you
  /// can put this code into a class library and still get the results you expect.
  /// (Otherwise it would return info on the DLL assembly instead of your application.)
  /// </summary>
  static public class ProgramInfo
  {

    static public string AssemblyGuid
    {
      get
      {
        object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(System.Runtime.InteropServices.GuidAttribute), false);
        if (attributes.Length == 0) {
          return String.Empty;
        }
        return ((System.Runtime.InteropServices.GuidAttribute)attributes[0]).Value;
      }
    }

    static public string AssemblyTitle
    {
      get
      {
        object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
        if (attributes.Length > 0) {
          AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
          if (titleAttribute.Title != "") {
            return titleAttribute.Title;
          }
        }
        return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().CodeBase);
      }
    }

  }

}
