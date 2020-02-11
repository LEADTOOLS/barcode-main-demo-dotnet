// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Windows.Forms;

namespace Leadtools.Demos
{
   public static class Messager
   {
      private static string _fileOpenErrorMessage;
      private static string _fileSaveErrorMessage;

      static Messager()
      {
         if (DemosGlobalization.GetCurrentThreadLanguage() == GlobalizationLanguage.Japanese)
         {
            _fileOpenErrorMessage = "Error opening file:";
            _fileSaveErrorMessage = "Error saving file:";
         }
         else
         {
            _fileOpenErrorMessage = "Error opening file:";
            _fileSaveErrorMessage = "Error saving file:";
         }
      }

      private static string _caption;

      public static string Caption
      {
         get
         {
            return _caption;
         }

         set
         {
            _caption = value;
         }
      }

      public static void ShowError(IWin32Window owner, Exception ex)
      {
         Show(owner, ex.Message, MessageBoxIcon.Exclamation, MessageBoxButtons.OK);
      }

      public static void ShowError(IWin32Window owner, string message)
      {
         Show(owner, message, MessageBoxIcon.Exclamation, MessageBoxButtons.OK);
      }

      public static void ShowWarning(IWin32Window owner, Exception ex)
      {
         Show(owner, ex.Message, MessageBoxIcon.Exclamation, MessageBoxButtons.OK);
      }

      public static void ShowWarning(IWin32Window owner, string message)
      {
         Show(owner, message, MessageBoxIcon.Exclamation, MessageBoxButtons.OK);
      }

      public static DialogResult ShowQuestion(IWin32Window owner, string message, MessageBoxButtons buttons)
      {
         return Show(owner, message, MessageBoxIcon.Question, buttons);
      }

      public static DialogResult ShowQuestion(IWin32Window owner, string message, MessageBoxIcon icon, MessageBoxButtons buttons)
      {
         return Show(owner, message, icon, buttons);
      }

      public static void ShowInformation(IWin32Window owner, string message)
      {
         Show(owner, message, MessageBoxIcon.Information, MessageBoxButtons.OK);
      }

      public static void Show(IWin32Window owner, Exception ex, MessageBoxIcon icon)
      {
         Show(owner, ex.Message, icon, MessageBoxButtons.OK);
      }

      public static void ShowFileOpenError(IWin32Window owner, string fileName, Exception ex)
      {
         string message = ex.Message;

         if(fileName != null && fileName != string.Empty)
         {
            if(ex != null)
               Show(owner, string.Format("{0}{2}{1}{2}{2}{3}", _fileOpenErrorMessage, fileName, Environment.NewLine, message), MessageBoxIcon.Exclamation, MessageBoxButtons.OK);
            else
               Show(owner, string.Format("{0}{1}", _fileOpenErrorMessage, fileName), MessageBoxIcon.Exclamation, MessageBoxButtons.OK);
         }
         else
         {
            if(ex != null)
               Show(owner, string.Format("{0}{1}{1}{2}", _fileOpenErrorMessage, Environment.NewLine, message), MessageBoxIcon.Exclamation, MessageBoxButtons.OK);
            else
               Show(owner, _fileOpenErrorMessage, MessageBoxIcon.Exclamation, MessageBoxButtons.OK);
         }
      }

      public static void ShowFileSaveError(IWin32Window owner, string fileName, Exception ex)
      {
         string message = ex.Message;

         if(fileName != null && fileName != string.Empty)
         {
            if(ex != null)
               ShowError(owner, string.Format("{0}{2}{1}{2}{2}{3}", _fileSaveErrorMessage, fileName, Environment.NewLine, message));
            else
               ShowError(owner, string.Format("{0}{1}", _fileSaveErrorMessage, fileName));
         }
         else
         {
            if(ex != null)
               ShowError(owner, string.Format("{0}{1}{1}{2}", _fileSaveErrorMessage, Environment.NewLine, message));
            else
               ShowError(owner, _fileSaveErrorMessage);
         }
      }

      public static DialogResult Show(IWin32Window owner, string message, MessageBoxIcon icon, MessageBoxButtons buttons)
      {
         return MessageBox.Show(owner, message, Caption, buttons, icon);
      }
   }
}
