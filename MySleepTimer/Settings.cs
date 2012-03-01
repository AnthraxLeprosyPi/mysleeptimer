#region Copyright (C) 2005-2010 Team MediaPortal

// Copyright (C) 2005-2010 Team MediaPortal
// http://www.team-mediaportal.com
// 
// MediaPortal is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 2 of the License, or
// (at your option) any later version.
// 
// MediaPortal is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with MediaPortal. If not, see <http://www.gnu.org/licenses/>.

#endregion

using System.IO;
using System.Reflection;
using MediaPortal.Configuration;
using MediaPortal.GUI.Library;
using MediaPortal.Util;
using Log = MediaPortal.ServiceImplementations.Log;

namespace MySleepTimer
{
  internal static class Settings
  {
    #region Properties

    private const string PLUGIN_NAME = "MySleepTimer";

    public static Action.ActionType ActionType { get; set; }
    public static string SleepBehavior { get; set; }

    public static bool PowerSchedulerAvailable { get; private set; }
    public static bool UsePowerSchedulerSettings { get; set; }
    public static RestartOptions ShutdownType { get; set; }
    public static bool ShutdownForce { get; set; }

    public static int SleepTimeMaxium { get; set; } //(1..n)
    public static int SleepTimeStep { get; set; } //(1..n)
    public static int ActionTimeOutMs { get; set; } //(1..n * 1000)
    public static int NotifyBeforeSleep { get; set; } //(0..n)
    public static int NotifyInterval { get; set; } //(1..NotifyBeforeSleep)
    public static int NotifyTimeOutMs { get; set; } //(1..65 * 1000)

    static Settings()
    {
      ActionType = Action.ActionType.ACTION_REMOTE_YELLOW_BUTTON;
      SleepBehavior = "Shutdown";

      UsePowerSchedulerSettings = true;
      ShutdownType = RestartOptions.ShutDown;
      ShutdownForce = false;

      SleepTimeMaxium = 120;
      SleepTimeStep = 10;
      ActionTimeOutMs = 2 * 1000;
      NotifyBeforeSleep = 3;
      NotifyInterval = 1;
      NotifyTimeOutMs = 3 * 1000;
    }

    #endregion

    public static void Load()
    {
      Log.Info("{0}: Settings.Load()", PLUGIN_NAME);

      using (
        MediaPortal.Profile.Settings xmlReader =
          new MediaPortal.Profile.Settings(Config.GetFile(Config.Dir.Config, "MediaPortal.xml")))
      {
        // ahutdown settings
        PowerSchedulerAvailable =
          (File.Exists(Config.GetSubFolder(Config.Dir.Plugins, "process") + @"\PowerSchedulerClientPlugin.dll")) &&
          xmlReader.GetValueAsBool("pluginsdlls", "PowerSchedulerClientPlugin.dll", false);
        UsePowerSchedulerSettings =
          xmlReader.GetValueAsBool(PLUGIN_NAME, "UsePowerSchedulerSettings", true);

        if (PowerSchedulerAvailable && UsePowerSchedulerSettings)
        {
          int tmp = xmlReader.GetValueAsInt("psclientplugin", "shutdownmode", 1);
          if (tmp == 1)
            ShutdownType = RestartOptions.Hibernate;
          else
            ShutdownType = RestartOptions.Suspend;

          ShutdownForce = xmlReader.GetValueAsBool("psclientplugin", "forceshutdown", false);
        }
        else
        {
          ShutdownType =
            (RestartOptions)
            xmlReader.GetValueAsInt(PLUGIN_NAME, "ShutdownType", (int)RestartOptions.ShutDown);
          ShutdownForce = xmlReader.GetValueAsBool(PLUGIN_NAME, "ShutdownForce", false);
        }

        // sleeptimer settings
        ActionType =
          (Action.ActionType)
          xmlReader.GetValueAsInt(PLUGIN_NAME, "ActionType",
                                  (int)(Action.ActionType.ACTION_REMOTE_YELLOW_BUTTON));
        SleepBehavior = xmlReader.GetValueAsString(PLUGIN_NAME, "SleepBehavior", "Shutdown");

        SleepTimeMaxium = xmlReader.GetValueAsInt(PLUGIN_NAME, "Maximum", 120);
        SleepTimeStep = xmlReader.GetValueAsInt(PLUGIN_NAME, "Step", 10);
        ActionTimeOutMs = xmlReader.GetValueAsInt(PLUGIN_NAME, "ActionTimeOut", 2) * 1000;
        NotifyBeforeSleep = xmlReader.GetValueAsInt(PLUGIN_NAME, "NotifyBeforeSleep", 3);
        NotifyInterval = xmlReader.GetValueAsInt(PLUGIN_NAME, "NotifyInterval", 1);
        NotifyTimeOutMs = xmlReader.GetValueAsInt(PLUGIN_NAME, "NotifyTimeOut", 3) * 1000;
      }

      WriteToLog();
    }

    public static void Save()
    {
      Log.Info("{0}: Settings.Save()", PLUGIN_NAME);

      using (
        MediaPortal.Profile.Settings xmlWriter =
          new MediaPortal.Profile.Settings(Config.GetFile(Config.Dir.Config, "MediaPortal.xml")))
      {
        // ahutdown settings
        xmlWriter.SetValueAsBool(PLUGIN_NAME, "UsePowerSchedulerSettings", UsePowerSchedulerSettings);
        if (!PowerSchedulerAvailable || !UsePowerSchedulerSettings)
        {
          xmlWriter.SetValue(PLUGIN_NAME, "ShutdownType", (int)ShutdownType);
          xmlWriter.SetValueAsBool(PLUGIN_NAME, "ShutdownForce", ShutdownForce);
        }

        // sleeptimer settings
        xmlWriter.SetValue(PLUGIN_NAME, "ActionType", (int)ActionType);
        xmlWriter.SetValue(PLUGIN_NAME, "SleepBehavior", SleepBehavior);

        xmlWriter.SetValue(PLUGIN_NAME, "Maximum", SleepTimeMaxium);
        xmlWriter.SetValue(PLUGIN_NAME, "Step", SleepTimeStep);
        xmlWriter.SetValue(PLUGIN_NAME, "ActionTimeOut", ActionTimeOutMs);
        xmlWriter.SetValue(PLUGIN_NAME, "NotifyBeforeSleep", NotifyBeforeSleep);
        xmlWriter.SetValue(PLUGIN_NAME, "NotifyInterval", NotifyInterval);
        xmlWriter.SetValue(PLUGIN_NAME, "NotifyTimeOut", NotifyTimeOutMs);
      }
    }

    public static void WriteToLog()
    {
      // get all properties
      PropertyInfo[] propertyInfos = typeof (Settings).GetProperties();
      // write property names and values
      foreach (PropertyInfo propertyInfo in propertyInfos)
      {
        Log.Info("{0}: {1}  =  {2}", PLUGIN_NAME, propertyInfo.Name, propertyInfo.GetValue(null, null).ToString());
      }
    }
  }
}